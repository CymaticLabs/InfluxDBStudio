using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Base class for concrete implentnation to InfluxDB clients.
    /// </summary>
    public abstract class InfluxDbClient
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the InfluxDB connection configuration used by the client.
        /// </summary>
        public InfluxDbConnection Connection { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates an InfluxDB client using the given InfluxDB connection information.
        /// </summary>
        /// <param name="connection">The InfluxDB connection configuration to use with the client.</param>
        public InfluxDbClient(InfluxDbConnection connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            Connection = connection;
        }

        #endregion Constructors

        #region Methods

        #region Databases

        /// <summary>
        /// Gets a list of database names for the current connection.
        /// </summary>
        /// <returns>A list of database names in the current connection.</returns>
        public abstract Task<IEnumerable<string>> GetDatabaseNamesAsync();

        /// <summary>
        /// Creates a new database with the given name.
        /// </summary>
        /// <param name="database">The name of the database to create.</param>
        /// <returns>An API response for the write request.</returns>
        public abstract Task<InfluxDbApiResponse> CreateDatabaseAsync(string database);

        /// <summary>
        /// Drops an existing database given its name.
        /// </summary>
        /// <param name="database">The name of the database to drop.</param>
        /// <returns>An API response for the write request.</returns>
        public abstract Task<InfluxDbApiResponse> DropDatabaseAsync(string database);

        #endregion Databases

        #region Retention Policies

        /// <summary>
        /// Gets the retention policies for a given database.
        /// </summary>
        /// <param name="database">The name of the database to get retention policies for.</param>
        /// <returns>The list of retention policies for the database.</returns>
        public abstract Task<IEnumerable<InfluxDbRetentionPolicy>> GetRetentionPoliciesAsync(string database);

        /// <summary>
        /// Creates a new retention policy for a given database.
        /// </summary>
        /// <param name="database">The name of the database to create the retention policy for.</param>
        /// <param name="policyName">The policy's name.</param>
        /// <param name="duration">The retention duration of data.</param>
        /// <param name="replication">The replication number for the policy.</param>
        /// <param name="isDefault">Whether or not this will be the default policy for the database.</param>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> CreateRetentionPolicyAsync(string database, string policyName, string duration, int replication, bool isDefault = false);

        /// <summary>
        /// Alters an existing retention policy for a given database.
        /// </summary>
        /// <param name="database">The name of the database the retention policy belongs to.</param>
        /// <param name="policyName">The policy's name to alter.</param>
        /// <param name="duration">The retention duration of data.</param>
        /// <param name="replication">The replication number for the policy.</param>
        /// <param name="isDefault">Whether or not this will be the default policy for the database.</param>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> AlterRetentionPolicyAsync(string database, string policyName, string duration, int replication, bool isDefault = false);

        /// <summary>
        /// Drops an existing retention policy.
        /// </summary>
        /// <param name="database">The name of the database the retention policy belongs to.</param>
        /// <param name="policyName">The name of the retention policy to drop.</param>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> DropRetentionPolicyAsync(string database, string policyName);

        #endregion Retention Policies

        #region Measurements

        /// <summary>
        /// Gets a list of database names for the current connection.
        /// </summary>
        /// <param name="database">The name of the database to get measurement names for.</param>
        /// <returns>A list of measurement names for the given database.</returns>
        public abstract Task<IEnumerable<string>> GetMeasurementNamesAsync(string database);

        /// <summary>
        /// Drops the series in a particular database and optional measurement.
        /// </summary>
        /// <param name="database">The database to drop the series from.</param>
        /// <param name="measurement">The measurement to drop the series from.</param>
        /// <returns>An API response for the write request.</returns>
        public abstract Task<InfluxDbApiResponse> DropMeasurementAsync(string database, string measurement);

        /// <summary>
        /// Gets the list of tag keys for a specified measurement.
        /// </summary>
        /// <param name="database">The database to use.</param>
        /// <param name="measurement">The measurment to get tag keys for.</param>
        /// <returns>A list of tag keys/names for the specified measurment.</returns>
        public abstract Task<IEnumerable<string>> GetTagKeysAsync(string database, string measurement);

        /// <summary>
        /// Gets the list of tag values for a specified measurement and tag.
        /// </summary>
        /// <param name="database">The database to use.</param>
        /// <param name="measurement">The measurment to get tag keys for.</param>
        /// <param name="tag">The name of the tag to get values for.</param>
        /// <returns>A list of tag keys/names for the specified measurment.</returns>
        public abstract Task<IEnumerable<InfluxDbTagValue>> GetTagValuesAsync(string database, string measurement, string tag);

        /// <summary>
        /// Gets the list of field keys for a specified measurement.
        /// </summary>
        /// <param name="database">The database to use.</param>
        /// <param name="measurement">The measurment to get field keys for.</param>
        /// <returns>A list of field keys/names for the specified measurment.</returns>
        public abstract Task<IEnumerable<InfluxDbFieldKey>> GetFieldKeysAsync(string database, string measurement);

        #endregion Measurements

        #region Series

        /// <summary>
        /// Gets a list of series set names for a given database and optionally measurement.
        /// </summary>
        /// <param name="database">The database to get series sets for.</param>
        /// <param name="measurement">The measurement to get series sets for.</param>
        /// <returns>A list of series names.</returns>
        public abstract Task<IEnumerable<string>> GetSeriesNamesAsync(string database, string measurement = null);

        /// <summary>
        /// Drops the series in a particular database and optional measurement.
        /// </summary>
        /// <param name="database">The database to drop the series from.</param>
        /// <param name="measurement">The measurement to drop the series from.</param>
        /// <returns>An API response for the write request.</returns>
        public abstract Task<InfluxDbApiResponse> DropSeriesAsync(string database, string measurement = null);

        #endregion Series

        #region Query

        /// <summary>
        /// Gets a list of the currently running queries.
        /// </summary>
        /// <returns>A list of the currently running queries.</returns>
        public abstract Task<IEnumerable<InfluxDbRunningQuery>> GetRunningQueriesAsync();

        /// <summary>
        /// Kills a running query given its process ID.
        /// </summary>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> KillQueryAsync(int pid);

        /// <summary>
        /// Executes a query against the connection for the given database.
        /// </summary>
        /// <param name="database">The name of the database to query.</param>
        /// <param name="query">The query to execute.</param>
        /// <returns>The result of the query.</returns>
        public abstract Task<IEnumerable<InfluxDbSeries>> QueryAsync(string database, string query);

        /// <summary>
        /// Gets the continuous queries for a given database.
        /// </summary>
        /// <param name="database">The name of the database.</param>
        /// <returns>The database's continous queries.</returns>
        public abstract Task<IEnumerable<InfluxDbContinuousQuery>> GetContinousQueriesAsync(string database);

        /// <summary>
        /// Creates a new Influx DB Continuous Query.
        /// </summary>
        /// <param name="cqParams">The parameters used to create the CQ.</param>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> CreateContinuousQueryAsync(InfluxDbCqParams cqParams);

        /// <summary>
        /// Drops an existing Influx DB Continuous Query.
        /// </summary>
        /// <param name="database">The name of the database the Continuous Query belongs to.</param>
        /// <param name="cqName">The name of the Continuous Query to drop.</param>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> DropContinuousQueryAsync(string database, string cqName);

        /// <summary>
        /// Performs a backfill query on the database based on a given time range and backfill parameters.
        /// </summary>
        /// <param name="database">The name of the database to perform the backfill on.</param>
        /// <param name="backfillParams">The backfill parameters query.</param>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> BackfillAsync(string database, InfluxDbBackfillParams backfillParams);

        #endregion Query

        #region Write

        /// <summary>
        /// Writes a point to the specified database and measurement.
        /// </summary>
        /// <param name="database">The name of the database to write to.</param>
        /// <param name="measurement">The name of the measurement to write to.</param>
        /// <param name="tags">The list of tag values to write.</param>
        /// <param name="fields">The list of field values to write.</param>
        /// <param name="timeStamp">The point's time stamp.</param>
        /// <param name="retentionPolicy">The retention policy to write to.</param>
        /// <returns>An API response for the write request.</returns>
        public abstract Task<InfluxDbApiResponse> WriteAsync(string database, string measurement,
            IDictionary<string, object> tags, IDictionary<string, object> fields, DateTime timeStamp, string retentionPolicy = null);

        /// <summary>
        /// Writes a point to the specified database and measurement.
        /// </summary>
        /// <param name="database">The name of the database to write to.</param>
        /// <param name="point">The InfluxDB point to write.</param>
        /// <param name="retentionPolicy">The retention policy to write to.</param>
        /// <returns>An API response for the write request.</returns>
        public abstract Task<InfluxDbApiResponse> WriteAsync(string database, InfluxDbPoint point, string retentionPolicy = null);

        /// <summary>
        /// Writes a list of points to the specified database.
        /// </summary>
        /// <param name="database">The name of the database to write to.</param>
        /// <param name="points">The InfluxDB points to write.</param>
        /// <param name="retentionPolicy">The retention policy to write to.</param>
        /// <returns>An API response for the write request.</returns>
        public abstract Task<InfluxDbApiResponse> WriteAsync(string database, IEnumerable<InfluxDbPoint> points, string retentionPolicy = null);

        #endregion Write

        #region Server

        /// <summary>
        /// Sends a ping request message to the InfluxDB server and returns the pong response.
        /// </summary>
        /// <returns>The server's response to the ping request.</returns>
        public abstract Task<InfluxDbPingResponse> PingAsync();

        /// <summary>
        /// Gets diagnostic information from the InfluxDB server.
        /// </summary>
        /// <returns>The server's diagnostics information.</returns>
        public abstract Task<InfluxDbDiagnostics> GetDiagnosticsAsync();

        /// <summary>
        /// Gets server statistics from the InfluxDB server.
        /// </summary>
        /// <returns>The server's statistics.</returns>
        public abstract Task<InfluxDbStats> GetStatsAsync();

        #endregion Server

        #region Users

        /// <summary>
        /// Gets a list of the current system users.
        /// </summary>
        /// <returns>A list of system users.</returns>
        public abstract Task<IEnumerable<InfluxDbUser>> GetUsersAsync();

        /// <summary>
        /// Creates a new InfluxDB user with the given user name, password, and admin privileges.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="isAdmin">Whether or not to grant administrator privileges to the user.</param>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> CreateUserAsync(string username, string password, bool isAdmin);

        /// <summary>
        /// Drops an existing InfluxDB user with the given user name.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> DropUserAsync(string username);

        /// <summary>
        /// Sets a user's password.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The password to set.</param>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> SetPasswordAsync(string username, string password);

        /// <summary>
        /// Gets a list of granted database privileges for a user.
        /// </summary>
        /// <param name="username">The name of the user to get granted privilges for.</param>
        /// <returns>A list of granted privileges for the user.</returns>
        public abstract Task<IEnumerable<InfluxDbGrant>> GetPrivilegesAsync(string username);

        /// <summary>
        /// Grants administrator privileges to a user.
        /// </summary>
        /// <param name="username">The name of the user to grant privileges to.</param>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> GrantAdministratorAsync(string username);
        
        /// <summary>
        /// Revokes administrator privileges from a user.
        /// </summary>
        /// <param name="username">The name of the user to revoke privileges from.</param>
        /// <returns>The API response.</returns>
        public abstract Task<InfluxDbApiResponse> RevokeAdministratorAsync(string username);

        /// <summary>
        /// Grants a privilege to a user for a given database.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="privilege">The privilege to grant.</param>
        /// <param name="database">The name of the database the privilege is for.</param>
        /// <returns>The query response.</returns>
        public abstract Task<InfluxDbApiResponse> GrantPrivilegeAsync(string username, InfluxDbPrivileges privilege, string database);

        /// <summary>
        /// Revokes a privilege from a user for a given database.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="privilege">The privilege to revoke.</param>
        /// <param name="database">The name of the database the privilege should be revoked from.</param>
        /// <returns>The query response.</returns>
        public abstract Task<InfluxDbApiResponse> RevokePrivilegeAsync(string username, InfluxDbPrivileges privilege, string database);

        #endregion Users

        #endregion Methods
    }
}
