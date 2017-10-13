using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using log4net;
using Newtonsoft.Json;
using CymaticLabs.InfluxDB.Data;
using CymaticLabs.InfluxDB.Studio.Controls;
using CymaticLabs.InfluxDB.Studio.Dialogs;

namespace CymaticLabs.InfluxDB.Studio
{
    /// <summary>
    /// The main application form.
    /// </summary>
    public partial class AppForm : Form
    {
        #region Enums
        
        /// <summary>
        /// Different InfluxDB types represented by tree view nodes.
        /// </summary>
        enum InfluxDbNodeTypes
        {
            /// <summary>
            /// Loading place holder used for lazy loading node data.
            /// </summary>
            LoadingPlacholder = 0,

            /// <summary>
            /// An InfluxDB server/connection.
            /// </summary>
            Connection = 1,

            /// <summary>
            /// An InfluxDB database.
            /// </summary>
            Database = 2,

            /// <summary>
            /// An InfluxDB database measurement (table).
            /// </summary>
            Measurement = 3,
        }

        #endregion Enums

        #region Fields

        // Singleton instance
        static AppForm instance;

        // The connections dialog used to manage connections
        ManageConnectionsDialog manageConnectionsDialog;

        // Used to create new databases
        CreateDatabaseDialog createDatabaseDialog;

        // Used to perform back fill queries
        private BackfillDialog backfillDialog;

        // The application about dialog
        AboutDialog aboutDialog;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the application settings.
        /// </summary>
        public static AppSettings Settings { get; private set; }

        /// <summary>
        /// Gets the application's logger.
        /// </summary>
        public static ILog Log { get; private set; }

        /// <summary>
        /// Gets the list of currently active InfluxDB client connections.
        /// </summary>
        public static List<InfluxDbClient> ActiveClients { get; private set; }

        /// <summary>
        /// The global tab context menu used for closing tabs with extended options.
        /// </summary>
        public static ContextMenuStrip TabContextMenu { get; private set; }

        #endregion Properties

        #region Constructors

        public AppForm()
        {
            // Setup static properties
            instance = this;
            Settings = new AppSettings();

            // Enable logging
            Log = LogManager.GetLogger("AppLogger");

            // Setup container for active database connection clients
            ActiveClients = new List<InfluxDbClient>();
            InitializeComponent();

            // Create dialog windows
            aboutDialog = new AboutDialog();
            createDatabaseDialog = new CreateDatabaseDialog();
            backfillDialog = new BackfillDialog();
            manageConnectionsDialog = new ManageConnectionsDialog();
            manageConnectionsDialog.ConnectionCreated += ManageConnectionsDialog_ConnectionCreated;
            manageConnectionsDialog.ConnectionUpdated += ManageConnectionsDialog_ConnectionUpdated;
            manageConnectionsDialog.ConnectionRemoved += ManageConnectionsDialog_ConnectionRemoved;
        }

        #endregion Constructors

        #region Event Handlers

        #region AppForm

        // Handle app load
        private async void AppForm_Load(object sender, EventArgs e)
        {
            // Assign the tab context menu
            TabContextMenu = tabContextMenuStrip;

            // Clear status
            statusLabel.Text = null;

            // Clear the current list of connections
            connectionsTreeView.Nodes.Clear();

            // Load current application settings
            Settings.LoadAll();

            // Apply the settings to the application
            ApplySettings();

            // Set initial tool strip state
            UpdateUIState();

            // Wait a little bit for the main form to load and then show the connections dialog
            await Task.Delay(250);
            await ShowConnectionsDialog();
        }

        #endregion AppForm

        #region File Menu

        #region File

        // File -> Import -> Application Settings
        private async void importAppSettingsMenuItem_Click(object sender, EventArgs e)
        {
            await ImportSettings(true);
        }

        // File -> Export -> Appliction Settings
        private void exportAppSettingsMenuItem_Click(object sender, EventArgs e)
        {
            ExportSettings();
        }

        // File -> Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion File

        #region Connections

        // Handles Connections -> Manage
        private async void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ShowConnectionsDialog();
        }

        #endregion Connections

        #region Query

