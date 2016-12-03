using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    /// <summary>
    /// Dialog used to grant InfluxDB users a new privilege.
    /// </summary>
    public partial class GrantPrivilegeDialog : Form
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the InfluxDB user who will have the privilege granted.
        /// </summary>
        public InfluxDbUser User { get; private set; }

        /// <summary>
        /// Gets or sets the InfluxDB client to use.
        /// </summary>
        public InfluxDbClient InfluxDbClient { get; set; }

        /// <summary>
        /// Gets the currently selected database name in the dialog.
        /// </summary>
        public string SelectedDatabase
        {
            get
            {
                if (databaseComboBox.SelectedItem == null) return null;
                return (string)databaseComboBox.SelectedItem;
            }
        }

        /// <summary>
        /// Gets the currently selected privilege in the dialog.
        /// </summary>
        public InfluxDbPrivileges SelectedPrivilege
        {
            get
            {
                if (privilegeComboBox.SelectedItem == null) return InfluxDbPrivileges.None;
                return (InfluxDbPrivileges)privilegeComboBox.SelectedItem;
            }
        }

        #endregion Properties

        #region Constructors

        public GrantPrivilegeDialog()
        {
            InitializeComponent();

            // Setup the privilege drop down with values dynamically
            foreach (InfluxDbPrivileges p in Enum.GetValues(typeof(InfluxDbPrivileges)))
            {
                if (p == InfluxDbPrivileges.None) continue;
                privilegeComboBox.Items.Add(p);
            }

            privilegeComboBox.SelectedIndex = 0;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Binds the dialog to a user.
        /// </summary>
        /// <param name="user">The user to bind to.</param>
        public async Task BindToUser(InfluxDbUser user)
        {
            // Bind user details
            User = user;
            usernameValue.Text = user.Name;

            // Bind the database list
            await BindDatabases();
        }

        // Binds the database drop down to the list of database for the current connection
        async Task BindDatabases()
        {
            // Clear current list of databases
            databaseComboBox.Items.Clear();

            // Get the total list of databases
            var dbNames = await InfluxDbClient.GetDatabaseNamesAsync();
            if (dbNames.Count() == 0) return;

            databaseComboBox.BeginUpdate();

            foreach (var db in dbNames)
            {
                databaseComboBox.Items.Add(db);
            }

            databaseComboBox.EndUpdate();

            // Select the first database
            databaseComboBox.SelectedIndex = 0;
        }

        #endregion Methods
    }
}
