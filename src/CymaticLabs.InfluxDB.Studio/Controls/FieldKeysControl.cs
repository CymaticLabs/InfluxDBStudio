using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Renders the field keys for a given measurement.
    /// </summary>
    public partial class FieldKeysControl : MeasurementControl
    {
        #region Fields

        #endregion Fields

        #region Properties

        public override string ExportFileNameStem { get { return "field_keys"; } }

        #endregion Properties

        #region Constructors

        public FieldKeysControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        protected async override Task OnExecuteQuery()
        {
            // Get field keys from the server
            var fieldKeys = await InfluxDbClient.GetFieldKeysAsync(Database, Measurement);
            if (fieldKeys == null || fieldKeys.Count() == 0) return;

            // Add default row count column
            listView.Columns.Add(new ColumnHeader() { Text = "#" });

            // Add tag key column
            listView.Columns.Add(new ColumnHeader() { Text = "fieldKey" });

            // Add tag key column
            listView.Columns.Add(new ColumnHeader() { Text = "fieldType" });

            // Add values
            var rowCount = 0;

            foreach (var fk in fieldKeys)
            {
                listView.Items.Add(new ListViewItem(new string[] { (++rowCount).ToString(), fk.Name, fk.Type }) {Tag = fk });
            }
        }

        #endregion Methods
    }
}
