using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ERPWebApp.Models;
using Microsoft.Extensions.Configuration;

namespace ERPWebApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl;

        public ClientController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl")
                          ?? throw new ArgumentNullException(nameof(_apiBaseUrl), "API base URL is not configured.");
        }

        /// <summary>
        /// Retrieves the list of clients from the API and displays them in the view.
        /// </summary>
        /// <returns>A view displaying the list of clients or an error view in case of failure.</returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri(_apiBaseUrl);

                var response = await httpClient.GetAsync("/api/Client");

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error", $"API request failed with status code {response.StatusCode}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var clients = JsonSerializer.Deserialize<List<Client>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (clients == null)
                {
                    return View("Error", "No client data available.");
                }

                return View(clients);
            }
            catch (Exception ex)
            {
                return View("Error", $"An error occurred: {ex.Message}");
            }
        }
    }
}
