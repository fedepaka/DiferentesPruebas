using System;
using System.Collections.Generic;

namespace Opedo.Licensing
{
    /// <summary>
    /// Represents a response from a licensing server to a client
    /// </summary>
    public class LicenseResponse
    {
        /// <summary>
        /// State of the response - if successful or not
        /// </summary>
        public LicenseResponseState State { get; set; }

        /// <summary>
        /// If the request was not successful, contains an error message from the server describing
        /// the error state
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Date when the assigned license will expire. The client should only allow offline access until
        /// this time.
        /// </summary>
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Number of modules allowed by the license
        /// </summary>
        public int? AllocatedModuleCount { get; set; }

        /// <summary>
        /// If true the user should be allowed to select any modules to activate.
        /// If false, only those allowed in <see cref="Modules"/> are allowed
        /// </summary>
        public bool AllowAnyModule { get; set; }

        /// <summary>
        /// If true, allow the user to exceed the number of modules specified in <see cref="AllocatedModuleCount"/>
        /// </summary>
        public bool AllowExceedingModuleCount { get; set; }

        /// <summary>
        /// If true, allow the user to reassign what modules they are using.
        /// If false, the modules specified in <see cref="Modules"/> are always used.
        /// </summary>
        public bool AllowModuleReassignment { get; set; }

        /// <summary>
        /// List of identifiers of modules that are allowed for this license.
        /// </summary>
        public List<string> Modules { get; set; }

        /// <summary>
        /// Guid used when modifying the license assignment from the client
        /// </summary>
        public Guid? ModificationGuid { get; set; }
    }
}
