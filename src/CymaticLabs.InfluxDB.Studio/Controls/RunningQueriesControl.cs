using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    public partial class RunningQueriesControl : RequestControl
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the currently selected running query, if any.
        /// </summary>
        public InfluxDbRunningQuery SelectedQuery { get; private set; }

        #endregion Properties

        #region Constructors

        public RunningQueriesControl()
        {
            InitializeComponent();

            // Set query editor styles, InfluxDB is SQL like, so use those
            queryEditor.Styles[Style.Sql.Identifier].ForeColor = Color.Blue;
            queryEditor.Styles[Style.Sql.String].ForeColor = Color.Red;
            queryEditor.Styles[Style.Sql.Number].ForeColor = Color.Magenta;
            queryEditor.Styles[Style.Sql.QuotedIdentifier].ForeColor = Color.Red;
        }

        #endregion Constructors

        #region Event Handlers

        // Handle query selection change
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                queryEditor.ReadOnly = false;
                queryEditor.Text = null;
                queryEditor.ReadOnly = true;
                killQueryButton.Enabled = killQueryToolStripMenuItem.Enabled = false;
                SelectedQuery = null;
            }
            else
            {
                SelectedQuery = (InfluxDbRunningQuery)listView.SelectedItems[0].Tag;
                queryEditor.ReadOnly = false;
                queryEditor.Text = SelectedQuery.Query;
                queryEditor.ReadOnly = true;
                killQueryButton.Enabled = killQueryToolStripMenuItem.Enabled = true;
            }
        }

        // Handle kill query
        private async void killQueryButton_Click(object sender, EventArgs e)
        {
            await KillQuery();
        }

        private async void killQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await KillQuery();
        }

        #endregion Event Handlers

        #region Methods

        #region Commands

        // Kills the selected query
        async Task KillQuery()
        {
            try
            {
                if (listView.SelectedItems.Count == 0) return;
                var pid = ((InfluxDbRunningQuery)listView.SelectedItems[0].Tag).PID;
                var response = await InfluxDbClient.KillQueryAsync(pid);

                if (!response.Success && !response.Body.Contains("query interrupted"))
                {
                    AppForm.DisplayError(response.Body);
                }
                else
                {
                    listView.BeginUpdate();
                    listView.SelectedItems[0].Remove();
                    listView.EndUpdate();
                }

                UpdateUIState();
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        #endregion Commands

        #region User Interface

        void UpdateUIState()
        {
            killQueryButton.Enabled = killQueryToolStripMenuItem.Enabled = listView.SelectedItems.Count > 0;
        }

        #endregion User Interface

        public async override Task ExecuteRequestAsync()
        {
            if (InfluxDbClient == null) throw new Exception("No InfluxDB client available.");

            // Clear current items
            listView.Items.Clear();

            // Start redraw
            listView.BeginUpdate();

            // Query and render
            var queries = await InfluxDbClient.GetRunningQueriesAsync();

            foreach (var q in queries)
            {
                listView.Items.Add(new ListViewItem(new string[]
                {
                    q.PID.ToString(),
                    q.Duration,
                    q.Database.ToString(),
                    q.Query
                }) { Tag = q });
            }

            // Restore selection
            if (SelectedQuery != null)
            {
                var pid = SelectedQuery.PID.ToString();

                foreach (ListViewItem li in listView.Items)
                {
                    if (li.Text == pid)
                    {
                        li.Selected = true;
                        SelectedQuery = (InfluxDbRunningQuery)li.Tag;
                    }
                }
            }

            // Resize each column
            //if (listView.Columns.Count > 0)
            //{
            //    var columnWidth = (Width - 12) / listView.Columns.Count;
            //    if (columnWidth < 96) columnWidth = 96;
            //    foreach (ColumnHeader col in listView.Columns) col.Width = columnWidth;
            //}

            // Render
            listView.EndUpdate();

            UpdateUIState();
        }

        #endregion Methods
    }
}
