using System;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Represents a tag value from a database measurement.
    /// </summary>
    public class InfluxDbTagValue
    {
        #region Fields

        /// <summary>
        /// The name of the tag that the value belongs to.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The value for the tag.
        /// </summary>
        public readonly string Value;

        #endregion Fields

        #region Constructors

        public InfluxDbTagValue(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            Name = name;
            Value = value;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
