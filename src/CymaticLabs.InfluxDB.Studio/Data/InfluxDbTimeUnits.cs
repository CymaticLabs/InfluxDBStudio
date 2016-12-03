namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Different time interval units supported by InfluxDb: u, ms, s, m, h, d, w.
    /// </summary>
    public enum InfluxDbTimeUnits
    {
        /// <summary>
        /// No interval specified or an unknown/unsupported interval.
        /// </summary>
        None,

        /// <summary>
        /// Microsecond: u
        /// </summary>
        Microseconds,

        /// <summary>
        /// Millisecond: ms
        /// </summary>
        Milliseconds,

        /// <summary>
        /// Seconds: s
        /// </summary>
        Seconds,

        /// <summary>
        /// Minutes: m
        /// </summary>
        Minutes,

        /// <summary>
        /// Hours: h
        /// </summary>
        Hours,

        /// <summary>
        /// Days: d
        /// </summary>
        Days,

        /// <summary>
        /// Weeks: w
        /// </summary>
        Weeks,
    }
}
