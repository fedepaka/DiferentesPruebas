using System.Collections.Generic;
using System.Text;

namespace Opedo.Licensing.Client
{
    /// <summary>
    /// Interface for saving and retrieving licenses
    /// </summary>
    public interface ILicensePersistLayer
    {
        /// <summary>
        /// Persists the specified license so it can be retrieved later
        /// </summary>
        /// <param name="license">License to cache</param>
        void Persist(CachedLicense license);

        /// <summary>
        /// Retrieves a cached license for the specified product identifier, if one exists.
        /// </summary>
        /// <param name="productIdentifier">Identifier of product to retrieve cached license for</param>
        /// <returns></returns>
        CachedLicense TryRetrieve(string productIdentifier, string email);
    }
}
