using System.Windows.Forms;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    /// <summary>
    /// Dialog used for creating new InfluxDB users.
    /// </summary>
    public partial class CreateUserDialog : Form
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the user name from the dialog window.
        /// </summary>
        public string Username
        {
            get { return username.Text; }
        }

        /// <summary>
        /// Gets the password from the dialog window.
        /// </summary>
        public string Password
        {
            get { return password.Text; }
        }

        #endregion Properties

        #region Constructors

        public CreateUserDialog()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Clears the username and password fields of the dialog.
        /// </summary>
        public void ClearCreateValues()
        {
            username.Text = null;
            password.Text = null;
            adminCheckBox.Checked = false;
        }

        /// <summary>
        /// Creates and returns a new InfluxDB user from the dialog values.
        /// </summary>
        public InfluxDbUser CreateUserFromDialog()
        {
            // Validate user name
            if (string.IsNullOrWhiteSpace(Username))
            {
                AppForm.DisplayError("User name cannot be blank.", "Bad User Name");
                return null;
            }

            // Validate password
            if (string.IsNullOrWhiteSpace(Password))
            {
                AppForm.DisplayError("Password cannot be blank.", "Bad Password");
                return null;
            }

            return new InfluxDbUser(username.Text, adminCheckBox.Checked);
        }

        #endregion Methods
    }
}
