using System;
using System.Text.RegularExpressions;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Static helper class for InfluxDB-related operations.
    /// </summary>
    public static class InfluxDbHelper
    {
        #region Fields

        //public const string 

        /// <summary>
        /// The string units for seconds in InfluxDB.
        /// </summary>
        public const string SecondsUnit = "s";

        /// <summary>
        /// The string units for milliseconds in InfluxDB.
        /// </summary>
        public const string MillisecondsUnit = "ms";

        /// <summary>
        /// The string units for microseconds in InfluxDB.
        /// </summary>
        public const string MicrosecondsUnit = "u";

        /// <summary>
        /// Regex used to validate time interval strings: 1h, 15m, 30s, etc.
        /// </summary>
        public static readonly Regex IntervalRegex = new Regex("([0-9\\.]+)(.)");

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Constructors

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Determine whether or not an InfluxDB time interval string is valid:
        /// "1h", "30m", "15s", etc.
        /// </summary>
        /// <param name="timeInterval">The time interval string to validate.</param>
        /// <returns>True if the string is a valid time interval, False if not.</returns>
        public static bool IsTimeIntervalValid(string timeInterval)
        {
            // Null string
            if (string.IsNullOrWhiteSpace(timeInterval)) return false;

            // Make sure the leading character is a number
            var fc = timeInterval[0];

            if (fc != '0' && fc != '1' && fc != '2' && fc != '3' && fc != '4' && fc != '5' && fc != '6' && fc != '7' && fc != '8' && fc != '9')
                return false;

            // Make sure the last character is a valid time unit character
            var lc = timeInterval[timeInterval.Length - 1];

            if (lc != 's' && lc != 'u' && lc != 'm' && lc != 'h' && lc != 'd' && lc != 'w')
                return false;

            // Otherwise parse with regex
            var matches = IntervalRegex.Match(timeInterval);

            // We should have just one match
            if (matches.Captures.Count != 1) return false;

            // We should have 3 groups: combined match, value match, units match ("10m", "10", "m")
            if (matches.Groups.Count != 3) return false;

            // Validate numeric value
            var rawValue = matches.Groups[1].Value;

            // Attempt to parse the value
            uint value;
            if (!uint.TryParse(rawValue, out value)) return false;

            // Validate units
            var units = matches.Groups[2].Value;
            return ConvertTimeUnit(units) != InfluxDbTimeUnits.None;
        }

        /// <summary>
        /// Converts a string time unit ("s", "m", "h", "d", etc.) into a <see cref="InfluxDbTimeUnits"/> value.
        /// </summary>
        /// <param name="unit">The string unit to convert.</param>
        /// <param name="throwIfInvalid">Whether or not the method will throw an exception if an invalid unit value is provided.</param>
        /// <returns>The matching enumeration value.
        /// <see cref="InfluxDbTimeUnits.None"/> if an invalid value is supplied and 'throwIfInvalid' is false.</returns>
        public static InfluxDbTimeUnits ConvertTimeUnit(string unit, bool throwIfInvalid = false)
        {
            if (string.IsNullOrWhiteSpace(unit)) throw new ArgumentNullException("unit");

            switch (unit.ToLower())
            {
                case "u":
                    return InfluxDbTimeUnits.Microseconds;

                case "ms":
                    return InfluxDbTimeUnits.Milliseconds;

                case "s":
                    return InfluxDbTimeUnits.Seconds;

                case "m":
                    return InfluxDbTimeUnits.Minutes;

                case "h":
                    return InfluxDbTimeUnits.Hours;

                case "d":
                    return InfluxDbTimeUnits.Days;

                case "w":
                    return InfluxDbTimeUnits.Weeks;
            }

            // Throw if requested
            if (throwIfInvalid) throw new ArgumentException("invalid time unit string: " + unit);

            // Otherwise just return "None"
            return InfluxDbTimeUnits.None;
        }

        /// <summary>
        /// Converts a <see cref="InfluxDbTimeUnits"/> value into its matching InfluxDB time unit string:
        /// "m", "s", "h", "d", etc.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static string ConvertTimeUnit(InfluxDbTimeUnits unit)
        {
            switch (unit)
            {
                case InfluxDbTimeUnits.Days:
                    return "d";

                case InfluxDbTimeUnits.Hours:
                    return "h";

                case InfluxDbTimeUnits.Microseconds:
                    return "u";

                case InfluxDbTimeUnits.Milliseconds:
                    return "ms";

                case InfluxDbTimeUnits.Minutes:
                    return "m";

                case InfluxDbTimeUnits.Seconds:
                    return "s";

                case InfluxDbTimeUnits.Weeks:
                    return "w";
            }

            throw new NotSupportedException("Unsupported time unit value: " + unit.ToString());
        }

        #endregion Methods
    }
}
