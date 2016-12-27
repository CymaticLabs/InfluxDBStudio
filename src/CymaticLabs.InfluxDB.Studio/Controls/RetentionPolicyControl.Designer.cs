namespace CymaticLabs.InfluxDB.Studio.Controls
{
    partial class RetentionPolicyControl
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.selectDbLabel = new System.Windows.Forms.ToolStripLabel();
            this.databaseComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.createButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.alterButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dropButton = new System.Windows.Forms.ToolStripButton();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderShardDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderReplica = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDefault = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createPolicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterPolicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropPolicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectDbLabel,
            this.databaseComboBox,
            this.toolStripSeparator1,
            this.createButton,
            this.toolStripSeparator2,
            this.alterButton,
            this.toolStripSeparator3,
            this.dropButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(600, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // selectDbLabel
            // 
            this.selectDbLabel.Name = "selectDbLabel";
            this.selectDbLabel.Size = new System.Drawing.Size(92, 22);
            this.selectDbLabel.Text = "Select Database:";
            // 
            // databaseComboBox
            // 
            this.databaseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseComboBox.Name = "databaseComboBox";
            this.databaseComboBox.Size = new System.Drawing.Size(121, 25);
            this.databaseComboBox.SelectedIndexChanged += new System.EventHandler(this.databaseComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // createButton
            // 
            this.createButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.CreateRetentionPolicy;
            this.createButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(96, 22);
            this.createButton.Text = "Create Policy";
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // alterButton
            // 
            this.alterButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.EditRetentionPolicy;
            this.alterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alterButton.Name = "alterButton";
            this.alterButton.Size = new System.Drawing.Size(87, 22);
            this.alterButton.Text = "Alter Policy";
            this.alterButton.Click += new System.EventHandler(this.alterButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // dropButton
            // 
            this.dropButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.DropRetentionPolicy;
            this.dropButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropButton.Name = "dropButton";
            this.dropButton.Size = new System.Drawing.Size(88, 22);
            this.dropButton.Text = "Drop Policy";
            this.dropButton.Click += new System.EventHandler(this.dropButton_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderDuration,
            this.columnHeaderShardDuration,
            this.columnHeaderReplica,
            this.columnHeaderDefault});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(600, 397);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Policy Name";
            this.columnHeaderName.Width = 225;
            // 
            // columnHeaderDuration
            // 
            this.columnHeaderDuration.Text = "Duration";
            this.columnHeaderDuration.Width = 100;
            // 
            // columnHeaderShardDuration
            // 
            this.columnHeaderShardDuration.Text = "Shard Group Duration";
            this.columnHeaderShardDuration.Width = 135;
            // 
            // columnHeaderReplica
            // 
            this.columnHeaderReplica.Text = "Replica N";
            this.columnHeaderReplica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderReplica.Width = 64;
            // 
            // columnHeaderDefault
            // 
            this.columnHeaderDefault.Text = "Default";
            this.columnHeaderDefault.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPolicyToolStripMenuItem,
            this.alterPolicyToolStripMenuItem,
            this.dropPolicyToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(144, 70);
            // 
            // createPolicyToolStripMenuItem
            // 
            this.createPolicyToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.CreateRetentionPolicy;
            this.createPolicyToolStripMenuItem.Name = "createPolicyToolStripMenuItem";
            this.createPolicyToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.createPolicyToolStripMenuItem.Text = "Create Policy";
            this.createPolicyToolStripMenuItem.Click += new System.EventHandler(this.createPolicyToolStripMenuItem_Click);
            // 
            // alterPolicyToolStripMenuItem
            // 
            this.alterPolicyToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.EditRetentionPolicy;
            this.alterPolicyToolStripMenuItem.Name = "alterPolicyToolStripMenuItem";
            this.alterPolicyToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.alterPolicyToolStripMenuItem.Text = "Alter Policy";
            this.alterPolicyToolStripMenuItem.Click += new System.EventHandler(this.alterPolicyToolStripMenuItem_Click);
            // 
            // dropPolicyToolStripMenuItem
            // 
            this.dropPolicyToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.DropRetentionPolicy;
            this.dropPolicyToolStripMenuItem.Name = "dropPolicyToolStripMenuItem";
            this.dropPolicyToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.dropPolicyToolStripMenuItem.Text = "Drop Policy";
            this.dropPolicyToolStripMenuItem.Click += new System.EventHandler(this.dropPolicyToolStripMenuItem_Click);
            // 
            // RetentionPolicyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "RetentionPolicyControl";
            this.Size = new System.Drawing.Size(600, 422);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel selectDbLabel;
        private System.Windows.Forms.ToolStripComboBox databaseComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton createButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton alterButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton dropButton;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderDuration;
        private System.Windows.Forms.ColumnHeader columnHeaderShardDuration;
        private System.Windows.Forms.ColumnHeader columnHeaderReplica;
        private System.Windows.Forms.ColumnHeader columnHeaderDefault;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem createPolicyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterPolicyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropPolicyToolStripMenuItem;
    }
}
