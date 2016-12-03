using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// A control that executes an InfluxDB query and displays the results.
    /// </summary>
    public partial class QueryControl : RequestControl
    {
        #region Fields

        // Used for timing operations.
        System.Diagnostics.Stopwatch stopWatch;

        // Used to give resulting rows an ID number
        int resultsCount = 0;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the query editor's text.
        /// </summary>
        public string EditorText
        {
            get { return queryEditor.Text; }
            set { queryEditor.Text = value; }
        }

        #endregion Properties

        #region Constructors

        public QueryControl()
        {
            stopWatch = new System.Diagnostics.Stopwatch();

            InitializeComponent();

            // Clear query results text
            resultsLabel.Text = null;

            // Set query editor styles, InfluxDB is SQL like, so use those
            queryEditor.Styles[Style.Sql.Identifier].ForeColor = Color.Blue;
            queryEditor.Styles[Style.Sql.String].ForeColor = Color.Red;
            queryEditor.Styles[Style.Sql.Number].ForeColor = Color.Magenta;
            queryEditor.Styles[Style.Sql.QuotedIdentifier].ForeColor = Color.Red;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Runs the current query against the configured connection and database.
        /// </summary>
        public override async Task ExecuteRequestAsync()
        {
            if (InfluxDbClient == null) throw new Exception("No InfluxDB client available.");

            // Reset the results count
            resultsCount = 0;

            // Get the database and the query
            var query = EditorText.Trim();
            bool isAggregate = query.ToLower().Contains("group by");

            // Clear the current results
            tabControl.Controls.Clear();

            // Start timing...
            stopWatch.Restart();

            // Execute the query
            var results = await InfluxDbClient.QueryAsync(Database, query);

            // Stop timing...
            stopWatch.Stop();

            // If there are results
            if (results != null && results.Count() > 0)
            {
                var tabCount = 0;
                var tabLabel = isAggregate ? "Group" : "Results";

                foreach (var result in results)
                {
                    // Create a new tab page to hold the query results control
                    var tab = new TabPage(string.Format("{0} {1}", tabLabel, ++tabCount));

                    // Create a new query results control
                    var queryResultsControl = new QueryResultsControl();
                    queryResultsControl.InfluxDbClient = InfluxDbClient;
                    queryResultsControl.Database = Database;
                    queryResultsControl.Dock = DockStyle.Fill;
                    tab.Controls.Add(queryResultsControl);

                    // Add the tab to the control
                    tabControl.TabPages.Add(tab);

                    // Render the results and increment the global total
                    resultsCount += queryResultsControl.UpdateResults(result);
                }
            }

            // Show stat results of query
            resultsLabel.Text = string.Format("results: {0}, response time: {1:0} ms", resultsCount, stopWatch.Elapsed.TotalMilliseconds);
        }

        #endregion Methods
    }
}
