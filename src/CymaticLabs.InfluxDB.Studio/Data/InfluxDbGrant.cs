using System;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// InfluxDB server granted database privileges.
    /// </summary>
    public class InfluxDbGrant
    {
        #region Fields

        /// <summary>
        /// The database name the granted privilege is for.
        /// </summary>
        public readonly string Database;

        /// <summary>
        /// The granted database privilege.
        /// </summary>
        public readonly InfluxDbPrivileges Privilege;

        #endregion Fields

        #region Constructors

        public InfluxDbGrant(string database, InfluxDbPrivileges privilege = InfluxDbPrivileges.None)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            Database = database;
            Privilege = privilege;
        }

        #endregion Constructors
    }
}
