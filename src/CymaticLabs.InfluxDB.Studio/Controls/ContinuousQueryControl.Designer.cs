namespace CymaticLabs.InfluxDB.Studio.Controls
{
    partial class ContinuousQueryControl
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
            this.createCqButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dropCqButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.backFillButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createCQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropCQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryEditor = new ScintillaNET.Scintilla();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createCqButton,
            this.toolStripSeparator1,
            this.dropCqButton,
            this.toolStripSeparator2,
            this.backFillButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(776, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // createCqButton
            // 
            this.createCqButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.CreateContinuousQuery;
            this.createCqButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createCqButton.Name = "createCqButton";
            this.createCqButton.Size = new System.Drawing.Size(81, 22);
            this.createCqButton.Text = "Create CQ";
            this.createCqButton.ToolTipText = "Create Continuous Query";
            this.createCqButton.Click += new System.EventHandler(this.createCqButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dropCqButton
            // 
            this.dropCqButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.DropContinuousQuery;
            this.dropCqButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropCqButton.Name = "dropCqButton";
            this.dropCqButton.Size = new System.Drawing.Size(73, 22);
            this.dropCqButton.Text = "Drop CQ";
            this.dropCqButton.ToolTipText = "Drop Continuous Query";
            this.dropCqButton.Click += new System.EventHandler(this.dropCqButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // backFillButton
            // 
            this.backFillButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.BackFill;
            this.backFillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backFillButton.Name = "backFillButton";
            this.backFillButton.Size = new System.Drawing.Size(89, 22);
            this.backFillButton.Text = "Run Backfill";
            this.backFillButton.Click += new System.EventHandler(this.backFillButton_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.queryEditor);
            this.splitContainer.Size = new System.Drawing.Size(776, 480);
            this.splitContainer.SplitterDistance = 205;
            this.splitContainer.TabIndex = 1;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(776, 205);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // columnHeader
            // 
            this.columnHeader.Text = "CQ Name";
            this.columnHeader.Width = 747;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createCQToolStripMenuItem,
            this.dropCQToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(129, 48);
            // 
            // createCQToolStripMenuItem
            // 
            this.createCQToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.CreateContinuousQuery;
            this.createCQToolStripMenuItem.Name = "createCQToolStripMenuItem";
            this.createCQToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.createCQToolStripMenuItem.Text = "Create CQ";
            this.createCQToolStripMenuItem.Click += new System.EventHandler(this.createCqButton_Click);
            // 
            // dropCQToolStripMenuItem
            // 
            this.dropCQToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.DropContinuousQuery;
            this.dropCQToolStripMenuItem.Name = "dropCQToolStripMenuItem";
            this.dropCQToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.dropCQToolStripMenuItem.Text = "Drop CQ";
            this.dropCQToolStripMenuItem.Click += new System.EventHandler(this.dropCqButton_Click);
            // 
            // queryEditor
            // 
            this.queryEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryEditor.Lexer = ScintillaNET.Lexer.Sql;
            this.queryEditor.Location = new System.Drawing.Point(0, 0);
            this.queryEditor.Name = "queryEditor";
            this.queryEditor.Size = new System.Drawing.Size(776, 271);
            this.queryEditor.TabIndex = 0;
            // 
            // ContinuousQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.Name = "ContinuousQueryControl";
            this.Size = new System.Drawing.Size(776, 505);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton createCqButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton dropCqButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListView listView;
        private ScintillaNET.Scintilla queryEditor;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem dropCQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCQToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton backFillButton;
    }
}
