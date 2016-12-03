using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Base class that renders information relating to measurements.
    /// </summary>
    public partial class MeasurementControl : RequestControl
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the measurement who's series are being displayed.
        /// </summary>
        public string Measurement { get; set; }

        /// <summary>
        /// Gets an optional export filename stem that is appended to the end of the suggested filename for export.
        /// </summary>
        public virtual string ExportFileNameStem { get; }

        #endregion Properties

        #region Constructors

        public MeasurementControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Event Handlers

        // Export All -> CSV
        protected async void exportAllCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ExportToCsv();
        }

        // Export All -> JSON
        protected void exportAllJsonMenuItem_Click(object sender, EventArgs e)
        {
            ExportToJson();
        }

        // Export Selected -> CSV
        protected async void exportSelectedCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ExportToCsv(true);
        }

        // Export Selected -> JSON
        protected void exportSelectedJsonMenuItem_Click(object sender, EventArgs e)
        {
            ExportToJson(true);
        }

        #endregion Event Handlers

        #region Methods

        // Exports series data to CSV
        protected virtual async Task ExportToCsv(bool onlySelected = false)
        {
            // Configure save dialog and open
            saveFileDialog.FileName = string.Format("{0}_{1}.csv", Measurement, ExportFileNameStem);
            saveFileDialog.Filter = "CSV files|*.csv|All files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var sb = new StringBuilder();

                // Create a stream writer to write the CSV file
                using (var sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sb.Clear();
                        
                    // Write the CSV column names (skip first column which is just row # label)
                    for (var i = 1; i < listView.Columns.Count; i++)
                    {
                        sb.Append(listView.Columns[i].Text);
                        if (i < listView.Columns.Count - 1) sb.Append(",");
                    }

                    await sw.WriteLineAsync(sb.ToString());

                    // Now write each series row
                    foreach (ListViewItem li in listView.Items)
                    {
                        if (onlySelected && !li.Selected) continue;

                        sb.Clear();

                        // (skip first column which is just row # label)
                        for (var i = 1; i < li.SubItems.Count; i++)
                        {
                            var sli = li.SubItems[i];
                            sb.Append(sli.Text);
                            if (i < li.SubItems.Count - 1) sb.Append(",");
                        }

                        await sw.WriteLineAsync(sb.ToString());
                    }
                }
            }
        }

        // Exports series data to a JSON array
        protected virtual void ExportToJson(bool onlySelected = false)
        {
            try
            {
                // Configure save dialog and open
                saveFileDialog.FileName = string.Format("{0}_{1}.json", Measurement, ExportFileNameStem);
                saveFileDialog.Filter = "JSON files|*.json|All files|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Collect the list of points
                    var array = new List<object>();

                    // Convert results to JSON for export
                    for (var i = 0; i < listView.Items.Count; i++)
                    {
                        var r = listView.Items[i];

                        if (onlySelected && !r.Selected) continue;

                        // Add to outgoing json structure
                        array.Add(r.Tag);
                    }

                    // Serialize to json
                    var json = JsonConvert.SerializeObject(array, Formatting.Indented);

                    // Write to disk
                    File.WriteAllText(saveFileDialog.FileName, json);
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        /// <summary>
        /// Fetches and renders the series for the current measurement.
        /// </summary>
        public async override Task ExecuteRequestAsync()
        {
            if (InfluxDbClient == null) throw new Exception("No InfluxDB client available.");

            // Clear current items
            listView.Items.Clear();
            listView.Columns.Clear();

            // Start redraw
            listView.BeginUpdate();

            // Query and render
            await OnExecuteQuery();

            // Resize each column
            if (listView.Columns.Count > 0)
            {
                var columnWidth = (Width - 12) / listView.Columns.Count;
                if (columnWidth < 96) columnWidth = 96;
                foreach (ColumnHeader col in listView.Columns) col.Width = columnWidth;
            }

            // Render
            listView.EndUpdate();
        }

        /// <summary>
        /// When overriden in derived classes, executes the custom query and databinding operations for the query.
        /// </summary>
        protected async virtual Task OnExecuteQuery()
        {
        }

        #endregion Methods
    }
}
