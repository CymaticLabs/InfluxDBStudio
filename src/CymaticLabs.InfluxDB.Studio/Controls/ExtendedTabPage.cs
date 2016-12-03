using System.Drawing;
using System.Windows.Forms;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Custom tab page that allows for extra rendering and functionality.
    /// </summary>
    public class ExtendedTabPage : TabPage
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the optional tab image to render.
        /// </summary>
        public Image TabImage { get; set; }

        /// <summary>
        /// Gets the current <see cref="RequestControl"/> contained within the tab, if any.
        /// </summary>
        public RequestControl RequestControl
        {
            get { return Controls.Count > 0 ? Controls[0] as RequestControl : null; }
        }

        #endregion Properties

        #region Constructors

        public ExtendedTabPage()
            : this(null, null)
        { }

        public ExtendedTabPage(string tabText)
            : this(tabText, null)
        { }

        public ExtendedTabPage(string tabText, Image tabImage)
            : base(tabText)
        {
            TabImage = tabImage;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
