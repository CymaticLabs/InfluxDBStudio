using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using CymaticLabs.InfluxDB.Data;
using CymaticLabs.InfluxDB.Studio.Dialogs;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Control used to list and edit InfluxDB continous queries.
    /// </summary>
    public partial class ContinuousQueryControl : RequestControl
    {
        #region Fields

        // Dialog used to create new continuous queries
        private CreateContinuousQueryDialog createCqDialog;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the currently selected CQ (if any).
        /// </summary>
        public InfluxDbContinuousQuery SelectedCq { get; private set; }

        #endregion Properties

        #region Constructors

        public ContinuousQueryControl()
        {
            InitializeComponent();

            createCqDialog = new CreateContinuousQueryDialog();

            // Set query editor styles, InfluxDB is SQL like, so use those
            queryEditor.Styles[Style.Sql.Identifier].ForeColor = Color.Blue;
            queryEditor.Styles[Style.Sql.String].ForeColor = Color.Red;
            queryEditor.Styles[Style.Sql.Number].ForeColor = Color.Magenta;
            queryEditor.Styles[Style.Sql.QuotedIdentifier].ForeColor = Color.Red;

            UpdateUIState();
        }

        #endregion Constructors

        #region Event Handlers

        // Handles creating a CQ
        private async void createCqButton_Click(object sender, EventArgs e)
        {
            await CreateContinuousQuery();
        }

        // Handles dropping a CQ
        private async void dropCqButton_Click(object sender, EventArgs e)
        {
            await DropContinuousQuery();
        }

        // Handle running a back fill
        private async void backFillButton_Click(object sender, EventArgs e)
        {
            await RunBackFill();
        }

        // Handles selection of CQ in list view
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count == 0)
                {
                    SelectedCq = null;

                    // Clear query text
                    queryEditor.ReadOnly = false;
                    queryEditor.Text = null;
                    queryEditor.ReadOnly = true;
                }
                else
                {
                    // Populate query text
                    SelectedCq = listView.SelectedItems[0].Tag as InfluxDbContinuousQuery;

                    queryEditor.ReadOnly = false;
                    queryEditor.Text = FormatCqQuery(SelectedCq.Query);
                    queryEditor.ReadOnly = true;
                }

                UpdateUIState();
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        #endregion Event Handlers

        #region Methods

        #region Commands

        // Create a Continuous Query
        async Task CreateContinuousQuery()
        {
            try
            {
                // Pass client connection down
                createCqDialog.ResetCqForm();
                createCqDialog.InfluxDbClient = InfluxDbClient;
                createCqDialog.Database = Database;

                // Bind dynamic data
                await createCqDialog.BindInfluxDataSources();

                if (createCqDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the resulting CQ params
                    var cqParams = createCqDialog.CqResult;

                    // Create the CQ and get the response
                    var response = await InfluxDbClient.CreateContinuousQueryAsync(cqParams);

                    if (response.Success)
                    {
                        await ExecuteRequestAsync();
                    }
                    else
                    {
                        AppForm.DisplayError(response.Body);
                    }

                    UpdateUIState();
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Drops a Continuous Query
        async Task DropContinuousQuery()
        {
            try
            {
                if (SelectedCq == null || Database == null) return;

                // Confirm Drop
                if (MessageBox.Show(string.Format("Drop CQ: {0}?", SelectedCq.Name), "Confirm Drop", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    == DialogResult.OK)
                {
                    var response = await InfluxDbClient.DropContinuousQueryAsync(Database, SelectedCq.Name);

                    if (response.Success)
                    {
                        SelectedCq = null;
                        await ExecuteRequestAsync();
                    }
                    else
                    {
                        AppForm.DisplayError(response.Body);
                    }
                    
                    UpdateUIState();
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Runs a Back Fill query
        async Task RunBackFill()
        {
            await AppForm.RunBackFill();
        }

        #endregion Commands

        #region User Interface

        // Updates the UI state
        void UpdateUIState()
        {
            dropCqButton.Enabled = listView.SelectedItems.Count == 1;
            dropCQToolStripMenuItem.Enabled = dropCqButton.Enabled;
        }

        #endregion User Interface

        #region Utility

        // Formats a CQ query for presentation in the query editor/display
        string FormatCqQuery(string query)
        {
            // New lines around BEGIN
            query = query.Replace(" BEGIN", "\nBEGIN");

            // New line around RESAMPLE
            query = query.Replace(" RESAMPLE", "\nRESAMPLE");

            // Indent select
            query = query.Replace(" SELECT", "\n\tSELECT");

            // New line around END
            query = query.Replace(" END", "\nEND");

            return query;
        }

        // Parses the raw query returned from a listed CQ into its various pieces
        IDictionary<string, string> ParseCqQuery(string query)
        {
            var values = new Dictionary<string, string>();
            var dbMarker = "ON ";
            var selectMarker = " BEGIN SELECT ";
            var intoMarker = " INTO ";
            var fromMarker = " FROM ";
            var groupByMarker = " GROUP BY ";

            // Find index of various markers in the query
            var dbIndexEnd = query.IndexOf(dbMarker) + dbMarker.Length;
            var selectIndexStart = query.IndexOf(selectMarker);
            var selectIndexEnd = selectIndexStart + selectMarker.Length;
            var intoIndexStart = query.IndexOf(intoMarker);
            var intoIndexEnd = intoIndexStart + intoMarker.Length;
            var fromIndexStart = query.IndexOf(fromMarker);
            var fromIndexEnd = fromIndexStart + fromMarker.Length;
            var groupByIndexStart = query.IndexOf(groupByMarker);
            var groupByIndexEnd = groupByIndexStart + groupByMarker.Length;

            // Substring out various pieces of the query based on marker indices
            var database = query.Substring(dbIndexEnd, selectIndexStart - dbIndexEnd).Trim();
            var subqueries = query.Substring(selectIndexEnd, intoIndexStart - selectIndexEnd).Trim();
            var destination = query.Substring(intoIndexEnd, fromIndexStart - intoIndexEnd).Trim();
            var source = query.Substring(fromIndexEnd, groupByIndexStart - fromIndexEnd).Trim();

            values.Add("database", database);
            values.Add("subqueries", subqueries);
            values.Add("destination", destination);
            values.Add("source", source);

            return values;
        }

        #endregion Utility

        public async override Task ExecuteRequestAsync()
        {
            try
            {
                // Clear current UI
                listView.Items.Clear();
                queryEditor.ReadOnly = false;
                queryEditor.Text = null;
                queryEditor.ReadOnly = true;

                if (string.IsNullOrEmpty(Database)) return;

                listView.BeginUpdate();

                var cqList = await InfluxDbClient.GetContinousQueriesAsync(Database);

                foreach (var cq in cqList)
                {
                    listView.Items.Add(new ListViewItem(new string[] { cq.Name }) { Tag = cq });
                }

                listView.EndUpdate();

                // If this is/was a currently selected query, restore it
                if (SelectedCq != null)
                {
                    foreach (ListViewItem li in listView.Items)
                    {
                        if (li.Text == SelectedCq.Name)
                        {
                            li.Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        #endregion Methods
    }
}
