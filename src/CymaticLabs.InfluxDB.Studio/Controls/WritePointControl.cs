using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Control used to write point data to a measurement/series.
    /// </summary>
    public partial class WritePointControl : UserControl
    {
        #region Fields

        // Used to hold the current list of field keys in memory
        IEnumerable<InfluxDbFieldKey> currentFieldKeys;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="InfluxDB.InfluxDbClient">InfluxDB connection</see> associated
        /// with the control.
        /// </summary>
        public InfluxDbClient InfluxDbClient { get; set; }

        /// <summary>
        /// Gets or sets the name of the database associated with the control.
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Gets or sets the name of the measurement associated with the control.
        /// </summary>
        public string Measurement { get; set; }

        #endregion Properties

        #region Constructors

        public WritePointControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Event Handlers

        // Handle update to timestamp
        private void nowButton_Click(object sender, EventArgs e)
        {
            timestamp.Value = DateTime.Now;
        }

        // Handle changes to selected measurement
        private async void measurement_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tagKey.Text = null;
                tagKey.Items.Clear();
                fieldKey.Text = null;
                fieldKey.Items.Clear();
                currentFieldKeys = null;

                if (measurement.SelectedItem == null) return;

                var tagKeys = await InfluxDbClient.GetTagKeysAsync(Database, measurement.SelectedItem.ToString());
                foreach (var tk in tagKeys) tagKey.Items.Add(tk);

                currentFieldKeys = await InfluxDbClient.GetFieldKeysAsync(Database, measurement.SelectedItem.ToString());
                foreach (var fk in currentFieldKeys) fieldKey.Items.Add(fk.Name);
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Handle changes to selected field key
        private void fieldKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentFieldKeys == null) return;

            // Go through and see if this is a known field key, and if so, automatically select its type
            var selectedFieldKey = (from fk in currentFieldKeys where fk.Name == fieldKey.Text select fk).FirstOrDefault();
            if (selectedFieldKey == null) return;

            for (var i = 0; i < fieldType.Items.Count; i++)
            {
                if (fieldType.Items[i].ToString().ToLower() == selectedFieldKey.Type)
                {
                    fieldType.SelectedIndex = i;
                    break;
                }
            }
        }

        // Handle add tag
        private void addTagButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(tagKey.Text))
                {
                    AppForm.DisplayError("Tag Key cannot be blank.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(tagValue.Text))
                {
                    AppForm.DisplayError("Tag Value cannot be blank.");
                    return;
                }

                // If the tag already exists, update it, otherwise add it
                foreach (ListViewItem li in tagsListView.Items)
                {
                    if (li.Text == tagKey.Text)
                    {
                        li.SubItems[1].Text = tagValue.Text;
                        tagValue.Text = null;
                        return;
                    }
                }

                tagsListView.Items.Add(new ListViewItem(new string[] { tagKey.Text, tagValue.Text }) { Tag = tagValue.Text });
                tagValue.Text = null;
                UpdateUIState();
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Handle add field
        private void addFieldButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(fieldKey.Text))
                {
                    AppForm.DisplayError("Field Key cannot be blank.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(fieldValue.Text))
                {
                    AppForm.DisplayError("Field Value cannot be blank.");
                    return;
                }

                // Parse the value
                var type = fieldType.SelectedItem.ToString().ToLower();
                object value = null;

                if (type == "float")
                {
                    value = float.Parse(fieldValue.Text);
                }
                else if (type == "integer")
                {
                    value = int.Parse(fieldValue.Text);
                }
                else if (type == "boolean")
                {
                    value = bool.Parse(fieldValue.Text);
                }

                // If the field already exists, update it, otherwise add it
                foreach (ListViewItem li in fieldsListView.Items)
                {
                    if (li.Text == fieldKey.Text)
                    {
                        li.SubItems[1].Text = fieldValue.Text;
                        li.SubItems[2].Text = fieldType.SelectedItem.ToString();
                        fieldValue.Text = null;
                        return;
                    }
                }

                fieldsListView.Items.Add(new ListViewItem(new string[] {
                    fieldKey.Text,
                    fieldValue.Text,
                    fieldType.SelectedItem.ToString()
                })
                { Tag = value });

                fieldValue.Text = null;
                UpdateUIState();
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        // Handle changes to tags list selection
        private void tagsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIState();
        }

        // Handle changes to fields list selection
        private void fieldsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIState();
        }

        // Handle remove selected tag
        private void removeSelectedTagMenuItem_Click(object sender, EventArgs e)
        {
            if (tagsListView.SelectedItems.Count == 0) return;
            tagsListView.SelectedItems[0].Remove();
            UpdateUIState();
        }

        // Handle remove all tags
        private void removeAllTagsMenuItem_Click(object sender, EventArgs e)
        {
            tagsListView.BeginUpdate();
            tagsListView.Items.Clear();
            tagsListView.EndUpdate();
            UpdateUIState();
        }

        // Handle remove selected field
        private void removeSelectedFieldMenuItem_Click(object sender, EventArgs e)
        {
            if (fieldsListView.SelectedItems.Count == 0) return;
            fieldsListView.SelectedItems[0].Remove();
            UpdateUIState();
        }

        // Handle remove all fields
        private void removeAllFieldsMenuItem_Click(object sender, EventArgs e)
        {
            fieldsListView.BeginUpdate();
            fieldsListView.Items.Clear();
            fieldsListView.EndUpdate();
            UpdateUIState();
        }

        #endregion Event Handlers

        #region Methods

        /// <summary>
        /// Resets the values on the form.
        /// </summary>
        public async Task ResetFormValues()
        {
            // Clear all values
            measurement.Items.Clear();
            tagKey.Items.Clear();
            tagValue.Text = null;
            fieldKey.Items.Clear();
            fieldValue.Text = null;
            fieldType.SelectedIndex = 0;
            timestamp.CustomFormat = string.Format("{0} @ {1}", AppForm.Settings.DateFormat, AppForm.Settings.TimeFormat);
            timestamp.Value = DateTime.Now;

            tagsListView.BeginUpdate();
            tagsListView.Items.Clear();
            tagsListView.EndUpdate();

            fieldsListView.BeginUpdate();
            fieldsListView.Items.Clear();
            fieldsListView.EndUpdate();

            // Query current database and select measurements
            if (string.IsNullOrWhiteSpace(Database)) return;

            var measurementNames = await InfluxDbClient.GetMeasurementNamesAsync(Database);

            foreach (var measurementName in measurementNames)
            {
                measurement.Items.Add(measurementName);
            }

            // If a measurement is specified, select that measurement
            if (!string.IsNullOrWhiteSpace(Measurement))
            {
                for (var i = 0; i < measurement.Items.Count; i++)
                {
                    if (measurement.Items[i].ToString() == Measurement)
                    {
                        measurement.SelectedIndex = i;
                        break;
                    }
                }
            }

            UpdateUIState();
        }

        // Updates the user interface based on the current state of the UI
        void UpdateUIState()
        {
            removeSelectedTagMenuItem.Enabled = tagsListView.SelectedItems.Count > 0;
            removeAllTagsMenuItem.Enabled = tagsListView.Items.Count > 0;

            removeSelectedFieldMenuItem.Enabled = fieldsListView.SelectedItems.Count > 0;
            removeAllFieldsMenuItem.Enabled = fieldsListView.Items.Count > 0;
        }

        #endregion Methods
    }
}
