using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CymaticLabs.InfluxDB.Data;
using CymaticLabs.InfluxDB.Studio.Dialogs;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Renders InfluxDB user information and allows for basic user management interactions.
    /// </summary>
    public partial class InfluxDbUsersControl : RequestControl
    {
        #region Fields

        // The current selected privilege grant (if any).
        private InfluxDbGrant selectedPrivilegeGrant;

        // Dialog used to create new users
        private CreateUserDialog createUserDialog;

        // Dialog used to edit existing users
        private EditUserDialog editUserDialog;

        // Dialog used to update user password
        private UserPasswordDialog userPasswordDialog;

        // Dialog used to grant new database privileges
        private GrantPrivilegeDialog grantPrivilegeDialog;

        // Dialog used to edit existing database privileges
        private EditPrivilegeDialog editPrivilegeDialog;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the currently selected user.
        /// </summary>
        public InfluxDbUser SelectedUser { get; private set; }

        /// <summary>
        /// Gets the currently selected privilege grant.
        /// </summary>
        public InfluxDbGrant SelectedPrivilegeGrant
        {
            get { return selectedPrivilegeGrant; }

            set
            {
                if (SelectedPrivilegeGrant == value) return;
                selectedPrivilegeGrant = value;
            }
        }

        #endregion Properties

        #region Constructors

        public InfluxDbUsersControl()
        {
            InitializeComponent();

            createUserDialog = new CreateUserDialog();
            editUserDialog = new EditUserDialog();
            userPasswordDialog = new UserPasswordDialog();
            grantPrivilegeDialog = new GrantPrivilegeDialog();
            editPrivilegeDialog = new EditPrivilegeDialog();

            // Set initial UI state
            UpdateUIState();
        }

        #endregion Constructors

        #region Event Handlers

        #region Users

        // Handle changes to the selected user
        private async void usersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = usersListView.SelectedItems.Count > 0 ? usersListView.SelectedItems[0] : null;

            if (selectedItem == null)
            {
                SelectedUser = null;

                // Clear grants
                SelectedPrivilegeGrant = null;
                grantsListView.BeginUpdate();
                grantsListView.Items.Clear();
                grantsListView.EndUpdate();
            }
            else
            {
                SelectedUser = selectedItem.Tag as InfluxDbUser;
                await BindToPrivileges(SelectedUser);
            }

            // Update interface buttons
            UpdateUIState();
        }

        // Create User
        private async void createUserButton_Click(object sender, EventArgs e)
        {
            await CreateUser();
        }

        // Edit User
        private async void editUserButton_Click(object sender, EventArgs e)
        {
            await EditUser();
        }

        // Change Password
        private async void changePasswordButton_Click(object sender, EventArgs e)
        {
            await ChangePassword();
        }

        // Drop User
        private async void dropUserButton_Click(object sender, EventArgs e)
        {
            await DropUser();
        }

        #endregion Users

        #region Grants/Privileges

        // Handle change to selected privilege
        private void grantsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = grantsListView.SelectedItems.Count > 0 ? grantsListView.SelectedItems[0] : null;

            if (selectedItem == null)
            {
                SelectedPrivilegeGrant = null;
            }
            else
            {
                SelectedPrivilegeGrant = selectedItem.Tag as InfluxDbGrant;
            }

            // Update interface buttons
            UpdateUIState();
        }

        // Handle grant new privilege
        private async void grantPrivilegeButton_Click(object sender, EventArgs e)
        {
            await GrantPrivilege();
        }

        // Handle edit privilege
        private async void editPrivilegeButton_Click(object sender, EventArgs e)
        {
            await EditPrivilege();
        }

        #endregion Grants/Privileges

        #endregion Event Handlers

        #region Methods

        #region Commands

        // Creates a new user
        async Task CreateUser()
        {
            try
            {
                // Clear dialog values
                createUserDialog.ClearCreateValues();

                if (createUserDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Get the user data
                    var user = createUserDialog.CreateUserFromDialog();
                    if (user == null) return;

                    // Ensure unique username
                    foreach (ListViewItem li in usersListView.Items)
                    {
                        if (li.Text == user.Name)
                        {
                            AppForm.DisplayError("User already exists: " + user.Name, "Create Error");
                            return;
                        }
                    }

                    // Create the user
                    var response = await InfluxDbClient.CreateUserAsync(user.Name, createUserDialog.Password, user.IsAdmin);

                    // Select the user and refresh the window
                    if (response.Success)
                    {
                        SelectedUser = user;
                        await ExecuteRequestAsync();
                    }
                    else
                    {
                        AppForm.DisplayError(response.Body);
                    }

                    // Update interface buttons
                    UpdateUIState();
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Edit the selected user
        async Task EditUser()
        {
            try
            {
                var user = SelectedUser;
                if (user == null) return;

                editUserDialog.BindToUser(user);

                if (editUserDialog.ShowDialog() == DialogResult.OK)
                {
                    // If there was no change in user status, there's nothing to do
                    var updatedUser = editUserDialog.CreateUserFromDialog();
                    if (user.IsAdmin == updatedUser.IsAdmin) return;

                    InfluxDbApiResponse response = null;

                    // Otherwise carry out the appropriate API call based on adding or removing admin privileges
                    if (updatedUser.IsAdmin)
                    {
                        response = await InfluxDbClient.GrantAdministratorAsync(updatedUser.Name);
                    }
                    else
                    {
                        response = await InfluxDbClient.RevokeAdministratorAsync(updatedUser.Name);
                    }

                    // Refresh the window
                    if (response.Success)
                    {
                        await ExecuteRequestAsync();
                    }
                    else
                    {
                        AppForm.DisplayError(response.Body);
                    }

                    // Update interface buttons
                    UpdateUIState();
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Update password for the selected user
        async Task ChangePassword()
        {
            try
            {
                var user = SelectedUser;
                if (user == null) return;

                userPasswordDialog.BindToUser(user);

                if (userPasswordDialog.ShowDialog() == DialogResult.OK)
                {
                    var response = await InfluxDbClient.SetPasswordAsync(user.Name, userPasswordDialog.Password);

                    // Select the user and refresh the window
                    if (!response.Success)
                    {
                        AppForm.DisplayError(response.Body);
                    }
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Drop the selected user
        async Task DropUser()
        {
            try
            {
                var user = SelectedUser;
                if (user == null) return;

                // Confirm drop
                if (MessageBox.Show(string.Format("Drop user: {0}?", user.Name), "Confirm User Drop", 
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }

                var response = await InfluxDbClient.DropUserAsync(user.Name);

                // Select the user and refresh the window
                if (response.Success)
                {
                    SelectedUser = null;
                    await ExecuteRequestAsync();
                }
                else
                {
                    AppForm.DisplayError(response.Body);
                }

                // Update interface buttons
                UpdateUIState();
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Grant privilege
        async Task GrantPrivilege()
        {
            try
            {
                var user = SelectedUser;
                if (user == null) return;

                grantPrivilegeDialog.InfluxDbClient = InfluxDbClient;
                await grantPrivilegeDialog.BindToUser(user);

                if (grantPrivilegeDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected database and privilege to grant
                    var username = grantPrivilegeDialog.User.Name;
                    var database = grantPrivilegeDialog.SelectedDatabase;
                    var privilege = grantPrivilegeDialog.SelectedPrivilege;

                    // Ensure a database was selected
                    if (string.IsNullOrWhiteSpace(database))
                    {
                        AppForm.DisplayError("You must supply a database to grant a privilege for.");
                        return;
                    }
                    // Otherwise if "None" was selected (shouldn't be possible), there's nothing to grant...
                    else if (privilege == InfluxDbPrivileges.None)
                    {
                        return;
                    }

                    // Grant the privilege
                    var response = await InfluxDbClient.GrantPrivilegeAsync(username, privilege, database);

                    // Refresh the window
                    if (response.Success)
                    {
                        await ExecuteRequestAsync();
                    }
                    else
                    {
                        AppForm.DisplayError(response.Body);
                    }

                    // Update interface buttons
                    UpdateUIState();
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Edit privilege
        async Task EditPrivilege()
        {
            try
            {
                var user = SelectedUser;
                if (user == null) return;

                var grant = SelectedPrivilegeGrant;
                if (grant == null) return;

                // Bind to data
                editPrivilegeDialog.BindToGrant(user.Name, grant);

                if (editPrivilegeDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected database and privilege to grant
                    var username = editPrivilegeDialog.Username;
                    var database = editPrivilegeDialog.Database;
                    var privilege = editPrivilegeDialog.SelectedPrivilege;

                    // Ensure a database was selected
                    if (string.IsNullOrWhiteSpace(database))
                    {
                        AppForm.DisplayError("You must supply a database to update a privilege for.");
                        return;
                    }

                    InfluxDbApiResponse response = null;

                    // If "None" was selected then we actually need to revoke the existing privilege
                    if (privilege == InfluxDbPrivileges.None)
                    {
                        response = await InfluxDbClient.RevokePrivilegeAsync(username, grant.Privilege, database);
                    }
                    // Otherwise just grant the new privilege
                    else
                    {
                        response = await InfluxDbClient.GrantPrivilegeAsync(username, privilege, database);
                    }

                    // Refresh the window
                    if (response.Success)
                    {
                        await ExecuteRequestAsync();
                    }
                    else
                    {
                        AppForm.DisplayError(response.Body);
                    }

                    // Update interface buttons
                    UpdateUIState();
                }
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        #endregion Commands

        #region Request

        public async override Task ExecuteRequestAsync()
        {
            usersListView.BeginUpdate();
            usersListView.Items.Clear();

            // Get the current list of users
            var users = await InfluxDbClient.GetUsersAsync();

            if (users != null && users.Count() > 0)
            {
                foreach (var user in users)
                {
                    usersListView.Items.Add(
                        new ListViewItem(new string[] {
                                user.Name,
                                user.IsAdmin ? CheckMark : null
                    }) { Tag = user });
                }
            }

            // Restore any previous selection
            var selectedUser = SelectedUser;

            if (selectedUser != null)
            {
                foreach (ListViewItem li in usersListView.Items)
                {
                    if (li.Text == selectedUser.Name)
                    {
                        li.Selected = true;
                        break;
                    }
                }
            }

            usersListView.EndUpdate();
        }

        // Binds to a user's privileges and displays them in the UI
        async Task BindToPrivileges(InfluxDbUser user)
        {
            grantsListView.Items.Clear();
            grantsListView.BeginUpdate();

            // No need for grants if this is an admin, so disable the panel
            if (user.IsAdmin)
            {
                grantsListView.Enabled = false;
            }
            // Otherwise render granted privileges for the user
            else
            {
                grantsListView.Enabled = true;
                var privileges = await InfluxDbClient.GetPrivilegesAsync(user.Name);

                if (privileges.Count() > 0)
                {
                    foreach (var p in privileges)
                    {
                        //Console.WriteLine("{0} => read: {1}, write: {2}, all: {3}", p.Database, p.Read, p.Write, p.All);
                        grantsListView.Items.Add(new ListViewItem(new string[] {
                        p.Database,
                        user.IsAdmin || p.Privilege == InfluxDbPrivileges.Read ? RequestControl.CheckMark : null,
                        user.IsAdmin || p.Privilege == InfluxDbPrivileges.Write ? RequestControl.CheckMark : null,
                        user.IsAdmin || p.Privilege == InfluxDbPrivileges.All ? RequestControl.CheckMark : null,
                    })
                        { Tag = p }); // Assign the privilege as tag
                    }
                }
            }
            
            // Restore any selected privilege
            if (SelectedPrivilegeGrant != null)
            {
                var database = selectedPrivilegeGrant.Database;

                foreach (ListViewItem li in grantsListView.Items)
                {
                    if (li.Text == database)
                    {
                        li.Selected = true;
                        break;
                    }
                }
            }

            grantsListView.EndUpdate();
        }

        #endregion Request

        #region User Interface

        // Updates the state of the interface based on current selections and values
        void UpdateUIState()
        {
            // Users
            var user = SelectedUser;
            editUserButton.Enabled = user != null;
            changePasswordButton.Enabled = user != null;
            dropUserButton.Enabled = user != null;

            editUserToolStripMenuItem.Enabled = user != null;
            changePasswordToolStripMenuItem.Enabled = user != null;
            dropUserToolStripMenuItem.Enabled = user != null;

            // Grants/Privileges
            var grant = SelectedPrivilegeGrant;
            grantPrivilegeButton.Enabled = user != null;
            editPrivilegeButton.Enabled = grant != null;

            grantPrivilegeToolStripMenuItem.Enabled = user != null;
            editPrivilegeToolStripMenuItem.Enabled = grant != null;
        }

        #endregion User Interface

        #endregion Methods
    }
}
