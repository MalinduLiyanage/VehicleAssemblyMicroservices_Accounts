using System.Text.Json;
using AccountsService.DTOs; 
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Collections.Generic;

namespace AccountsService.Utilities.CommunicationClientUtility
{
    public class CommunicationClientUtility
    {
        private readonly HttpClient httpClient;
        private readonly string? assemblyServiceWorkerUrl;

        public CommunicationClientUtility(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            assemblyServiceWorkerUrl = configuration["ServiceUrls:AssemblyServiceGetWorkerAssembles"];
        }

        public async Task<List<AssembleDTO>> GetWorkerAssemblyData(int id)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync($"{assemblyServiceWorkerUrl}{id}", new { id });

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<AssembleDTO>(); 
            }

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<AssembleDTO>>(content) ?? new List<AssembleDTO>(); 
        }


    }
}
