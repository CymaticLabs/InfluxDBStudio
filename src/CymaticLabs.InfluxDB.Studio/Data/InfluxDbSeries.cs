using System;
using System.Collections.Generic;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Represents the result of an InfluxDB query.
    /// </summary>
    public class InfluxDbSeries
    {
        #region Fields

        // Internal look-up of a column's index given its name
        Dictionary<string, int> columnIndexByName;

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

        public InfluxDbSeries(string name, IList<string> columns, IDictionary<string, string> tags, IList<IList<object>> values)
        {
            //if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            if (columns == null) throw new ArgumentNullException("columns");
            if (tags == null) throw new ArgumentNullException("tags");
            if (values == null) throw new ArgumentNullException("values");

            Name = name;
            Columns = columns;
            Tags = tags;
            Values = values;

            columnIndexByName = new Dictionary<string, int>();

            // Cache column name/index look-up
            if (columns.Count > 0)
            {
                for (var i = 0; i < columns.Count; i++)
                {
                    var colName = columns[i];
                    if (!columnIndexByName.ContainsKey(colName)) columnIndexByName.Add(colName, i);
                }
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets a column's index in the <see cref="Columns"/> list given its name.
        /// </summary>
        /// <param name="name">The column name to get the index for.</param>
        /// <returns>The column's index in the <see cref="Columns"/> list if found, otherwise -1.</returns>
        public int GetColumnIndex(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            return columnIndexByName.ContainsKey(name) ? columnIndexByName[name] : -1;
        }

        #endregion Methods
    }
}
