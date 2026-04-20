using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLigi.WebUI.Dtos.SeasonDtos;
using System.Text;

namespace PremierLigi.WebUI.Controllers
{
    public class SeasonController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SeasonController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SeasonList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Season");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(jsonData);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSeason()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeason(CreateSeasonDto createSeasonDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSeasonDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7146/api/Season", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("SeasonList");
            return View();
        }

        public async Task<IActionResult> DeleteSeason(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("http://localhost:7146/api/Season?id=" + id);
            return RedirectToAction("SeasonList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSeason(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Season/GetSeason?id=" + id);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("SeasonList");
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdSeasonDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSeason(UpdateSeasonDto updateSeasonDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSeasonDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7146/api/Season", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("SeasonList");
            return View();
        }
    }
}