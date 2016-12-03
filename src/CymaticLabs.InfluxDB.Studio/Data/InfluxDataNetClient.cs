using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfluxData.Net.InfluxDb.Enums;
using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb.Models;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// InfluxData.NET implementation.
    /// </summary>
    public class InfluxDataNetClient : InfluxDbClient
    {
        #region Fields

        // The underlying InfluxData.NET client connection
        private InfluxData.Net.InfluxDb.InfluxDbClient influx;

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates an InfluxDB client using the given InfluxDB connection information.
        /// </summary>
        /// <param name="connection">The InfluxDB connection configuration to use with the client.</param>
        public InfluxDataNetClient(InfluxDbConnection connection) :
            base(connection)
        {
            // Create the underlying concrete client
            var c = connection;

            influx = new InfluxData.Net.InfluxDb.InfluxDbClient(c.HttpConnectionString, 
                c.Username, c.Password, InfluxDbVersion.Latest);
        }

        #endregion Constructors

        #region Methods

        #region Databases

        /// <summary>
        /// Gets a list of database names for the current connection.
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable<string>> GetDatabaseNamesAsync()
        {
            var databases = await influx.Database.GetDatabasesAsync().ConfigureAwait(false);
            return (from db in databases select db.Name);
        }

        /// <summary>
        /// Creates a new database with the given name.
        /// </summary>
        /// <param name="database">The name of the database to create.</param>
        /// <returns>An API response for the write request.</returns>
        public async override Task<InfluxDbApiResponse> CreateDatabaseAsync(string database)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            var response = await influx.Database.CreateDatabaseAsync(database).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Drops an existing database given its name.
        /// </summary>
        /// <param name="database">The name of the database to drop.</param>
        /// <returns>An API response for the write request.</returns>
        public async override Task<InfluxDbApiResponse> DropDatabaseAsync(string database)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            var response = await influx.Database.DropDatabaseAsync(database).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        #endregion Databases

        #region Measurements

        /// <summary>
        /// Gets a list of database names for the current connection.
        /// </summary>
        /// <param name="database">The name of the database to get measurement names for.</param>
        /// <returns>A list of measurement names for the given database.</returns>
        public async override Task<IEnumerable<string>> GetMeasurementNamesAsync(string database)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            var measurements = await influx.Serie.GetMeasurementsAsync(database).ConfigureAwait(false);
            return (from m in measurements select m.Name);
        }

        /// <summary>
        /// Drops the series in a particular database and optional measurement.
        /// </summary>
        /// <param name="database">The database to drop the series from.</param>
        /// <param name="measurement">The measurement to drop the series from.</param>
        /// <returns>An API response for the write request.</returns>
        public async override Task<InfluxDbApiResponse> DropMeasurementAsync(string database, string measurement)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            if (string.IsNullOrWhiteSpace(measurement)) throw new ArgumentNullException("measurement");
            var response = await influx.Serie.DropMeasurementAsync(database, measurement).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Gets the list of tag keys for a specified measurement.
        /// </summary>
        /// <param name="database">The database to use.</param>
        /// <param name="measurement">The measurment to get tag keys for.</param>
        /// <returns>A list of tag keys/names for the specified measurment.</returns>
        public async override Task<IEnumerable<string>> GetTagKeysAsync(string database, string measurement)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            if (string.IsNullOrWhiteSpace(measurement)) throw new ArgumentNullException("measurement");
            var response = await influx.Serie.GetTagKeysAsync(database, measurement).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Gets the list of tag values for a specified measurement and tag.
        /// </summary>
        /// <param name="database">The database to use.</param>
        /// <param name="measurement">The measurment to get tag keys for.</param>
        /// <param name="tag">The name of the tag to get values for.</param>
        /// <returns>A list of tag keys/names for the specified measurment.</returns>
        public async override Task<IEnumerable<InfluxDbTagValue>> GetTagValuesAsync(string database, string measurement, string tag)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            if (string.IsNullOrWhiteSpace(measurement)) throw new ArgumentNullException("measurement");
            if (string.IsNullOrWhiteSpace(tag)) throw new ArgumentNullException("tag");
            var response = await influx.Serie.GetTagValuesAsync(database, measurement, tag).ConfigureAwait(false);
            return (from tv in response select new InfluxDbTagValue(tv.Name, tv.Value));
        }

        /// <summary>
        /// Gets the list of field keys for a specified measurement.
        /// </summary>
        /// <param name="database">The database to use.</param>
        /// <param name="measurement">The measurment to get field keys for.</param>
        /// <returns>A list of field keys/names for the specified measurment.</returns>
        public async override Task<IEnumerable<InfluxDbFieldKey>> GetFieldKeysAsync(string database, string measurement)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            if (string.IsNullOrWhiteSpace(measurement)) throw new ArgumentNullException("measurement");
            var response = await influx.Serie.GetFieldKeysAsync(database, measurement).ConfigureAwait(false);
            return (from fk in response select new InfluxDbFieldKey(fk.Name, fk.Type));
        }

        #endregion Measurements

        #region Series

        /// <summary>
        /// Gets a list of series set names for a given database and optionally measurement.
        /// </summary>
        /// <param name="database">The database to get series sets for.</param>
        /// <param name="measurement">The measurement to get series sets for.</param>
        /// <returns>A list of series names.</returns>
        public async override Task<IEnumerable<string>> GetSeriesNamesAsync(string database, string measurement = null)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            var response = await influx.Serie.GetSeriesAsync(database, measurement).ConfigureAwait(false);

            var seriesNames = new List<string>();

            foreach (var set in response)
            {
                foreach (var series in set.Series)
                {
                    seriesNames.Add(series.Key);
                }
            }

            return seriesNames;
        }

        /// <summary>
        /// Drops the series in a particular database and optional measurement.
        /// </summary>
        /// <param name="database">The database to drop the series from.</param>
        /// <param name="measurement">The measurement to drop the series from.</param>
        /// <returns>An API response for the write request.</returns>
        public async override Task<InfluxDbApiResponse> DropSeriesAsync(string database, string measurement = null)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            var response = await influx.Serie.DropSeriesAsync(database, measurement).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        #endregion Series

        #region Query

        /// <summary>
        /// Executes a query against the connection for the given database.
        /// </summary>
        /// <param name="database">The name of the database to query.</param>
        /// <param name="query">The query to execute.</param>
        /// <returns></returns>
        public async override Task<IEnumerable<InfluxDbQueryResult>> QueryAsync(string database, string query)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentNullException("query");

            var response = await influx.Client.QueryAsync(database, query).ConfigureAwait(false);
            var results = new List<InfluxDbQueryResult>(response.Count());

            foreach (var r in response)
            {
                results.Add(new InfluxDbQueryResult(r.Name, r.Columns, r.Tags, r.Values));
            }

            return results;
        }

        /// <summary>
        /// Gets the continuous queries for a given database.
        /// </summary>
        /// <param name="database">The name of the database.</param>
        /// <returns>The database's continous queries.</returns>
        public async override Task<IEnumerable<InfluxDbContinuousQuery>> GetContinousQueriesAsync(string database)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");

            var response = await influx.ContinuousQuery.GetContinuousQueriesAsync(database).ConfigureAwait(false);
            var results = new List<InfluxDbContinuousQuery>(response.Count());

            foreach (var cq in response)
            {
                results.Add(new InfluxDbContinuousQuery(cq.Name, cq.Query));
            }

            return results;
        }

        /// <summary>
        /// Creates a new Influx DB Continuous Query.
        /// </summary>
        /// <param name="cqParams">The parameters used to create the CQ.</param>
        /// <returns>The API response.</returns>
        public async override Task<InfluxDbApiResponse> CreateContinuousQueryAsync(InfluxDbCqParams cqParams)
        {
            if (cqParams == null) throw new ArgumentNullException("cqParams");

            // Validate
            if (string.IsNullOrWhiteSpace(cqParams.Name)) throw new ArgumentNullException("cqParams.Name");
            if (string.IsNullOrWhiteSpace(cqParams.Database)) throw new ArgumentNullException("cqParams.Database");
            if (string.IsNullOrWhiteSpace(cqParams.Destination)) throw new ArgumentNullException("cqParams.Destination");
            if (string.IsNullOrWhiteSpace(cqParams.Source)) throw new ArgumentNullException("cqParams.Source");
            if (string.IsNullOrWhiteSpace(cqParams.Interval)) throw new ArgumentNullException("cqParams.Interval");
            
            if (!InfluxDbHelper.IsTimeIntervalValid(cqParams.Interval))
                throw new ArgumentException("cqParams.Interval is invalid: " + cqParams.Interval);

            if (!string.IsNullOrWhiteSpace(cqParams.ResampleEveryInterval) 
                && !InfluxDbHelper.IsTimeIntervalValid(cqParams.ResampleEveryInterval))
            {
                throw new ArgumentException("cqParams.ResampleEveryInterval is invalid: " + cqParams.ResampleEveryInterval);
            }

            if (!string.IsNullOrWhiteSpace(cqParams.ResampleForInterval)
                && !InfluxDbHelper.IsTimeIntervalValid(cqParams.ResampleForInterval))
            {
                throw new ArgumentException("cqParams.ResampleForInterval is invalid: " + cqParams.ResampleForInterval);
            }

            // Copy values to InfluxData.Net equivalent
            var _cqParams = new CqParams()
            {
                CqName = cqParams.Name,
                DbName = cqParams.Database,
                DsSerieName = cqParams.Destination,
                SourceSerieName = cqParams.Source,
                Downsamplers = cqParams.SubQueries.ToList(),
                Interval = cqParams.Interval,
                FillType = (FillType)Enum.Parse(typeof(FillType), cqParams.FillType.ToString(), true),
                Tags = cqParams.Tags != null ? cqParams.Tags.ToList() : null,
            };

            // Add resample values if they exist
            if (!string.IsNullOrWhiteSpace(cqParams.ResampleEveryInterval)
                || !string.IsNullOrWhiteSpace(cqParams.ResampleForInterval))
            {
                _cqParams.Resample = new CqResampleParam()
                {
                    Every = cqParams.ResampleEveryInterval,
                    For = cqParams.ResampleForInterval
                };
            }

            // Execute the request and return response
            var response = await influx.ContinuousQuery.CreateContinuousQueryAsync(_cqParams).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Drops an existing Influx DB Continuous Query.
        /// </summary>
        /// <param name="database">The name of the database the Continuous Query belongs to.</param>
        /// <param name="cqName">The name of the Continuous Query to drop.</param>
        /// <returns>The API response.</returns>
        public async override Task<InfluxDbApiResponse> DropContinuousQueryAsync(string database, string cqName)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            if (string.IsNullOrWhiteSpace(cqName)) throw new ArgumentNullException("cqName");
            var response = await influx.ContinuousQuery.DeleteContinuousQueryAsync(database, cqName).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        #endregion Query

        #region Write

        /// <summary>
        /// Writes a point to the specified database and measurement.
        /// </summary>
        /// <param name="db">The name of the database to write to.</param>
        /// <param name="measurement">The name of the measurement to write to.</param>
        /// <param name="tags">The list of tag values to write.</param>
        /// <param name="fields">The list of field values to write.</param>
        /// <param name="timeStamp">The point's time stamp.</param>
        /// <param name="retentionPolicy">The retention policy to write to.</param>
        /// <returns>An API response for the write request.</returns>
        public async override Task<InfluxDbApiResponse> WriteAsync(string db, string measurement,
            IDictionary<string, object> tags, IDictionary<string, object> fields,
            DateTime timeStamp, string retentionPolicy = null)
        {
            var point = new InfluxDbPoint(measurement, tags, fields, timeStamp);
            return await WriteAsync(db, point, retentionPolicy).ConfigureAwait(false);
        }

        /// <summary>
        /// Writes a point to the specified database and measurement.
        /// </summary>
        /// <param name="database">The name of the database to write to.</param>
        /// <param name="point">The InfluxDB point to write.</param>
        /// <param name="retentionPolicy">The retention policy to write to.</param>
        /// <returns>An API response for the write request.</returns>
        public async override Task<InfluxDbApiResponse> WriteAsync(string database, InfluxDbPoint point, string retentionPolicy = null)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            var p = new Point() { Name = point.Measurement, Fields = point.Fields, Tags = point.Tags, Timestamp = point.TimeStamp };
            var response = await influx.Client.WriteAsync(database, p, retentionPolicy).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Writes a list of points to the specified database.
        /// </summary>
        /// <param name="database">The name of the database to write to.</param>
        /// <param name="points">The InfluxDB points to write.</param>
        /// <param name="retentionPolicy">The retention policy to write to.</param>
        /// <returns>An API response for the write request.</returns>
        public async override Task<InfluxDbApiResponse> WriteAsync(string database, IEnumerable<InfluxDbPoint> points, string retentionPolicy = null)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            if (points == null || points.Count() == 0) throw new ArgumentNullException("points cannot be null or empty");

            var list = new List<Point>(points.Count());

            foreach (var point in points)
            {
                var p = new Point() { Name = point.Measurement, Fields = point.Fields, Tags = point.Tags, Timestamp = point.TimeStamp };
                list.Add(p);
            }
            
            var response = await influx.Client.WriteAsync(database, list, retentionPolicy).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        #endregion Write

        #region Server

        /// <summary>
        /// Sends a ping request message to the InfluxDB server and returns the pong response.
        /// </summary>
        /// <returns>The server's response to the ping request.</returns>
        public async override Task<InfluxDbPingResponse> PingAsync()
        {
            var response = await influx.Diagnostics.PingAsync().ConfigureAwait(false);
            return new InfluxDbPingResponse(response.Success, response.ResponseTime, response.Version);
        }

        /// <summary>
        /// Gets diagnostic information from the InfluxDB server.
        /// </summary>
        /// <returns>The server's diagnostics information.</returns>
        public async override Task<InfluxDbDiagnostics> GetDiagnosticsAsync()
        {
            var response = await influx.Diagnostics.GetDiagnosticsAsync().ConfigureAwait(false);

            return new InfluxDbDiagnostics()
            {
                Branch = response.Build.Branch,
                BuildVersion = response.Build.Version,
                Commit = response.Build.Commit,
                CurrentTime = response.System.CurrentTime,
                GoArch = response.Runtime.GOARCH,
                GoMaxProc = response.Runtime.GOMAXPROCS,
                GoOs = response.Runtime.GOOS,
                GoVersion = response.Runtime.Version,
                Hostname = response.Network.Hostname,
                PID = response.System.PID,
                Started = response.System.Started,
                Uptime = response.System.Uptime,
            };
        }

        #endregion Server

        #region Users

        /// <summary>
        /// Gets a list of the current database users.
        /// </summary>
        public async override Task<IEnumerable<InfluxDbUser>> GetUsersAsync()
        {
            var response = await influx.User.GetUsersAsync().ConfigureAwait(false);
            return (from u in response select new InfluxDbUser(u.Name, u.IsAdmin));
        }

        /// <summary>
        /// Creates a new InfluxDB user with the given user name, password, and admin privileges.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="isAdmin">Whether or not to grant administrator privileges to the user.</param>
        public async override Task<InfluxDbApiResponse> CreateUserAsync(string username, string password, bool isAdmin)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username");
            var response = await influx.User.CreateUserAsync(username, password, isAdmin).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Drops an existing InfluxDB user with the given user name.
        /// </summary>
        /// <param name="username">The user's name.</param>
        public async override Task<InfluxDbApiResponse> DropUserAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username");
            var response = await influx.User.DropUserAsync(username).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Sets a user's password.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The password to set.</param>
        public async override Task<InfluxDbApiResponse> SetPasswordAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username");
            var response = await influx.User.SetPasswordAsync(username, password).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Gets a list of granted database privileges for a user.
        /// </summary>
        /// <param name="username">The name of the user to get granted privilges for.</param>
        public async override Task<IEnumerable<InfluxDbGrant>> GetPrivilegesAsync(string username)
        {
            var response = await influx.User.GetPrivilegesAsync(username).ConfigureAwait(false);
            return (from gp in response select new InfluxDbGrant(gp.Database, (InfluxDbPrivileges)((int)gp.Privilege)));
        }

        /// <summary>
        /// Grants administrator privileges to a user.
        /// </summary>
        /// <param name="username">The name of the user to grant privileges to.</param>
        /// <returns>The API response.</returns>
        public async override Task<InfluxDbApiResponse> GrantAdministratorAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username");
            var response = await influx.User.GrantAdministratorAsync(username).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Revokes administrator privileges from a user.
        /// </summary>
        /// <param name="username">The name of the user to revoke privileges from.</param>
        /// <returns>The API response.</returns>
        public async override Task<InfluxDbApiResponse> RevokeAdministratorAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username");
            var response = await influx.User.RevokeAdministratorAsync(username).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Grants a privilege to a user for a given database.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="privilege">The privilege to grant.</param>
        /// <param name="database">The name of the database the privilege is for.</param>
        /// <returns>The query response.</returns>
        public async override Task<InfluxDbApiResponse> GrantPrivilegeAsync(string username, 
            InfluxDbPrivileges privilege, string database)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username");
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            var p = (InfluxData.Net.InfluxDb.Enums.Privileges)((int)(privilege));
            var response = await influx.User.GrantPrivilegeAsync(username, p, database).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Revokes a privilege from a user for a given database.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="privilege">The privilege to revoke.</param>
        /// <param name="database">The name of the database the privilege should be revoked from.</param>
        /// <returns>The query response.</returns>
        public async override Task<InfluxDbApiResponse> RevokePrivilegeAsync(string username, 
            InfluxDbPrivileges privilege, string database)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username");
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            var p = (InfluxData.Net.InfluxDb.Enums.Privileges)((int)(privilege));
            var response = await influx.User.RevokePrivilegeAsync(username, p, database).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        #endregion Users

        #endregion Methods
    }
}
