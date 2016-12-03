namespace CymaticLabs.InfluxDB.Studio.Controls
{
    partial class DiagnosticsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.systemGroupBox = new System.Windows.Forms.GroupBox();
            this.uptimeValue = new System.Windows.Forms.Label();
            this.startedValue = new System.Windows.Forms.Label();
            this.currentTimeValue = new System.Windows.Forms.Label();
            this.pidValue = new System.Windows.Forms.Label();
            this.uptimeLabel = new System.Windows.Forms.Label();
            this.startedLabel = new System.Windows.Forms.Label();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.pidLabel = new System.Windows.Forms.Label();
            this.buildGroupBox = new System.Windows.Forms.GroupBox();
            this.buildVersionValue = new System.Windows.Forms.Label();
            this.commitValue = new System.Windows.Forms.Label();
            this.branchValue = new System.Windows.Forms.Label();
            this.buildVersionLabel = new System.Windows.Forms.Label();
            this.commitLabel = new System.Windows.Forms.Label();
            this.branchLabel = new System.Windows.Forms.Label();
            this.runetimeGroupBox = new System.Windows.Forms.GroupBox();
            this.goVersionValue = new System.Windows.Forms.Label();
            this.goOsValue = new System.Windows.Forms.Label();
            this.goMaxProcsValue = new System.Windows.Forms.Label();
            this.goArchValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.goOsLabel = new System.Windows.Forms.Label();
            this.goMaxProcsLabel = new System.Windows.Forms.Label();
            this.goArchLabel = new System.Windows.Forms.Label();
            this.networkGroupBox = new System.Windows.Forms.GroupBox();
            this.hostnameValue = new System.Windows.Forms.Label();
            this.hostnameLabel = new System.Windows.Forms.Label();
            this.systemGroupBox.SuspendLayout();
            this.buildGroupBox.SuspendLayout();
            this.runetimeGroupBox.SuspendLayout();
            this.networkGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // systemGroupBox
            // 
            this.systemGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.systemGroupBox.Controls.Add(this.uptimeValue);
            this.systemGroupBox.Controls.Add(this.startedValue);
            this.systemGroupBox.Controls.Add(this.currentTimeValue);
            this.systemGroupBox.Controls.Add(this.pidValue);
            this.systemGroupBox.Controls.Add(this.uptimeLabel);
            this.systemGroupBox.Controls.Add(this.startedLabel);
            this.systemGroupBox.Controls.Add(this.currentTimeLabel);
            this.systemGroupBox.Controls.Add(this.pidLabel);
            this.systemGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemGroupBox.Location = new System.Drawing.Point(3, 11);
            this.systemGroupBox.Name = "systemGroupBox";
            this.systemGroupBox.Size = new System.Drawing.Size(665, 125);
            this.systemGroupBox.TabIndex = 0;
            this.systemGroupBox.TabStop = false;
            this.systemGroupBox.Text = "System";
            // 
            // uptimeValue
            // 
            this.uptimeValue.AutoSize = true;
            this.uptimeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uptimeValue.Location = new System.Drawing.Point(103, 97);
            this.uptimeValue.Name = "uptimeValue";
            this.uptimeValue.Size = new System.Drawing.Size(10, 13);
            this.uptimeValue.TabIndex = 0;
            this.uptimeValue.Text = "-";
            // 
            // startedValue
            // 
            this.startedValue.AutoSize = true;
            this.startedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startedValue.Location = new System.Drawing.Point(103, 74);
            this.startedValue.Name = "startedValue";
            this.startedValue.Size = new System.Drawing.Size(10, 13);
            this.startedValue.TabIndex = 0;
            this.startedValue.Text = "-";
            // 
            // currentTimeValue
            // 
            this.currentTimeValue.AutoSize = true;
            this.currentTimeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTimeValue.Location = new System.Drawing.Point(103, 52);
            this.currentTimeValue.Name = "currentTimeValue";
            this.currentTimeValue.Size = new System.Drawing.Size(10, 13);
            this.currentTimeValue.TabIndex = 0;
            this.currentTimeValue.Text = "-";
            // 
            // pidValue
            // 
            this.pidValue.AutoSize = true;
            this.pidValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pidValue.Location = new System.Drawing.Point(103, 30);
            this.pidValue.Name = "pidValue";
            this.pidValue.Size = new System.Drawing.Size(10, 13);
            this.pidValue.TabIndex = 0;
            this.pidValue.Text = "-";
            // 
            // uptimeLabel
            // 
            this.uptimeLabel.AutoSize = true;
            this.uptimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uptimeLabel.Location = new System.Drawing.Point(14, 97);
            this.uptimeLabel.Name = "uptimeLabel";
            this.uptimeLabel.Size = new System.Drawing.Size(50, 13);
            this.uptimeLabel.TabIndex = 0;
            this.uptimeLabel.Text = "Uptime:";
            // 
            // startedLabel
            // 
            this.startedLabel.AutoSize = true;
            this.startedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startedLabel.Location = new System.Drawing.Point(14, 74);
            this.startedLabel.Name = "startedLabel";
            this.startedLabel.Size = new System.Drawing.Size(52, 13);
            this.startedLabel.TabIndex = 0;
            this.startedLabel.Text = "Started:";
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTimeLabel.Location = new System.Drawing.Point(14, 52);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(83, 13);
            this.currentTimeLabel.TabIndex = 0;
            this.currentTimeLabel.Text = "Current Time:";
            // 
            // pidLabel
            // 
            this.pidLabel.AutoSize = true;
            this.pidLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pidLabel.Location = new System.Drawing.Point(14, 30);
            this.pidLabel.Name = "pidLabel";
            this.pidLabel.Size = new System.Drawing.Size(32, 13);
            this.pidLabel.TabIndex = 0;
            this.pidLabel.Text = "PID:";
            // 
            // buildGroupBox
            // 
            this.buildGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buildGroupBox.Controls.Add(this.buildVersionValue);
            this.buildGroupBox.Controls.Add(this.commitValue);
            this.buildGroupBox.Controls.Add(this.branchValue);
            this.buildGroupBox.Controls.Add(this.buildVersionLabel);
            this.buildGroupBox.Controls.Add(this.commitLabel);
            this.buildGroupBox.Controls.Add(this.branchLabel);
            this.buildGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildGroupBox.Location = new System.Drawing.Point(3, 142);
            this.buildGroupBox.Name = "buildGroupBox";
            this.buildGroupBox.Size = new System.Drawing.Size(665, 104);
            this.buildGroupBox.TabIndex = 0;
            this.buildGroupBox.TabStop = false;
            this.buildGroupBox.Text = "Build";
            // 
            // buildVersionValue
            // 
            this.buildVersionValue.AutoSize = true;
            this.buildVersionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildVersionValue.Location = new System.Drawing.Point(103, 74);
            this.buildVersionValue.Name = "buildVersionValue";
            this.buildVersionValue.Size = new System.Drawing.Size(10, 13);
            this.buildVersionValue.TabIndex = 0;
            this.buildVersionValue.Text = "-";
            // 
            // commitValue
            // 
            this.commitValue.AutoSize = true;
            this.commitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commitValue.Location = new System.Drawing.Point(103, 52);
            this.commitValue.Name = "commitValue";
            this.commitValue.Size = new System.Drawing.Size(10, 13);
            this.commitValue.TabIndex = 0;
            this.commitValue.Text = "-";
            // 
            // branchValue
            // 
            this.branchValue.AutoSize = true;
            this.branchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchValue.Location = new System.Drawing.Point(103, 30);
            this.branchValue.Name = "branchValue";
            this.branchValue.Size = new System.Drawing.Size(10, 13);
            this.branchValue.TabIndex = 0;
            this.branchValue.Text = "-";
            // 
            // buildVersionLabel
            // 
            this.buildVersionLabel.AutoSize = true;
            this.buildVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildVersionLabel.Location = new System.Drawing.Point(14, 74);
            this.buildVersionLabel.Name = "buildVersionLabel";
            this.buildVersionLabel.Size = new System.Drawing.Size(53, 13);
            this.buildVersionLabel.TabIndex = 0;
            this.buildVersionLabel.Text = "Version:";
            // 
            // commitLabel
            // 
            this.commitLabel.AutoSize = true;
            this.commitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commitLabel.Location = new System.Drawing.Point(14, 52);
            this.commitLabel.Name = "commitLabel";
            this.commitLabel.Size = new System.Drawing.Size(51, 13);
            this.commitLabel.TabIndex = 0;
            this.commitLabel.Text = "Commit:";
            // 
            // branchLabel
            // 
            this.branchLabel.AutoSize = true;
            this.branchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchLabel.Location = new System.Drawing.Point(14, 30);
            this.branchLabel.Name = "branchLabel";
            this.branchLabel.Size = new System.Drawing.Size(51, 13);
            this.branchLabel.TabIndex = 0;
            this.branchLabel.Text = "Branch:";
            // 
            // runetimeGroupBox
            // 
            this.runetimeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runetimeGroupBox.Controls.Add(this.goVersionValue);
            this.runetimeGroupBox.Controls.Add(this.goOsValue);
            this.runetimeGroupBox.Controls.Add(this.goMaxProcsValue);
            this.runetimeGroupBox.Controls.Add(this.goArchValue);
            this.runetimeGroupBox.Controls.Add(this.label5);
            this.runetimeGroupBox.Controls.Add(this.goOsLabel);
            this.runetimeGroupBox.Controls.Add(this.goMaxProcsLabel);
            this.runetimeGroupBox.Controls.Add(this.goArchLabel);
            this.runetimeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runetimeGroupBox.Location = new System.Drawing.Point(3, 252);
            this.runetimeGroupBox.Name = "runetimeGroupBox";
            this.runetimeGroupBox.Size = new System.Drawing.Size(665, 125);
            this.runetimeGroupBox.TabIndex = 0;
            this.runetimeGroupBox.TabStop = false;
            this.runetimeGroupBox.Text = "Go Runtime";
            // 
            // goVersionValue
            // 
            this.goVersionValue.AutoSize = true;
            this.goVersionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goVersionValue.Location = new System.Drawing.Point(103, 97);
            this.goVersionValue.Name = "goVersionValue";
            this.goVersionValue.Size = new System.Drawing.Size(10, 13);
            this.goVersionValue.TabIndex = 0;
            this.goVersionValue.Text = "-";
            // 
            // goOsValue
            // 
            this.goOsValue.AutoSize = true;
            this.goOsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goOsValue.Location = new System.Drawing.Point(103, 74);
            this.goOsValue.Name = "goOsValue";
            this.goOsValue.Size = new System.Drawing.Size(10, 13);
            this.goOsValue.TabIndex = 0;
            this.goOsValue.Text = "-";
            // 
            // goMaxProcsValue
            // 
            this.goMaxProcsValue.AutoSize = true;
            this.goMaxProcsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goMaxProcsValue.Location = new System.Drawing.Point(103, 52);
            this.goMaxProcsValue.Name = "goMaxProcsValue";
            this.goMaxProcsValue.Size = new System.Drawing.Size(10, 13);
            this.goMaxProcsValue.TabIndex = 0;
            this.goMaxProcsValue.Text = "-";
            // 
            // goArchValue
            // 
            this.goArchValue.AutoSize = true;
            this.goArchValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goArchValue.Location = new System.Drawing.Point(103, 30);
            this.goArchValue.Name = "goArchValue";
            this.goArchValue.Size = new System.Drawing.Size(10, 13);
            this.goArchValue.TabIndex = 0;
            this.goArchValue.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Version:";
            // 
            // goOsLabel
            // 
            this.goOsLabel.AutoSize = true;
            this.goOsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goOsLabel.Location = new System.Drawing.Point(14, 74);
            this.goOsLabel.Name = "goOsLabel";
            this.goOsLabel.Size = new System.Drawing.Size(28, 13);
            this.goOsLabel.TabIndex = 0;
            this.goOsLabel.Text = "OS:";
            // 
            // goMaxProcsLabel
            // 
            this.goMaxProcsLabel.AutoSize = true;
            this.goMaxProcsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goMaxProcsLabel.Location = new System.Drawing.Point(14, 52);
            this.goMaxProcsLabel.Name = "goMaxProcsLabel";
            this.goMaxProcsLabel.Size = new System.Drawing.Size(70, 13);
            this.goMaxProcsLabel.TabIndex = 0;
            this.goMaxProcsLabel.Text = "Max Procs:";
            // 
            // goArchLabel
            // 
            this.goArchLabel.AutoSize = true;
            this.goArchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goArchLabel.Location = new System.Drawing.Point(14, 30);
            this.goArchLabel.Name = "goArchLabel";
            this.goArchLabel.Size = new System.Drawing.Size(80, 13);
            this.goArchLabel.TabIndex = 0;
            this.goArchLabel.Text = "Architecture:";
            // 
            // networkGroupBox
            // 
            this.networkGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.networkGroupBox.Controls.Add(this.hostnameValue);
            this.networkGroupBox.Controls.Add(this.hostnameLabel);
            this.networkGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.networkGroupBox.Location = new System.Drawing.Point(3, 383);
            this.networkGroupBox.Name = "networkGroupBox";
            this.networkGroupBox.Size = new System.Drawing.Size(665, 62);
            this.networkGroupBox.TabIndex = 0;
            this.networkGroupBox.TabStop = false;
            this.networkGroupBox.Text = "Network";
            // 
            // hostnameValue
            // 
            this.hostnameValue.AutoSize = true;
            this.hostnameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostnameValue.Location = new System.Drawing.Point(103, 30);
            this.hostnameValue.Name = "hostnameValue";
            this.hostnameValue.Size = new System.Drawing.Size(10, 13);
            this.hostnameValue.TabIndex = 0;
            this.hostnameValue.Text = "-";
            // 
            // hostnameLabel
            // 
            this.hostnameLabel.AutoSize = true;
            this.hostnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostnameLabel.Location = new System.Drawing.Point(14, 30);
            this.hostnameLabel.Name = "hostnameLabel";
            this.hostnameLabel.Size = new System.Drawing.Size(67, 13);
            this.hostnameLabel.TabIndex = 0;
            this.hostnameLabel.Text = "Hostname:";
            // 
            // DiagnosticsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.networkGroupBox);
            this.Controls.Add(this.buildGroupBox);
            this.Controls.Add(this.runetimeGroupBox);
            this.Controls.Add(this.systemGroupBox);
            this.Name = "DiagnosticsControl";
            this.Size = new System.Drawing.Size(671, 463);
            this.systemGroupBox.ResumeLayout(false);
            this.systemGroupBox.PerformLayout();
            this.buildGroupBox.ResumeLayout(false);
            this.buildGroupBox.PerformLayout();
            this.runetimeGroupBox.ResumeLayout(false);
            this.runetimeGroupBox.PerformLayout();
            this.networkGroupBox.ResumeLayout(false);
            this.networkGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox systemGroupBox;
        private System.Windows.Forms.Label pidLabel;
        private System.Windows.Forms.Label pidValue;
        private System.Windows.Forms.Label currentTimeValue;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label startedValue;
        private System.Windows.Forms.Label startedLabel;
        private System.Windows.Forms.Label uptimeValue;
        private System.Windows.Forms.Label uptimeLabel;
        private System.Windows.Forms.GroupBox buildGroupBox;
        private System.Windows.Forms.Label buildVersionValue;
        private System.Windows.Forms.Label commitValue;
        private System.Windows.Forms.Label branchValue;
        private System.Windows.Forms.Label buildVersionLabel;
        private System.Windows.Forms.Label commitLabel;
        private System.Windows.Forms.Label branchLabel;
        private System.Windows.Forms.GroupBox runetimeGroupBox;
        private System.Windows.Forms.Label goVersionValue;
        private System.Windows.Forms.Label goOsValue;
        private System.Windows.Forms.Label goMaxProcsValue;
        private System.Windows.Forms.Label goArchValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label goOsLabel;
        private System.Windows.Forms.Label goMaxProcsLabel;
        private System.Windows.Forms.Label goArchLabel;
        private System.Windows.Forms.GroupBox networkGroupBox;
        private System.Windows.Forms.Label hostnameValue;
        private System.Windows.Forms.Label hostnameLabel;
    }
}
