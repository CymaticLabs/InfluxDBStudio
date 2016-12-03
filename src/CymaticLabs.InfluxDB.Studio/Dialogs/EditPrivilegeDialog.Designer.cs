namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    partial class EditPrivilegeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPrivilegeDialog));
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.privilegeComboBox = new System.Windows.Forms.ComboBox();
            this.privilegeLabel = new System.Windows.Forms.Label();
            this.databasesLabel = new System.Windows.Forms.Label();
            this.usernameValue = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.databaseValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(189, 119);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(270, 119);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // privilegeComboBox
            // 
            this.privilegeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.privilegeComboBox.FormattingEnabled = true;
            this.privilegeComboBox.Location = new System.Drawing.Point(79, 78);
            this.privilegeComboBox.Name = "privilegeComboBox";
            this.privilegeComboBox.Size = new System.Drawing.Size(266, 21);
            this.privilegeComboBox.TabIndex = 17;
            // 
            // privilegeLabel
            // 
            this.privilegeLabel.AutoSize = true;
            this.privilegeLabel.Location = new System.Drawing.Point(12, 81);
            this.privilegeLabel.Name = "privilegeLabel";
            this.privilegeLabel.Size = new System.Drawing.Size(50, 13);
            this.privilegeLabel.TabIndex = 15;
            this.privilegeLabel.Text = "Privilege:";
            // 
            // databasesLabel
            // 
            this.databasesLabel.AutoSize = true;
            this.databasesLabel.Location = new System.Drawing.Point(12, 46);
            this.databasesLabel.Name = "databasesLabel";
            this.databasesLabel.Size = new System.Drawing.Size(56, 13);
            this.databasesLabel.TabIndex = 16;
            this.databasesLabel.Text = "Database:";
            // 
            // usernameValue
            // 
            this.usernameValue.AutoSize = true;
            this.usernameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameValue.Location = new System.Drawing.Point(76, 15);
            this.usernameValue.Name = "usernameValue";
            this.usernameValue.Size = new System.Drawing.Size(11, 13);
            this.usernameValue.TabIndex = 13;
            this.usernameValue.Text = "-";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 15);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(32, 13);
            this.usernameLabel.TabIndex = 14;
            this.usernameLabel.Text = "User:";
            // 
            // databaseValue
            // 
            this.databaseValue.AutoSize = true;
            this.databaseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseValue.Location = new System.Drawing.Point(76, 46);
            this.databaseValue.Name = "databaseValue";
            this.databaseValue.Size = new System.Drawing.Size(11, 13);
            this.databaseValue.TabIndex = 13;
            this.databaseValue.Text = "-";
            // 
            // EditPrivilegeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 156);
            this.ControlBox = false;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.privilegeComboBox);
            this.Controls.Add(this.privilegeLabel);
            this.Controls.Add(this.databasesLabel);
            this.Controls.Add(this.databaseValue);
            this.Controls.Add(this.usernameValue);
            this.Controls.Add(this.usernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditPrivilegeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Privilege";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox privilegeComboBox;
        private System.Windows.Forms.Label privilegeLabel;
        private System.Windows.Forms.Label databasesLabel;
        private System.Windows.Forms.Label usernameValue;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label databaseValue;
    }
}