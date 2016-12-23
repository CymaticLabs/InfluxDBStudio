namespace CymaticLabs.InfluxDB.Studio.Controls
{
    partial class StatsControl
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
            this.selectStatLabel = new System.Windows.Forms.ToolStripLabel();
            this.statsComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectStatLabel,
            this.statsComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(633, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // selectStatLabel
            // 
            this.selectStatLabel.Name = "selectStatLabel";
            this.selectStatLabel.Size = new System.Drawing.Size(85, 22);
            this.selectStatLabel.Text = "Select Statistic:";
            // 
            // statsComboBox
            // 
            this.statsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statsComboBox.Name = "statsComboBox";
            this.statsComboBox.Size = new System.Drawing.Size(121, 25);
            this.statsComboBox.SelectedIndexChanged += new System.EventHandler(this.statsComboBox_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(0, 32);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(633, 465);
            this.tabControl.TabIndex = 1;
            // 
            // StatsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "StatsControl";
            this.Size = new System.Drawing.Size(633, 497);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox statsComboBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripLabel selectStatLabel;
    }
}
