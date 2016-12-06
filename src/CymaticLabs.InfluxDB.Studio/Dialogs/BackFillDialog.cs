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
    /// Used to perform data back fills for aggregate data.
    /// </summary>
    public partial class BackfillDialog : Form
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
        /// Gets the resulting Backfill Query parameters from the dialog.
        /// </summary>
        public InfluxDbBackfillParams BackfillResult { get; private set; }

        #endregion Properties

        #region Constructors

        public BackfillDialog()
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

        // Form Load
        private void BackFillDialog_Load(object sender, EventArgs e)
        {
            // Setup help/info tool tips
            destinationToolTip.SetToolTip(destinationInfo, Properties.Resources.BF_Destination_Info);
            sourceToolTip.SetToolTip(sourceInfo, Properties.Resources.BF_Source_Info);
            intervalToolTip.SetToolTip(intervalInfo, Properties.Resources.BF_Interval_Info);
            fillTypeToolTip.SetToolTip(fillTypeInfo, Properties.Resources.CQ_FillType_Info);
            filtersToolTip.SetToolTip(filtersInfo, Properties.Resources.BF_Filters_Info);
            tagsToolTip.SetToolTip(tagsInfo, Properties.Resources.CQ_Tags_Info);
        }

        // Form Closing
        private void BackfillDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // If the user is closing/canceling the form, nothing to do
                if (DialogResult != DialogResult.OK) return;

                // Create the Backfill result from form values
                BackfillResult = CreateBackfillParamsFromValues();

                // If a valid result wasn't returned, cancel
                if (BackfillResult == null) e.Cancel = true;
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
        public void ResetBackFillForm()
        {
            // Reset form values
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

            // Reset time/date format
            var dateTimeFormat = string.Format("{0} @ {1}", AppForm.Settings.DateFormat, AppForm.Settings.TimeFormat);
            fromDateTimePicker.CustomFormat = dateTimeFormat;
            toDateTimePicker.CustomFormat = dateTimeFormat;

            // Reset result
            BackfillResult = null;

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
        bool ValidateBackfillValues()
        {
            try
            {
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
                    if (MessageBox.Show("Source is the same as the Destination. These are typically different values for a Backfill Query. Are you sure that you want to have duplicate values?", "Confirm",
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

                // From/To time
                var fromTime = fromDateTimePicker.Value;
                var toTime = toDateTimePicker.Value;

                if (fromTime >= toTime)
                {
                    AppForm.DisplayError("'From Time' is later than 'To Time'. 'From Time' should come before 'To Time'.");
                    return false;
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
        /// Creates a new <see cref="InfluxDbBackfillParams">Backfill Query</see> parameters object
        /// from the current dialog values.
        /// </summary>
        /// <returns>A Backfill params object if current values are valid, otherwise NULL.</returns>
        public InfluxDbBackfillParams CreateBackfillParamsFromValues()
        {
            if (!ValidateBackfillValues()) return null;

            try
            {
                // Collect form values
                var destination = destinationComboBox.SelectedItem != null ? destinationComboBox.SelectedItem as string : destinationComboBox.Text;
                var source = sourceComboBox.SelectedItem != null ? sourceComboBox.SelectedItem as string : sourceComboBox.Text;

                // Subqueries
                var subQueries = new List<string>();
                subQueries.Add(queryEditor.Text.Trim());

                // Filters
                List<string> filters = new List<string>();

                if (!string.IsNullOrWhiteSpace(filtersTextBox.Text))
                {
                    var parsedFilters = filtersTextBox.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var filter in parsedFilters) filters.Add(filter.Trim());
                }

                // Tags
                List<string> tags = new List<string>();

                if (!string.IsNullOrWhiteSpace(tagsTextBox.Text))
                {
                    var parsedTags = tagsTextBox.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var tag in parsedTags) tags.Add(tag.Trim());
                }

                // Create the Backfill parameters
                var backfillParams = new InfluxDbBackfillParams()
                {
                    Destination = destination,
                    Source = source,
                    SubQueries = subQueries,
                    Interval = intervalTextBox.Text,
                    FillType = (InfluxDbFillTypes)fillTypeComboBox.SelectedItem,
                    FromTime = fromDateTimePicker.Value,
                    ToTime = toDateTimePicker.Value,
                    Filters = filters.Count > 0 ? filters : null,
                    Tags = tags.Count > 0 ? tags : null,
                };

                return backfillParams;
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
