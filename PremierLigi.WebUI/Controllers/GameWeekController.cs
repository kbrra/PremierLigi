using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLigi.WebUI.Dtos.GameWeekDtos;
using PremierLigi.WebUI.Dtos.SeasonDtos;
using System.Text;

namespace PremierLigi.WebUI.Controllers
{
    public class GameWeekController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GameWeekController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GameWeekList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/GameWeek");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultGameWeekDto>>(jsonData);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateGameWeek()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Season");
            var jsonData = await response.Content.ReadAsStringAsync();
            var seasons = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(jsonData);
            ViewBag.Seasons = seasons;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameWeek(CreateGameWeekDto createGameWeekDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createGameWeekDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7146/api/GameWeek", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GameWeekList");
            return View();
        }

        public async Task<IActionResult> DeleteGameWeek(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("http://localhost:7146/api/GameWeek?id=" + id);
            return RedirectToAction("GameWeekList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGameWeek(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/GameWeek/GetGameWeek?id=" + id);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("GameWeekList");
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdGameWeekDto>(jsonData);

            var seasonResponse = await client.GetAsync("http://localhost:7146/api/Season");
            var seasonJson = await seasonResponse.Content.ReadAsStringAsync();
            var seasons = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(seasonJson);
            ViewBag.Seasons = seasons;

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGameWeek(UpdateGameWeekDto updateGameWeekDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateGameWeekDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7146/api/GameWeek", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GameWeekList");
            return View();
        }
    }
}