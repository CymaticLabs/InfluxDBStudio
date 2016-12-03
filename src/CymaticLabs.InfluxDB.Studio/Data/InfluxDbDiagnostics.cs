using System;
using System.Text.RegularExpressions;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Contains diagnostics information for an InfluxDB server.
    /// </summary>
    public class InfluxDbDiagnostics
    {
        #region Properties

        /// <summary>
        /// The host name of the InfluxDB server.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// The InfluxDB branch.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// The InfluxDB commit.
        /// </summary>
        public string Commit { get; set; }

        /// <summary>
        /// The InfluxDB build version.
        /// </summary>
        public string BuildVersion { get; set; }

        /// <summary>
        /// The time at which the InfluxDB process was started.
        /// </summary>
        public DateTime Started { get; set; }

        /// <summary>
        /// The current InfluxDB server time.
        /// </summary>
        public DateTime CurrentTime { get; set; }

        /// <summary>
        /// The uptime of the InfluxDB process.
        /// </summary>
        public TimeSpan Uptime { get; set; }

        /// <summary>
        /// The InfluxDB process ID.
        /// </summary>
        public long PID { get; set; }

        /// <summary>
        /// The architecture of the InfluxDB GO runtime.
        /// </summary>
        public string GoArch { get; set; }

        /// <summary>
        /// The maximum number of processors available to the InfluxDB GO runtime.
        /// </summary>
        public long GoMaxProc { get; set; }

        /// <summary>
        /// The operating system of the InfluxDB GO runtime.
        /// </summary>
        public string GoOs { get; set; }

        /// <summary>
        /// The version of the InfluxDB GO runtime.
        /// </summary>
        public string GoVersion { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Parses a GO duration string. This is the type of string returned from an InfluxDB
        /// diagnostics query's "uptime" value.
        /// </summary>
        /// <param name="duration">The duration string to parse.</param>
        /// <returns>A positive <see cref="TimeSpan"/> if parses was successful, otherwise a negative one.</returns>
        public static TimeSpan ParseGoDuration(string duration)
        {
            try
            {
                int h = -1, m = -1, s = -1, ms = -1;
                Regex regex = new Regex("([0-9\\.]+)(.)");
                var matches = regex.Matches(duration);

                foreach (Match match in matches)
                {
                    var value = match.Groups[1].Value;
                    var units = match.Groups[2].Value;

                    if (units == "h")
                    {
                        h = int.Parse(value);
                    }
                    else if (units == "m")
                    {
                        m = int.Parse(value);
                    }
                    else if (units == "s")
                    {
                        var parsedSeconds = value.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                        s = int.Parse(parsedSeconds[0]);

                        //if (parsedSeconds.Length == 2)
                        //{
                        //    var _ms = parsedSeconds[1];
                        //    if (_ms.Length > 3) _ms = _ms.Substring(0, 3);
                        //    ms = int.Parse(_ms);
                        //}
                    }
                }

                return new TimeSpan(0, h > 0 ? h : 0, m > 0 ? m : 0, s > 0 ? s : 0, ms > 0 ? ms : 0);
            }
            catch
            {
                return new TimeSpan(0, 0, -1);
            }
        }

        #endregion Methods
    }
}
