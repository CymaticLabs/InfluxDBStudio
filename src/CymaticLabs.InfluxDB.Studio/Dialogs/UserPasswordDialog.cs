using System.Windows.Forms;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    /// <summary>
    /// Used to update an InfluxDB user's password.
    /// </summary>
    public partial class UserPasswordDialog : Form
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the dialog's password text.
        /// </summary>
        public string Password
        {
            get { return password.Text; }
        }

        #endregion Properties

        #region Constructors

        public UserPasswordDialog()
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
            password.Text = null;
        }

        #endregion Methods
    }
}
