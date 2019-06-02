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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.influxDBLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // influxDBLogo
            // 
            this.influxDBLogo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.influxdb_logo;
            this.influxDBLogo.Location = new System.Drawing.Point(14, 13);
            this.influxDBLogo.Name = "influxDBLogo";
            this.influxDBLogo.Size = new System.Drawing.Size(192, 178);
            this.influxDBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.influxDBLogo.TabIndex = 0;
            this.influxDBLogo.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(220, 14);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(135, 20);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "InfluxDB Studio";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(354, 14);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(64, 20);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "0.0.0.0";
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(423, 280);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(87, 25);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(220, 43);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(209, 15);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Visual InfluxDB Management Tool";
            // 
            // projectLabel
            // 
            this.projectLabel.AutoSize = true;
            this.projectLabel.Location = new System.Drawing.Point(220, 70);
            this.projectLabel.Name = "projectLabel";
            this.projectLabel.Size = new System.Drawing.Size(162, 15);
            this.projectLabel.TabIndex = 3;
            this.projectLabel.Text = "Visit the project website on";
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(220, 97);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(312, 15);
            this.copyrightLabel.TabIndex = 3;
            this.copyrightLabel.Text = "Copyright 2017 Michael Everett. All  rights reserved.";
            // 
            // warranyLabel
            // 
            this.warranyLabel.Location = new System.Drawing.Point(220, 151);
            this.warranyLabel.Name = "warranyLabel";
            this.warranyLabel.Size = new System.Drawing.Size(292, 66);
            this.warranyLabel.TabIndex = 3;
            this.warranyLabel.Text = "The program is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE WARRANT" +
    "Y OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARITCULAR PURPOSE.";
            // 
            // projectLinkLabel
            // 
            this.projectLinkLabel.AutoSize = true;
            this.projectLinkLabel.Location = new System.Drawing.Point(372, 70);
            this.projectLinkLabel.Name = "projectLinkLabel";
            this.projectLinkLabel.Size = new System.Drawing.Size(46, 15);
            this.projectLinkLabel.TabIndex = 4;
            this.projectLinkLabel.TabStop = true;
            this.projectLinkLabel.Text = "Github";
            this.projectLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.projectLinkLabel_LinkClicked);
            // 
            // influxDataNetLabel
            // 
            this.influxDataNetLabel.AutoSize = true;
            this.influxDataNetLabel.Location = new System.Drawing.Point(220, 124);
            this.influxDataNetLabel.Name = "influxDataNetLabel";
            this.influxDataNetLabel.Size = new System.Drawing.Size(78, 15);
            this.influxDataNetLabel.TabIndex = 3;
            this.influxDataNetLabel.Text = "Powered by ";
            // 
            // influxDataNetLinkLabel
            // 
            this.influxDataNetLinkLabel.AutoSize = true;
            this.influxDataNetLinkLabel.Location = new System.Drawing.Point(290, 124);
            this.influxDataNetLinkLabel.Name = "influxDataNetLinkLabel";
            this.influxDataNetLinkLabel.Size = new System.Drawing.Size(92, 15);
            this.influxDataNetLinkLabel.TabIndex = 4;
            this.influxDataNetLinkLabel.TabStop = true;
            this.influxDataNetLinkLabel.Text = "InfluxData.Net";
            this.influxDataNetLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.influxDataNetLinkLabel_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(315, 225);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(64, 15);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "sam80180";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Modificada por ";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(286, 252);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(98, 15);
            this.linkLabel2.TabIndex = 8;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "ASP.NET icons";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Iconos por ";
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 319);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}