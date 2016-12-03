namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    partial class ConnectionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionDialog));
            this.cancelButon = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.useSsl = new System.Windows.Forms.CheckBox();
            this.port = new System.Windows.Forms.NumericUpDown();
            this.databaseInstructions = new System.Windows.Forms.Label();
            this.addressInstructions = new System.Windows.Forms.Label();
            this.nameInstructions = new System.Windows.Forms.Label();
            this.host = new System.Windows.Forms.TextBox();
            this.database = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.securityLabel = new System.Windows.Forms.Label();
            this.databaseLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.pingButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.port)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButon
            // 
            this.cancelButon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButon.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButon.Location = new System.Drawing.Point(389, 319);
            this.cancelButon.Name = "cancelButon";
            this.cancelButon.Size = new System.Drawing.Size(75, 23);
            this.cancelButon.TabIndex = 9;
            this.cancelButon.Text = "Cancel";
            this.cancelButon.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(308, 319);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // testButton
            // 
            this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testButton.Location = new System.Drawing.Point(10, 319);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 7;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.useSsl);
            this.panel1.Controls.Add(this.port);
            this.panel1.Controls.Add(this.databaseInstructions);
            this.panel1.Controls.Add(this.addressInstructions);
            this.panel1.Controls.Add(this.nameInstructions);
            this.panel1.Controls.Add(this.host);
            this.panel1.Controls.Add(this.database);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.username);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.addressLabel);
            this.panel1.Controls.Add(this.securityLabel);
            this.panel1.Controls.Add(this.databaseLabel);
            this.panel1.Controls.Add(this.passwordLabel);
            this.panel1.Controls.Add(this.usernameLabel);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 293);
            this.panel1.TabIndex = 2;
            // 
            // useSsl
            // 
            this.useSsl.AutoSize = true;
            this.useSsl.Location = new System.Drawing.Point(76, 263);
            this.useSsl.Name = "useSsl";
            this.useSsl.Size = new System.Drawing.Size(68, 17);
            this.useSsl.TabIndex = 6;
            this.useSsl.Text = "Use SSL";
            this.useSsl.UseVisualStyleBackColor = true;
            // 
            // port
            // 
            this.port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.port.Location = new System.Drawing.Point(365, 61);
            this.port.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(84, 20);
            this.port.TabIndex = 2;
            this.port.Value = new decimal(new int[] {
            8086,
            0,
            0,
            0});
            // 
            // databaseInstructions
            // 
            this.databaseInstructions.AutoSize = true;
            this.databaseInstructions.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.databaseInstructions.Location = new System.Drawing.Point(73, 144);
            this.databaseInstructions.Name = "databaseInstructions";
            this.databaseInstructions.Size = new System.Drawing.Size(356, 26);
            this.databaseInstructions.TabIndex = 9;
            this.databaseInstructions.Text = "Optionally specify the name of a single database to connect to.\r\nThis can be usef" +
    "ul when you don\'t have admin privileges to list databases.";
            // 
            // addressInstructions
            // 
            this.addressInstructions.AutoSize = true;
            this.addressInstructions.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.addressInstructions.Location = new System.Drawing.Point(73, 85);
            this.addressInstructions.Name = "addressInstructions";
            this.addressInstructions.Size = new System.Drawing.Size(233, 13);
            this.addressInstructions.TabIndex = 9;
            this.addressInstructions.Text = "Specify the host and port of the InfluxDB server.";
            // 
            // nameInstructions
            // 
            this.nameInstructions.AutoSize = true;
            this.nameInstructions.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nameInstructions.Location = new System.Drawing.Point(73, 27);
            this.nameInstructions.Name = "nameInstructions";
            this.nameInstructions.Size = new System.Drawing.Size(344, 13);
            this.nameInstructions.TabIndex = 10;
            this.nameInstructions.Text = "Choose a connection name that will help you to identify this connection.";
            // 
            // host
            // 
            this.host.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.host.Location = new System.Drawing.Point(76, 62);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(265, 20);
            this.host.TabIndex = 1;
            this.host.Text = "localhost";
            // 
            // database
            // 
            this.database.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.database.Location = new System.Drawing.Point(76, 121);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(373, 20);
            this.database.TabIndex = 3;
            // 
            // password
            // 
            this.password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password.Location = new System.Drawing.Point(76, 227);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(373, 20);
            this.password.TabIndex = 5;
            this.password.UseSystemPasswordChar = true;
            // 
            // username
            // 
            this.username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.username.Location = new System.Drawing.Point(76, 187);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(373, 20);
            this.username.TabIndex = 4;
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name.Location = new System.Drawing.Point(76, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(373, 20);
            this.name.TabIndex = 0;
            this.name.Text = "New Connection";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(347, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = ":";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(3, 62);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(48, 13);
            this.addressLabel.TabIndex = 4;
            this.addressLabel.Text = "Address:";
            // 
            // securityLabel
            // 
            this.securityLabel.AutoSize = true;
            this.securityLabel.Location = new System.Drawing.Point(3, 264);
            this.securityLabel.Name = "securityLabel";
            this.securityLabel.Size = new System.Drawing.Size(48, 13);
            this.securityLabel.TabIndex = 5;
            this.securityLabel.Text = "Security:";
            // 
            // databaseLabel
            // 
            this.databaseLabel.AutoSize = true;
            this.databaseLabel.Location = new System.Drawing.Point(3, 124);
            this.databaseLabel.Name = "databaseLabel";
            this.databaseLabel.Size = new System.Drawing.Size(56, 13);
            this.databaseLabel.TabIndex = 5;
            this.databaseLabel.Text = "Database:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(3, 230);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(3, 190);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(63, 13);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "User Name:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(3, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Name:";
            // 
            // pingButton
            // 
            this.pingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pingButton.Location = new System.Drawing.Point(91, 319);
            this.pingButton.Name = "pingButton";
            this.pingButton.Size = new System.Drawing.Size(75, 23);
            this.pingButton.TabIndex = 7;
            this.pingButton.Text = "Ping";
            this.pingButton.UseVisualStyleBackColor = true;
            this.pingButton.Click += new System.EventHandler(this.pingButton_Click);
            // 
            // ConnectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 354);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pingButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.port)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancelButon;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label addressInstructions;
        private System.Windows.Forms.Label nameInstructions;
        private System.Windows.Forms.TextBox host;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.NumericUpDown port;
        private System.Windows.Forms.CheckBox useSsl;
        private System.Windows.Forms.Label securityLabel;
        private System.Windows.Forms.Label databaseInstructions;
        private System.Windows.Forms.TextBox database;
        private System.Windows.Forms.Label databaseLabel;
        private System.Windows.Forms.Button pingButton;
    }
}