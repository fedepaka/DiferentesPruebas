using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Opedo.Licensing.Client
{
    public static class Example
    {
        private static LicenseResponse license;
        private static LicenseManager manager;

        public static async void Start()
        {
            // set the uri of the license server - should be stored in a configuration file or similar
            Uri serverUri = new Uri("http://jsys.us.to:8003/Service");

            // specify the identifier of the product
            // this must be unique across different products, but what it is exactly isn't important
            // as long as it is collaborated between the client and server
            string identifier = "LM"; // LeanMail

            // create an instance of the licensing service
            manager = new LicenseManager(serverUri, identifier)
            {

                // the length of time that is allowed to pass without having contact to the server can be customized
                MaximumTimeElapsedWithoutServerContact = TimeSpan.FromDays(14)
            };


            // the email address of the user starting the add-in should be available, and sent to
            // the license server
            string email = "fedepaka@gmail.com";

            // NOTE: the methods for the license manager are all asynchronous
            // when the product starts, attempt to contact the server using the license manager
            license = await manager.GetLicenseAsync(email);
            //license = await manager.c(email);

            // the license manager attempts to retrieve the license information from the server, but if it is not accessible
            // but has been in the past, cached license information is returned provided that the server has been reached in the past

            switch (license.State)
            {
                case LicenseResponseState.Failure:
                    // something went wrong - error message may be in returned data
                    throw new Exception("License error " + license.ErrorMessage);

                case LicenseResponseState.Failure_LicenseExpired:
                    // the license has expired - show an appropriate error message to the user
                    throw new Exception("License error " + license.ErrorMessage);

                case LicenseResponseState.Failure_NoLicense:
                    // the user/company does not have a license for the product
                    // in this case you should prompt the user for if they want to create a trial account
                    license = await manager.CreateTrialAsync(email, "Federico", "Ramirez", "+54 00000");

                    // check the response to make sure a trial was created
                    if (license.State != LicenseResponseState.Success_TrialCreated)
                        throw new Exception("Unable to create trial " + license.ErrorMessage);
                    break;

                case LicenseResponseState.Failure_NoModulesAvailable:
                    // there are no available module licenses for the company the user belongs to
                    throw new Exception("License error " + license.ErrorMessage);

                case LicenseResponseState.Success:
                    // a license was successfully returned;
                    break;
            }

            // the license object contains additional information on what the license allows the user to do

            // license.AllocatedModuleCount
            //   contains the number of module licenses allowed by the license; may be null in which case this is not limited
            // license.AllowAnyModule
            //   if true, allows any modules to be used rather than those explicitly specified
            // license.AllowExceedingModuleCount
            //   if true, allow the user to use more modules than specified in license.AllocatedModuleCount
            // license.AllowModuleReassignment
            //   if true, the application should allow the user to select what modules they would like to be enabled
            //   see the method below
            // license.ExpiryDate
            //   contains the expiration date for the license
            // license.ModificationGuid
            //   guid used to request modifications to the license if this is allowed (through AllowModuleReassignment)
            // license.Modules
            //   list of identifiers of the modules in the product that the license allows the user to use
            //   this should be used to enable/disable the modules, unless AllowAnyModule is true
        }

        public static async Task UpdateLicense()
        {
            // the identifiers for the modules are just like the identifier for the product, we simply need to
            // keep them unique and agree on them between the client and server
            // this should be equivalent to the modules the user has specified they'd like to use
            var moduleIdentifiers = new List<string>()
            {
                "LMIA", // InstantArchive
                "I480" // Inbox480
            };

            // once the user has been asked what modules they would like to use, send the identifiers
            // to the server to update the license
            license = await manager.UpdateLicenseAsync(license, moduleIdentifiers);

            // we also need to check that the server accepted the change
            if (license.State != LicenseResponseState.Success)
                throw new Exception("License server did not accept request: " + license.ErrorMessage);
        }

        
    }
}
