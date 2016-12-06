using System;
using System.Collections.Generic;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Contains parameter values needed to run a backfill query.
    /// </summary>
    public class InfluxDbBackfillParams
    {
        #region Properties

        /// <summary>
        /// Gets or sets the InfluxDB downsampling functions/fields for the "SELECT" part of the query.
        /// </summary>
        public IEnumerable<string> SubQueries { get; set; }

        /// <summary>
        /// Gets or sets the name of the destination measurement to insert values into.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the name of the source measurement to select values from.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the back fill query interval (1d, 2h, 30m, 15s, etc.).
        /// </summary>
        public string Interval { get; set; }

        /// <summary>
        /// Time from boundary.
        /// </summary>
        public DateTime FromTime { get; set; }

        /// <summary>
        /// Time to boundary.
        /// </summary>
        public DateTime ToTime { get; set; }

        /// <summary>
        /// List of "WHERE" clause filters.
        /// </summary>
        public IList<string> Filters { get; set; }

        /// <summary>
        /// Gets or sets the list of tags to carry over to the destination measurement.
        /// This is an optional property.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="InfluxDbFillTypes">fill type</see> for time intervals with no data.
        /// </summary>
        public InfluxDbFillTypes FillType { get; set; }

        #endregion Properties
    }
}
