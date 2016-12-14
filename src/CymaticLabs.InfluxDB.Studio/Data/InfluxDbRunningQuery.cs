using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Stores information about a presently running query on the InfluxDB server.
    /// </summary>
    public class InfluxDbRunningQuery
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// The query's process ID.
        /// </summary>
        public int PID { get; private set; }

        /// <summary>
        /// The database the query is running against.
        /// </summary>
        public string Database { get; private set; }

        /// <summary>
        /// How long the query has been running on the server.
        /// </summary>
        public string Duration { get; private set; }

        /// <summary>
        /// The body of the query that is running.
        /// </summary>
        public string Query { get; private set; }

        #endregion Properties

        #region Constructors

        public InfluxDbRunningQuery(int pid, string database, string durartion, string query)
        {
            PID = pid;
            Database = database;
            Duration = durartion;
            Query = query;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
