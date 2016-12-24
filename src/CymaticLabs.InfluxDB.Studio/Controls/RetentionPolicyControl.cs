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
    /// Control for working with Retention Policies.
    /// </summary>
    public partial class RetentionPolicyControl : RequestControl
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the presently selected database.
        /// </summary>
        public string SelectedDatabase { get; private set; }

        #endregion Properties

        #region Constructors

        public RetentionPolicyControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Event Handlers

        // Handles changes to the selected database
        private async void databaseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (databaseComboBox.Items.Count == 0 || databaseComboBox.SelectedItem == null) return;
            SelectedDatabase = databaseComboBox.SelectedItem.ToString();
            await BindSelectedPolicy();
        }

        #endregion Event Handlers

        #region Methods

        /// <summary>
        /// Runs the current query against the configured connection and database.
        /// </summary>
        public override async Task ExecuteRequestAsync()
        {
            if (InfluxDbClient == null) throw new Exception("No InfluxDB client available.");

            // Clear current
            listView.Items.Clear();
            databaseComboBox.Items.Clear();

            // If this connection specifies just one database, use it
            if (!string.IsNullOrWhiteSpace(InfluxDbClient.Connection.Database))
            {
                databaseComboBox.Items.Add(InfluxDbClient.Connection.Database);
            }
            // Otherwise load the current list
            else
            {
                var databaseNames = await InfluxDbClient.GetDatabaseNamesAsync();
                foreach (var dbName in databaseNames) databaseComboBox.Items.Add(dbName);
            }

            // Select default database
            if (SelectedDatabase == null)
            {
                databaseComboBox.SelectedIndex = 0;
                SelectedDatabase = databaseComboBox.Items[databaseComboBox.SelectedIndex].ToString();
            }
            else
            {
                for (var i = 0; i < databaseComboBox.Items.Count; i++)
                {
                    var database = databaseComboBox.Items[i].ToString();

                    if (database == SelectedDatabase)
                    {
                        databaseComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        // Binds retention policies for the current database
        async Task BindSelectedPolicy()
        {
            listView.Items.Clear();
            if (string.IsNullOrWhiteSpace(SelectedDatabase)) return;

            listView.BeginUpdate();

            var policies = await InfluxDbClient.GetRetentionPoliciesAsync(SelectedDatabase);

            foreach (var rp in policies)
            {
                var li = new ListViewItem(new string[]
                {
                    rp.Name,
                    rp.Duration,
                    rp.ShardGroupDuration,
                    rp.ReplicationCopies.ToString(),
                    rp.Default ? CheckMark : null
                })
                { Tag = rp };

                listView.Items.Add(li);
            }

            listView.EndUpdate();
        }

        #endregion Methods
    }
}
