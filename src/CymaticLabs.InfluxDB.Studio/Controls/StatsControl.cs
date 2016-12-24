using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Control that displays InfluxDB server stats.
    /// </summary>
    public partial class StatsControl : RequestControl
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the currently selected (if any) statistic name.
        /// </summary>
        public string SelectedStatistic { get; private set; }

        /// <summary>
        /// Gets the current statistics data for the control.
        /// </summary>
        public InfluxDbStats CurrentStatistics { get; private set; }

        #endregion Properties

        #region Constructors

        public StatsControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Event Handlers

        // Handles changes to stat name
        private void statsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lastStatistic = SelectedStatistic;
            SelectedStatistic = statsComboBox.SelectedItem == null ? null : statsComboBox.SelectedItem.ToString();
            if (lastStatistic != SelectedStatistic) BindSelectedStats();
        }

        #endregion Event Handlers

        #region Methods

        /// <summary>
        /// Runs the current query against the configured connection and database.
        /// </summary>
        public override async Task ExecuteRequestAsync()
        {
            if (InfluxDbClient == null) throw new Exception("No InfluxDB client available.");

            // Clear list items
            statsComboBox.Items.Clear();

            // Clear the current results
            tabControl.Controls.Clear();

            // Execute the query
            CurrentStatistics = await InfluxDbClient.GetStatsAsync();

            // Use reflection to dynamically create results
            foreach (var pi in CurrentStatistics.GetType().GetProperties())
            {
                var value = pi.GetValue(CurrentStatistics);
                var statResult = value as IEnumerable<InfluxDbSeries>;
                if (value == null || statResult == null || statResult.Count() == 0) continue; // no results/not supported
                statsComboBox.Items.Add(pi.Name);
            }

            // Restore selection if one existed
            if (!string.IsNullOrWhiteSpace(SelectedStatistic))
            {
                for (var i = 0; i < statsComboBox.Items.Count; i++)
                {
                    var item = statsComboBox.Items[i];

                    if (item.ToString() == SelectedStatistic)
                    {
                        statsComboBox.SelectedIndex = i;
                        BindSelectedStats();
                        break;
                    }
                }
            }
            // Otherwise just select the first result
            else
            {
                statsComboBox.SelectedIndex = 0;
            }
        }

        // Displays the statistic data for the selected statistic
        void BindSelectedStats()
        {
            // Clear current tab list
            tabControl.TabPages.Clear();

            if (string.IsNullOrWhiteSpace(SelectedStatistic) || statsComboBox.SelectedItem == null) return;
            IEnumerable<InfluxDbSeries> statResults = null;

            // Use reflection to get the selected statistic
            statResults = (from pi in CurrentStatistics.GetType().GetProperties()
                          where pi.Name == SelectedStatistic
                          select pi.GetValue(CurrentStatistics) as IEnumerable<InfluxDbSeries>).FirstOrDefault();

            if (statResults == null) return;

            var tabCount = 0;

            // Go through each result data set for the current stat and create tab'd result set.
            foreach (var series in statResults)
            {
                // Create a new tab page to hold the query results control
                var tab = new TabPage(string.Format("{0} {1}", series.Name, ++tabCount));
                //var tab = new TabPage(string.Format("{0}", series.Name));

                // Create a new query results control
                var queryResultsControl = new QueryResultsControl();
                queryResultsControl.InfluxDbClient = InfluxDbClient;
                //queryResultsControl.Database = Database;
                queryResultsControl.Dock = DockStyle.Fill;
                tab.Controls.Add(queryResultsControl);

                // Add the tab to the control
                tabControl.TabPages.Add(tab);

                // Display result data
                queryResultsControl.UpdateResults(series);
            }
        }

        #endregion Methods
    }
}
