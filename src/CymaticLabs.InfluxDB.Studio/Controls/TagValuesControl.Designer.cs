namespace CymaticLabs.InfluxDB.Studio.Controls
{
    partial class TagValuesControl
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tagKeysLabel = new System.Windows.Forms.ToolStripLabel();
            this.tagKeysComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Dock = System.Windows.Forms.DockStyle.None;
            this.listView.Location = new System.Drawing.Point(0, 28);
            this.listView.Size = new System.Drawing.Size(773, 449);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagKeysLabel,
            this.tagKeysComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(773, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip";
            // 
            // tagKeysLabel
            // 
            this.tagKeysLabel.Name = "tagKeysLabel";
            this.tagKeysLabel.Size = new System.Drawing.Size(56, 22);
            this.tagKeysLabel.Text = "tag keys: ";
            // 
            // tagKeysComboBox
            // 
            this.tagKeysComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tagKeysComboBox.Name = "tagKeysComboBox";
            this.tagKeysComboBox.Size = new System.Drawing.Size(121, 25);
            this.tagKeysComboBox.SelectedIndexChanged += new System.EventHandler(this.tagKeysComboBox_SelectedIndexChanged);
            // 
            // TagValuesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "TagValuesControl";
            this.Controls.SetChildIndex(this.listView, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tagKeysComboBox;
        private System.Windows.Forms.ToolStripLabel tagKeysLabel;
    }
}
