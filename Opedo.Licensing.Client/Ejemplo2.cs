using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Opedo.Licensing.Client
{
    public static class Ejemplo2
    {
        private static LicenseResponse license;
        private static LicenseManager manager;

        //private static string email = "framirez@folderit.net";
        private static string email = "fedepaka@hotmail.com";

        private static Uri serverUri = new Uri("http://jsys.us.to:8003/Service");

        private static string identifier = "LM"; // LeanMail

        /// <summary>
        /// 
        /// </summary>
        public static async void Prueba2()
        {
            manager = new LicenseManager(serverUri, identifier)
            {
                // the length of time that is allowed to pass without having contact to the server can be customized
                MaximumTimeElapsedWithoutServerContact = TimeSpan.FromDays(14)
            };

            var licenciaGuardada = manager.TryGetSavedDataLicense(email);

            //si está guardada, validar que se haya actualizado hoy
            if (licenciaGuardada != null)
            {
                var x = licenciaGuardada.CachedTimestamp.AddDays(1).Date <= DateTime.Now.Date;

                if (x)
                {
                    await ConsultarLicencia();
                }
            }
            else
            {
                await ConsultarLicencia();
            }
        }

        public static async Task<LicenseResponse> Prueba3(string myEmail, string nombre, string apellido, string telefono)
        {
            email = string.IsNullOrEmpty(myEmail) ? email : myEmail.Trim();

            manager = new LicenseManager(serverUri, identifier)
            {
                // the length of time that is allowed to pass without having contact to the server can be customized
                MaximumTimeElapsedWithoutServerContact = TimeSpan.FromDays(14)
            };


            //recupero la licencia guardada
            var licenciaGuardada = manager.TryGetSavedDataLicense(email);

            if (licenciaGuardada != null)
            {

                if (string.IsNullOrEmpty(licenciaGuardada.Email) || licenciaGuardada.License.State == LicenseResponseState.Failure_NoLicense)
                {
                    // the user/company does not have a license for the product
                    // in this case you should prompt the user for if they want to create a trial account
                    try
                    {
                        license = await manager.CreateTrialAsync(email, nombre, apellido, telefono);
                        return license;
                    }
                    catch (Exception ex)
                    {
                        //consulto y actualizo caché
                        license = await ConsultarLicencia();
                        return license;
                    }
                }
                else
                {

                    if (email != licenciaGuardada.Email)
                    {
                        //consulto y actualizo caché
                        license = await ConsultarLicencia();

                    }
                    else
                    {
                        //si está guardada, validar que se haya actualizado hoy
                        var actualizadaRecientemente = licenciaGuardada.CachedTimestamp.AddDays(1).Date > DateTime.Now.Date;

                        if (!actualizadaRecientemente)
                        {
                            //consulto y actualizo caché
                            license = await ConsultarLicencia();
                        }
                        else
                        {
                            license = licenciaGuardada.License;
                        }
                    }

                    return license;
                }
            }
            else
            {
                //no está cacheada, entonces la consulto, guardo y devuelvo los módulos
                license = await ConsultarLicencia();
                return license;
            }
        }

        private static async Task<LicenseResponse> ConsultarLicencia()
        {

            //// create an instance of the licensing service
            //manager = new LicenseManager(serverUri, identifier)
            //{
            //    // the length of time that is allowed to pass without having contact to the server can be customized
            //    MaximumTimeElapsedWithoutServerContact = TimeSpan.FromDays(14)
            //};

            // NOTE: the methods for the license manager are all asynchronous
            // when the product starts, attempt to contact the server using the license manager
            license = await manager.GetLicenseAsync(email);

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
                    license = await manager.CreateTrialAsync(email, "juan", "perez", "+54 00000");

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
            return license;
        }
    }
}
