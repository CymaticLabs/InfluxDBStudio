namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    partial class BackfillDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackfillDialog));
            this.queryEditor = new ScintillaNET.Scintilla();
            this.createButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.sourceInfo = new System.Windows.Forms.PictureBox();
            this.destinationInfo = new System.Windows.Forms.PictureBox();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.filtersInfo = new System.Windows.Forms.PictureBox();
            this.tagsInfo = new System.Windows.Forms.PictureBox();
            this.fillTypeInfo = new System.Windows.Forms.PictureBox();
            this.intervalInfo = new System.Windows.Forms.PictureBox();
            this.destinationComboBox = new System.Windows.Forms.ComboBox();
            this.filtersLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fromTimeLabel = new System.Windows.Forms.Label();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.toTimeLabel = new System.Windows.Forms.Label();
            this.fillTypeLabel = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.filtersTextBox = new System.Windows.Forms.TextBox();
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.tagsTextBox = new System.Windows.Forms.TextBox();
            this.fillTypeComboBox = new System.Windows.Forms.ComboBox();
            this.databaseValue = new System.Windows.Forms.Label();
            this.databaseLabel = new System.Windows.Forms.Label();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.intervalToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.fillTypeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tagsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.destinationToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.sourceToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.filtersToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtersInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillTypeInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // queryEditor
            // 
            this.queryEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryEditor.Lexer = ScintillaNET.Lexer.Sql;
            this.queryEditor.Location = new System.Drawing.Point(12, 280);
            this.queryEditor.Name = "queryEditor";
            this.queryEditor.Size = new System.Drawing.Size(595, 145);
            this.queryEditor.TabIndex = 8;
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createButton.Location = new System.Drawing.Point(451, 431);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Run";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(532, 431);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.sourceInfo);
            this.groupBox.Controls.Add(this.destinationInfo);
            this.groupBox.Controls.Add(this.toDateTimePicker);
            this.groupBox.Controls.Add(this.fromDateTimePicker);
            this.groupBox.Controls.Add(this.filtersInfo);
            this.groupBox.Controls.Add(this.tagsInfo);
            this.groupBox.Controls.Add(this.fillTypeInfo);
            this.groupBox.Controls.Add(this.intervalInfo);
            this.groupBox.Controls.Add(this.destinationComboBox);
            this.groupBox.Controls.Add(this.filtersLabel);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.fromTimeLabel);
            this.groupBox.Controls.Add(this.destinationLabel);
            this.groupBox.Controls.Add(this.sourceComboBox);
            this.groupBox.Controls.Add(this.toTimeLabel);
            this.groupBox.Controls.Add(this.fillTypeLabel);
            this.groupBox.Controls.Add(this.sourceLabel);
            this.groupBox.Controls.Add(this.filtersTextBox);
            this.groupBox.Controls.Add(this.intervalTextBox);
            this.groupBox.Controls.Add(this.tagsTextBox);
            this.groupBox.Controls.Add(this.fillTypeComboBox);
            this.groupBox.Controls.Add(this.databaseValue);
            this.groupBox.Controls.Add(this.databaseLabel);
            this.groupBox.Controls.Add(this.intervalLabel);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(595, 262);
            this.groupBox.TabIndex = 15;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Details";
            // 
            // sourceInfo
            // 
            this.sourceInfo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Info;
            this.sourceInfo.Location = new System.Drawing.Point(562, 64);
            this.sourceInfo.Name = "sourceInfo";
            this.sourceInfo.Size = new System.Drawing.Size(16, 16);
            this.sourceInfo.TabIndex = 13;
            this.sourceInfo.TabStop = false;
            // 
            // destinationInfo
            // 
            this.destinationInfo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Info;
            this.destinationInfo.Location = new System.Drawing.Point(270, 64);
            this.destinationInfo.Name = "destinationInfo";
            this.destinationInfo.Size = new System.Drawing.Size(16, 16);
            this.destinationInfo.TabIndex = 14;
            this.destinationInfo.TabStop = false;
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.CustomFormat = "d/MM/yyyy @ hh:mm:ss tt";
            this.toDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDateTimePicker.Location = new System.Drawing.Point(376, 137);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(180, 20);
            this.toDateTimePicker.TabIndex = 5;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.CustomFormat = "d/MM/yyyy @ hh:mm:ss tt";
            this.fromDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDateTimePicker.Location = new System.Drawing.Point(84, 137);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(180, 20);
            this.fromDateTimePicker.TabIndex = 4;
            // 
            // filtersInfo
            // 
            this.filtersInfo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Info;
            this.filtersInfo.Location = new System.Drawing.Point(562, 178);
            this.filtersInfo.Name = "filtersInfo";
            this.filtersInfo.Size = new System.Drawing.Size(16, 16);
            this.filtersInfo.TabIndex = 11;
            this.filtersInfo.TabStop = false;
            // 
            // tagsInfo
            // 
            this.tagsInfo.Image = global::CymaticLabs.InfluxDB.Studio.Properties.Resources.Info;
            this.tagsInfo.Location = new System.Drawing.Point(562, 217);
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
            // destinationComboBox
            // 
            this.destinationComboBox.FormattingEnabled = true;
            this.destinationComboBox.Location = new System.Drawing.Point(84, 61);
            this.destinationComboBox.Name = "destinationComboBox";
            this.destinationComboBox.Size = new System.Drawing.Size(180, 24);
            this.destinationComboBox.TabIndex = 0;
            // 
            // filtersLabel
            // 
            this.filtersLabel.AutoSize = true;
            this.filtersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtersLabel.Location = new System.Drawing.Point(14, 180);
            this.filtersLabel.Name = "filtersLabel";
            this.filtersLabel.Size = new System.Drawing.Size(37, 13);
            this.filtersLabel.TabIndex = 9;
            this.filtersLabel.Text = "Filters:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tags:";
            // 
            // fromTimeLabel
            // 
            this.fromTimeLabel.AutoSize = true;
            this.fromTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromTimeLabel.Location = new System.Drawing.Point(14, 143);
            this.fromTimeLabel.Name = "fromTimeLabel";
            this.fromTimeLabel.Size = new System.Drawing.Size(59, 13);
            this.fromTimeLabel.TabIndex = 9;
            this.fromTimeLabel.Text = "From Time:";
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
            this.sourceComboBox.TabIndex = 1;
            // 
            // toTimeLabel
            // 
            this.toTimeLabel.AutoSize = true;
            this.toTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toTimeLabel.Location = new System.Drawing.Point(311, 143);
            this.toTimeLabel.Name = "toTimeLabel";
            this.toTimeLabel.Size = new System.Drawing.Size(49, 13);
            this.toTimeLabel.TabIndex = 3;
            this.toTimeLabel.Text = "To Time:";
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
            // filtersTextBox
            // 
            this.filtersTextBox.Location = new System.Drawing.Point(84, 175);
            this.filtersTextBox.Name = "filtersTextBox";
            this.filtersTextBox.Size = new System.Drawing.Size(472, 22);
            this.filtersTextBox.TabIndex = 6;
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.Location = new System.Drawing.Point(84, 98);
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(103, 22);
            this.intervalTextBox.TabIndex = 2;
            // 
            // tagsTextBox
            // 
            this.tagsTextBox.Location = new System.Drawing.Point(84, 214);
            this.tagsTextBox.Name = "tagsTextBox";
            this.tagsTextBox.Size = new System.Drawing.Size(472, 22);
            this.tagsTextBox.TabIndex = 7;
            // 
            // fillTypeComboBox
            // 
            this.fillTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fillTypeComboBox.FormattingEnabled = true;
            this.fillTypeComboBox.Location = new System.Drawing.Point(376, 98);
            this.fillTypeComboBox.Name = "fillTypeComboBox";
            this.fillTypeComboBox.Size = new System.Drawing.Size(103, 24);
            this.fillTypeComboBox.TabIndex = 3;
            // 
            // databaseValue
            // 
            this.databaseValue.AutoSize = true;
            this.databaseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseValue.Location = new System.Drawing.Point(76, 31);
            this.databaseValue.Name = "databaseValue";
            this.databaseValue.Size = new System.Drawing.Size(11, 13);
            this.databaseValue.TabIndex = 0;
            this.databaseValue.Text = "-";
            // 
            // databaseLabel
            // 
            this.databaseLabel.AutoSize = true;
            this.databaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseLabel.Location = new System.Drawing.Point(14, 31);
            this.databaseLabel.Name = "databaseLabel";
            this.databaseLabel.Size = new System.Drawing.Size(56, 13);
            this.databaseLabel.TabIndex = 0;
            this.databaseLabel.Text = "Database:";
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
            // destinationToolTip
            // 
            this.destinationToolTip.AutoPopDelay = 32767;
            this.destinationToolTip.InitialDelay = 500;
            this.destinationToolTip.ReshowDelay = 100;
            this.destinationToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.destinationToolTip.ToolTipTitle = "Destination";
            // 
            // sourceToolTip
            // 
            this.sourceToolTip.AutoPopDelay = 32767;
            this.sourceToolTip.InitialDelay = 500;
            this.sourceToolTip.ReshowDelay = 100;
            this.sourceToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.sourceToolTip.ToolTipTitle = "Source";
            // 
            // filtersToolTip
            // 
            this.filtersToolTip.AutoPopDelay = 32767;
            this.filtersToolTip.InitialDelay = 500;
            this.filtersToolTip.ReshowDelay = 100;
            this.filtersToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.filtersToolTip.ToolTipTitle = "Filters";
            // 
            // BackfillDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 466);
            this.Controls.Add(this.queryEditor);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackfillDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Run Back Fill Query";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackfillDialog_FormClosing);
            this.Load += new System.EventHandler(this.BackFillDialog_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtersInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillTypeInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ScintillaNET.Scintilla queryEditor;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.PictureBox tagsInfo;
        private System.Windows.Forms.PictureBox fillTypeInfo;
        private System.Windows.Forms.PictureBox intervalInfo;
        private System.Windows.Forms.ComboBox destinationComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.ComboBox sourceComboBox;
        private System.Windows.Forms.Label fillTypeLabel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.TextBox tagsTextBox;
        private System.Windows.Forms.ComboBox fillTypeComboBox;
        private System.Windows.Forms.Label databaseValue;
        private System.Windows.Forms.Label databaseLabel;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.Label fromTimeLabel;
        private System.Windows.Forms.Label toTimeLabel;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.PictureBox sourceInfo;
        private System.Windows.Forms.PictureBox destinationInfo;
        private System.Windows.Forms.PictureBox filtersInfo;
        private System.Windows.Forms.Label filtersLabel;
        private System.Windows.Forms.TextBox filtersTextBox;
        private System.Windows.Forms.ToolTip intervalToolTip;
        private System.Windows.Forms.ToolTip fillTypeToolTip;
        private System.Windows.Forms.ToolTip tagsToolTip;
        private System.Windows.Forms.ToolTip destinationToolTip;
        private System.Windows.Forms.ToolTip sourceToolTip;
        private System.Windows.Forms.ToolTip filtersToolTip;
    }
}