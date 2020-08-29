using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace Opedo.Licensing.Client
{
    static class Extensions
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, Uri uri, object target)
        {
            var content = new StringContent(JsonSerializer.Serialize(target), Encoding.UTF8, "application/json");
               
            return await client.PostAsync(uri, content);
        }

        public static async Task<TResult> PostAndReturnJsonAsync<TResult>(this HttpClient client, Uri uri, object target)
        {
            var response = await client.PostAsJsonAsync(uri, target).ConfigureAwait(false);

            // send request
            return await JsonSerializer.DeserializeAsync<TResult>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }).ConfigureAwait(false);
        }
    }
}
