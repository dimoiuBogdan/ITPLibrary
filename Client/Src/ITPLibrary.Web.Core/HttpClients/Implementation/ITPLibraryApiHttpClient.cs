using ITPLibrary.Web.Core.HttpClients.Interface;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.HttpClients.Implementation
{
    public class ITPLibraryApiHttpClient : IITPLibraryApiHttpClient
    {
        public HttpClient _httpClient;

        public ITPLibraryApiHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<T>> GetMany<T>(string uri)
        {
            var result = await _httpClient.GetAsync(uri);

            var json = await result.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<IEnumerable<T>>(json);

            return res;
        }

        public async Task<T> GetOne<T>(string uri)
        {
            var result = await _httpClient.GetAsync(uri);

            var json = await result.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<T>(json);

            return res;
        }

        //public async Task<bool> Post(object payload, string uri)
        //{
        //    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(payload));

        //    var res = await _httpClient.PostAsync(uri, httpContent);

        //    if (res.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
