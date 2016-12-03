namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    partial class CreateContinuousQueryDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateContinuousQueryDialog));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.resampleForInfo = new System.Windows.Forms.PictureBox();
            this.resampleForTextBox = new System.Windows.Forms.TextBox();
            this.resampleForLabel = new System.Windows.Forms.Label();
            this.resampleInfo = new System.Windows.Forms.PictureBox();
            this.resampleEveryInfo = new System.Windows.Forms.PictureBox();
            this.tagsInfo = new System.Windows.Forms.PictureBox();
            this.fillTypeInfo = new System.Windows.Forms.PictureBox();
            this.intervalInfo = new System.Windows.Forms.PictureBox();
            this.resampleCheckBox = new System.Windows.Forms.CheckBox();
            this.destinationComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.fillTypeLabel = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.resampleEveryTextBox = new System.Windows.Forms.TextBox();
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.tagsTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.fillTypeComboBox = new System.Windows.Forms.ComboBox();
            this.databaseValue = new System.Windows.Forms.Label();
            this.databaseLabel = new System.Windows.Forms.Label();
            this.resampleEveryLabel = new System.Windows.Forms.Label();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.intervalToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.fillTypeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tagsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.resampleToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.resampleForToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.resampleEveryToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.queryEditor = new ScintillaNET.Scintilla();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resampleForInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resampleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resampleEveryInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillTypeInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.resampleForInfo);
            this.groupBox.Controls.Add(this.resampleForTextBox);
            this.groupBox.Controls.Add(this.resampleForLabel);
            this.groupBox.Controls.Add(this.resampleInfo);
            this.groupBox.Controls.Add(this.resampleEveryInfo);
            this.groupBox.Controls.Add(this.tagsInfo);
            this.groupBox.Controls.Add(this.fillTypeInfo);
            this.groupBox.Controls.Add(this.intervalInfo);
            this.groupBox.Controls.Add(this.resampleCheckBox);
            this.groupBox.Controls.Add(this.destinationComboBox);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.destinationLabel);
            this.groupBox.Controls.Add(this.sourceComboBox);
            this.groupBox.Controls.Add(this.fillTypeLabel);
            this.groupBox.Controls.Add(this.sourceLabel);
            this.groupBox.Controls.Add(this.resampleEveryTextBox);
            this.groupBox.Controls.Add(this.intervalTextBox);
            this.groupBox.Controls.Add(this.tagsTextBox);
            this.groupBox.Controls.Add(this.nameTextBox);
            this.groupBox.Controls.Add(this.fillTypeComboBox);
            this.groupBox.Controls.Add(this.databaseValue);
            this.groupBox.Controls.Add(this.databaseLabel);
            this.groupBox.Controls.Add(this.resampleEveryLabel);
            this.groupBox.Controls.Add(this.intervalLabel);
            this.groupBox.Controls.Add(this.nameLabel);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(595, 211);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Details";
            // 
            // resampleForInfo
            // 
            this.resampleForInfo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Info;
            this.resampleForInfo.Location = new System.Drawing.Point(562, 172);
            this.resampleForInfo.Name = "resampleForInfo";
            this.resampleForInfo.Size = new System.Drawing.Size(16, 16);
            this.resampleForInfo.TabIndex = 14;
            this.resampleForInfo.TabStop = false;
            // 
            // resampleForTextBox
            // 
            this.resampleForTextBox.Enabled = false;
            this.resampleForTextBox.Location = new System.Drawing.Point(453, 169);
            this.resampleForTextBox.Name = "resampleForTextBox";
            this.resampleForTextBox.Size = new System.Drawing.Size(103, 22);
            this.resampleForTextBox.TabIndex = 9;
            // 
            // resampleForLabel
            // 
            this.resampleForLabel.AutoSize = true;
            this.resampleForLabel.Enabled = false;
            this.resampleForLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resampleForLabel.Location = new System.Drawing.Point(421, 174);
            this.resampleForLabel.Name = "resampleForLabel";
            this.resampleForLabel.Size = new System.Drawing.Size(25, 13);
            this.resampleForLabel.TabIndex = 12;
            this.resampleForLabel.Text = "For:";
            // 
            // resampleInfo
            // 
            this.resampleInfo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Info;
            this.resampleInfo.Location = new System.Drawing.Point(157, 173);
            this.resampleInfo.Name = "resampleInfo";
            this.resampleInfo.Size = new System.Drawing.Size(16, 16);
            this.resampleInfo.TabIndex = 11;
            this.resampleInfo.TabStop = false;
            // 
            // resampleEveryInfo
            // 
            this.resampleEveryInfo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Info;
            this.resampleEveryInfo.Location = new System.Drawing.Point(376, 172);
            this.resampleEveryInfo.Name = "resampleEveryInfo";
            this.resampleEveryInfo.Size = new System.Drawing.Size(16, 16);
            this.resampleEveryInfo.TabIndex = 11;
            this.resampleEveryInfo.TabStop = false;
            // 
            // tagsInfo
            // 
            this.tagsInfo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Info;
            this.tagsInfo.Location = new System.Drawing.Point(562, 138);
            this.tagsInfo.Name = "tagsInfo";
            this.tagsInfo.Size = new System.Drawing.Size(16, 16);
            this.tagsInfo.TabIndex = 11;
            this.tagsInfo.TabStop = false;
            // 
            // fillTypeInfo
            // 
            this.fillTypeInfo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Info;
            this.fillTypeInfo.Location = new System.Drawing.Point(485, 101);
            this.fillTypeInfo.Name = "fillTypeInfo";
            this.fillTypeInfo.Size = new System.Drawing.Size(16, 16);
            this.fillTypeInfo.TabIndex = 11;
            this.fillTypeInfo.TabStop = false;
            // 
            // intervalInfo
            // 
            this.intervalInfo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Info;
            this.intervalInfo.Location = new System.Drawing.Point(193, 101);
            this.intervalInfo.Name = "intervalInfo";
            this.intervalInfo.Size = new System.Drawing.Size(16, 16);
            this.intervalInfo.TabIndex = 11;
            this.intervalInfo.TabStop = false;
            // 
            // resampleCheckBox
            // 
            this.resampleCheckBox.AutoSize = true;
            this.resampleCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resampleCheckBox.Location = new System.Drawing.Point(84, 173);
            this.resampleCheckBox.Name = "resampleCheckBox";
            this.resampleCheckBox.Size = new System.Drawing.Size(73, 17);
            this.resampleCheckBox.TabIndex = 7;
            this.resampleCheckBox.Text = "Resample";
            this.resampleCheckBox.UseVisualStyleBackColor = true;
            this.resampleCheckBox.CheckedChanged += new System.EventHandler(this.resampleCheckBox_CheckedChanged);
            // 
            // destinationComboBox
            // 
            this.destinationComboBox.FormattingEnabled = true;
            this.destinationComboBox.Location = new System.Drawing.Point(84, 61);
            this.destinationComboBox.Name = "destinationComboBox";
            this.destinationComboBox.Size = new System.Drawing.Size(180, 24);
            this.destinationComboBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tags:";
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationLabel.Location = new System.Drawing.Point(14, 66);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(63, 13);
            this.destinationLabel.TabIndex = 9;
            this.destinationLabel.Text = "Destination:";
            // 
            // sourceComboBox
            // 
            this.sourceComboBox.FormattingEnabled = true;
            this.sourceComboBox.Location = new System.Drawing.Point(376, 61);
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.Size = new System.Drawing.Size(180, 24);
            this.sourceComboBox.TabIndex = 3;
            // 
            // fillTypeLabel
            // 
            this.fillTypeLabel.AutoSize = true;
            this.fillTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fillTypeLabel.Location = new System.Drawing.Point(311, 103);
            this.fillTypeLabel.Name = "fillTypeLabel";
            this.fillTypeLabel.Size = new System.Drawing.Size(49, 13);
            this.fillTypeLabel.TabIndex = 3;
            this.fillTypeLabel.Text = "Fill Type:";
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceLabel.Location = new System.Drawing.Point(311, 66);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(44, 13);
            this.sourceLabel.TabIndex = 3;
            this.sourceLabel.Text = "Source:";
            // 
            // resampleEveryTextBox
            // 
            this.resampleEveryTextBox.Enabled = false;
            this.resampleEveryTextBox.Location = new System.Drawing.Point(267, 169);
            this.resampleEveryTextBox.Name = "resampleEveryTextBox";
            this.resampleEveryTextBox.Size = new System.Drawing.Size(103, 22);
            this.resampleEveryTextBox.TabIndex = 8;
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.Location = new System.Drawing.Point(84, 98);
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(103, 22);
            this.intervalTextBox.TabIndex = 4;
            // 
            // tagsTextBox
            // 
            this.tagsTextBox.Location = new System.Drawing.Point(84, 135);
            this.tagsTextBox.Name = "tagsTextBox";
            this.tagsTextBox.Size = new System.Drawing.Size(472, 22);
            this.tagsTextBox.TabIndex = 6;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(84, 29);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(180, 22);
            this.nameTextBox.TabIndex = 1;
            // 
            // fillTypeComboBox
            // 
            this.fillTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fillTypeComboBox.FormattingEnabled = true;
            this.fillTypeComboBox.Location = new System.Drawing.Point(376, 98);
            this.fillTypeComboBox.Name = "fillTypeComboBox";
            this.fillTypeComboBox.Size = new System.Drawing.Size(103, 24);
            this.fillTypeComboBox.TabIndex = 5;
            // 
            // databaseValue
            // 
            this.databaseValue.AutoSize = true;
            this.databaseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseValue.Location = new System.Drawing.Point(373, 32);
            this.databaseValue.Name = "databaseValue";
            this.databaseValue.Size = new System.Drawing.Size(11, 13);
            this.databaseValue.TabIndex = 0;
            this.databaseValue.Text = "-";
            // 
            // databaseLabel
            // 
            this.databaseLabel.AutoSize = true;
            this.databaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseLabel.Location = new System.Drawing.Point(311, 32);
            this.databaseLabel.Name = "databaseLabel";
            this.databaseLabel.Size = new System.Drawing.Size(56, 13);
            this.databaseLabel.TabIndex = 0;
            this.databaseLabel.Text = "Database:";
            // 
            // resampleEveryLabel
            // 
            this.resampleEveryLabel.AutoSize = true;
            this.resampleEveryLabel.Enabled = false;
            this.resampleEveryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resampleEveryLabel.Location = new System.Drawing.Point(224, 174);
            this.resampleEveryLabel.Name = "resampleEveryLabel";
            this.resampleEveryLabel.Size = new System.Drawing.Size(37, 13);
            this.resampleEveryLabel.TabIndex = 0;
            this.resampleEveryLabel.Text = "Every:";
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervalLabel.Location = new System.Drawing.Point(14, 103);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(45, 13);
            this.intervalLabel.TabIndex = 0;
            this.intervalLabel.Text = "Interval:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(14, 32);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(56, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "CQ Name:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(532, 422);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createButton.Location = new System.Drawing.Point(451, 422);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 12;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // intervalToolTip
            // 
            this.intervalToolTip.AutoPopDelay = 32767;
            this.intervalToolTip.InitialDelay = 500;
            this.intervalToolTip.ReshowDelay = 100;
            this.intervalToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.intervalToolTip.ToolTipTitle = "Interval";
            // 
            // fillTypeToolTip
            // 
            this.fillTypeToolTip.AutoPopDelay = 32767;
            this.fillTypeToolTip.InitialDelay = 500;
            this.fillTypeToolTip.ReshowDelay = 100;
            this.fillTypeToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.fillTypeToolTip.ToolTipTitle = "Fill Type";
            // 
            // tagsToolTip
            // 
            this.tagsToolTip.AutoPopDelay = 32767;
            this.tagsToolTip.InitialDelay = 500;
            this.tagsToolTip.ReshowDelay = 100;
            this.tagsToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tagsToolTip.ToolTipTitle = "Tags";
            // 
            // resampleToolTip
            // 
            this.resampleToolTip.AutoPopDelay = 32767;
            this.resampleToolTip.InitialDelay = 500;
            this.resampleToolTip.ReshowDelay = 100;
            this.resampleToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.resampleToolTip.ToolTipTitle = "Enable Resampling";
            // 
            // resampleForToolTip
            // 
            this.resampleForToolTip.AutoPopDelay = 32767;
            this.resampleForToolTip.InitialDelay = 500;
            this.resampleForToolTip.ReshowDelay = 100;
            this.resampleForToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.resampleForToolTip.ToolTipTitle = "Resample For";
            // 
            // resampleEveryToolTip
            // 
            this.resampleEveryToolTip.AutoPopDelay = 32767;
            this.resampleEveryToolTip.InitialDelay = 500;
            this.resampleEveryToolTip.ReshowDelay = 100;
            this.resampleEveryToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.resampleEveryToolTip.ToolTipTitle = "Resample Every";
            // 
            // queryEditor
            // 
            this.queryEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryEditor.Lexer = ScintillaNET.Lexer.Sql;
            this.queryEditor.Location = new System.Drawing.Point(12, 229);
            this.queryEditor.Name = "queryEditor";
            this.queryEditor.Size = new System.Drawing.Size(595, 187);
            this.queryEditor.TabIndex = 14;
            // 
            // CreateContinuousQueryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 457);
            this.Controls.Add(this.queryEditor);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateContinuousQueryDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Continuous Query";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateContinuousQueryDialog_FormClosing);
            this.Load += new System.EventHandler(this.CreateContinuousQueryDialog_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resampleForInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resampleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resampleEveryInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillTypeInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ComboBox sourceComboBox;
        private System.Windows.Forms.Label fillTypeLabel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox fillTypeComboBox;
        private System.Windows.Forms.Label databaseLabel;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label databaseValue;
        private System.Windows.Forms.ComboBox destinationComboBox;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.TextBox resampleEveryTextBox;
        private System.Windows.Forms.Label resampleEveryLabel;
        private System.Windows.Forms.CheckBox resampleCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tagsTextBox;
        private System.Windows.Forms.ToolTip intervalToolTip;
        private System.Windows.Forms.PictureBox intervalInfo;
        private System.Windows.Forms.ToolTip fillTypeToolTip;
        private System.Windows.Forms.PictureBox fillTypeInfo;
        private System.Windows.Forms.PictureBox tagsInfo;
        private System.Windows.Forms.PictureBox resampleEveryInfo;
        private System.Windows.Forms.PictureBox resampleInfo;
        private System.Windows.Forms.ToolTip tagsToolTip;
        private System.Windows.Forms.ToolTip resampleToolTip;
        private System.Windows.Forms.ToolTip resampleForToolTip;
        private System.Windows.Forms.ToolTip resampleEveryToolTip;
        private System.Windows.Forms.PictureBox resampleForInfo;
        private System.Windows.Forms.TextBox resampleForTextBox;
        private System.Windows.Forms.Label resampleForLabel;
        private ScintillaNET.Scintilla queryEditor;
    }
}