        // Query -> Run
        private async void runQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ExecuteCurrentRequest();
        }
        
        // Query -> New Query
        private void newQueryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            NewQuery(node);
        }

        // Query -> Show Queries
        private async void showQueriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowQueries(node);
        }

        #endregion Query

        #region Settings

        // Handles Settings -> Allow Untrusted SSL Certificates
        private void allowUntrustedSSLToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            var allowUntrustedSsl = allowUntrustedSSLToolStripMenuItem.Checked;
            SslIgnoreValidator.AllowUntrusted = allowUntrustedSsl;
            Settings.AllowUntrustedSsl = allowUntrustedSsl;
        }

        // Handles Settings -> Time Format -> change of time format
        private void timeFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.TimeFormat = timeFormatComboBox.SelectedIndex == 0 ? AppSettings.TimeFormat12Hour : AppSettings.TimeFormat24Hour;
        }

        // Handles Settings -> Date Format -> change of date format
        private void dateFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.DateFormat = dateFormatComboBox.SelectedIndex == 0 ? AppSettings.DateFormatMonth : AppSettings.DateFormatDay;
        }

        #endregion Settings

        #region Help

        // Help -> About
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutDialog.ShowDialog();
        }

        #endregion Help

        #endregion File Menu

        #region Tool Strip

        // Manage Connections
        private async void manageConnectionsButton_Click(object sender, EventArgs e)
        {
            await ShowConnectionsDialog();
        }

        // Disconnect
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;

            var type = GetNodeType(node);

            switch (type)
            {
                case InfluxDbNodeTypes.Connection:
                    Disconnect(node);
                    break;

                case InfluxDbNodeTypes.Database:
                    Disconnect(node.Parent);
                    break;

                case InfluxDbNodeTypes.Measurement:
                    Disconnect(node.Parent.Parent);
                    break;
            }
        }

        // Show Retention Policies
        private async void showPoliciesButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowRetentionPolicies(node);
        }

        // Show Users
        private async void showUsersButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowUsers(node);
        }

        // Show Statistics
        private async void showStatsButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowStatistics(node);
        }

        // Show Diagnostics
        private async void showDiagnosticsButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowDiagnostics(node);
        }

        // Refresh
        private async void refreshButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            var type = GetNodeType(node);

            switch (type)
            {
                case InfluxDbNodeTypes.Connection:
                    await RefreshConnection(node);
                    break;

                case InfluxDbNodeTypes.Database:
                    await RefreshDatabase(node);
                    break;
            }
        }

        // Run Query
        private async void runQueryButton_Click(object sender, EventArgs e)
        {
            if (CanRunQuery()) await ExecuteCurrentRequest();
        }

        // New Query
        private void newQueryButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            NewQuery(node);
        }

        // Query -> Show Queries
        private async void showQueriesButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowQueries(node);
        }

        // Create Database
        private async void createDatabaseButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await CreateDatabase(node);
        }

        // Show Continuous Queries
        private async void continuousQueryButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowContinuousQueries(node);
        }

        // Run Back Fill
        private async void backFillButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await RunBackFill(node);
        }

        // Drop Database
        private async void dropDatabaseButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await DropDatabase(node);
        }

        // Show Tag Keys
        private async void tagKeysButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowTagKeys(node);
        }

        // Show Tag Values
        private async void tagValuesButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowTagValues(node);
        }

        // Show Field Keys
        private async void fieldKeysButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowFieldKeys(node);
        }

        // Show Series
        private async void showSeriesButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowSeries(node);
        }

        // Drop Series
        private async void dropSeriesButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await DropSeries(node);
        }

        // Drop Measurement
        private async void dropMeasurementButton_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await DropMeasurement(node);
        }

        #endregion Tool Strip

        #region Connections Tree View

        #region Tree Nodes

        // Handle selection change
        private void connectionsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Update the UI accordingly
            UpdateUIState();
        }

        // Handle connections clicks
        private void connectionsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // If this is a right click, set the clicked node to the selected node for conext menus
            if (e.Button == MouseButtons.Right) connectionsTreeView.SelectedNode = e.Node;
        }

        // Handle node double click
        private void connectionsTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // If this is a measurement, launch a new query
            var node = e.Node;
            if (GetNodeType(node) != InfluxDbNodeTypes.Measurement) return;
            NewQuery(node);
        }

        // Handle tree node expansion
        private async void connectionsTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            await ExpandNodeChildren(e.Node);
        }

        #endregion Tree Nodes

        #region Connection Context Menu

        // Connection -> Refresh
        private async void connectionRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await RefreshConnection(node);
        }

        // Connection -> Create Database
        private async void createDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await CreateDatabase(node);
        }

        // Connection -> Show Queries
        private async void showQueriesContextMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowQueries(node);
        }

        // Connection -> Show Retention Policies
        private  async void showRetentionPoliciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowRetentionPolicies(node);
        }

        // Connection -> Show Users
        private async void showUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowUsers(node);
        }

        // Connection -> Show Statistics
        private async void showStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowStatistics(node);
        }

        // Connection -> Show Diagnostics
        private async void diagnosticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowDiagnostics(node);
        }

        // Connection -> Disconnect
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            Disconnect(node);
        }

        #endregion Connection Context Menu

        #region Database Context Menu

        // Database -> Refresh
        private async void databaseRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await RefreshDatabase(node);
        }

        // Database -> Continous Queries
        private async void continousQueriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowContinuousQueries(node);
        }

        // Database -> Run Back Fill
        private async void backFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await RunBackFill(node);
        }

        // Database -> Drop Database
        private async void dropDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await DropDatabase(node);
        }

        #endregion Database Context Menu

        #region Measurement Context Menu

        // Measurement -> Show Series
        private async void showSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowSeries(node);
        }

        // Measurement -> Tag Keys
        private async void tagKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowTagKeys(node);
        }

        // Measurement -> Tag Values
        private async void tagValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowTagValues(node);
        }

        // Measurement -> Field Keys
        private async void fieldKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await ShowFieldKeys(node);
        }

        // Measurement -> Drop Measurement
        private async void dropMeasurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await DropMeasurement(node);
        }

        // Measurement => Drop Series
        private async void dropSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            await DropSeries(node);
        }

        #endregion Measurement Context Menu

        #region Context Menu Shared

        // Handle database/measurement -> New Query
        private void newQueryMenuItem_Click(object sender, EventArgs e)
        {
            var node = connectionsTreeView.SelectedNode;
            if (node == null) return;
            NewQuery(node);
        }

        #endregion Context Menu Shared

        #endregion Connections Tree View

        #region Tab Control

        // Handle user closing of tabs
        private void tabControl_TabClosed(object sender, TabPage e)
        {
            UpdateUIState();
        }

        #endregion Tab Control

        #region Manage Connections Dialog

        // Handles the creation of a connection
        private void ManageConnectionsDialog_ConnectionCreated(InfluxDbConnection connection)
        {
            try
            {
                // Ensure this is not a duplicate by name
                foreach (var c in Settings.Connections)
                {
                    if (c.Name == connection.Name)
                    {
                        DisplayError("A connection already exists with name: " + c.Name, "Connection Exists");
                        return;
                    }
                }

                // Add to the global list
                Settings.Connections.Add(connection);

                // Save connection data
                Settings.SaveConnections();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }
            

        // Handles the update of a connection
        private async void ManageConnectionsDialog_ConnectionUpdated(InfluxDbConnection connection)
        {
            try
            {
                // Save connection data
                Settings.SaveConnections();

                // Go through active connection and update the matching connection in the UI if found
                foreach (TreeNode node in connectionsTreeView.Nodes)
                {
                    var c = node.Tag as InfluxDbConnection;

                    if (c.Id == connection.Id || c == connection)
                    {
                        await RenderConnectionDetails(node, connection, true);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Handles the removal of a connection
        private void ManageConnectionsDialog_ConnectionRemoved(InfluxDbConnection connection)
        {
            try
            {
                // Remove the connection from the global list
                foreach (var c in Settings.Connections)
                {
                    if (c.Id == connection.Id)
                    {
                        Settings.Connections.Remove(c);
                        break;
                    }
                }

                // Save connection data
                Settings.SaveConnections();

                // Remove from UI
                foreach (TreeNode node in connectionsTreeView.Nodes)
                {
                    if (node.Text == connection.Name)
                    {
                        Disconnect(node);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        #endregion Manage Connections Dialog

        #endregion Event Handlers

        #region Methods

        #region Commands

        #region Application

        // Import application settings
        async Task ImportSettings(bool showConnectionManage = false)
        {
            try
            {
                // Prompt to open
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Open the file
                    var json = File.ReadAllText(openFileDialog.FileName);

                    // Convert to app settings object
                    Settings = JsonConvert.DeserializeObject<AppSettings>(json);

                    // Save to disk
                    Settings.SaveAll();

                    // Apply Settings
                    ApplySettings();

                    // Show connections manager if requested
                    if (showConnectionManage) await ShowConnectionsDialog();
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Export application settings
        void ExportSettings()
        {
            try
            {
                // Prompt to save
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Serialize to JSON
                    var json = JsonConvert.SerializeObject(Settings, Formatting.Indented);

                    // Write to file
                    File.WriteAllText(saveFileDialog.FileName, json);
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        #endregion Application

        #region Connection

        // Loads data under a tree node
        async Task ExpandNodeChildren(TreeNode node)
        {
            try
            {
                // Check to see if this a loading place holder node
                if (node.FirstNode == null || node.FirstNode.ImageIndex != (int)InfluxDbNodeTypes.LoadingPlacholder)
                    return;

                // Get the connection and client for this node
                var connection = GetConnection(node);
                var client = GetClient(connection);

                switch (GetNodeType(node))
                {
                    case InfluxDbNodeTypes.Connection:
                        await RenderDatabases(node, client);
                        break;

                    case InfluxDbNodeTypes.Database:
                        await RenderMeasurements(node, client);
                        break;
                    
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Connection -> Refresh
        async Task RefreshConnection(TreeNode node)
        {
            try
            {
                // Remove all child nodes
                node.Nodes.Clear();

                // Get the connection and client for the node
                var connection = GetConnection(node);
                var client = GetClient(connection);

                // Add a placeholder
                var placeholderNode = CreateTreeNode("loading...", InfluxDbNodeTypes.LoadingPlacholder);
                node.Nodes.Add(placeholderNode);

                // Refresh and rerender
                await RenderDatabases(node, client);
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Connection -> Create Database
        async Task CreateDatabase(TreeNode node)
        {
            try
            {
                // Get the selected connection
                var connection = node.Tag as InfluxDbConnection;
                createDatabaseDialog.ConnectionName = connection.Name;
                createDatabaseDialog.DatabaseName = connection.Database;

                // Get the active client for this connection
                var client = GetClient(connection);

                // Show the create database dialog
                if (createDatabaseDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get current list of database names
                    var currentDbNames = await client.GetDatabaseNamesAsync();

                    // Validate new database name
                    if (string.IsNullOrWhiteSpace(createDatabaseDialog.DatabaseName))
                    {
                        DisplayError("Database name cannot be blank.", "Error Creating Database");
                    }
                    // Ensure unique name
                    else if (currentDbNames.Contains(createDatabaseDialog.DatabaseName))
                    {
                        DisplayError("A database named '" + createDatabaseDialog.DatabaseName + "' already exists.", "Error Creating Database");
                        return;
                    }
                    // Attempt to create the database
                    else
                    {
                        // Create the database and receive the response
                        var response = await client.CreateDatabaseAsync(createDatabaseDialog.DatabaseName);

                        if (!response.Success)
                        {
                            DisplayError(response.Body, "Error Creating Database");
                            return;
                        }

                        // If the create was successful, show the new database
                        var newDatabaseNode = CreateTreeNode(createDatabaseDialog.DatabaseName, InfluxDbNodeTypes.Database);
                        node.Nodes.Add(newDatabaseNode);
                        newDatabaseNode.ContextMenuStrip = databaseContextMenu;

                        // Don't render measurement, instead include a loading place holder
                        var placeholderNode = CreateTreeNode("loading...", InfluxDbNodeTypes.LoadingPlacholder);
                        newDatabaseNode.Nodes.Add(placeholderNode);

                        connectionsTreeView.SelectedNode = newDatabaseNode;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Connection -> Show Retention Policies
        async Task ShowRetentionPolicies(TreeNode node)
        {
            try
            {
                // Get connection
                var connection = GetConnection(node);
                var client = GetClient(connection);

                // Create a new control
                var policyControl = new RetentionPolicyControl();
                policyControl.InfluxDbClient = client;

                // Add a tab with a query control in it
                tabControl.AddTabWithControl(connection.Name + ".policies", policyControl, Properties.Resources.RetentionPolicy);

                // Update UI
                UpdateUIState();

                // Render
                await policyControl.ExecuteRequestAsync();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Connection -> Show Users
        async Task ShowUsers(TreeNode node)
        {
            try
            {
                // Get connection
                var connection = GetConnection(node);
                var client = GetClient(connection);

                // Create a new users control
                var usersControl = new InfluxDbUsersControl();
                usersControl.InfluxDbClient = client;

                // Add a tab with a query control in it
                tabControl.AddTabWithControl(connection.Name + ".users", usersControl, Properties.Resources.Users);

                // Update UI
                UpdateUIState();

                // Render
                await usersControl.ExecuteRequestAsync();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Connection -> Show Statistics
        async Task ShowStatistics(TreeNode node)
        {
            try
            {
                // Get connection
                var connection = GetConnection(node);
                var client = GetClient(connection);

                // Create a new diagnostics control
                var statsControl = new StatsControl();
                statsControl.InfluxDbClient = client;

                // Add a tab with a query control in it
                tabControl.AddTabWithControl(connection.Name + ".statistics", statsControl, Properties.Resources.Stats);

                // Update UI
                UpdateUIState();

                // Render
                await statsControl.ExecuteRequestAsync();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Connection -> Show Diagnostics
        async Task ShowDiagnostics(TreeNode node)
        {
            try
            {
                // Query diagnostics info
                var connection = GetConnection(node);
                var client = GetClient(connection);

                // Create a new diagnostics control
                var diagnosticsControl = new DiagnosticsControl();
                diagnosticsControl.InfluxDbClient = client;

                // Add a tab with a query control in it
                tabControl.AddTabWithControl(connection.Name + ".diagnostics", diagnosticsControl, Properties.Resources.Diagnostics);

                // Update UI
                UpdateUIState();

                // Render
                await diagnosticsControl.ExecuteRequestAsync();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Connection -> Disconnect
        void Disconnect(TreeNode node)
        {
            try
            {
                // Remove from active connections list
                var connection = GetConnection(node);
                var client = GetClient(connection);

                // Go through and remove all tabs associated with this connection
                var removedTabs = new List<TabPage>();

                foreach (TabPage tab in tabControl.TabPages)
                {
                    if (tab.Controls.Count > 0 && tab.Controls[0] is RequestControl)
                    {
                        var requestControl = tab.Controls[0] as RequestControl;
                        if (requestControl == null) continue;
                        if (requestControl.InfluxDbClient.Connection.Id == connection.Id)
                        {
                            removedTabs.Add(tab);
                        }
                    }
                }

                foreach (TabPage tab in removedTabs)
                {
                    tabControl.Controls.Remove(tab);
                }

                // Remove from active clients
                ActiveClients.Remove(client);

                // Really nothing to disconnect, just remove the node
                connectionsTreeView.Nodes.Remove(node);
                
                // Update UI
                UpdateUIState();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        #endregion Connection

        #region Database

        // Database -> Refresh
        async Task RefreshDatabase(TreeNode node)
        {
            try
            {
                // Remove all child nodes
                node.Nodes.Clear();

                // Get the connection and client for the node
                var connection = GetConnection(node);
                var client = GetClient(connection);

                // Add a placeholder
                var placeholderNode = new TreeNode("loading...", 4, 4);
                node.Nodes.Add(placeholderNode);

                // Refresh and rerender
                await RenderMeasurements(node, client);
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Database -> Continuous Queries
        async Task ShowContinuousQueries(TreeNode node)
        {
            try
            {
                // Get the connection for this node
                var connection = GetConnection(node);

                // Get the active client for this connection
                var client = GetClient(connection);
                var database = node.Text;

                // Create a new contiuous query control
                var continousQueryControl = new ContinuousQueryControl();
                continousQueryControl.InfluxDbClient = client;
                continousQueryControl.Database = database;

                // Add a tab with a query control in it
                tabControl.AddTabWithControl(connection.Name + "." + database + " CQs", 
                    continousQueryControl, Properties.Resources.ContinuousQuery);

                UpdateUIState();

                await continousQueryControl.ExecuteRequestAsync();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Database -> Back Fill
        async Task RunBackFill(TreeNode node)
        {
            try
            {
                // Get the connection for this node
                var connection = GetConnection(node);

                // Get the active client for this connection
                var client = GetClient(connection);
                var database = node.Text;

                // Pass client connection down
                backfillDialog.ResetBackFillForm();
                backfillDialog.InfluxDbClient = client;
                backfillDialog.Database = database;

                // Bind dynamic data
                await backfillDialog.BindInfluxDataSources();

                if (backfillDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the resulting Backfill params
                    var backfillParams = backfillDialog.BackfillResult;

                    // Create the CQ and get the response
                    var response = await client.BackfillAsync(database, backfillParams);

                    if (!response.Success)
                    {
                        DisplayError(response.Body);
                    }

                    UpdateUIState();
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Database -> Drop Database
        async Task DropDatabase(TreeNode node)
        {
            try
            {
                var name = node.Text;

                // Confirm delete
                if (MessageBox.Show("Drop database: " + name + "?", "Confirm Drop", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    // Get the connection
                    var connection = GetConnection(node);

                    if (connection == null)
                    {
                        DisplayError("Connection not found: " + createDatabaseDialog.ConnectionName, "Error Creating Database");
                        return;
                    }

                    // Get the active client for the connection
                    var client = GetClient(connection);

                    // Create the database and receive the response
                    var response = await client.DropDatabaseAsync(name);

                    if (!response.Success)
                    {
                        DisplayError(response.Body, "Error Dropping Database");
                        return;
                    }

                    // Remove the database from the UI list
                    connectionsTreeView.BeginUpdate();
                    connectionsTreeView.Nodes.Remove(node);
                    connectionsTreeView.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        #endregion Database

        #region Measurement

        // Measurement -> Show Series
        async Task ShowSeries(TreeNode node)
        {
            try
            {
                var connection = GetConnection(node);
                var client = GetClient(connection);
                var database = node.Parent.Text;
                var measurement = node.Text;

                
                // Create a new series control
                var seriesControl = new SeriesControl();
                seriesControl.InfluxDbClient = client;
                seriesControl.Database = database;
                seriesControl.Measurement = measurement;

                // Add a tab with a series control in it
                tabControl.AddTabWithControl(connection.Name + "." + measurement + ".series", 
                    seriesControl, Properties.Resources.Series);

                // Update UI
                UpdateUIState();

                // Render
                await seriesControl.ExecuteRequestAsync();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Measurement -> Tag Keys
        async Task ShowTagKeys(TreeNode node)
        {
            try
            {
                var connection = GetConnection(node);
                var client = GetClient(connection);
                var database = node.Parent.Text;
                var measurement = node.Text;

                // Create a new tag keys control
                var tagKeysControl = new TagKeysControl();
                tagKeysControl.InfluxDbClient = client;
                tagKeysControl.Database = database;
                tagKeysControl.Measurement = measurement;

                // Add a tab with a tag keys control in it
                tabControl.AddTabWithControl(connection.Name + "." + measurement + ".tag_keys", 
                    tagKeysControl, Properties.Resources.TagKeys);

                // Update UI
                UpdateUIState();

                // Render
                await tagKeysControl.ExecuteRequestAsync();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Measurement -> Tag Values
        async Task ShowTagValues(TreeNode node)
        {
            try
            {
                var connection = GetConnection(node);
                var client = GetClient(connection);
                var database = node.Parent.Text;
                var measurement = node.Text;

                // Create a new tag values control
                var tagValuesControl = new TagValuesControl();
                tagValuesControl.InfluxDbClient = client;
                tagValuesControl.Database = database;
                tagValuesControl.Measurement = measurement;

                // Add a tab with a tag values control in it
                tabControl.AddTabWithControl(connection.Name + "." + measurement + ".tag_values", 
                    tagValuesControl, Properties.Resources.TagValues);

                // Update UI
                UpdateUIState();

                // Render
                await tagValuesControl.ExecuteRequestAsync();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Measurement - Field Keys
        async Task ShowFieldKeys(TreeNode node)
        {
            try
            {
                var connection = GetConnection(node);
                var client = GetClient(connection);
                var database = node.Parent.Text;
                var measurement = node.Text;

                // Create a new query control
                var fieldKeysControl = new FieldKeysControl();
                fieldKeysControl.InfluxDbClient = client;
                fieldKeysControl.Database = database;
                fieldKeysControl.Measurement = measurement;

                // Add a tab with a query control in it
                tabControl.AddTabWithControl(connection.Name + "." + measurement + ".field_keys", 
                    fieldKeysControl, Properties.Resources.FieldKeys);

                // Update UI
                UpdateUIState();

                // Render
                await fieldKeysControl.ExecuteRequestAsync();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Measurement - Drop Measurement
        async Task DropMeasurement(TreeNode node)
        {
            try
            {
                var name = node.Text;
                var dbName = node.Parent.Text;

                // Confirm delete
                if (MessageBox.Show("Drop measurement: " + name + "?", "Confirm Drop", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    // Get the connection
                    var connection = GetConnection(node);

                    if (connection == null)
                    {
                        DisplayError("Connection not found: " + createDatabaseDialog.ConnectionName, "Error Creating Database");
                        return;
                    }

                    // Get the active client for the connection
                    var client = GetClient(connection);

                    // Create the database and receive the response
                    var response = await client.DropMeasurementAsync(dbName, name);

                    if (!response.Success)
                    {
                        DisplayError(response.Body, "Error Dropping Measurement");
                        return;
                    }

                    // Remove the series from the UI list
                    connectionsTreeView.BeginUpdate();
                    connectionsTreeView.Nodes.Remove(node);
                    connectionsTreeView.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Measurement -> Drop Series
        async Task DropSeries(TreeNode node)
        {
            try
            {
                var name = node.Text;
                var dbName = node.Parent.Text;

                // Confirm delete
                if (MessageBox.Show("Drop series for: " + name + "?", "Confirm Drop", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    // Get the connection
                    var connection = GetConnection(node);

                    if (connection == null)
                    {
                        DisplayError("Connection not found: " + createDatabaseDialog.ConnectionName, "Error Creating Database");
                        return;
                    }

                    // Get the active client for the connection
                    var client = GetClient(connection);

                    // Create the database and receive the response
                    var response = await client.DropSeriesAsync(dbName, name);

                    if (!response.Success)
                    {
                        DisplayError(response.Body, "Error Dropping Series");
                        return;
                    }

                    // Remove the series from the UI list
                    connectionsTreeView.BeginUpdate();
                    node.Nodes.Clear();
                    connectionsTreeView.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        #endregion Measurement

        #region Queries/Requests

        // Database|Measurement -> New Query
        void NewQuery(TreeNode node)
        {
            try
            {
                // Get the connection for this node
                var connection = GetConnection(node);

                // Get the active client for this connection
                var client = GetClient(connection);

                // Some dynamic values
                string database = null;
                string measurement = "measurement";

                // Figure out what type of node was clicked
                switch (GetNodeType(node))
                {
                    // Connection
                    case InfluxDbNodeTypes.Connection:
                        return;

                    // Database
                    case InfluxDbNodeTypes.Database:
                        database = node.Text;
                        break;

                    // Measurement
                    case InfluxDbNodeTypes.Measurement:
                        database = node.Parent.Text;
                        measurement = node.Text;
                        break;
                }

                // Create a new query control
                var queryControl = new QueryControl();
                queryControl.InfluxDbClient = client;
                queryControl.Database = database;
                queryControl.EditorText = string.Format("SELECT * FROM \"{0}\" WHERE time > now() - 5m", measurement);

                // Add a tab with a query control in it
                tabControl.AddTabWithControl(connection.Name + "." + database, queryControl, Properties.Resources.RunQuery);

                // Update UI
                UpdateUIState();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Queries -> Show Queries
        async Task ShowQueries(TreeNode node)
        {
            try
            {
                // Get the connection for this node
                var connection = GetConnection(node);

                // Get the active client for this connection
                var client = GetClient(connection);

                // Create a new contiuous query control
                var runningQueriesControl = new RunningQueriesControl();
                runningQueriesControl.InfluxDbClient = client;

                // Add a tab with a query control in it
                tabControl.AddTabWithControl(connection.Name + ".queries",
                    runningQueriesControl, Properties.Resources.ShowQueries);

                UpdateUIState();

                await runningQueriesControl.ExecuteRequestAsync();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Executes the current request control's request
        async Task ExecuteCurrentRequest()
        {
            // Execute the query
            try
            {
                // Get the selected tab
                var tab = tabControl.SelectedTab;
                if (tab == null) return;

                // Get the request control for this tab
                RequestControl requestControl = null;

                foreach (Control c in tabControl.SelectedTab.Controls)
                {
                    if (c is RequestControl)
                    {
                        requestControl = (RequestControl)c;
                        break;
                    }
                }

                if (requestControl == null) return;
                await requestControl.ExecuteRequestAsync();
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        #endregion Queries/Requests

        #endregion Commands

        #region Settings

        // Load application settings
        void ApplySettings()
        {
            // Set time format
            if (Settings.TimeFormat == AppSettings.TimeFormat12Hour)
            {
                // 12 hour
                timeFormatComboBox.SelectedIndex = 0;
            }
            else
            {
                // 24 hour
                timeFormatComboBox.SelectedIndex = 1;
            }

            // Set date format
            if (Settings.DateFormat == AppSettings.DateFormatMonth)
            {
                // month-first
                dateFormatComboBox.SelectedIndex = 0;
            }
            else
            {
                // day-first
                dateFormatComboBox.SelectedIndex = 1;
            }

            // Apply untrusted SSL
            allowUntrustedSSLToolStripMenuItem.Checked = Settings.AllowUntrustedSsl;
        }

        #endregion Settings

        #region User Interface

        // Updates the state of the tool strip to match the current user interaction
        void UpdateUIState()
        {
            var node = connectionsTreeView.SelectedNode;
            var type = node != null ? GetNodeType(node) : InfluxDbNodeTypes.LoadingPlacholder;
            var canRunQeury = CanRunQuery();

            #region File Menu

            // Reset
            refreshToolStripMenuItem.Enabled = false;
            runQueryToolStripMenuItem.Enabled = false;
            newQueryToolStripMenuItem2.Enabled = false;
            showQueriesToolStripMenuItem.Enabled = false;

            if (node != null)
            {
                refreshToolStripMenuItem.Enabled = true;
            }

            // Update run query based on whether or not a request control is currently in focus
            runQueryToolStripMenuItem.Enabled = canRunQeury;
            newQueryToolStripMenuItem2.Enabled = type == InfluxDbNodeTypes.Database || type == InfluxDbNodeTypes.Measurement;
            showQueriesToolStripMenuItem.Enabled = type == InfluxDbNodeTypes.Connection;

            #endregion File Menu

            #region Tool Strip

            // Start out by clearing all button states
            disconnectButton.Enabled = false;
            showQueriesButton.Enabled = false;
            showPoliciesButton.Enabled = false;
            showUsersButton.Enabled = false;
            showStatsButton.Enabled = false;
            showDiagnosticsButton.Enabled = false;
            refreshButton.Enabled = false;
            runQueryButton.Enabled = false;
            newQueryButton.Enabled = false;
            createDatabaseButton.Enabled = false;
            continuousQueryButton.Enabled = false;
            backFillButton.Enabled = false;
            dropDatabaseButton.Enabled = false;
            tagKeysButton.Enabled = false;
            tagValuesButton.Enabled = false;
            fieldKeysButton.Enabled = false;
            showSeriesButton.Enabled = false;
            dropSeriesButton.Enabled = false;
            dropMeasurementButton.Enabled = false;

            // If a node is selected, update button states according to selected node
            if (node != null)
            {
                // Update button states accordingly
                disconnectButton.Enabled = true;
                refreshButton.Enabled = type == InfluxDbNodeTypes.Connection || type == InfluxDbNodeTypes.Database;
                newQueryButton.Enabled = type == InfluxDbNodeTypes.Database || type == InfluxDbNodeTypes.Measurement;
                showQueriesButton.Enabled = type == InfluxDbNodeTypes.Connection;
                showPoliciesButton.Enabled = type == InfluxDbNodeTypes.Connection;
                showUsersButton.Enabled = type == InfluxDbNodeTypes.Connection;
                showStatsButton.Enabled = type == InfluxDbNodeTypes.Connection;
                showDiagnosticsButton.Enabled = type == InfluxDbNodeTypes.Connection;
                createDatabaseButton.Enabled = type == InfluxDbNodeTypes.Connection;
                continuousQueryButton.Enabled = type == InfluxDbNodeTypes.Database;
                backFillButton.Enabled = type == InfluxDbNodeTypes.Database;
                dropDatabaseButton.Enabled = type == InfluxDbNodeTypes.Database && node.Text != "_internal";
                tagKeysButton.Enabled = type == InfluxDbNodeTypes.Measurement;
                tagValuesButton.Enabled = type == InfluxDbNodeTypes.Measurement;
                fieldKeysButton.Enabled = type == InfluxDbNodeTypes.Measurement;
                showSeriesButton.Enabled = type == InfluxDbNodeTypes.Measurement;
                dropSeriesButton.Enabled = type == InfluxDbNodeTypes.Measurement;
                dropMeasurementButton.Enabled = type == InfluxDbNodeTypes.Measurement;
            }

            // Update run query based on whether or not a request control is currently in focus
            runQueryButton.Enabled = canRunQeury;

            #endregion Tool Strip

            #region Context Menus

            showQueriesContextMenuItem.Enabled = type == InfluxDbNodeTypes.Connection;
            continousQueriesToolStripMenuItem.Enabled = type == InfluxDbNodeTypes.Database;
            backFillToolStripMenuItem.Enabled = type == InfluxDbNodeTypes.Database;
            dropDatabaseToolStripMenuItem.Enabled = type == InfluxDbNodeTypes.Database && node.Text != "_internal";

            #endregion Context Menus
        }

        // Determines whether or not a query is in focus that can run
        bool CanRunQuery()
        {
            return tabControl.SelectedTab != null && tabControl.SelectedTab.Controls.Count > 0 && tabControl.SelectedTab.Controls[0] is RequestControl;
        }

        #endregion User Interface

        #region Connections

        #region Utility

        // Gets a connection given its tree node.
        InfluxDbConnection GetConnection(TreeNode node)
        {
            TreeNode current = node;

            while (current.Parent != null)
            {
                current = current.Parent;
            }

            return current.Tag as InfluxDbConnection;
        }

        // Gets the active InfluxDB for a given connection
        InfluxDbClient GetClient(InfluxDbConnection connection)
        {
            foreach (var client in ActiveClients)
            {
                if (client.Connection.Id == connection.Id || client.Connection == connection) return client;
            }

            return null;
        }

        #endregion Utility

        #region Rendering

        // Updates and shows the connection dialog
        async Task ShowConnectionsDialog()
        {
            // Update the current list of connections in the dialog
            manageConnectionsDialog.RedrawConnections();

            // Show the dialog
            if (manageConnectionsDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected connection
                var c = manageConnectionsDialog.SelectedConnection;

                // Add the selected connection to the active connection view
                if (c != null) await RenderConnection(c);
            }
        }

        // Adds an InfluxDB connection to the active list
        async Task RenderConnection(InfluxDbConnection connection)
        {
            try
            {
                // Add the connection
                var connectionNode = CreateTreeNode(connection.Name, InfluxDbNodeTypes.Connection, connection);
                connectionNode.ContextMenuStrip = connectionsContextMenu;
                connectionsTreeView.Nodes.Add(connectionNode);

                // Create an active client for this connection
                var client = InfluxDbClientFactory.Create(connection);
                ActiveClients.Add(client);

                // Render the connection in the view
                await RenderConnectionDetails(connectionNode, connection);

                // If there are currently no selected nodes, select the new connection
                if (connectionsTreeView.SelectedNode == null) connectionsTreeView.SelectedNode = connectionNode;
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Render the connection details of a top-level connection node in the active connections list
        async Task RenderConnectionDetails(TreeNode connectionNode, InfluxDbConnection connection, bool update = false)
        {
            try
            {
                // If this is an update, update values and clear child nodes and redraw
                if (update)
                {
                    connectionNode.Text = connection.Name;
                    connectionNode.Collapse();
                    connectionNode.Nodes.Clear();
                }

                // Get the client for this connection
                var client = GetClient(connection);

                // If a single database name is specified on the connection, don't query InfluxDB for databse names.
                // This can be helpful if the user connecting doesn't have permission to do database discovery.
                if (!string.IsNullOrWhiteSpace(connection.Database))
                {
                    // Render children
                    await RenderDatabases(connectionNode, client);
                }
                else
                {
                    // Don't render databses, instead include a loading place holder
                    var placeholderNode = CreateTreeNode("loading...", InfluxDbNodeTypes.LoadingPlacholder);
                    connectionNode.Nodes.Add(placeholderNode);
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Renders the database nodes under a connection node
        async Task RenderDatabases(TreeNode connectionNode, InfluxDbClient client)
        {
            try
            {
                var connection = client.Connection;

                // Query database(s)
                var dbNames = new List<string>();

                // If a single database name is specified on the connection, don't query InfluxDB for databse names.
                // This can be helpful if the user connecting doesn't have permission to do database discovery.
                if (string.IsNullOrWhiteSpace(connection.Database))
                {
                    dbNames.AddRange(await client.GetDatabaseNamesAsync());
                }
                else
                {
                    dbNames.Add(connection.Database);
                }

                // Clear current children
                connectionNode.Nodes.Clear();

                // Iterate through returned databases and add their details
                foreach (var dbName in dbNames)
                {
                    // Ignore _internal db
                    //if (dbName == "_internal") continue;

                    // Add databases
                    var dbNode = CreateTreeNode(dbName, InfluxDbNodeTypes.Database);
                    dbNode.ContextMenuStrip = databaseContextMenu;
                    connectionNode.Nodes.Add(dbNode);

                    // Don't render measurement, instead include a loading place holder
                    var placeholderNode = CreateTreeNode("loading...", InfluxDbNodeTypes.LoadingPlacholder);
                    dbNode.Nodes.Add(placeholderNode);
                }
            }
            catch(Exception ex)
            {
                DisplayException(ex);
            }
        }

        // Renders the measurement nodes under a database node
        async Task RenderMeasurements(TreeNode dbNode, InfluxDbClient client)
        {
            try
            {
                var dbName = dbNode.Text;

                // Add measurements
                var measurementNames = await client.GetMeasurementNamesAsync(dbName);

                // Clear current children
                dbNode.Nodes.Clear();

                // Render children
                foreach (var measurementName in measurementNames)
                {
                    var measurementNode = CreateTreeNode(measurementName, InfluxDbNodeTypes.Measurement);
                    measurementNode.ContextMenuStrip = measurementContextMenu;
                    dbNode.Nodes.Add(measurementNode);
                }
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }
        
        #endregion Rendering

        #endregion Connections

        #region Utility

        // Gets the InfluxDB type from a given tere node.
        InfluxDbNodeTypes GetNodeType(TreeNode node)
        {
            return (InfluxDbNodeTypes)node.ImageIndex;
        }

        // Determines whether or not a tree node is a specific InfluxDB type
        bool IsNodeType(TreeNode node, InfluxDbNodeTypes type)
        {
            return node.ImageIndex == (int)type;
        }

        // Returns a specific tree node type
        TreeNode CreateTreeNode(string text, InfluxDbNodeTypes type, object tag = null)
        {
            return new TreeNode(text, (int)type, (int)type) { Tag = tag };
        }

        #endregion Utility

        #region Static

        /// <summary>
        /// Opens the Back Fill dialog and allows a user to run a back fill query.
        /// </summary>
        public static async Task RunBackFill()
        {
            if (instance == null || instance.connectionsTreeView.SelectedNode == null) return;
            await instance.RunBackFill(instance.connectionsTreeView.SelectedNode);
        }

        /// <summary>
        /// Sets the text of the applications status bar.
        /// </summary>
        /// <param name="text">The text to set.</param>
        public static void SetStatus(string text)
        {
            if (instance == null) return;
            instance.statusLabel.Text = text;
        }

        /// <summary>
        /// Displays an unexpected exception that occured in the application to the user.
        /// </summary>
        /// <param name="ex">The exception that occured.</param>
        /// <param name="caption">The optional error message caption to display.</param>
        /// <param name="stackTrace">Determines whether or not the exception's stack trace should be displayed.</param>
        public static void DisplayException(Exception ex, string caption = "Unexpected Error", bool stackTrace = false)
        {
            if (ex == null) throw new ArgumentNullException("ex");

            // Workaround for KILL QUERY command
            if (ex is InfluxData.Net.Common.Infrastructure.InfluxDataApiException)
            {
                var apiEx = (InfluxData.Net.Common.Infrastructure.InfluxDataApiException)ex;
                if (apiEx.ResponseBody.Contains("query interrupted")) return;
            }

            var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            if (stackTrace) message += "\n\n{0}" + ex.StackTrace;

            try { Log.ErrorFormat("{0}", ex); }
            catch { }

            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays an error message to the user.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        /// <param name="caption">The optional error caption to display.</param>
        public static void DisplayError(string message, string caption = "Error")
        {
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException("message");

            try { Log.ErrorFormat("{0}", message); }
            catch { }

            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Static

        #endregion Methods
    }
}
