using System;
using System.Collections.Generic;

namespace Opedo.Licensing
{
    /// <summary>
    /// Represents a request to modify a license
    /// </summary>
    public class ModifyLicenseRequest
    {
        /// <summary>
        /// List of identifiers of modules that are requested.
        /// </summary>
        public List<string> Modules { get; set; }

        /// <summary>
        /// Modification guid of the license
        /// </summary>
        public Guid LicenseModificationGuid { get; set; }
    }
}
