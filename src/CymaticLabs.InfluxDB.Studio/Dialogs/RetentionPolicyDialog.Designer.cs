namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    partial class RetentionPolicyDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetentionPolicyDialog));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.replicationLabel = new System.Windows.Forms.Label();
            this.replicationNumeric = new System.Windows.Forms.NumericUpDown();
            this.defaultLabel = new System.Windows.Forms.Label();
            this.defaultCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.durationInfo = new System.Windows.Forms.PictureBox();
            this.durationToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.replicationNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(87, 13);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(180, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(12, 16);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(69, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Policy Name:";
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationLabel.Location = new System.Drawing.Point(12, 46);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(50, 13);
            this.durationLabel.TabIndex = 2;
            this.durationLabel.Text = "Duration:";
            // 
            // durationTextBox
            // 
            this.durationTextBox.Location = new System.Drawing.Point(87, 43);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(99, 20);
            this.durationTextBox.TabIndex = 1;
            // 
            // replicationLabel
            // 
            this.replicationLabel.AutoSize = true;
            this.replicationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replicationLabel.Location = new System.Drawing.Point(12, 76);
            this.replicationLabel.Name = "replicationLabel";
            this.replicationLabel.Size = new System.Drawing.Size(63, 13);
            this.replicationLabel.TabIndex = 2;
            this.replicationLabel.Text = "Replication:";
            // 
            // replicationNumeric
            // 
            this.replicationNumeric.Location = new System.Drawing.Point(87, 74);
            this.replicationNumeric.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.replicationNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.replicationNumeric.Name = "replicationNumeric";
            this.replicationNumeric.Size = new System.Drawing.Size(59, 20);
            this.replicationNumeric.TabIndex = 2;
            this.replicationNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // defaultLabel
            // 
            this.defaultLabel.AutoSize = true;
            this.defaultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultLabel.Location = new System.Drawing.Point(12, 106);
            this.defaultLabel.Name = "defaultLabel";
            this.defaultLabel.Size = new System.Drawing.Size(44, 13);
            this.defaultLabel.TabIndex = 2;
            this.defaultLabel.Text = "Default:";
            // 
            // defaultCheckBox
            // 
            this.defaultCheckBox.AutoSize = true;
            this.defaultCheckBox.Location = new System.Drawing.Point(87, 105);
            this.defaultCheckBox.Name = "defaultCheckBox";
            this.defaultCheckBox.Size = new System.Drawing.Size(15, 14);
            this.defaultCheckBox.TabIndex = 3;
            this.defaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(215, 134);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createButton.Location = new System.Drawing.Point(134, 134);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 4;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // durationInfo
            // 
            this.durationInfo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Info;
            this.durationInfo.Location = new System.Drawing.Point(192, 45);
            this.durationInfo.Name = "durationInfo";
            this.durationInfo.Size = new System.Drawing.Size(16, 16);
            this.durationInfo.TabIndex = 12;
            this.durationInfo.TabStop = false;
            // 
            // durationToolTip
            // 
            this.durationToolTip.AutoPopDelay = 32767;
            this.durationToolTip.InitialDelay = 500;
            this.durationToolTip.ReshowDelay = 100;
            this.durationToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.durationToolTip.ToolTipTitle = "Duration";
            // 
            // RetentionPolicyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 169);
            this.Controls.Add(this.durationInfo);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.defaultCheckBox);
            this.Controls.Add(this.replicationNumeric);
            this.Controls.Add(this.durationTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.defaultLabel);
            this.Controls.Add(this.replicationLabel);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RetentionPolicyDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Retention Policy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RetentionPolicyDialog_FormClosing);
            this.Load += new System.EventHandler(this.CreateRetentionPolicyDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.replicationNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.TextBox durationTextBox;
        private System.Windows.Forms.Label replicationLabel;
        private System.Windows.Forms.NumericUpDown replicationNumeric;
        private System.Windows.Forms.Label defaultLabel;
        private System.Windows.Forms.CheckBox defaultCheckBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.PictureBox durationInfo;
        private System.Windows.Forms.ToolTip durationToolTip;
    }
}