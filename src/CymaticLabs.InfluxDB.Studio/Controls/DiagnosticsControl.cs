using System;
using System.Threading.Tasks;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Renders InfluxDB server diagnostics information.
    /// </summary>
    public partial class DiagnosticsControl : RequestControl
    {
        #region Fields

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Constructors

        public DiagnosticsControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Binds the control to server diagnostics information.
        /// </summary>
        public async override Task ExecuteRequestAsync()
        {
            if (InfluxDbClient == null) throw new Exception("No InfluxDB client available.");

            // Clear current values
            var blank = "-";

            // System
            pidValue.Text = blank;
            currentTimeValue.Text = blank;
            startedValue.Text = blank;
            uptimeValue.Text = blank;

            // Build
            branchValue.Text = blank;
            commitValue.Text = blank;
            buildVersionValue.Text = blank;

            // Runtime
            goArchValue.Text = blank;
            goMaxProcsValue.Text = blank;
            goOsValue.Text = blank;
            goVersionValue.Text = blank;

            // Network
            hostnameValue.Text = blank;

            // Query new values
            var diagnostics = await InfluxDbClient.GetDiagnosticsAsync();
            if (diagnostics == null) return;

            // System
            pidValue.Text = diagnostics.PID.ToString();
            currentTimeValue.Text = diagnostics.CurrentTime.ToString();
            startedValue.Text = diagnostics.Started.ToString();
            var ut = diagnostics.Uptime;
            uptimeValue.Text = string.Format("{0}d {1}h {2}m {3}s {4}ms", ut.Days, ut.Hours, ut.Minutes, ut.Seconds, ut.Milliseconds);

            // Build
            branchValue.Text = diagnostics.Branch;
            commitValue.Text = diagnostics.Commit;
            buildVersionValue.Text = diagnostics.BuildVersion;

            // Runtime
            goArchValue.Text = diagnostics.GoArch;
            goMaxProcsValue.Text = diagnostics.GoMaxProc.ToString();
            goOsValue.Text = diagnostics.GoOs;
            goVersionValue.Text = diagnostics.GoVersion;

            // Network
            hostnameValue.Text = diagnostics.Hostname;
        }

        #endregion Methods
    }
}
