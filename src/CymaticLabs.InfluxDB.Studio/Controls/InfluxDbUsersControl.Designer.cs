namespace CymaticLabs.InfluxDB.Studio.Controls
{
    partial class InfluxDbUsersControl
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.userToolStrip = new System.Windows.Forms.ToolStrip();
            this.createUserButton = new System.Windows.Forms.ToolStripButton();
            this.editUserButton = new System.Windows.Forms.ToolStripButton();
            this.changePasswordButton = new System.Windows.Forms.ToolStripButton();
            this.dropUserButton = new System.Windows.Forms.ToolStripButton();
            this.usersListView = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAdmin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grantsListView = new System.Windows.Forms.ListView();
            this.columnHeaderDatabase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWrite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAll = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grantsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grantPrivilegeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPrivilegeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grantsToolStrip = new System.Windows.Forms.ToolStrip();
            this.grantPrivilegeButton = new System.Windows.Forms.ToolStripButton();
            this.editPrivilegeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.userToolStrip.SuspendLayout();
            this.userContextMenuStrip.SuspendLayout();
            this.grantsContextMenuStrip.SuspendLayout();
            this.grantsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.userToolStrip);
            this.splitContainer.Panel1.Controls.Add(this.usersListView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.grantsListView);
            this.splitContainer.Panel2.Controls.Add(this.grantsToolStrip);
            this.splitContainer.Size = new System.Drawing.Size(797, 568);
            this.splitContainer.SplitterDistance = 285;
            this.splitContainer.TabIndex = 0;
            // 
            // userToolStrip
            // 
            this.userToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createUserButton,
            this.toolStripSeparator1,
            this.editUserButton,
            this.toolStripSeparator2,
            this.changePasswordButton,
            this.toolStripSeparator3,
            this.dropUserButton});
            this.userToolStrip.Location = new System.Drawing.Point(0, 0);
            this.userToolStrip.Name = "userToolStrip";
            this.userToolStrip.Size = new System.Drawing.Size(797, 25);
            this.userToolStrip.TabIndex = 1;
            this.userToolStrip.Text = "toolStrip1";
            // 
            // createUserButton
            // 
            this.createUserButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.CreateUser;
            this.createUserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(87, 22);
            this.createUserButton.Text = "Create User";
            this.createUserButton.Click += new System.EventHandler(this.createUserButton_Click);
            // 
            // editUserButton
            // 
            this.editUserButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.EditUser;
            this.editUserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editUserButton.Name = "editUserButton";
            this.editUserButton.Size = new System.Drawing.Size(73, 22);
            this.editUserButton.Text = "Edit User";
            this.editUserButton.Click += new System.EventHandler(this.editUserButton_Click);
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Password;
            this.changePasswordButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(121, 22);
            this.changePasswordButton.Text = "Change Password";
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // dropUserButton
            // 
            this.dropUserButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.DropUser;
            this.dropUserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropUserButton.Name = "dropUserButton";
            this.dropUserButton.Size = new System.Drawing.Size(79, 22);
            this.dropUserButton.Text = "Drop User";
            this.dropUserButton.Click += new System.EventHandler(this.dropUserButton_Click);
            // 
            // usersListView
            // 
            this.usersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderAdmin});
            this.usersListView.ContextMenuStrip = this.userContextMenuStrip;
            this.usersListView.FullRowSelect = true;
            this.usersListView.GridLines = true;
            this.usersListView.HideSelection = false;
            this.usersListView.Location = new System.Drawing.Point(0, 28);
            this.usersListView.MultiSelect = false;
            this.usersListView.Name = "usersListView";
            this.usersListView.Size = new System.Drawing.Size(797, 254);
            this.usersListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.usersListView.TabIndex = 0;
            this.usersListView.UseCompatibleStateImageBehavior = false;
            this.usersListView.View = System.Windows.Forms.View.Details;
            this.usersListView.SelectedIndexChanged += new System.EventHandler(this.usersListView_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 192;
            // 
            // columnHeaderAdmin
            // 
            this.columnHeaderAdmin.Text = "Admin";
            this.columnHeaderAdmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderAdmin.Width = 72;
            // 
            // userContextMenuStrip
            // 
            this.userContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createUserToolStripMenuItem,
            this.editUserToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.dropUserToolStripMenuItem});
            this.userContextMenuStrip.Name = "userContextMenuStrip";
            this.userContextMenuStrip.Size = new System.Drawing.Size(169, 92);
            // 
            // createUserToolStripMenuItem
            // 
            this.createUserToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.CreateUser;
            this.createUserToolStripMenuItem.Name = "createUserToolStripMenuItem";
            this.createUserToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.createUserToolStripMenuItem.Text = "Create User";
            this.createUserToolStripMenuItem.Click += new System.EventHandler(this.createUserButton_Click);
            // 
            // editUserToolStripMenuItem
            // 
            this.editUserToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.EditUser;
            this.editUserToolStripMenuItem.Name = "editUserToolStripMenuItem";
            this.editUserToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.editUserToolStripMenuItem.Text = "Edit User";
            this.editUserToolStripMenuItem.Click += new System.EventHandler(this.editUserButton_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Password;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // dropUserToolStripMenuItem
            // 
            this.dropUserToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.DropUser;
            this.dropUserToolStripMenuItem.Name = "dropUserToolStripMenuItem";
            this.dropUserToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.dropUserToolStripMenuItem.Text = "Drop User";
            this.dropUserToolStripMenuItem.Click += new System.EventHandler(this.dropUserButton_Click);
            // 
            // grantsListView
            // 
            this.grantsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDatabase,
            this.columnHeaderRead,
            this.columnHeaderWrite,
            this.columnHeaderAll});
            this.grantsListView.ContextMenuStrip = this.grantsContextMenuStrip;
            this.grantsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grantsListView.FullRowSelect = true;
            this.grantsListView.GridLines = true;
            this.grantsListView.HideSelection = false;
            this.grantsListView.Location = new System.Drawing.Point(0, 25);
            this.grantsListView.MultiSelect = false;
            this.grantsListView.Name = "grantsListView";
            this.grantsListView.Size = new System.Drawing.Size(797, 254);
            this.grantsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.grantsListView.TabIndex = 1;
            this.grantsListView.UseCompatibleStateImageBehavior = false;
            this.grantsListView.View = System.Windows.Forms.View.Details;
            this.grantsListView.SelectedIndexChanged += new System.EventHandler(this.grantsListView_SelectedIndexChanged);
            // 
            // columnHeaderDatabase
            // 
            this.columnHeaderDatabase.Text = "Database";
            this.columnHeaderDatabase.Width = 192;
            // 
            // columnHeaderRead
            // 
            this.columnHeaderRead.Text = "Read";
            this.columnHeaderRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeaderWrite
            // 
            this.columnHeaderWrite.Text = "Write";
            this.columnHeaderWrite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeaderAll
            // 
            this.columnHeaderAll.Text = "All";
            this.columnHeaderAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grantsContextMenuStrip
            // 
            this.grantsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grantPrivilegeToolStripMenuItem,
            this.editPrivilegeToolStripMenuItem});
            this.grantsContextMenuStrip.Name = "grantsContextMenuStrip";
            this.grantsContextMenuStrip.Size = new System.Drawing.Size(152, 48);
            // 
            // grantPrivilegeToolStripMenuItem
            // 
            this.grantPrivilegeToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.GrantPrivilege;
            this.grantPrivilegeToolStripMenuItem.Name = "grantPrivilegeToolStripMenuItem";
            this.grantPrivilegeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.grantPrivilegeToolStripMenuItem.Text = "Grant Privilege";
            this.grantPrivilegeToolStripMenuItem.Click += new System.EventHandler(this.grantPrivilegeButton_Click);
            // 
            // editPrivilegeToolStripMenuItem
            // 
            this.editPrivilegeToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.EditPrivilege;
            this.editPrivilegeToolStripMenuItem.Name = "editPrivilegeToolStripMenuItem";
            this.editPrivilegeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.editPrivilegeToolStripMenuItem.Text = "Edit Privilege";
            this.editPrivilegeToolStripMenuItem.Click += new System.EventHandler(this.editPrivilegeButton_Click);
            // 
            // grantsToolStrip
            // 
            this.grantsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grantPrivilegeButton,
            this.toolStripSeparator4,
            this.editPrivilegeButton});
            this.grantsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.grantsToolStrip.Name = "grantsToolStrip";
            this.grantsToolStrip.Size = new System.Drawing.Size(797, 25);
            this.grantsToolStrip.TabIndex = 0;
            this.grantsToolStrip.Text = "toolStrip1";
            // 
            // grantPrivilegeButton
            // 
            this.grantPrivilegeButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.GrantPrivilege;
            this.grantPrivilegeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.grantPrivilegeButton.Name = "grantPrivilegeButton";
            this.grantPrivilegeButton.Size = new System.Drawing.Size(104, 22);
            this.grantPrivilegeButton.Text = "Grant Privilege";
            this.grantPrivilegeButton.Click += new System.EventHandler(this.grantPrivilegeButton_Click);
            // 
            // editPrivilegeButton
            // 
            this.editPrivilegeButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.EditPrivilege;
            this.editPrivilegeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editPrivilegeButton.Name = "editPrivilegeButton";
            this.editPrivilegeButton.Size = new System.Drawing.Size(95, 22);
            this.editPrivilegeButton.Text = "Edit Privilege";
            this.editPrivilegeButton.Click += new System.EventHandler(this.editPrivilegeButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // InfluxDbUsersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "InfluxDbUsersControl";
            this.Size = new System.Drawing.Size(797, 568);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.userToolStrip.ResumeLayout(false);
            this.userToolStrip.PerformLayout();
            this.userContextMenuStrip.ResumeLayout(false);
            this.grantsContextMenuStrip.ResumeLayout(false);
            this.grantsToolStrip.ResumeLayout(false);
            this.grantsToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListView usersListView;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderAdmin;
        private System.Windows.Forms.ToolStrip userToolStrip;
        private System.Windows.Forms.ToolStripButton createUserButton;
        private System.Windows.Forms.ToolStripButton editUserButton;
        private System.Windows.Forms.ToolStripButton dropUserButton;
        private System.Windows.Forms.ToolStrip grantsToolStrip;
        private System.Windows.Forms.ToolStripButton grantPrivilegeButton;
        private System.Windows.Forms.ListView grantsListView;
        private System.Windows.Forms.ColumnHeader columnHeaderDatabase;
        private System.Windows.Forms.ColumnHeader columnHeaderRead;
        private System.Windows.Forms.ColumnHeader columnHeaderWrite;
        private System.Windows.Forms.ColumnHeader columnHeaderAll;
        private System.Windows.Forms.ToolStripButton editPrivilegeButton;
        private System.Windows.Forms.ToolStripButton changePasswordButton;
        private System.Windows.Forms.ContextMenuStrip userContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem createUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropUserToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip grantsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem grantPrivilegeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPrivilegeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}
