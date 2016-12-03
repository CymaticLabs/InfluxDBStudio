namespace CymaticLabs.InfluxDB.Studio.Controls
{
    partial class MeasurementControl
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
            this.listView = new System.Windows.Forms.ListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSelectedCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.exportAllJsonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSelectedJsonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(773, 480);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAllToolStripMenuItem,
            this.exportSelectedToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(155, 70);
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAllCsvToolStripMenuItem,
            this.exportAllJsonMenuItem});
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exportAllToolStripMenuItem.Text = "Export All";
            // 
            // exportAllCsvToolStripMenuItem
            // 
            this.exportAllCsvToolStripMenuItem.Name = "exportAllCsvToolStripMenuItem";
            this.exportAllCsvToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportAllCsvToolStripMenuItem.Text = "CSV";
            this.exportAllCsvToolStripMenuItem.Click += new System.EventHandler(this.exportAllCsvToolStripMenuItem_Click);
            // 
            // exportSelectedToolStripMenuItem
            // 
            this.exportSelectedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSelectedCsvToolStripMenuItem,
            this.exportSelectedJsonMenuItem});
            this.exportSelectedToolStripMenuItem.Name = "exportSelectedToolStripMenuItem";
            this.exportSelectedToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exportSelectedToolStripMenuItem.Text = "Export Selected";
            // 
            // exportSelectedCsvToolStripMenuItem
            // 
            this.exportSelectedCsvToolStripMenuItem.Name = "exportSelectedCsvToolStripMenuItem";
            this.exportSelectedCsvToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportSelectedCsvToolStripMenuItem.Text = "CSV";
            this.exportSelectedCsvToolStripMenuItem.Click += new System.EventHandler(this.exportSelectedCsvToolStripMenuItem_Click);
            // 
            // exportAllJsonMenuItem
            // 
            this.exportAllJsonMenuItem.Name = "exportAllJsonMenuItem";
            this.exportAllJsonMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportAllJsonMenuItem.Text = "JSON";
            this.exportAllJsonMenuItem.Click += new System.EventHandler(this.exportAllJsonMenuItem_Click);
            // 
            // exportSelectedJsonMenuItem
            // 
            this.exportSelectedJsonMenuItem.Name = "exportSelectedJsonMenuItem";
            this.exportSelectedJsonMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportSelectedJsonMenuItem.Text = "JSON";
            this.exportSelectedJsonMenuItem.Click += new System.EventHandler(this.exportSelectedJsonMenuItem_Click);
            // 
            // MeasurementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Name = "MeasurementControl";
            this.Size = new System.Drawing.Size(773, 480);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedCsvToolStripMenuItem;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        protected System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ToolStripMenuItem exportAllJsonMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedJsonMenuItem;
    }
}
