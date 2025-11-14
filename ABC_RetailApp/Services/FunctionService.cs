namespace ABC_RetailApp.Services
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class FunctionService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public FunctionService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> CallFunction(string functionKey, object payload)
        {
            string url = _config[$"FunctionUrls:{functionKey}"];
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}