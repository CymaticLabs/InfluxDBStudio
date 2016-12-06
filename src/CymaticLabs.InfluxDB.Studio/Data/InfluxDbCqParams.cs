using System.Collections.Generic;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Contains the parameters necessary to create a new InfluxDB Continuous Query.
    /// </summary>
    public class InfluxDbCqParams
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the continuous query.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the database the continuous query is for.
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Gets or sets the list of the continuous query's subqueries/downsamplers.
        /// </summary>
        /// <example>MEAN("raw_field") AS avg_field</example>
        public IEnumerable<string> SubQueries { get; set; }

        /// <summary>
        /// Gets or sets the name of the destination measurement to insert continuous query values into.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the name of the source measurement to select values from.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the continuous query interval (1d, 2h, 30m, 15s, etc.).
        /// </summary>
        public string Interval { get; set; }

        /// <summary>
        /// Gets or sets the list of tags to carry over to the destination measurement.
        /// This is an optional property.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="InfluxDbFillTypes">fill type</see> for time intervals with no data.
        /// </summary>
        public InfluxDbFillTypes FillType { get; set; }

        /// <summary>
        /// Gets or sets the RESAMPLE EVERY interval which is part of continuous query advanced syntax.
        /// This is an optional property.
        /// </summary>
        public string ResampleEveryInterval { get; set; }

        /// <summary>
        /// Gets or sets the RESAMPLE FOR interval which is part of continuous query advanced syntax.
        /// This is an optional property.
        /// </summary>
        public string ResampleForInterval { get; set; }

        #endregion Properties
    }
}
