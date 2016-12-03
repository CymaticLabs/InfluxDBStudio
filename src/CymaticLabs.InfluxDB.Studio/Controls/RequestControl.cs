using System.Threading.Tasks;
using System.Windows.Forms;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Base class for controls that contain and carry out an InfluxDB API request.
    /// </summary>
    public partial class RequestControl : UserControl
    {
        #region Fields

        /// <summary>
        /// Text check mark used in UI.
        /// </summary>
        public const string CheckMark = "✓";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="InfluxDB.InfluxDbClient">InfluxDB connection</see> associated
        /// with the request.
        /// </summary>
        public InfluxDbClient InfluxDbClient { get; set; }

        /// <summary>
        /// Gets or sets the name of the database associated with the request.
        /// </summary>
        public string Database { get; set; }

        #endregion Properties

        #region Constructors

        public RequestControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// When overriden in derived classes, executes an InfluxDB API request and processes the result.
        /// </summary>
        public virtual async Task ExecuteRequestAsync() { }

        #endregion Methods
    }
}
