using System.ComponentModel;

namespace Opedo.Licensing
{
    /// <summary>
    /// Represents a request by a client for a license
    /// </summary>
    public class LicenseRequest
    {
        /// <summary>
        /// Email address uniquely identifying the user requesting a license
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Name of the local machine from where the originates
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// Name of the product the license request is for
        /// </summary>
        public string Product { get; set; }
    }
}
