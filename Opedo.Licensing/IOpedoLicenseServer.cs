using System;
using System.Collections.Generic;
using System.Text;

namespace Opedo.Licensing
{
    public interface IOpedoLicenseServer
    {
        /// <summary>
        /// Request a new or existing license
        /// </summary>
        /// <param name="request">Object containing information on the license request</param>
        /// <returns></returns>
        LicenseResponse GetLicense(LicenseRequest request);

        /// <summary>
        /// Request modifications to an existing license
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        LicenseResponse UpdateLicense(ModifyLicenseRequest request);
    }
}
