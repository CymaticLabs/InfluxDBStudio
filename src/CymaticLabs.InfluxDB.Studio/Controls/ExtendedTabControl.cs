using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CymaticLabs.InfluxDB.Studio.Controls
{
    /// <summary>
    /// Custom version of <see cref="TabControl"/> that adds the ability
    /// to close tabs and render custom icons on the tabs and other UI tweaks.
    /// </summary>
    public partial class ExtendedTabControl : TabControl
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets whether the user can close the tab manually.
        /// </summary>
        [Category("Behavior")]
        [Browsable(true)]
        [Description("Whether or not to render a close button on the tabs.")]
        public bool ShowTabCloseArea { get; set; }

        [Category("Appearance")]
        [Browsable(true)]
        [Description("The leading X offset where tab text is rendered within the tab.")]
        public int TabLeadingOffset { get; set; }

        [Category("Appearance")]
        [Browsable(true)]
        [Description("The leading X offset before the tab close button is rendered, if enabled.")]
        public int TabCloseSpace { get; set; }

        [Category("Appearance")]
        [Browsable(true)]
        [Description("The width of the close tab button/area.")]
        public int TabCloseWidth { get; set; }

        [Category("Appearance")]
        [Browsable(true)]
        [Description("The left/x offset of the tab image.")]
        public int TabImageLeft { get; set; }

        [Category("Appearance")]
        [Browsable(true)]
        [Description("The width of the tab image.")]
        public int TabImageWidth { get; set; }

        [Category("Appearance")]
        [Browsable(true)]
        [Description("The top/y offset of the tab image.")]
        public int TabImageTop { get; set; }

        [Category("Appearance")]
        [Browsable(true)]
        [Description("The height of the tab image.")]
        public int TabImageHeight { get; set; }

        #endregion Properties

        #region Events

        /// <summary>
        /// Occurs when a tab is opened.
        /// </summary>
        [Category("Behavior")]
        [Browsable(true)]
        [Description("Occurs when a new tab page is opened.")]
        public event EventHandler<TabPage> TabOpened;

        /// <summary>
        /// Occurs when a tab is closed.
        /// </summary>
        [Category("Behavior")]
        [Browsable(true)]
        [Description("Occurs when an existing tab page is closed.")]
        public event EventHandler<TabPage> TabClosed;

        #endregion Events

        #region Constructors

        public ExtendedTabControl()
        {
            // Initialize tab values
            TabLeadingOffset = 8;
            TabCloseSpace = 8;
            TabCloseWidth = 16;
            TabImageLeft = 4;
            TabImageWidth = 16;
            TabImageTop = 4;
            TabImageHeight = 16;

            InitializeComponent();

            // Hook into drawing custom tabs
            DrawItem += ExtendedTabControl_DrawItem;
            DrawMode = TabDrawMode.OwnerDrawFixed;
            SizeMode = TabSizeMode.Fixed;
        }

        #endregion Constructors

        #region Event Handlers

        // Handle tab control mouse up - used for custom close interaction
        private void ExtendedTabControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (!ShowTabCloseArea) return;

            Rectangle r = GetTabRect(SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - TabCloseWidth, r.Top + 4, 10, 10);

            if (closeButton.Contains(e.Location))
            {
                // Remove tab if a close click detected
                var tab = SelectedTab;
                TabPages.Remove(tab);

                // Notify
                if (TabClosed != null) TabClosed(this, tab);
            }
        }

        // Handle drawing of custom tab
        private void ExtendedTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            // If selected change font color
            var tab = TabPages[e.Index];
            var isSelected = SelectedIndex == e.Index;
            var brush = isSelected ? new SolidBrush(Color.FromArgb(0, 0, 0)) : new SolidBrush(Color.FromArgb(128, 128, 128));
            if (isSelected) e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(212, 212, 212)), new RectangleF(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height));

            // Render tab image if present
            if (tab is ExtendedTabPage)
            {
                var image = ((ExtendedTabPage)tab).TabImage;

                if (image != null)
                {
                    e.Graphics.DrawImage(image, e.Bounds.Left + TabImageLeft, e.Bounds.Top + TabImageTop + (isSelected ? 0 : -2));
                }
            }

            //This code will render a "x" mark at the end of the Tab caption.
            if (ShowTabCloseArea) e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - TabCloseWidth, e.Bounds.Top + 4);
            e.Graphics.DrawString(tab.Text, e.Font, brush, e.Bounds.Left + TabLeadingOffset + TabImageLeft + TabImageWidth, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        #endregion Event Handlers

        #region Methods

        /// <summary>
        /// Adds a new tab with the given control in it.
        /// </summary>
        /// <param name="tabText">The text to render on the tab.</param>
        /// <param name="control">The control to open in a new tab.</param>
        /// <param name="tabImage">The optional image to use with the tab.</param>
        /// <returns>Returns the created <see cref="TabPage"/>.</returns>
        public TabPage AddTabWithControl(string tabText, Control control, Image tabImage = null)
        {
            if (control == null) throw new ArgumentNullException("control");

            // Create the tab
            var tab = new ExtendedTabPage(tabText, tabImage);

            // Add the control
            tab.Controls.Add(control);
            control.Dock = DockStyle.Fill;

            // Add to tab pages
            TabPages.Add(tab);
            SelectedTab = tab;

            // Resize
            ResizeTabs();

            // Notify
            if (TabOpened != null) TabOpened(this, tab);

            return tab;
        }

        /// <summary>
        /// Resizes tabs for use with custom owner drawn tabs with close buttons.
        /// </summary>
        public void ResizeTabs()
        {
            int tabWidth = ItemSize.Width;

            // Adjust tab size based on tab text
            for (var i = 0; i < TabPages.Count; i++)
            {
                var tab = TabPages[i];

                int currentTabWidth = TextRenderer.MeasureText(tab.Text, Font).Width;
                currentTabWidth += TabLeadingOffset + TabCloseSpace + TabCloseWidth + TabImageLeft + TabImageWidth;
                if (currentTabWidth > tabWidth) tabWidth = currentTabWidth;
                
            }

            // Resize tabs to new width
            Size newTabSize = new Size(tabWidth, ItemSize.Height);
            ItemSize = newTabSize;
        }

        #endregion Methods
    }
}
