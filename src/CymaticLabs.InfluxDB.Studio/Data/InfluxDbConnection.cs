using Newtonsoft.Json;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Represents the connection information required to connect to a specific InfluxDB server.
    /// </summary>
    public class InfluxDbConnection
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Sets the unique ID of the connction instance. Ideally this value
        /// does not changed once assigned.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the human-readable name of the connection.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the host URL for the InfluxDB server to connect to.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the port number to use when connecting to the InfluxDB server.
        /// </summary>
        public ushort Port { get; set; }

        /// <summary>
        /// The name of the preferred database to use (optional).
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Gets or sets the username to use when connecting to the InfluxDB server.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password to use when connecting to the InfluxDB server.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets whether or not to use SSL to communicate with the InfluxDB server.
        /// </summary>
        public bool UseSsl { get; set; }

        /// <summary>
        /// Gets the combined/unified host connection string including protocol and port number for
        /// HTTP API access to the InfluxDB server.
        /// </summary>
        [JsonIgnore]
        public string HttpConnectionString
        {
            get
            {
                return string.Format("{0}://{1}:{2}", UseSsl ? "https" : "http", Host, Port);
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates an InfluxDB connection with the provided configuration details.
        /// </summary>
        /// <param name="id">A unique ID to assign the connection.</param>
        /// <param name="name">The human-readable name for the connection.</param>
        /// <param name="host">The host URL for the InfluxDB server to connect to.</param>
        /// <param name="port">The port number to use when connecting to the InfluxDB server.</param>
        /// <param name="username">The username to use when connecting to the InfluxDB server.</param>
        /// <param name="password">The password to use when connecting to the InfluxDB server.</param>
        /// <param name="useSsl">Whether or not to use SSL to communicate with the InfluxDB server.</param>
        /// <param name="database">The name of the preferred database to use (optional).</param>
        public InfluxDbConnection(string id, string name, string host, ushort port, 
            string username, string password, bool useSsl = true, string database = null)
        {
            Id = id;
            Name = name;
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            UseSsl = useSsl;
            Database = database;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
