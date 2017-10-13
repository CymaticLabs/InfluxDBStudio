namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    partial class AboutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.influxDBLogo = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.projectLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.warranyLabel = new System.Windows.Forms.Label();
            this.projectLinkLabel = new System.Windows.Forms.LinkLabel();
            this.influxDataNetLabel = new System.Windows.Forms.Label();
            this.influxDataNetLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.influxDBLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // influxDBLogo
            // 
            this.influxDBLogo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.influxdb_logo;
            this.influxDBLogo.Location = new System.Drawing.Point(12, 12);
            this.influxDBLogo.Name = "influxDBLogo";
            this.influxDBLogo.Size = new System.Drawing.Size(165, 165);
            this.influxDBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.influxDBLogo.TabIndex = 0;
            this.influxDBLogo.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(189, 13);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(112, 16);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "InfluxDB Studio";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(298, 13);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(52, 16);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "0.0.0.0";
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(363, 204);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(189, 40);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(167, 13);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Visual InfluxDB Management Tool";
            // 
            // projectLabel
            // 
            this.projectLabel.AutoSize = true;
            this.projectLabel.Location = new System.Drawing.Point(189, 65);
            this.projectLabel.Name = "projectLabel";
            this.projectLabel.Size = new System.Drawing.Size(133, 13);
            this.projectLabel.TabIndex = 3;
            this.projectLabel.Text = "Visit the project website on";
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(189, 90);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(250, 13);
            this.copyrightLabel.TabIndex = 3;
            this.copyrightLabel.Text = "Copyright 2017 Michael Everett. All  rights reserved.";
            // 
            // warranyLabel
            // 
            this.warranyLabel.Location = new System.Drawing.Point(189, 140);
            this.warranyLabel.Name = "warranyLabel";
            this.warranyLabel.Size = new System.Drawing.Size(250, 61);
            this.warranyLabel.TabIndex = 3;
            this.warranyLabel.Text = "The program is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE WARRANT" +
    "Y OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARITCULAR PURPOSE.";
            // 
            // projectLinkLabel
            // 
            this.projectLinkLabel.AutoSize = true;
            this.projectLinkLabel.Location = new System.Drawing.Point(319, 65);
            this.projectLinkLabel.Name = "projectLinkLabel";
            this.projectLinkLabel.Size = new System.Drawing.Size(38, 13);
            this.projectLinkLabel.TabIndex = 4;
            this.projectLinkLabel.TabStop = true;
            this.projectLinkLabel.Text = "Github";
            this.projectLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.projectLinkLabel_LinkClicked);
            // 
            // influxDataNetLabel
            // 
            this.influxDataNetLabel.AutoSize = true;
            this.influxDataNetLabel.Location = new System.Drawing.Point(189, 115);
            this.influxDataNetLabel.Name = "influxDataNetLabel";
            this.influxDataNetLabel.Size = new System.Drawing.Size(66, 13);
            this.influxDataNetLabel.TabIndex = 3;
            this.influxDataNetLabel.Text = "Powered by ";
            // 
            // influxDataNetLinkLabel
            // 
            this.influxDataNetLinkLabel.AutoSize = true;
            this.influxDataNetLinkLabel.Location = new System.Drawing.Point(249, 115);
            this.influxDataNetLinkLabel.Name = "influxDataNetLinkLabel";
            this.influxDataNetLinkLabel.Size = new System.Drawing.Size(75, 13);
            this.influxDataNetLinkLabel.TabIndex = 4;
            this.influxDataNetLinkLabel.TabStop = true;
            this.influxDataNetLinkLabel.Text = "InfluxData.Net";
            this.influxDataNetLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.influxDataNetLinkLabel_LinkClicked);
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 239);
            this.Controls.Add(this.influxDataNetLinkLabel);
            this.Controls.Add(this.projectLinkLabel);
            this.Controls.Add(this.warranyLabel);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.influxDataNetLabel);
            this.Controls.Add(this.projectLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.influxDBLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About InfluxDB Studio";
            this.Load += new System.EventHandler(this.AboutDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.influxDBLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox influxDBLogo;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label projectLabel;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Label warranyLabel;
        private System.Windows.Forms.LinkLabel projectLinkLabel;
        private System.Windows.Forms.Label influxDataNetLabel;
        private System.Windows.Forms.LinkLabel influxDataNetLinkLabel;
    }
}