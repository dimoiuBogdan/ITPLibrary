using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPLibrary.Web.Core.HttpClients.Interface
{
    public interface IITPLibraryApiHttpClient
    {
        Task<IEnumerable<T>> GetMany<T>(string requestUri);
        Task<T> GetOne<T>(string requestUri);
        //Task<bool> Post(object payload, string postUri);
    }
}
