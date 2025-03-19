using System.Text.Json;
using AccountsService.DTOs;  // Make sure AssembleDTO exists here
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
        private readonly string assemblyServiceWorkerUrl;

        public CommunicationClientUtility(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            assemblyServiceWorkerUrl = configuration["ServiceUrls:AssemblyServiceGetWorkerAssembles"];
        }

        public async Task<List<AssembleDTO>> GetWorkerAssemblyData(int id)
        {
            var response = await httpClient.PostAsJsonAsync($"{assemblyServiceWorkerUrl}{id}", new { id });

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;  // Return null if no assemblies are found
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<AssembleDTO>>(content);  // Deserialize into List<AssembleDTO>
        }

    }
}
