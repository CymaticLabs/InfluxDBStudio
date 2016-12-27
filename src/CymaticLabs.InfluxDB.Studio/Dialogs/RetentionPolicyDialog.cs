using System;
using System.Windows.Forms;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    /// <summary>
    /// Dialog used for creating Retention Policies.
    /// </summary>
    public partial class RetentionPolicyDialog : Form
    {
        #region Fields

        // Whether or not the policy is being created or altered/updated.
        bool isCreating = true;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the policy name value from the dialog.
        /// </summary>
        public string PolicyName
        {
            get { return nameTextBox.Text; }
        }

        /// <summary>
        /// Gets the policy duration value from the dialog.
        /// </summary>
        public string PolicyDuration
        {
            get { return durationTextBox.Text; }
        }

        /// <summary>
        /// Gets the policy replication value from the dialog.
        /// </summary>
        public int PolicyReplication
        {
            get { return (int)replicationNumeric.Value; }
        }

        /// <summary>
        /// Gets the policy "default" flag value from the dialog.
        /// </summary>
        public bool PolicyDefault
        {
            get { return defaultCheckBox.Checked; }
        }

        /// <summary>
        /// Gets whether or not the policy is being created or altered/updated.
        /// </summary>
        public bool IsCreating
        {
            get { return isCreating; }

            set
            {
                isCreating = value;
                nameTextBox.ReadOnly = !isCreating;
                createButton.Text = isCreating ? "Create" : "Update";
            }
        }

        #endregion Properties

        #region Constructors

        public RetentionPolicyDialog()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Event Handlers

        // Handle form load
        private void CreateRetentionPolicyDialog_Load(object sender, EventArgs e)
        {
            // Setup help/info tool tips
            durationToolTip.SetToolTip(durationInfo, Properties.Resources.RP_Duration_Info);
        }

        // Handle form closing
        private void RetentionPolicyDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // If the user is closing/canceling the form, nothing to do
                if (DialogResult != DialogResult.OK) return;

                // Validate values
                if (!ValidatePolicyValues())
                {
                    e.Cancel = true;
                    return;
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
        /// Clears out/resets the form's current values.
        /// </summary>
        public void ResetPolicyValues()
        {
            IsCreating = true;
            nameTextBox.Text = null;
            durationTextBox.Text = null;
            replicationNumeric.Value = 1;
            defaultCheckBox.Checked = false;
        }

        /// <summary>
        /// Binds the dialog to the supplied retention policy.
        /// </summary>
        /// <param name="policy">The retention policy to bind to.</param>
        public void BindToPolicy(InfluxDbRetentionPolicy policy)
        {
            nameTextBox.ReadOnly = false;
            nameTextBox.Text = policy.Name;
            durationTextBox.Text = policy.Duration;
            replicationNumeric.Value = policy.ReplicationCopies;
            defaultCheckBox.Checked = policy.Default;
            IsCreating = false;
        }

        // Validates the form values
        bool ValidatePolicyValues()
        {
            // Name
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                AppForm.DisplayError("Retention Policy name cannot be blank.");
                return false;
            }

            // Duration
            var duration = durationTextBox.Text;

            if (string.IsNullOrWhiteSpace(duration))
            {
                AppForm.DisplayError("Duration cannot be blank. It should be an InfluxDB time interval value such as: 1d, 2h, 10m, 30s, etc.");
                return false;
            }

            duration = duration.Trim();

            if (!InfluxDbHelper.IsTimeIntervalValid(duration))
            {
                AppForm.DisplayError("Duration value is invalid. It should be an InfluxDB time interval value such as: 1d, 2h, 10m, 30s, etc.");
                return false;
            }

            return true;
        }

        #endregion Methods
    }
}
