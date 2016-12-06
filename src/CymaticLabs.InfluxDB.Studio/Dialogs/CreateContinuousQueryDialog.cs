using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    /// <summary>
    /// Dialog used to create a new Continuous Query.
    /// </summary>
    public partial class CreateContinuousQueryDialog : Form
    {
        #region Fields

        // Place holder text for the query editing portion of a new down sampler query
        const string QueryEditorPlaceholderText = "#edit your query / downsamplers here";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="InfluxDB.InfluxDbClient">InfluxDB connection</see> associated
        /// with the dialog.
        /// </summary>
        public InfluxDbClient InfluxDbClient { get; set; }

        /// <summary>
        /// Gets or sets the name of the database associated with the dialog.
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Gets the resulting Continuous Query parameters from the dialog.
        /// </summary>
        public InfluxDbCqParams CqResult { get; private set; }

        #endregion Properties

        #region Constructors

        public CreateContinuousQueryDialog()
        {
            InitializeComponent();

            // Populate fill type drop down
            foreach (var fillType in Enum.GetValues(typeof(InfluxDbFillTypes)))
            {
                fillTypeComboBox.Items.Add(fillType);
            }

            fillTypeComboBox.SelectedIndex = 0;

            // Set query editor styles, InfluxDB is SQL like, so use those
            queryEditor.Styles[Style.Sql.Identifier].ForeColor = Color.Blue;
            queryEditor.Styles[Style.Sql.String].ForeColor = Color.Red;
            queryEditor.Styles[Style.Sql.Number].ForeColor = Color.Magenta;
            queryEditor.Styles[Style.Sql.QuotedIdentifier].ForeColor = Color.Red;
        }

        #endregion Constructors

        #region Event Handlers

        private void CreateContinuousQueryDialog_Load(object sender, EventArgs e)
        {
            // Setup help/info tool tips
            destinationToolTip.SetToolTip(destinationInfo, Properties.Resources.CQ_Destination_Info);
            sourceToolTip.SetToolTip(sourceInfo, Properties.Resources.CQ_Source_Info);
            intervalToolTip.SetToolTip(intervalInfo, Properties.Resources.CQ_Interval_Info);
            fillTypeToolTip.SetToolTip(fillTypeInfo, Properties.Resources.CQ_FillType_Info);
            tagsToolTip.SetToolTip(tagsInfo, Properties.Resources.CQ_Tags_Info);
            resampleToolTip.SetToolTip(resampleInfo, Properties.Resources.CQ_Resample_Info);
            resampleEveryToolTip.SetToolTip(resampleEveryInfo, Properties.Resources.CQ_ResampleEvery_Info);
            resampleForToolTip.SetToolTip(resampleForInfo, Properties.Resources.CQ_ResampleFor_Info);
        }

        // Handle add new subquery button
        private void addQueryButton_Click(object sender, EventArgs e)
        {
            NewQuery();
        }

        // Handle changes to the reample enable/disable check box
        private void resampleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            resampleEveryLabel.Enabled = resampleEveryTextBox.Enabled = resampleCheckBox.Checked;
            resampleForLabel.Enabled = resampleForTextBox.Enabled = resampleCheckBox.Checked;
        }

        // Handles closing of the form
        private void CreateContinuousQueryDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // If the user is closing/canceling the form, nothing to do
                if (DialogResult != DialogResult.OK) return;

                // Create the CQ result from form values
                CqResult = CreateCqParamsFromValues();

                // If a valid result wasn't returned, cancel
                if (CqResult == null) e.Cancel = true;
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        #endregion Event Handlers

        #region Methods

        #region Commands

        // Adds a new query tab
        public void NewQuery()
        {
            queryEditor.Text = QueryEditorPlaceholderText;
        }

        #endregion Commands

        #region User Interface

        /// <summary>
        /// Resets the dialog form to its initial state.
        /// </summary>
        public void ResetCqForm()
        {
            // Reset form values
            nameTextBox.Text = null;
            databaseValue.Text = null;
            destinationComboBox.SelectedItem = null;
            destinationComboBox.Text = null;
            destinationComboBox.Items.Clear();
            sourceComboBox.SelectedItem = null;
            sourceComboBox.Text = null;
            sourceComboBox.Items.Clear();
            intervalTextBox.Text = null;
            fillTypeComboBox.SelectedIndex = 0;
            tagsTextBox.Text = null;
            resampleCheckBox.Checked = false;
            resampleEveryTextBox.Text = null;
            resampleForTextBox.Text = null;

            // Reset result
            CqResult = null;

            // Clear query
            NewQuery();
        }

        #endregion User Interface

        #region Data

        /// <summary>
        /// Binds the form's database drop down to the list of available databases for the 
        /// current connection.
        /// </summary>
        public async Task BindInfluxDataSources()
        {
            try
            {
                // No database assigned
                if (string.IsNullOrWhiteSpace(Database)) return;

                // Display database name in UI
                databaseValue.Text = Database;

                // Clear the current list of measurements and reload
                destinationComboBox.Items.Clear();
                sourceComboBox.Items.Clear();
                var measurementNames = await InfluxDbClient.GetMeasurementNamesAsync(Database);

                foreach (var measurement in measurementNames)
                {
                    destinationComboBox.Items.Add(measurement);
                    sourceComboBox.Items.Add(measurement);
                }

                destinationComboBox.SelectedItem = null;
                sourceComboBox.SelectedItem = null;
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Validates the current form values
        bool ValidateCqValues()
        {
            try
            {
                // Validate values
                var cqName = nameTextBox.Text;

                // CQ Name
                if (string.IsNullOrWhiteSpace(cqName))
                {
                    AppForm.DisplayError("Continuous Query name cannot be blank.");
                    return false;
                }

                // Source & Destination
                var destination = destinationComboBox.SelectedItem as string;
                if (string.IsNullOrWhiteSpace(destination)) destination = destinationComboBox.Text;
                var source = sourceComboBox.SelectedItem as string;
                if (string.IsNullOrWhiteSpace(source)) source = sourceComboBox.Text;

                if (string.IsNullOrWhiteSpace(destination))
                {
                    AppForm.DisplayError("Destination cannot be blank.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(source))
                {
                    AppForm.DisplayError("Source cannot be blank.");
                    return false;
                }

                if (destination == source)
                {
                    if (MessageBox.Show("Source is the same as the Destination. These are typically different values for a Continous Query. Are you sure that you want to have duplicate values?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return false;
                    }
                }

                // Interval
                var interval = intervalTextBox.Text;

                if (string.IsNullOrWhiteSpace(interval))
                {
                    AppForm.DisplayError("Interval cannot be blank. It should be an InfluxDB time interval value such as: 1d, 2h, 10m, 30s, etc.");
                    return false;
                }

                interval = interval.Trim();

                if (!InfluxDbHelper.IsTimeIntervalValid(interval))
                {
                    AppForm.DisplayError("Interval value is invalid. It should be an InfluxDB time interval value such as: 1d, 2h, 10m, 30s, etc.");
                    return false;
                }

                // Resample Every
                if (resampleCheckBox.Checked)
                {
                    var resampleEvery = resampleEveryTextBox.Text;

                    if (!string.IsNullOrWhiteSpace(resampleEvery))
                    {
                        resampleEvery = resampleEvery.Trim();

                        if (!InfluxDbHelper.IsTimeIntervalValid(resampleEvery))
                        {
                            AppForm.DisplayError("Resample Every interval value is invalid. It should be an InfluxDB time interval value such as: 1d, 2h, 10m, 30s, etc.");
                            return false;
                        }
                    }
                }

                // Resample For
                if (resampleCheckBox.Checked)
                {
                    var resampleFor = resampleForTextBox.Text;

                    if (!string.IsNullOrWhiteSpace(resampleFor))
                    {
                        resampleFor = resampleFor.Trim();

                        if (!InfluxDbHelper.IsTimeIntervalValid(resampleFor))
                        {
                            AppForm.DisplayError("Resample For interval value is invalid. It should be an InfluxDB time interval value such as: 1d, 2h, 10m, 30s, etc.");
                            return false;
                        }
                    }
                }

                // Subquery
                if (queryEditor.Text == null || queryEditor.Text.Length == 0 || queryEditor.Text == QueryEditorPlaceholderText)
                {
                    AppForm.DisplayError("SubQuery cannot be blank.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
                return false;
            }
        }

        /// <summary>
        /// Creates a new <see cref="InfluxDbCqParams">Continuous Query</see> parameters object
        /// from the current dialog values.
        /// </summary>
        /// <returns>A CQ params object if current values are valid, otherwise NULL.</returns>
        public InfluxDbCqParams CreateCqParamsFromValues()
        {
            if (!ValidateCqValues()) return null;

            try
            {
                // Collect form values
                var destination = destinationComboBox.SelectedItem != null ? destinationComboBox.SelectedItem as string : destinationComboBox.Text;
                var source = sourceComboBox.SelectedItem != null ? sourceComboBox.SelectedItem as string : sourceComboBox.Text;

                // Subqueries
                var subQueries = new List<string>();
                subQueries.Add(queryEditor.Text.Trim());

                // Tags
                List<string> tags = new List<string>();

                if (!string.IsNullOrWhiteSpace(tagsTextBox.Text))
                {
                    var parsedTags = tagsTextBox.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var tag in parsedTags) tags.Add(tag.Trim());
                }

                // Create the CQ parameters
                var cqParams = new InfluxDbCqParams()
                {
                    Name = nameTextBox.Text,
                    Database = databaseValue.Text,
                    Destination = destination,
                    Source = source,
                    SubQueries = subQueries,
                    Interval = intervalTextBox.Text,
                    FillType = (InfluxDbFillTypes)fillTypeComboBox.SelectedItem,
                    Tags = tags.Count > 0 ? tags : null,
                    ResampleEveryInterval = resampleEveryTextBox.Text,
                    ResampleForInterval = resampleForTextBox.Text
                };

                return cqParams;
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
                return null;
            }
        }

        #endregion Data

        #endregion Methods
    }
}
