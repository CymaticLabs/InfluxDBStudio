using System;
using System.Collections.Generic;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Represents a point in an InfluxDB database/measurement/series.
    /// </summary>
    public class InfluxDbPoint
    {
        #region Fields

        /// <summary>
        /// Gets the name of the measurement to use.
        /// </summary>
        public readonly string Measurement;

        /// <summary>
        /// Gets the points list of tag values.
        /// </summary>
        public readonly IDictionary<string, object> Tags;

        /// <summary>
        /// Gets the points list of field values.
        /// </summary>
        public readonly IDictionary<string, object> Fields;

        /// <summary>
        /// Gets the point's time stamp.
        /// </summary>
        public readonly DateTime TimeStamp;

        #endregion Fields

        #region Constructors

        public InfluxDbPoint(string measurement, 
            IDictionary<string, object> tags, IDictionary<string, object> fields, DateTime? timeStamp = null)
        {
            if (string.IsNullOrWhiteSpace(measurement)) throw new ArgumentNullException("measurement");
            Measurement = measurement;
            Tags = tags;
            Fields = fields;
            if (timeStamp == null) timeStamp = DateTime.UtcNow;
            TimeStamp = (DateTime)timeStamp;
        }

        #endregion Constructors
    }
}
