using ITPLibrary.Web.Core.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.HttpClients.Interface
{
    public interface IITPLibraryApiHttpClient
    {
        Task</*IEnumerable<*/T> GetMany<T>(string requestUri);
        Task<T> GetOne<T>(string requestUri);
        Task<TReturn> Post<TReturn, TConvert>(TConvert payload, string postUri);
        Task<T> Delete<T>(string postUri);
        Task<TReturn> Patch<TReturn, TConvert>(TConvert payload, string patchUri);
    }
}
