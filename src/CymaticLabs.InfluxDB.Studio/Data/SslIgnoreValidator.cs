using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Utility class used to ignore verifying SSL/TLS certificates.
    /// </summary>
    public static class SslIgnoreValidator
    {
        // Whether or not the SSL validator override has been enabled or not
        //private static bool enabled = true;

        // Whether or not to allow untrusted SSL/TLS certificates.
        private static bool allowUntrusted = true;

        /// <summary>
        /// Gets whether or not to allow untrusted SSL/TLS certificates.
        /// </summary>
        public static bool AllowUntrusted
        {
            get { return allowUntrusted; }
            
            set
            {
                allowUntrusted = value;

                // Configure untrusted allowances as needed
                OverrideValidation();
                //enabled = allowUntrusted;
            }
        }

        // Custom validation method
        private static bool OnValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors != SslPolicyErrors.None)
            {
                /*
                if (!allowUntrusted && sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors)
                {
                    return false;
                }
                */
                return (allowUntrusted ? true : false);
            }

            return true;
        }

        // Overrides SSL/TLS certificate validation.
        static void OverrideValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback = OnValidateCertificate;
            ServicePointManager.Expect100Continue = true;
        }
    }
}
