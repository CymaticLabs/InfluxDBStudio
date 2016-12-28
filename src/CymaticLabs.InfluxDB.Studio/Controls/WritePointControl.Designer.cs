namespace CymaticLabs.InfluxDB.Studio.Controls
{
    partial class WritePointControl
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
            this.measurementLabel = new System.Windows.Forms.Label();
            this.measurement = new System.Windows.Forms.ComboBox();
            this.tagKeyLabel = new System.Windows.Forms.Label();
            this.tagKey = new System.Windows.Forms.ComboBox();
            this.tagValueLabel = new System.Windows.Forms.Label();
            this.tagValue = new System.Windows.Forms.TextBox();
            this.addTagButton = new System.Windows.Forms.Button();
            this.tagsGroupBox = new System.Windows.Forms.GroupBox();
            this.tagsListView = new System.Windows.Forms.ListView();
            this.columnHeaderTagKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTagValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tagsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timestampLabel = new System.Windows.Forms.Label();
            this.timestamp = new System.Windows.Forms.DateTimePicker();
            this.fieldsGroupBox = new System.Windows.Forms.GroupBox();
            this.fieldsListView = new System.Windows.Forms.ListView();
            this.columnHeaderFieldKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFieldValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFieldType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fieldsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fieldTypeLabel = new System.Windows.Forms.Label();
            this.fieldKeyLabel = new System.Windows.Forms.Label();
            this.fieldValue = new System.Windows.Forms.TextBox();
            this.fieldValueLabel = new System.Windows.Forms.Label();
            this.fieldType = new System.Windows.Forms.ComboBox();
            this.addFieldButton = new System.Windows.Forms.Button();
            this.fieldKey = new System.Windows.Forms.ComboBox();
            this.nowButton = new System.Windows.Forms.Button();
            this.detailsGroupBox = new System.Windows.Forms.GroupBox();
            this.writeButton = new System.Windows.Forms.Button();
            this.removeSelectedTagMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllTagsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedFieldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllFieldsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagsGroupBox.SuspendLayout();
            this.tagsContextMenu.SuspendLayout();
            this.fieldsGroupBox.SuspendLayout();
            this.fieldsContextMenu.SuspendLayout();
            this.detailsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // measurementLabel
            // 
            this.measurementLabel.AutoSize = true;
            this.measurementLabel.Location = new System.Drawing.Point(14, 21);
            this.measurementLabel.Name = "measurementLabel";
            this.measurementLabel.Size = new System.Drawing.Size(74, 13);
            this.measurementLabel.TabIndex = 0;
            this.measurementLabel.Text = "Measurement:";
            // 
            // measurement
            // 
            this.measurement.FormattingEnabled = true;
            this.measurement.Location = new System.Drawing.Point(94, 18);
            this.measurement.Name = "measurement";
            this.measurement.Size = new System.Drawing.Size(163, 21);
            this.measurement.TabIndex = 2;
            this.measurement.SelectedIndexChanged += new System.EventHandler(this.measurement_SelectedIndexChanged);
            // 
            // tagKeyLabel
            // 
            this.tagKeyLabel.AutoSize = true;
            this.tagKeyLabel.Location = new System.Drawing.Point(14, 27);
            this.tagKeyLabel.Name = "tagKeyLabel";
            this.tagKeyLabel.Size = new System.Drawing.Size(28, 13);
            this.tagKeyLabel.TabIndex = 0;
            this.tagKeyLabel.Text = "Key:";
            // 
            // tagKey
            // 
            this.tagKey.FormattingEnabled = true;
            this.tagKey.Location = new System.Drawing.Point(48, 24);
            this.tagKey.Name = "tagKey";
            this.tagKey.Size = new System.Drawing.Size(130, 21);
            this.tagKey.TabIndex = 6;
            // 
            // tagValueLabel
            // 
            this.tagValueLabel.AutoSize = true;
            this.tagValueLabel.Location = new System.Drawing.Point(192, 27);
            this.tagValueLabel.Name = "tagValueLabel";
            this.tagValueLabel.Size = new System.Drawing.Size(37, 13);
            this.tagValueLabel.TabIndex = 0;
            this.tagValueLabel.Text = "Value:";
            // 
            // tagValue
            // 
            this.tagValue.Location = new System.Drawing.Point(235, 24);
            this.tagValue.Name = "tagValue";
            this.tagValue.Size = new System.Drawing.Size(153, 20);
            this.tagValue.TabIndex = 7;
            // 
            // addTagButton
            // 
            this.addTagButton.Location = new System.Drawing.Point(402, 22);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(47, 23);
            this.addTagButton.TabIndex = 8;
            this.addTagButton.Text = "Add";
            this.addTagButton.UseVisualStyleBackColor = true;
            this.addTagButton.Click += new System.EventHandler(this.addTagButton_Click);
            // 
            // tagsGroupBox
            // 
            this.tagsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsGroupBox.Controls.Add(this.tagsListView);
            this.tagsGroupBox.Controls.Add(this.tagKeyLabel);
            this.tagsGroupBox.Controls.Add(this.tagValueLabel);
            this.tagsGroupBox.Controls.Add(this.addTagButton);
            this.tagsGroupBox.Controls.Add(this.tagKey);
            this.tagsGroupBox.Controls.Add(this.tagValue);
            this.tagsGroupBox.Location = new System.Drawing.Point(3, 95);
            this.tagsGroupBox.Name = "tagsGroupBox";
            this.tagsGroupBox.Size = new System.Drawing.Size(596, 181);
            this.tagsGroupBox.TabIndex = 5;
            this.tagsGroupBox.TabStop = false;
            this.tagsGroupBox.Text = "Tags";
            // 
            // tagsListView
            // 
            this.tagsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTagKey,
            this.columnHeaderTagValue});
            this.tagsListView.ContextMenuStrip = this.tagsContextMenu;
            this.tagsListView.FullRowSelect = true;
            this.tagsListView.GridLines = true;
            this.tagsListView.HideSelection = false;
            this.tagsListView.Location = new System.Drawing.Point(6, 59);
            this.tagsListView.Name = "tagsListView";
            this.tagsListView.Size = new System.Drawing.Size(584, 116);
            this.tagsListView.TabIndex = 9;
            this.tagsListView.UseCompatibleStateImageBehavior = false;
            this.tagsListView.View = System.Windows.Forms.View.Details;
            this.tagsListView.SelectedIndexChanged += new System.EventHandler(this.tagsListView_SelectedIndexChanged);
            // 
            // columnHeaderTagKey
            // 
            this.columnHeaderTagKey.Text = "Tag Key";
            this.columnHeaderTagKey.Width = 275;
            // 
            // columnHeaderTagValue
            // 
            this.columnHeaderTagValue.Text = "Tag Value";
            this.columnHeaderTagValue.Width = 291;
            // 
            // tagsContextMenu
            // 
            this.tagsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedTagMenuItem,
            this.removeAllTagsMenuItem});
            this.tagsContextMenu.Name = "tagsContextMenu";
            this.tagsContextMenu.Size = new System.Drawing.Size(165, 48);
            // 
            // timestampLabel
            // 
            this.timestampLabel.AutoSize = true;
            this.timestampLabel.Location = new System.Drawing.Point(268, 21);
            this.timestampLabel.Name = "timestampLabel";
            this.timestampLabel.Size = new System.Drawing.Size(61, 13);
            this.timestampLabel.TabIndex = 0;
            this.timestampLabel.Text = "Timestamp:";
            // 
            // timestamp
            // 
            this.timestamp.CustomFormat = "d/MM/yyyy @ hh:mm:ss tt";
            this.timestamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timestamp.Location = new System.Drawing.Point(335, 18);
            this.timestamp.Name = "timestamp";
            this.timestamp.Size = new System.Drawing.Size(192, 20);
            this.timestamp.TabIndex = 3;
            // 
            // fieldsGroupBox
            // 
            this.fieldsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsGroupBox.Controls.Add(this.fieldsListView);
            this.fieldsGroupBox.Controls.Add(this.fieldTypeLabel);
            this.fieldsGroupBox.Controls.Add(this.fieldKeyLabel);
            this.fieldsGroupBox.Controls.Add(this.fieldValue);
            this.fieldsGroupBox.Controls.Add(this.fieldValueLabel);
            this.fieldsGroupBox.Controls.Add(this.fieldType);
            this.fieldsGroupBox.Controls.Add(this.addFieldButton);
            this.fieldsGroupBox.Controls.Add(this.fieldKey);
            this.fieldsGroupBox.Location = new System.Drawing.Point(6, 282);
            this.fieldsGroupBox.Name = "fieldsGroupBox";
            this.fieldsGroupBox.Size = new System.Drawing.Size(593, 190);
            this.fieldsGroupBox.TabIndex = 10;
            this.fieldsGroupBox.TabStop = false;
            this.fieldsGroupBox.Text = "Fields";
            // 
            // fieldsListView
            // 
            this.fieldsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFieldKey,
            this.columnHeaderFieldValue,
            this.columnHeaderFieldType});
            this.fieldsListView.ContextMenuStrip = this.fieldsContextMenu;
            this.fieldsListView.FullRowSelect = true;
            this.fieldsListView.GridLines = true;
            this.fieldsListView.HideSelection = false;
            this.fieldsListView.Location = new System.Drawing.Point(6, 54);
            this.fieldsListView.Name = "fieldsListView";
            this.fieldsListView.Size = new System.Drawing.Size(581, 130);
            this.fieldsListView.TabIndex = 15;
            this.fieldsListView.UseCompatibleStateImageBehavior = false;
            this.fieldsListView.View = System.Windows.Forms.View.Details;
            this.fieldsListView.SelectedIndexChanged += new System.EventHandler(this.fieldsListView_SelectedIndexChanged);
            // 
            // columnHeaderFieldKey
            // 
            this.columnHeaderFieldKey.Text = "Field Key";
            this.columnHeaderFieldKey.Width = 237;
            // 
            // columnHeaderFieldValue
            // 
            this.columnHeaderFieldValue.Text = "Field Value";
            this.columnHeaderFieldValue.Width = 245;
            // 
            // columnHeaderFieldType
            // 
            this.columnHeaderFieldType.Text = "Field Type";
            this.columnHeaderFieldType.Width = 85;
            // 
            // fieldsContextMenu
            // 
            this.fieldsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedFieldMenuItem,
            this.removeAllFieldsMenuItem});
            this.fieldsContextMenu.Name = "fieldsContextMenu";
            this.fieldsContextMenu.Size = new System.Drawing.Size(165, 70);
            // 
            // fieldTypeLabel
            // 
            this.fieldTypeLabel.AutoSize = true;
            this.fieldTypeLabel.Location = new System.Drawing.Point(398, 26);
            this.fieldTypeLabel.Name = "fieldTypeLabel";
            this.fieldTypeLabel.Size = new System.Drawing.Size(34, 13);
            this.fieldTypeLabel.TabIndex = 0;
            this.fieldTypeLabel.Text = "Type:";
            // 
            // fieldKeyLabel
            // 
            this.fieldKeyLabel.AutoSize = true;
            this.fieldKeyLabel.Location = new System.Drawing.Point(11, 26);
            this.fieldKeyLabel.Name = "fieldKeyLabel";
            this.fieldKeyLabel.Size = new System.Drawing.Size(28, 13);
            this.fieldKeyLabel.TabIndex = 0;
            this.fieldKeyLabel.Text = "Key:";
            // 
            // fieldValue
            // 
            this.fieldValue.Location = new System.Drawing.Point(268, 23);
            this.fieldValue.Name = "fieldValue";
            this.fieldValue.Size = new System.Drawing.Size(117, 20);
            this.fieldValue.TabIndex = 12;
            // 
            // fieldValueLabel
            // 
            this.fieldValueLabel.AutoSize = true;
            this.fieldValueLabel.Location = new System.Drawing.Point(225, 26);
            this.fieldValueLabel.Name = "fieldValueLabel";
            this.fieldValueLabel.Size = new System.Drawing.Size(37, 13);
            this.fieldValueLabel.TabIndex = 0;
            this.fieldValueLabel.Text = "Value:";
            // 
            // fieldType
            // 
            this.fieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fieldType.FormattingEnabled = true;
            this.fieldType.Items.AddRange(new object[] {
            "Float",
            "Integer",
            "Boolean",
            "String"});
            this.fieldType.Location = new System.Drawing.Point(438, 23);
            this.fieldType.Name = "fieldType";
            this.fieldType.Size = new System.Drawing.Size(72, 21);
            this.fieldType.TabIndex = 13;
            // 
            // addFieldButton
            // 
            this.addFieldButton.Location = new System.Drawing.Point(524, 21);
            this.addFieldButton.Name = "addFieldButton";
            this.addFieldButton.Size = new System.Drawing.Size(47, 23);
            this.addFieldButton.TabIndex = 14;
            this.addFieldButton.Text = "Add";
            this.addFieldButton.UseVisualStyleBackColor = true;
            this.addFieldButton.Click += new System.EventHandler(this.addFieldButton_Click);
            // 
            // fieldKey
            // 
            this.fieldKey.FormattingEnabled = true;
            this.fieldKey.Location = new System.Drawing.Point(50, 23);
            this.fieldKey.Name = "fieldKey";
            this.fieldKey.Size = new System.Drawing.Size(161, 21);
            this.fieldKey.TabIndex = 11;
            this.fieldKey.SelectedIndexChanged += new System.EventHandler(this.fieldKey_SelectedIndexChanged);
            // 
            // nowButton
            // 
            this.nowButton.Location = new System.Drawing.Point(539, 16);
            this.nowButton.Name = "nowButton";
            this.nowButton.Size = new System.Drawing.Size(45, 23);
            this.nowButton.TabIndex = 4;
            this.nowButton.Text = "Now";
            this.nowButton.UseVisualStyleBackColor = true;
            this.nowButton.Click += new System.EventHandler(this.nowButton_Click);
            // 
            // detailsGroupBox
            // 
            this.detailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsGroupBox.Controls.Add(this.measurementLabel);
            this.detailsGroupBox.Controls.Add(this.timestampLabel);
            this.detailsGroupBox.Controls.Add(this.timestamp);
            this.detailsGroupBox.Controls.Add(this.measurement);
            this.detailsGroupBox.Controls.Add(this.nowButton);
            this.detailsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsGroupBox.Location = new System.Drawing.Point(3, 41);
            this.detailsGroupBox.Name = "detailsGroupBox";
            this.detailsGroupBox.Size = new System.Drawing.Size(596, 48);
            this.detailsGroupBox.TabIndex = 1;
            this.detailsGroupBox.TabStop = false;
            this.detailsGroupBox.Text = "Details";
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(228, 12);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(198, 23);
            this.writeButton.TabIndex = 0;
            this.writeButton.Text = "Write Point";
            this.writeButton.UseVisualStyleBackColor = true;
            // 
            // removeSelectedTagMenuItem
            // 
            this.removeSelectedTagMenuItem.Name = "removeSelectedTagMenuItem";
            this.removeSelectedTagMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeSelectedTagMenuItem.Text = "Remove Selected";
            this.removeSelectedTagMenuItem.Click += new System.EventHandler(this.removeSelectedTagMenuItem_Click);
            // 
            // removeAllTagsMenuItem
            // 
            this.removeAllTagsMenuItem.Name = "removeAllTagsMenuItem";
            this.removeAllTagsMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeAllTagsMenuItem.Text = "Remove All";
            this.removeAllTagsMenuItem.Click += new System.EventHandler(this.removeAllTagsMenuItem_Click);
            // 
            // removeSelectedFieldMenuItem
            // 
            this.removeSelectedFieldMenuItem.Name = "removeSelectedFieldMenuItem";
            this.removeSelectedFieldMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeSelectedFieldMenuItem.Text = "Remove Selected";
            this.removeSelectedFieldMenuItem.Click += new System.EventHandler(this.removeSelectedFieldMenuItem_Click);
            // 
            // removeAllFieldsMenuItem
            // 
            this.removeAllFieldsMenuItem.Name = "removeAllFieldsMenuItem";
            this.removeAllFieldsMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeAllFieldsMenuItem.Text = "Remove All";
            this.removeAllFieldsMenuItem.Click += new System.EventHandler(this.removeAllFieldsMenuItem_Click);
            // 
            // WritePointControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.detailsGroupBox);
            this.Controls.Add(this.fieldsGroupBox);
            this.Controls.Add(this.tagsGroupBox);
            this.Name = "WritePointControl";
            this.Size = new System.Drawing.Size(605, 475);
            this.tagsGroupBox.ResumeLayout(false);
            this.tagsGroupBox.PerformLayout();
            this.tagsContextMenu.ResumeLayout(false);
            this.fieldsGroupBox.ResumeLayout(false);
            this.fieldsGroupBox.PerformLayout();
            this.fieldsContextMenu.ResumeLayout(false);
            this.detailsGroupBox.ResumeLayout(false);
            this.detailsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label measurementLabel;
        private System.Windows.Forms.ComboBox measurement;
        private System.Windows.Forms.Label tagKeyLabel;
        private System.Windows.Forms.ComboBox tagKey;
        private System.Windows.Forms.Label tagValueLabel;
        private System.Windows.Forms.TextBox tagValue;
        private System.Windows.Forms.Button addTagButton;
        private System.Windows.Forms.GroupBox tagsGroupBox;
        private System.Windows.Forms.ListView tagsListView;
        private System.Windows.Forms.ColumnHeader columnHeaderTagKey;
        private System.Windows.Forms.ColumnHeader columnHeaderTagValue;
        private System.Windows.Forms.Label timestampLabel;
        private System.Windows.Forms.DateTimePicker timestamp;
        private System.Windows.Forms.GroupBox fieldsGroupBox;
        private System.Windows.Forms.Label fieldKeyLabel;
        private System.Windows.Forms.TextBox fieldValue;
        private System.Windows.Forms.Label fieldValueLabel;
        private System.Windows.Forms.ComboBox fieldKey;
        private System.Windows.Forms.Button nowButton;
        private System.Windows.Forms.Label fieldTypeLabel;
        private System.Windows.Forms.ComboBox fieldType;
        private System.Windows.Forms.Button addFieldButton;
        private System.Windows.Forms.ListView fieldsListView;
        private System.Windows.Forms.ColumnHeader columnHeaderFieldKey;
        private System.Windows.Forms.ColumnHeader columnHeaderFieldValue;
        private System.Windows.Forms.ColumnHeader columnHeaderFieldType;
        private System.Windows.Forms.GroupBox detailsGroupBox;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.ContextMenuStrip tagsContextMenu;
        private System.Windows.Forms.ContextMenuStrip fieldsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedTagMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllTagsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedFieldMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllFieldsMenuItem;
    }
}
