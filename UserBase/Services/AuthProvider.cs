using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UserBase.Entities;

namespace UserBase.Services
{

    public class AuthProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly string _baseUri = "https://run.mocky.io/v3/83599a37-9b03-47d1-970d-555f8835355c";


        public AuthProvider()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public async Task<Auth> AuthAsync(string email, string password)
        {
            var uri = _baseUri;

            var httpClient = new HttpClient();


            var byteArray = Encoding.ASCII.GetBytes($"{email}:{password}");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            HttpResponseMessage response = await httpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(content);
            }

            string serialized = await response.Content.ReadAsStringAsync();

            var result = await Task.Run(() =>
                JsonConvert.DeserializeObject<Auth>(serialized, _serializerSettings));

            return result;

        }
    }
}
