using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfluxData.Net.InfluxDb.Enums;
using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb.Models;
using InfluxData.Net.InfluxDb.Models.Responses;

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

        #region Retention Policies

        /// <summary>
        /// Gets the retention policies for a given database.
        /// </summary>
        /// <param name="database">The name of the database to get retention policies for.</param>
        /// <returns>The list of retention policies for the database.</returns>
        public async override Task<IEnumerable<InfluxDbRetentionPolicy>> GetRetentionPoliciesAsync(string database)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            var response = await influx.Retention.GetRetentionPoliciesAsync(database);

            return from rp in response
                   select new InfluxDbRetentionPolicy()
                   {
                       Database = database,
                       Default = rp.Default,
                       Duration = rp.Duration,
                       Name = rp.Name,
                       ReplicationCopies = rp.ReplicationCopies,
                       ShardGroupDuration = rp.ShardGroupDuration,
                   };
        }

        /// <summary>
        /// Creates a new retention policy for a given database.
        /// </summary>
        /// <param name="database">The name of the database to create the retention policy for.</param>
        /// <param name="policyName">The policy's name.</param>
        /// <param name="duration">The retention duration of data.</param>
        /// <param name="replication">The replication number for the policy.</param>
        /// <param name="isDefault">Whether or not this will be the default policy for the database.</param>
        /// <returns>The API response.</returns>
        public async override Task<InfluxDbApiResponse> CreateRetentionPolicyAsync(string database, string policyName, string duration, int replication, bool isDefault = false)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            if (string.IsNullOrWhiteSpace(policyName)) throw new ArgumentNullException("policyName");
            if (string.IsNullOrWhiteSpace(duration)) throw new ArgumentNullException("duration");
            if (replication <= 0) replication = 1;

            // Create the policy and get the response
            var response = await influx.Retention.CreateRetentionPolicyAsync(database, policyName, duration, replication).ConfigureAwait(false);

            // If the default was supplied, run a second query to alter and add the default status since InfluxData.NET doesn't allow for the default argument
            if (response != null && response.Success && isDefault)
            {
                var alterResponse = await influx.Client.QueryAsync(string.Format("ALTER RETENTION POLICY \"{0}\" ON \"{1}\" DEFAULT",database, policyName, database)).ConfigureAwait(false);
            }

            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Alters an existing retention policy for a given database.
        /// </summary>
        /// <param name="database">The name of the database the retention policy belongs to.</param>
        /// <param name="policyName">The policy's name to alter.</param>
        /// <param name="duration">The retention duration of data.</param>
        /// <param name="replication">The replication number for the policy.</param>
        /// <param name="isDefault">Whether or not this will be the default policy for the database.</param>
        /// <returns>The API response.</returns>
        public async override Task<InfluxDbApiResponse> AlterRetentionPolicyAsync(string database, string policyName, string duration, int replication, bool isDefault = false)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            if (string.IsNullOrWhiteSpace(policyName)) throw new ArgumentNullException("policyName");
            if (string.IsNullOrWhiteSpace(duration)) throw new ArgumentNullException("duration");
            if (replication <= 0) replication = 1;

            // Alter the policy and get the response
            var response = await influx.Retention.AlterRetentionPolicyAsync(database, policyName, duration, replication).ConfigureAwait(false);

            // If the default was supplied, run a second query to alter and add the default status since InfluxData.NET doesn't allow for the default argument
            if (response != null && response.Success && isDefault)
            {
                var alterResponse = await influx.Client.QueryAsync(string.Format("ALTER RETENTION POLICY \"{0}\" ON \"{1}\" DEFAULT",database, policyName, database)).ConfigureAwait(false);
            }

            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Drops an existing retention policy.
        /// </summary>
        /// <param name="database">The name of the database the retention policy belongs to.</param>
        /// <param name="policyName">The name of the retention policy to drop.</param>
        /// <returns>The API response.</returns>
        public async override Task<InfluxDbApiResponse> DropRetentionPolicyAsync(string database, string policyName)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            if (string.IsNullOrWhiteSpace(policyName)) throw new ArgumentNullException("policyName");

            var response = await influx.Retention.DropRetentionPolicyAsync(database, policyName);

            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        #endregion Retention Policies

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
        /// Gets a list of the currently running queries.
        /// </summary>
        /// <returns>A list of the currently running queries.</returns>
        public async override Task<IEnumerable<InfluxDbRunningQuery>> GetRunningQueriesAsync()
        {
            var response = await influx.Client.QueryAsync( "SHOW QUERIES", "_internal").ConfigureAwait(false);
            if (response.Count() == 0 || response.First().Values == null) return new InfluxDbRunningQuery[0];
            var results = response.First().Values;
            var queries = new List<InfluxDbRunningQuery>(results.Count);

            foreach (var r in results)
            {
                queries.Add(new InfluxDbRunningQuery(int.Parse(r[0].ToString()), r[2] as string, r[3] as string, r[1] as string));
            }

            return queries;
        }

        /// <summary>
        /// Kills a running query given its process ID.
        /// </summary>
        /// <returns>The API response.</returns>
        public async override Task<InfluxDbApiResponse> KillQueryAsync(int pid)
        {
            var response = await influx.RequestClient.PostQueryAsync(string.Format("KILL QUERY {0}", pid)).ConfigureAwait(false);
            return new InfluxDbApiResponse(response.Body, response.StatusCode, response.Success);
        }

        /// <summary>
        /// Executes a query against the connection for the given database.
        /// </summary>
        /// <param name="database">The name of the database to query.</param>
        /// <param name="query">The query to execute.</param>
        /// <returns></returns>
        public async override Task<IEnumerable<InfluxDbSeries>> QueryAsync(string database, string query)
        {
            if (string.IsNullOrWhiteSpace(database)) throw new ArgumentNullException("database");
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentNullException("query");

            var response = await influx.Client.QueryAsync(query, database).ConfigureAwait(false);
            var results = new List<InfluxDbSeries>(response.Count());

            foreach (var r in response)
            {
                results.Add(new InfluxDbSeries(r.Name, r.Columns, r.Tags, r.Values));
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

            if (cqParams.SubQueries == null || cqParams.SubQueries.Count() == 0 || string.IsNullOrWhiteSpace(cqParams.SubQueries.First()))
                throw new ArgumentException("cqParams.SubQueries needs at least one query.");

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

        /// <summary>
        /// Performs a backfill query on the database based on a given time range and backfill parameters.
        /// </summary>
        /// <param name="database">The name of the database to perform the backfill on.</param>
        /// <param name="backfillParams">The backfill parameters query.</param>
        /// <returns>The API response.</returns>
        public async override Task<InfluxDbApiResponse> BackfillAsync(string database, InfluxDbBackfillParams backfillParams)
        {
            if (backfillParams == null) throw new ArgumentNullException("backfillParams");

            // Validate
            if (string.IsNullOrWhiteSpace(backfillParams.Destination)) throw new ArgumentNullException("backfillParams.Destination");
            if (string.IsNullOrWhiteSpace(backfillParams.Source)) throw new ArgumentNullException("backfillParams.Source");
            if (string.IsNullOrWhiteSpace(backfillParams.Interval)) throw new ArgumentNullException("backfillParams.Interval");

            if (backfillParams.SubQueries == null || backfillParams.SubQueries.Count() == 0 || string.IsNullOrWhiteSpace(backfillParams.SubQueries.First()))
                throw new ArgumentException("backfillParams.SubQueries needs at least one query.");

            if (!InfluxDbHelper.IsTimeIntervalValid(backfillParams.Interval))
                throw new ArgumentException("backfillParams.Interval is invalid: " + backfillParams.Interval);

            // Copy values to InfluxData.Net equivalent
            var _bfParams = new BackfillParams()
            {
                DsSerieName = backfillParams.Destination,
                SourceSerieName = backfillParams.Source,
                Downsamplers = backfillParams.SubQueries.ToList(),
                Interval = backfillParams.Interval,
                TimeFrom = backfillParams.FromTime,
                TimeTo = backfillParams.ToTime,
                Filters = backfillParams.Filters != null ? backfillParams.Filters.ToList() : null,
                FillType = (FillType)Enum.Parse(typeof(FillType), backfillParams.FillType.ToString(), true),
                Tags = backfillParams.Tags != null ? backfillParams.Tags.ToList() : null,
            };

            // Execute the request and return response
            var response = await influx.ContinuousQuery.BackfillAsync(database, _bfParams).ConfigureAwait(false);
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
            var response = await influx.Client.WriteAsync(p, database,  retentionPolicy).ConfigureAwait(false);
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
            
            var response = await influx.Client.WriteAsync( list, database, retentionPolicy).ConfigureAwait(false);
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

        /// <summary>
        /// Gets server statistics from the InfluxDB server.
        /// </summary>
        /// <returns>The server's statistics.</returns>
        public async override Task<InfluxDbStats> GetStatsAsync()
        {
            var stats = await influx.Diagnostics.GetStatsAsync().ConfigureAwait(false);

            return new InfluxDbStats()
            {
                CQ = stats.CQ == null ? null : (from s in stats.CQ select ConvertSeries(s)),
                Database = stats.Database == null ? null : (from s in stats.Database select ConvertSeries(s)),
                Engine = stats.Engine == null ? null : (from s in stats.Engine select ConvertSeries(s)),
                Httpd = stats.Httpd == null ? null : (from s in stats.Httpd select ConvertSeries(s)),
                QueryExecutor = stats.QueryExecutor == null ? null : (from s in stats.QueryExecutor select ConvertSeries(s)),
                Runtime = stats.Runtime == null ? null : (from s in stats.Runtime select ConvertSeries(s)),
                Shard = stats.Shard == null ? null : (from s in stats.Shard select ConvertSeries(s)),
                Subscriber = stats.Subscriber == null ? null : (from s in stats.Subscriber select ConvertSeries(s)),
                Tsm1Cache = stats.Tsm1Cache == null ? null : (from s in stats.Tsm1Cache select ConvertSeries(s)),
                Tsm1Filestore = stats.Tsm1Filestore == null ? null : (from s in stats.Tsm1Filestore select ConvertSeries(s)),
                Tsm1Wal = stats.Tsm1Wal == null ? null : (from s in stats.Tsm1Wal select ConvertSeries(s)),
                WAL = stats.WAL == null ? null : (from s in stats.WAL select ConvertSeries(s)),
                Write = stats.Write == null ? null : (from s in stats.Write select ConvertSeries(s))
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
            if (response == null || response.Count() == 0) return new InfluxDbUser[0];
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

        #region Utility

        // Converts from InfluxData.NET serie to native
        InfluxDbSeries ConvertSeries(Serie serie)
        {
            return new InfluxDbSeries(serie.Name, serie.Columns, serie.Tags, serie.Values);
        }

        #endregion Utility

        #endregion Methods
    }
}
