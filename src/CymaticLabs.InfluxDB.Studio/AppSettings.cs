using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CymaticLabs.InfluxDB.Data;

namespace CymaticLabs.InfluxDB.Studio
{
    /// <summary>
    /// Intermediate object used to import or export application settings.
    /// </summary>
    public class AppSettings
    {
        #region Fields

        /// <summary>
        /// Time format string for 12 hour time.
        /// </summary>
        public const string TimeFormat12Hour = "hh:mm:ss tt";

        /// <summary>
        /// Time format string for 24 hour time.
        /// </summary>
        public const string TimeFormat24Hour = "HH:mm:ss";

        /// <summary>
        /// Date format string for day-first dates.
        /// </summary>
        public const string DateFormatDay = "d/MM/yyyy";

        /// <summary>
        /// Date format string for month-first dates.
        /// </summary>
        public const string DateFormatMonth = "M/dd/yyyy";

        // Whether or not to allow untrusted SSL certificates
        bool allowUntrustedSsl = false;

        // Internal app time format setting
        string timeFormat;

        // Internal app date format setting
        string dateFormat;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the application version the settings are for/from.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Gets the current time format setting.
        /// </summary>
        public string TimeFormat
        {
            get { return timeFormat; }

            set
            {
                if (timeFormat != value)
                {
                    timeFormat = value;
                    Properties.Settings.Default.TimeFormat = timeFormat;
                    Properties.Settings.Default.Save(); // update settings file
                }
            }
        }

        /// <summary>
        /// Gets the current date format setting.
        /// </summary>
        public string DateFormat
        {
            get { return dateFormat; }

            set
            {
                if (dateFormat != value)
                {
                    dateFormat = value;
                    Properties.Settings.Default.DateFormat = dateFormat;
                    Properties.Settings.Default.Save(); // update settings file
                }
            }
        }

        /// <summary>
        /// Gets or sets whether or not the application should allow untrusted SSL certificates
        /// when communicating to InfluxDB servers.
        /// </summary>
        public bool AllowUntrustedSsl
        {
            get { return allowUntrustedSsl; }

            set
            {
                if (allowUntrustedSsl != value)
                {
                    allowUntrustedSsl = value;
                    Properties.Settings.Default.AllowUntrustedSsl = allowUntrustedSsl;
                    Properties.Settings.Default.Save(); // update settings file
                }
            }
        }

        /// <summary>
        /// Gets or sets the available InfluxDB connections.
        /// </summary>
        public List<InfluxDbConnection> Connections { get; set; }

        #endregion Properties

        #region Constructors

        public AppSettings()
        {
            // Initialize default settings
            timeFormat = TimeFormat12Hour;
            dateFormat = DateFormatMonth;
            allowUntrustedSsl = false;
            Connections = new List<InfluxDbConnection>();

            // Set the version string
            Version = GetType().Assembly.GetName().Version.ToString();

            // Upgrade settings as needed
            Properties.Settings.Default.Upgrade();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads settings from disk.
        /// </summary>
        public void LoadAll()
        {
            timeFormat = Properties.Settings.Default.TimeFormat;
            dateFormat = Properties.Settings.Default.DateFormat;
            allowUntrustedSsl = Properties.Settings.Default.AllowUntrustedSsl;
            LoadConnections();
        }

        /// <summary>
        /// Saves all current settings ti disk.
        /// </summary>
        public void SaveAll()
        {
            Properties.Settings.Default.TimeFormat = TimeFormat;
            Properties.Settings.Default.DateFormat = DateFormat;
            Properties.Settings.Default.AllowUntrustedSsl = AllowUntrustedSsl;
            SaveConnections();
        }

        /// <summary>
        /// Loads all connections data from disk.
        /// </summary>
        public void LoadConnections()
        {
            var json = Properties.Settings.Default.ConnectionsJson;
            var loadedConnections = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            Connections = new List<InfluxDbConnection>();

            if (loadedConnections is JArray)
            {
                var array = (JArray)loadedConnections;

                foreach (var item in array)
                {
                    try
                    {
                        // Convert to connection object
                        var connection = item.ToObject<InfluxDbConnection>();
                        if (connection != null) Connections.Add(connection);
                    }
                    catch (Exception ex)
                    {
                        AppForm.DisplayException(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Saves current connection data to disk.
        /// </summary>
        public void SaveConnections()
        {
            try
            {
                // Save to disk
                var json = JsonConvert.SerializeObject(Connections);
                Properties.Settings.Default.ConnectionsJson = json;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                AppForm.DisplayException(ex);
            }
        }

        #endregion Methods
    }
}
