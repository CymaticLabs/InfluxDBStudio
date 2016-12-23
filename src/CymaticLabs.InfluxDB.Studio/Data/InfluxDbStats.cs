using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Represents a collection of InfluxDB server statistics.
    /// </summary>
    public class InfluxDbStats
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// A list of server stats related to Continuous Queries.
        /// </summary>
        public IEnumerable<InfluxDbSeries> CQ { get; set; }

        /// <summary>
        /// A list of server stats related to the database engine.
        /// </summary>
        public IEnumerable<InfluxDbSeries> Engine { get; set; }

        /// <summary>
        /// A list of server stats related to shards.
        /// </summary>
        public IEnumerable<InfluxDbSeries> Shard { get; set; }

        /// <summary>
        /// A list of server stats related to the HTTP process.
        /// </summary>
        public IEnumerable<InfluxDbSeries> Httpd { get; set; }

        /// <summary>
        /// A list of server stats related to WAL storage.
        /// </summary>
        public IEnumerable<InfluxDbSeries> WAL { get; set; }

        /// <summary>
        /// A list of server stats related to database writes.
        /// </summary>
        public IEnumerable<InfluxDbSeries> Write { get; set; }

        /// <summary>
        /// A list of server stats related to the GoLang runtime.
        /// </summary>
        public IEnumerable<InfluxDbSeries> Runtime { get; set; }

        /// <summary>
        /// A list of server stats related to databases.
        /// </summary>
        public IEnumerable<InfluxDbSeries> Database { get; set; }

        /// <summary>
        /// A list of server stats related to the query executor.
        /// </summary>
        public IEnumerable<InfluxDbSeries> QueryExecutor { get; set; }

        /// <summary>
        /// A list of server stats related to subscriptions.
        /// </summary>
        public IEnumerable<InfluxDbSeries> Subscriber { get; set; }

        /// <summary>
        /// A list of server stats related to the TSM1 cache.
        /// </summary>
        public IEnumerable<InfluxDbSeries> Tsm1Cache { get; set; }

        /// <summary>
        /// A list of server stats related to the TSM1 filestore.
        /// </summary>
        public IEnumerable<InfluxDbSeries> Tsm1Filestore { get; set; }

        /// <summary>
        /// A list of server stats related to the TSM1 WAL storage.
        /// </summary>
        public IEnumerable<InfluxDbSeries> Tsm1Wal { get; set; }

        #endregion Properties

        #region Constructors

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
