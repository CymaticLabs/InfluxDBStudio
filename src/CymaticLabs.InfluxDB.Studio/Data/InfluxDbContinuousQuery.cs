using System;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// An InfluxDB continuous query.
    /// </summary>
    public class InfluxDbContinuousQuery
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the name of the continous query.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the body of the continous query.
        /// </summary>
        public string Query { get; private set; }

        #endregion Properties

        #region Constructors

        public InfluxDbContinuousQuery(string name, string query)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentNullException("query");

            Name = name;
            Query = query;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
