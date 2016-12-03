using System;
using System.Windows.Forms;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    /// <summary>
    /// Dialog used to edit InfluxDB users database privileges.
    /// </summary>
    public partial class EditPrivilegeDialog : Form
    {
        #region Fields

        InfluxDbGrant grant;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the username of the InfluxDB user who will have the privilege edited.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the database of the InfluxDB the privilege is for.
        /// </summary>
        public string Database { get; private set; }

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

        public EditPrivilegeDialog()
        {
            InitializeComponent();

            // Setup the privilege drop down with values dynamically
            foreach (InfluxDbPrivileges p in Enum.GetValues(typeof(InfluxDbPrivileges)))
            {
                privilegeComboBox.Items.Add(p);
            }

            privilegeComboBox.SelectedIndex = 0;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Binds the dialog to a user.
        /// </summary>
        /// <param name="grant">The privilege grant to bind to.</param>
        public void BindToGrant(string username, InfluxDbGrant grant)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username");
            if (grant == null) throw new ArgumentNullException("grant");

            // Bind user details
            Username = usernameValue.Text = username;
            Database = databaseValue.Text = grant.Database;

            for (var i = 0; i < privilegeComboBox.Items.Count; i++)
            {
                var p = (InfluxDbPrivileges)privilegeComboBox.Items[i];

                if (p == grant.Privilege)
                {
                    privilegeComboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        #endregion Methods

    }
}
