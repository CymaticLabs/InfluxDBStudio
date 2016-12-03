using System;
using System.Collections.Generic;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Represents the result of an InfluxDB query.
    /// </summary>
    public class InfluxDbQueryResult
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the name of the resulting series.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the list of column names for the result.
        /// </summary>
        public IList<string> Columns { get; private set; }

        /// <summary>
        /// Gets the tag results for the query.
        /// </summary>
        public IDictionary<string, string> Tags { get; private set; }

        /// <summary>
        /// Gets the values for the query where the first level is the row and the second the columns.
        /// </summary>
        public IList<IList<object>> Values { get; private set; }

        #endregion Properties

        #region Constructors

        public InfluxDbQueryResult(string name, IList<string> columns, IDictionary<string, string> tags, IList<IList<object>> values)
        {
            //if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            if (columns == null) throw new ArgumentNullException("columns");
            if (tags == null) throw new ArgumentNullException("tags");
            if (values == null) throw new ArgumentNullException("values");

            Name = name;
            Columns = columns;
            Tags = tags;
            Values = values;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
