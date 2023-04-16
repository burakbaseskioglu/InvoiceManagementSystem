using InvoiceManagementSystem.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Core.Utilities.Service.HttpService
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string url);
        Task<HttpResult> PostAsync(string url, object data, object queryString = null);
        Task<T> PutAsync<T>(string url, object data);
        Task<T> DeleteAsync<T>(string url);
    }
}
