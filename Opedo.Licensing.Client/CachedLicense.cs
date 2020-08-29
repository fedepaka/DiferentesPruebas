using System;
using System.Collections.Generic;
using System.Text;

namespace Opedo.Licensing.Client
{
    public class CachedLicense
    {
        public LicenseResponse License { get; set; }

        public string ProductIdentifier { get; set; }

        public DateTime CachedTimestamp { get; set; }

        //todo paka
        public string Email { get; set; }
    }
}
