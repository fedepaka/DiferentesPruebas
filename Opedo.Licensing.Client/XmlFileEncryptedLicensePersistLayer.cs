using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Opedo.Licensing.Client
{
    /// <summary>
    /// Implementation of <see cref="ILicensePersistLayer"/> using encrypted XML files. Is used
    /// to store retrieved licenses for offline usage.
    /// </summary>
    public class XmlFileEncryptedLicensePersistLayer : ILicensePersistLayer
    {
        private static readonly byte[] Key = new byte[32] { 109, 14, 206, 202, 57, 107, 240, 188, 239, 72, 19, 106, 82, 3, 25, 211, 93, 116, 17, 46, 61, 76, 155, 205, 5, 205, 87, 2, 217, 115, 108, 212 };
        private static readonly byte[] IV = new byte[16] { 3, 166, 42, 236, 5, 35, 97, 17, 58, 65, 39, 118, 85, 140, 234, 137 };
        public string RootDirectory { get; }

        public XmlFileEncryptedLicensePersistLayer()
        {
            RootDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Opedo Licensing");
        }

        public void Persist(CachedLicense license)
        {
            if (license is null)
                throw new ArgumentNullException(nameof(license));

            string filename = Path.Combine(RootDirectory, FilenameFromIdentifier(license.ProductIdentifier+license.Email));

            Directory.CreateDirectory(RootDirectory);

            using (Aes aes = Aes.Create())
            using (ICryptoTransform transform = aes.CreateEncryptor(Key, IV))
            using (FileStream outputStream = File.Create(filename))
            using (CryptoStream cs = new CryptoStream(outputStream, transform, CryptoStreamMode.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CachedLicense));

                serializer.Serialize(cs, license);
            }
        }

        public CachedLicense TryRetrieve(string productIdentifier, string email)
        {
            string filename = Path.Combine(RootDirectory, FilenameFromIdentifier(productIdentifier+email));

            if (File.Exists(filename))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Aes aes = Aes.Create())
                    using (ICryptoTransform transform = aes.CreateDecryptor(Key, IV))
                    using (FileStream fileStream = File.OpenRead(filename))
                    using (CryptoStream cs = new CryptoStream(fileStream, transform, CryptoStreamMode.Read))
                    {
                        cs.CopyTo(ms);
                    }

                    ms.Seek(0, SeekOrigin.Begin);

                    return (CachedLicense)new XmlSerializer(typeof(CachedLicense)).Deserialize(ms);
                }
            }

            return null;
        }

        /// <summary>
        /// Creates a file name for the specified product identifier
        /// </summary>
        private static string FilenameFromIdentifier(string identifier) => CleanIdentifier(identifier) + ".lic";

        /// <summary>
        /// Cleans the specified identifier for characters not valid in a file name
        /// </summary>
        private static string CleanIdentifier(string identifier)
        {
            return Regex.Replace(identifier, "[^a-zA-Z0-9]", "");
        }
    }
}
