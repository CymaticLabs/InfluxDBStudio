using System;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Represents the reply from a ping message sent to an InfluxDB server.
    /// </summary>
    public class InfluxDbPingResponse
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets whether or not the ping request was successfully received.
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// Gets the amount of time it took for the server to respond to the ping request.
        /// </summary>
        public TimeSpan ResponseTime { get; private set; }

        /// <summary>
        /// Gets the InfluxDB version that the server responded with.
        /// </summary>
        public string Version { get; private set; }

        #endregion Properties

        #region Constructors

        public InfluxDbPingResponse(bool success, TimeSpan responseTime, string version)
        {
            if (string.IsNullOrWhiteSpace(version)) throw new ArgumentNullException("version");
            Success = success;
            ResponseTime = responseTime;
            Version = version;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
