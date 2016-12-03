using System.Windows.Forms;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    /// <summary>
    /// Dialog used for editing/updating InfluxDB users.
    /// </summary>
    public partial class EditUserDialog : Form
    {
        #region Fields

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Constructors

        public EditUserDialog()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Binds the dialog to a user.
        /// </summary>
        /// <param name="user">The user to bind to.</param>
        public void BindToUser(InfluxDbUser user)
        {
            usernameValue.Text = user.Name;
            adminCheckBox.Checked = user.IsAdmin;
        }

        /// <summary>
        /// Creates and returns a new InfluxDB user from the dialog values.
        /// </summary>
        public InfluxDbUser CreateUserFromDialog()
        {
            return new InfluxDbUser(usernameValue.Text, adminCheckBox.Checked);
        }

        #endregion Methods
    }
}
