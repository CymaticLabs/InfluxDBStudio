namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Different InfluxDB supported time precisions.
    /// </summary>
    public enum InfluxDbTimePrecisions
    {
        /// <summary>
        /// Unsupported or unspecified time precision.
        /// </summary>
        None,

        /// <summary>
        /// Microsecond precision (us/μs).
        /// </summary>
        Microseconds,

        /// <summary>
        /// Millisecond precision: (ms); InfluxDB default.
        /// </summary>
        Milliseconds,

        /// <summary>
        /// Seconds: (s).
        /// </summary>
        Seconds,
    }
}
