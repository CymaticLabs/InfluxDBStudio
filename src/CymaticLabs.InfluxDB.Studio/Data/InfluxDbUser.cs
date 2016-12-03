using System;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// A InfluxDB database user.
    /// </summary>
    public class InfluxDbUser
    {
        #region Fields

        /// <summary>
        /// The user's name.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Whether or not the user is a database administrator.
        /// </summary>
        public readonly bool IsAdmin;

        #endregion Fields

        #region Constructors

        public InfluxDbUser(string name, bool isAdmin)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            Name = name;
            IsAdmin = isAdmin;
        }

        #endregion Constructors
    }
}
