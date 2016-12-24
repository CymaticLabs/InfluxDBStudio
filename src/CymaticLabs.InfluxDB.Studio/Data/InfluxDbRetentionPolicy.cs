using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Represents a retention policy for a given database.
    /// </summary>
    public class InfluxDbRetentionPolicy
    {
        /// <summary>
        /// RP name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// RP database.
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// RP duration.
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// RP shard group duration.
        /// </summary>
        public string ShardGroupDuration { get; set; }

        /// <summary>
        /// RP replication copies.
        /// </summary>
        public int ReplicationCopies { get; set; }

        /// <summary>
        /// RP replication copies.
        /// </summary>
        public bool Default { get; set; }
    }
}
