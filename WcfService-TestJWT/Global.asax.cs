using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using WcfService_TestJWT.Utils;

namespace WcfService_TestJWT
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var validateAuth = ConfigurationSettings.AppSettings.Get("CREDIN_AUTHENTICATE");
            if (app.Request.PathInfo.Equals("/PostDataComposite") && validateAuth.Equals("true"))
            {
                var autorization = app.Request.Headers.GetValues("Authorization");
                if (autorization != null)
                {
                    var customToken = autorization.Length > 0 ? autorization[0] : "";
                    var encryptedtoken = customToken.StartsWith("Custom ") ? customToken.Substring(7) : customToken;
                    var token = StringCipher.Decrypt(encryptedtoken, ConfigurationSettings.AppSettings.Get("CREDIN_SECRET"));
                    var tokenItems = token.Split('_');
                    var userPasswordHashed = tokenItems[0];
                    var dateToken = DateTime.Parse(tokenItems[1]);
                    var user = ConfigurationSettings.AppSettings.Get("CREDIN_USER");
                    var password = ConfigurationSettings.AppSettings.Get("CREDIN_PASSWORD");
                    if (!userPasswordHashed.Equals(HashString(string.Format("{0}:{1}", user, password), ConfigurationSettings.AppSettings.Get("CREDIN_SECRET"))))
                    {
                        // Hash of user:password is not correct, not authorized
                        HttpContext context = HttpContext.Current;
                        context.Response.StatusCode = 401;
                        context.Response.End();
                    }
                    var c = dateToken.CompareTo(DateTime.Now);
                    if (dateToken.CompareTo(DateTime.Now) > 0)
                    {
                        // Date of token is later than Now. That is impossible, not authorized
                        HttpContext context = HttpContext.Current;
                        context.Response.StatusCode = 401;
                        context.Response.End();
                    }
                    var addedDate = dateToken.AddMinutes(int.Parse(ConfigurationSettings.AppSettings.Get("CREDIN_EXPIRE_MINUTES")));
                    if (addedDate.CompareTo(DateTime.Now) < 0)
                    {
                        // Old token, not authorized
                        HttpContext context = HttpContext.Current;
                        context.Response.StatusCode = 401;
                        context.Response.End();
                    }

                    var encryptedData = app.Request.Headers.GetValues("Credin-Data")[0];
                    try
                    {
                        var decryptedData = StringCipher.Decrypt(encryptedData, ConfigurationSettings.AppSettings.Get("CREDIN_SECRET"));

                        using (Stream receiveStream = app.Request.InputStream)
                        {
                            var memoryStream = new MemoryStream();
                            receiveStream.CopyTo(memoryStream);
                            using (StreamReader readStream = new StreamReader(memoryStream, Encoding.UTF8))
                            {
                                memoryStream.Seek(0, SeekOrigin.Begin);
                                var requestContent = readStream.ReadToEnd();

                                var asd = app.Request;
                                if (!decryptedData.Equals(requestContent))
                                {
                                    // Encrypted data at header does not match with request body, not authorized
                                    HttpContext context = HttpContext.Current;
                                    context.Response.StatusCode = 401;
                                    context.Response.End();
                                }
                                HttpContext.Current.ClearError();
                            }
                        }

                    }
                    catch (Exception er)
                    {
                        // Something happened at decrypting or parsing the data, not authorized
                        HttpContext context = HttpContext.Current;
                        context.Response.StatusCode = 401;
                        context.Response.End();
                    }
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private string HashString(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
    }
}