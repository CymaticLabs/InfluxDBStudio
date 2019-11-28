using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CymaticLabs.InfluxDB.Studio.Controls;

namespace CymaticLabs.InfluxDB.Studio.Dialogs
{
    public partial class SelectCsvDelimiter : Form
    {
        #region Fields

        #endregion Fields

        #region Properties
        public string CsvDelimiter { get; private set; }

        #endregion Properties

        #region Constructors

        public SelectCsvDelimiter()
        {
            InitializeComponent();
        }

        public SelectCsvDelimiter(string csvDelimiter) : this()
        {
            if (csvDelimiter != null)
            {
                CsvDelimiter = csvDelimiter;
            }

            this.comboBox1.SelectedIndex = this.comboBox1.FindString(CsvDelimiter);
        }

        #endregion Constructors

        #region Event Handlers

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            CsvDelimiter = comboBox1.SelectedItem.ToString();
        }

        #endregion Event Handlers

        public static void SelectCsv(Form parentForm)
        {
            using (var selectCsvDelimiter = new SelectCsvDelimiter(AppForm.Settings.CsvDelimiter))
            {
                selectCsvDelimiter.DialogResult = DialogResult.Cancel;
                selectCsvDelimiter.StartPosition = FormStartPosition.CenterParent;

                var dialogResult = selectCsvDelimiter.ShowDialog(parentForm);
                if (dialogResult == DialogResult.OK)
                {
                    AppForm.Settings.CsvDelimiter = selectCsvDelimiter.CsvDelimiter;
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
