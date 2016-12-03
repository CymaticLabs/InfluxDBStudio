namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Different user database permissions.
    /// </summary>
    public enum InfluxDbPrivileges
    {
        /// <summary>
        /// No privileges specified; uninitialized privilege.
        /// </summary>
        None = 0,

        /// <summary>
        /// User can only read from the database.
        /// </summary>
        Read = 1,

        /// <summary>
        /// User can only write to the database.
        /// </summary>
        Write = 2,

        /// <summary>
        /// User can read and write to and from the database.
        /// </summary>
        All = 4,
    }
}
