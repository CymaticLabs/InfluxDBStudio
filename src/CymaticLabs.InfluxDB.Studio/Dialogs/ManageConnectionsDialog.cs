using System;
using System.Windows.Forms;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    /// <summary>
    /// Handles the removal of InfluxDB client connections.
    /// </summary>
    /// <param name="connection">The client connection that was removed.</param>
    public delegate void InfluxDbConnectionEventHandler(InfluxDbConnection connection);

    /// <summary>
    /// Dialog that contains a list of InfluxDB connections and allows connection
    /// management and the ability to connect.
    /// </summary>
    public partial class ManageConnectionsDialog : Form
    {
        #region Fields

        // Dialog used to configure individual connections
        ConnectionDialog connectionDialog;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the currently selected connection, if any.
        /// </summary>
        public InfluxDbConnection SelectedConnection
        {
            get
            {
                return listView.SelectedItems.Count > 0 ? listView.SelectedItems[0].Tag as InfluxDbConnection : null;
            }
        }

        #endregion Properties

        #region Events

        /// <summary>
        /// Occurs when an InfluxDB client connection is created.
        /// </summary>
        public event InfluxDbConnectionEventHandler ConnectionCreated;

        /// <summary>
        /// Occurs when an InfluxDB client connection is updated.
        /// </summary>
        public event InfluxDbConnectionEventHandler ConnectionUpdated;

        /// <summary>
        /// Occurs when an InfluxDB client connection is removed.
        /// </summary>
        public event InfluxDbConnectionEventHandler ConnectionRemoved;

        #endregion Events

        #region Constructors

        public ManageConnectionsDialog()
        {
            InitializeComponent();
            connectionDialog = new ConnectionDialog();
        }

        #endregion Constructors

        #region Event Handlers

        // Handles double click on list item
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var connection = SelectedConnection;
                if (connection == null) return;
                if (connectButton.Enabled) DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Handle changes to the selected connection
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // If an item is selected we can connect to it
                editConnection.Enabled = removeConnection.Enabled = connectButton.Enabled = listView.SelectedItems.Count > 0;

                // Ensure that it is not already open in the active connections list
                var selectedConnection = SelectedConnection;
                if (selectedConnection == null) return;

                foreach (var client in AppForm.ActiveClients)
                {
                    if (client.Connection.Id == selectedConnection.Id || client.Connection == selectedConnection)
                    {
                        connectButton.Enabled = false;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Handle create connection
        private void createConnection_Click(object sender, EventArgs e)
        {
            try
            {
                connectionDialog.ResetValues();

                // Show the create dialog
                if (connectionDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get a connection object from the dialog
                    var connection = connectionDialog.CreateConnection();

                    // Notify
                    if (ConnectionCreated != null) ConnectionCreated(connection);

                    // Redraw
                    RedrawConnections();
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Handle edit connection
        private void editConnection_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the current connection
                var connection = SelectedConnection;
                if (connection == null) return;

                // Bind the dialog to the connection values
                connectionDialog.BindToConnection(connection);
                
                // Open dialog
                if (connectionDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update/save values
                    connectionDialog.UpdateConnectionFromDialog(connection);

                    // Notify
                    if (ConnectionUpdated != null) ConnectionUpdated(connection);

                    // Redraw
                    RedrawConnections();
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Handle remove connection
        private void removeConnection_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the current connection
                var connection = SelectedConnection;
                if (connection == null) return;

                // Get the select list item
                var li = listView.SelectedItems[0];

                if (MessageBox.Show("Delete connection: " + connection.Name + "?", "Confirm Delete",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    // Remove from local UI
                    listView.BeginUpdate();
                    listView.Items.Remove(li);
                    listView.EndUpdate();

                    // Notify
                    if (ConnectionRemoved != null) ConnectionRemoved(connection);
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        #endregion Event Handlers

        #region Methods

        /// <summary>
        /// Updates the current list of connections in the UI.
        /// </summary>
        public void RedrawConnections()
        {
            // Clear the current list of items
            listView.BeginUpdate();
            listView.Items.Clear();

            // Go through each connection and add it to the list
            foreach (var c in AppForm.Settings.Connections)
            {
                var li = new ListViewItem(c.Name, 0);
                li.Tag = c;
                listView.Items.Add(li);
                li.SubItems.Add(new ListViewItem.ListViewSubItem(li, c.Host + ":" + c.Port.ToString()));
            }

            listView.EndUpdate();
            if (listView.Items.Count > 0) listView.Items[0].Selected = true;
            listView.Select();
        }

        #endregion Methods
    }
}
