namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    partial class GrantPrivilegeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrantPrivilegeDialog));
            this.usernameValue = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.databasesLabel = new System.Windows.Forms.Label();
            this.databaseComboBox = new System.Windows.Forms.ComboBox();
            this.privilegeLabel = new System.Windows.Forms.Label();
            this.privilegeComboBox = new System.Windows.Forms.ComboBox();
            this.grantButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameValue
            // 
            this.usernameValue.AutoSize = true;
            this.usernameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameValue.Location = new System.Drawing.Point(76, 17);
            this.usernameValue.Name = "usernameValue";
            this.usernameValue.Size = new System.Drawing.Size(11, 13);
            this.usernameValue.TabIndex = 7;
            this.usernameValue.Text = "-";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 17);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(32, 13);
            this.usernameLabel.TabIndex = 8;
            this.usernameLabel.Text = "User:";
            // 
            // databasesLabel
            // 
            this.databasesLabel.AutoSize = true;
            this.databasesLabel.Location = new System.Drawing.Point(12, 48);
            this.databasesLabel.Name = "databasesLabel";
            this.databasesLabel.Size = new System.Drawing.Size(56, 13);
            this.databasesLabel.TabIndex = 9;
            this.databasesLabel.Text = "Database:";
            // 
            // databaseComboBox
            // 
            this.databaseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseComboBox.FormattingEnabled = true;
            this.databaseComboBox.Location = new System.Drawing.Point(79, 45);
            this.databaseComboBox.Name = "databaseComboBox";
            this.databaseComboBox.Size = new System.Drawing.Size(266, 21);
            this.databaseComboBox.TabIndex = 10;
            // 
            // privilegeLabel
            // 
            this.privilegeLabel.AutoSize = true;
            this.privilegeLabel.Location = new System.Drawing.Point(12, 83);
            this.privilegeLabel.Name = "privilegeLabel";
            this.privilegeLabel.Size = new System.Drawing.Size(50, 13);
            this.privilegeLabel.TabIndex = 9;
            this.privilegeLabel.Text = "Privilege:";
            // 
            // privilegeComboBox
            // 
            this.privilegeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.privilegeComboBox.FormattingEnabled = true;
            this.privilegeComboBox.Location = new System.Drawing.Point(79, 80);
            this.privilegeComboBox.Name = "privilegeComboBox";
            this.privilegeComboBox.Size = new System.Drawing.Size(266, 21);
            this.privilegeComboBox.TabIndex = 10;
            // 
            // grantButton
            // 
            this.grantButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.grantButton.Location = new System.Drawing.Point(189, 121);
            this.grantButton.Name = "grantButton";
            this.grantButton.Size = new System.Drawing.Size(75, 23);
            this.grantButton.TabIndex = 11;
            this.grantButton.Text = "Grant";
            this.grantButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(270, 121);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // GrantPrivilegeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 156);
            this.ControlBox = false;
            this.Controls.Add(this.grantButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.privilegeComboBox);
            this.Controls.Add(this.databaseComboBox);
            this.Controls.Add(this.privilegeLabel);
            this.Controls.Add(this.databasesLabel);
            this.Controls.Add(this.usernameValue);
            this.Controls.Add(this.usernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GrantPrivilegeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Grant Privilege";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameValue;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label databasesLabel;
        private System.Windows.Forms.ComboBox databaseComboBox;
        private System.Windows.Forms.Label privilegeLabel;
        private System.Windows.Forms.ComboBox privilegeComboBox;
        private System.Windows.Forms.Button grantButton;
        private System.Windows.Forms.Button cancelButton;
    }
}