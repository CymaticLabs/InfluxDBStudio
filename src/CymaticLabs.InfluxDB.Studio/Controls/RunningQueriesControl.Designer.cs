namespace CymaticLabs.InfluxDB.Studio.Controls
{
    partial class RunningQueriesControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.killQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryEditor = new ScintillaNET.Scintilla();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.killQueryButton = new System.Windows.Forms.ToolStripButton();
            this.listView = new System.Windows.Forms.ListView();
            this.pidColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.durationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.databaseColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.queryColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.queryEditor);
            this.splitContainer1.Size = new System.Drawing.Size(738, 513);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.killQueryToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(126, 26);
            // 
            // killQueryToolStripMenuItem
            // 
            this.killQueryToolStripMenuItem.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.KillQuery;
            this.killQueryToolStripMenuItem.Name = "killQueryToolStripMenuItem";
            this.killQueryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.killQueryToolStripMenuItem.Text = "Kill Query";
            this.killQueryToolStripMenuItem.Click += new System.EventHandler(this.killQueryToolStripMenuItem_Click);
            // 
            // queryEditor
            // 
            this.queryEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryEditor.Lexer = ScintillaNET.Lexer.Sql;
            this.queryEditor.Location = new System.Drawing.Point(0, 0);
            this.queryEditor.Name = "queryEditor";
            this.queryEditor.ReadOnly = true;
            this.queryEditor.Size = new System.Drawing.Size(738, 271);
            this.queryEditor.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.killQueryButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(738, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // killQueryButton
            // 
            this.killQueryButton.Enabled = false;
            this.killQueryButton.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.KillQuery;
            this.killQueryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.killQueryButton.Name = "killQueryButton";
            this.killQueryButton.Size = new System.Drawing.Size(78, 22);
            this.killQueryButton.Text = "Kill Query";
            this.killQueryButton.Click += new System.EventHandler(this.killQueryButton_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pidColumnHeader,
            this.durationColumnHeader,
            this.databaseColumnHeader,
            this.queryColumnHeader});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(738, 213);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // pidColumnHeader
            // 
            this.pidColumnHeader.Text = "PID";
            // 
            // durationColumnHeader
            // 
            this.durationColumnHeader.Text = "Duration";
            // 
            // databaseColumnHeader
            // 
            this.databaseColumnHeader.Text = "Database";
            this.databaseColumnHeader.Width = 154;
            // 
            // queryColumnHeader
            // 
            this.queryColumnHeader.Text = "Query";
            this.queryColumnHeader.Width = 397;
            // 
            // RunningQueriesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "RunningQueriesControl";
            this.Size = new System.Drawing.Size(738, 513);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ScintillaNET.Scintilla queryEditor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem killQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton killQueryButton;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader pidColumnHeader;
        private System.Windows.Forms.ColumnHeader durationColumnHeader;
        private System.Windows.Forms.ColumnHeader databaseColumnHeader;
        private System.Windows.Forms.ColumnHeader queryColumnHeader;
    }
}
