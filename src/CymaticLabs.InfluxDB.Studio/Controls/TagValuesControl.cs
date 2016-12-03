using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Renders the tag values for a given measurement.
    /// </summary>
    public partial class TagValuesControl : MeasurementControl
    {
        #region Fields

        #endregion Fields

        #region Properties

        public override string ExportFileNameStem
        {
            get { return string.Format("tag_values_{0}", tagKeysComboBox.SelectedItem as string); }
        }

        #endregion Properties

        #region Constructors

        public TagValuesControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Event Handlers

        // Handle changes to tag key
        private async void tagKeysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            await ExecuteRequestAsync();
        }

        #endregion Event Handlers

        #region Methods

        protected async override Task OnExecuteQuery()
        {
            // Fetch tag keys if the drop down has not yet been populated
            if (tagKeysComboBox.Items.Count == 0)
            {
                // Get the current list of tag keys for the measurement
                var tagKeys = await InfluxDbClient.GetTagKeysAsync(Database, Measurement);

                if (tagKeys != null && tagKeys.Count() > 0)
                {
                    foreach (var tag in tagKeys) tagKeysComboBox.Items.Add(tag);
                    tagKeysComboBox.SelectedItem = tagKeys.First();
                }
            }
            else
            {
                await BindTagValues();
            }
        }

        // Queries tag values for the selected tag key and displays them
        async Task BindTagValues()
        {
            // Clear the current items
            listView.Items.Clear();

            // Get the values for the current tag key
            var selectedTag = tagKeysComboBox.SelectedItem as string;

            if (selectedTag != null)
            {
                var tagValues = await InfluxDbClient.GetTagValuesAsync(Database, Measurement, selectedTag);

                // Add default row count column
                listView.Columns.Add(new ColumnHeader() { Text = "#" });

                // Add tag value column
                listView.Columns.Add(new ColumnHeader() { Text = "tagValue" });

                // Add each value to the list
                var rowCount = 0;

                foreach (var tv in tagValues)
                {
                    listView.Items.Add(new ListViewItem(new string[] { (++rowCount).ToString(), tv.Value }) { Tag = tv });
                }
            }
        }

        #endregion Methods
    }
}
