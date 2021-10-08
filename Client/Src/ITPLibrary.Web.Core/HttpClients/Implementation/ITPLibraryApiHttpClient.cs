using ITPLibrary.Web.Core.HttpClients.Interface;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
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

        public async Task<T> GetMany<T>(string uri)
        {
            var result = await _httpClient.GetAsync(uri);

            var json = await result.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<T>(json);

            return res;
        }

        public async Task<T> GetOne<T>(string uri)
        {
            var result = await _httpClient.GetAsync(uri);

            var json = await result.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<T>(json);

            return res;
        }

        public async Task<TReturn> Post<TReturn, TConvert>(TConvert payload, string postUri)
        {
            var dtoAsString = JsonConvert.SerializeObject(payload);

            var content = new StringContent(dtoAsString, Encoding.UTF8, "application/json");
            // Adauga id din BooksController ( API )
            var result = await _httpClient.PostAsync(postUri, content);

            var json = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TReturn>(json);
        }
    }
}
