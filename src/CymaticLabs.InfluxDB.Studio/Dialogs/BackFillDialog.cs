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
    public partial class BackFillDialog : Form
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

        #endregion Properties

        #region Constructors

        public BackFillDialog()
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
            //CqResult = null;

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

        #endregion Data

        #endregion Methods
    }
}
