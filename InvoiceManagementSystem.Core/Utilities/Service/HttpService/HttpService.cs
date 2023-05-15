using System.Text;
using System.Text.Json;

namespace InvoiceManagementSystem.Core.Utilities.Service.HttpService
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<T> DeleteAsync<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResult> PostAsync(string url, object data, object queryString = null, string token = null)
        {
            try
            {
                HttpResponseMessage response;
                var jsonData = JsonSerializer.Serialize(data);

                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var client = _httpClientFactory.CreateClient("paymentApi");
                client.DefaultRequestHeaders.Add("Authorization", $"{token}");
                response = queryString != null ? await client.PostAsync($"{url}/{queryString}", stringContent) : await client.PostAsync($"{url}", stringContent);
                var result = await response.Content.ReadAsStringAsync();
                var resultData = JsonSerializer.Deserialize<HttpResult>(result);
                return resultData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<T> PutAsync<T>(string url, object data)
        {
            throw new NotImplementedException();
        }
    }
}
