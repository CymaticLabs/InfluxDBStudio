using System;
using System.Windows.Forms;

namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    /// <summary>
    /// Application about dialog.
    /// </summary>
    public partial class AboutDialog : Form
    {
        #region Fields

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Constructors

        public AboutDialog()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Event Handlers

        // Form Load
        private void AboutDialog_Load(object sender, EventArgs e)
        {
            // Apply the current version number
            versionLabel.Text = AppForm.Settings.Version;
        }

        // Launch project link
        private void projectLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/CymaticLabs/InfluxDBStudio");
        }

        // Launch InfluxData.Net link
        private void influxDataNetLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/pootzko/InfluxData.Net");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/sam80180/InfluxDBStudio");
        } // fin linkLabel1_LinkClicked()

        #endregion Event Handlers

        #region Methods

        #endregion Methods

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.iconfinder.com/iconsets/aspneticons");
        } // fin linkLabel2_LinkClicked()
    }
}
