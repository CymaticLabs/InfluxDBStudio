using System.Windows.Forms;

namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    /// <summary>
    /// Dialog window used to create a new database.
    /// </summary>
    public partial class CreateDatabaseDialog : Form
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the connection name displayed in the dialog.
        /// </summary>
        public string ConnectionName
        {
            get { return connectionLabel.Text; }
            set { connectionLabel.Text = value; }
        }

        /// <summary>
        /// Gets or sets the database name in the dialog's textbox.
        /// </summary>
        public string DatabaseName
        {
            get { return textBox.Text; }
            set { textBox.Text = value; textBox.Focus(); }
        }

        #endregion Properties

        #region Constructors

        public CreateDatabaseDialog()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
