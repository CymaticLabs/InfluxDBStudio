using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Renders series information for a given measurement.
    /// </summary>
    public partial class SeriesControl : MeasurementControl
    {
        #region Fields

        #endregion Fields

        #region Properties

        public override string ExportFileNameStem { get { return "series"; } }

        #endregion Properties

        #region Constructors

        public SeriesControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        protected override async Task OnExecuteQuery()
        {
            // Get the names of the series
            var seriesSetNames = await InfluxDbClient.GetSeriesNamesAsync(Database, Measurement);
            if (seriesSetNames.Count() == 0) return;

            var columnNameToIndex = new Dictionary<string, int>();
            var columnList = new List<ColumnHeader>();
            var seriesValues = new List<Dictionary<string, string>>();

            // First column is just a row number
            var rowCol = new ColumnHeader() { Text = "#" };
            columnList.Add(rowCol);
            listView.Columns.Add(rowCol);

            // Build the column list and parse series values
            foreach (var seriesName in seriesSetNames)
            {
                // Parse the series data
                var parsedSeries = seriesName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var values = new Dictionary<string, string>();
                seriesValues.Add(values);

                foreach (var pair in parsedSeries)
                {
                    var parsedPair = pair.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = parsedPair[0];
                    if (name == Measurement || parsedPair.Length == 1) continue; // ignore measurement name
                    var value = parsedPair[1];

                    // Create an column name -> index look up table, normalizing names/tags
                    if (!columnNameToIndex.ContainsKey(name))
                    {
                        columnNameToIndex.Add(name, columnList.Count);
                        var col = new ColumnHeader() { Text = name };
                        columnList.Add(col);
                        listView.Columns.Add(col);
                    }

                    // Add this value pair to the series entry
                    values.Add(name, value);
                }
            }

            // Go through each entry and render its values in the correct column
            for (var i = 0; i < seriesValues.Count; i++)
            {
                var values = seriesValues[i];
                var li = new ListViewItem((i + 1).ToString()) { Tag = values };
                listView.Items.Add(li);

                for (var x = 1; x < columnList.Count; x++)
                {
                    var col = columnList[x];
                    var name = col.Text;
                    var sli = new ListViewItem.ListViewSubItem(li, values.ContainsKey(name) ? values[name] : null);
                    li.SubItems.Add(sli);
                }
            }
        }

        #endregion Methods
    }
}
