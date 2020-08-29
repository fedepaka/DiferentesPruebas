using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Opedo.Licensing.Client
{
    /// <summary>
    /// Main entry point for the license manager
    /// </summary>
    public class LicenseManager : IDisposable
    {
        private readonly HttpClient _client;
        private readonly ILicensePersistLayer _licensePersistLayer;

        /// <summary>
        /// Create a new license manager for the specified server <see cref="Uri"/> and for a specified product.
        /// </summary>
        /// <param name="serverUri">Uri to the license server to connect to</param>
        /// <param name="productIdentifier">Identifier for the product to handle licenses for</param>
        public LicenseManager(Uri serverUri, string productIdentifier)
            : this(serverUri, productIdentifier, new XmlFileEncryptedLicensePersistLayer())
        {

        }

        /// <summary>
        /// Create a new license manager for the specified server <see cref="Uri"/> and for a specified product.
        /// </summary>
        /// <param name="serverUri">Uri to the license server to connect to</param>
        /// <param name="productIdentifier">Identifier for the product to handle licenses for</param>
        /// <param name="licensePersistLayer">
        ///   Implementation of <see cref="ILicensePersistLayer"/> to be used for saving and retrieving
        ///   licenses when the server cannot be reached
        /// </param>
        public LicenseManager(Uri serverUri, string productIdentifier, ILicensePersistLayer licensePersistLayer)
        {
            ServerUri = serverUri ?? throw new ArgumentNullException(nameof(serverUri));
            ProductIdentifier = productIdentifier;

            _licensePersistLayer = licensePersistLayer;
            _client = new HttpClient();
            MaximumTimeElapsedWithoutServerContact = TimeSpan.FromDays(14);
        }

        /// <summary>
        /// Gets the Uri to the license server in use
        /// </summary>
        public Uri ServerUri { get; }

        /// <summary>
        /// Gets the identifier of the product this manager is for
        /// </summary>
        public string ProductIdentifier { get; }

        /// <summary>
        /// Gets or sets the maximum time allowed without contact to the licensing server, assuming that
        /// a license was sucessfully validated and persisted in the past.
        /// </summary>
        public TimeSpan MaximumTimeElapsedWithoutServerContact { get; set; }

        /// <summary>
        /// Contacts the server and asynchronously returns a response to the specified <see cref="LicenseRequest"/>
        /// </summary>
        /// <param name="request">Request to retrieve a response for</param>
        /// <returns></returns>
        public async Task<LicenseResponse> GetLicenseAsync(string email)
        {
            UriBuilder uriBuilder = new UriBuilder(ServerUri)
            {
                Query = string.Format("Email={0}&MachineName={1}&Product={2}",
                    Uri.EscapeDataString(email),
                    Uri.EscapeDataString(Environment.MachineName),
                    Uri.EscapeDataString(ProductIdentifier)
                    )
            };

            if (!uriBuilder.Path.EndsWith("/"))
                uriBuilder.Path += "/";

            uriBuilder.Path += "license";


            try
            {
                // fetch license from server
                var license = await _client.PostAndReturnJsonAsync<LicenseResponse>(uriBuilder.Uri, new LicenseRequest()
                {
                    Email = email,
                    MachineName = Environment.MachineName,
                    Product = ProductIdentifier
                });

                if (license.State == LicenseResponseState.Success)
                {


                    // cache license for offline usage
                    _licensePersistLayer.Persist(new CachedLicense()
                    {
                        CachedTimestamp = DateTime.Now,
                        License = license,
                        ProductIdentifier = ProductIdentifier,
                        //todo paka
                        Email = email

                    });

                    
                }
                return license;

            }
            catch (Exception ex)
            {
                var cachedLicense = _licensePersistLayer.TryRetrieve(ProductIdentifier, email);

                if (cachedLicense != null)
                {
                    if (cachedLicense.CachedTimestamp > DateTime.Now + MaximumTimeElapsedWithoutServerContact)
                        throw new LicensingException($"Cannot contact licensing server and cached license is older than the maximum time allowed ({MaximumTimeElapsedWithoutServerContact})", ex);

                    return cachedLicense.License;
                }

                throw;
            }
        }

        /// <summary>
        /// Asynchronously updates the specified license to use the specified module identifiers.
        /// Returns an updated license.
        /// </summary>
        /// <param name="license">License to update</param>
        /// <param name="modules">Identifiers of modules to utilize for the license</param>
        /// <returns></returns>
        public async Task<LicenseResponse> UpdateLicenseAsync(LicenseResponse license, List<string> modules)
        {
            UriBuilder uriBuilder = new UriBuilder(ServerUri);
            
            if (!uriBuilder.Path.EndsWith("/"))
                uriBuilder.Path += "/";
            
            uriBuilder.Path += "modifylicense";

            var newLicense = await _client.PostAndReturnJsonAsync<LicenseResponse>(uriBuilder.Uri, new ModifyLicenseRequest()
            {
                LicenseModificationGuid = license.ModificationGuid.Value,
                Modules = modules
            });


            if (newLicense.State != LicenseResponseState.Success)
                throw new LicensingException($"Unable to update license. {newLicense.ErrorMessage}");

            // cache license for offline usage
            _licensePersistLayer.Persist(new CachedLicense()
            {
                CachedTimestamp = DateTime.Now,
                License = newLicense,
                ProductIdentifier = ProductIdentifier
            });

            return newLicense;
        }

        /// <summary>
        /// Retrieves a saved license if one exists
        /// </summary>
        /// <returns></returns>
        public LicenseResponse TryGetSavedLicense(string email)
        {
            return _licensePersistLayer.TryRetrieve(ProductIdentifier, email)?.License;
        }

        /// <summary>
        /// TODO Fedepaka
        /// </summary>
        /// <returns></returns>
        public CachedLicense TryGetSavedDataLicense(string email)
        {
            return _licensePersistLayer.TryRetrieve(ProductIdentifier, email);
        }

        public async Task<LicenseResponse> CreateTrialAsync(string email, string firstName, string lastName, string phone)
        {
            UriBuilder uriBuilder = new UriBuilder(ServerUri);
            
            if (!uriBuilder.Path.EndsWith("/"))
                uriBuilder.Path += "/";

            uriBuilder.Path += "createTrial";

            var trial = await _client.PostAndReturnJsonAsync<LicenseResponse>(uriBuilder.Uri, new CreateTrialRequest()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UserPhone = phone,
                Product = ProductIdentifier
            }).ConfigureAwait(false);

            //TODO PAKA: no dar error, devolver la licencia trial
            //if (trial.State != LicenseResponseState.Success)
            //    throw new LicensingException($"Unable to create trial. {trial.ErrorMessage}");

            // cache license for offline usage
            _licensePersistLayer.Persist(new CachedLicense()
            {
                CachedTimestamp = DateTime.Now,
                License = trial,
                ProductIdentifier = ProductIdentifier,
                Email = email
            });

            return trial;
        }

        public void Dispose()
        {
            ((IDisposable)_client).Dispose();
        }
    }
}
