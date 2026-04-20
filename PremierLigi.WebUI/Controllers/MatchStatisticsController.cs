using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLigi.WebUI.Dtos.MatchStatisticsDtos;
using System.Text;

namespace PremierLigi.WebUI.Controllers
{
    public class MatchStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> StatisticsDetail(int matchId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/MatchStatistics/GetByMatch?matchId=" + matchId);
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultMatchStatisticsDto>(jsonData);
            ViewBag.MatchId = matchId;
            return View(value);
        }

        [HttpGet]
        public IActionResult CreateStatistics(int matchId)
        {
            ViewBag.MatchId = matchId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStatistics(CreateMatchStatisticsDto createMatchStatisticsDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMatchStatisticsDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7146/api/MatchStatistics", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("StatisticsDetail", new { matchId = createMatchStatisticsDto.MatchId });
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatistics(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/MatchStatistics/GetStatistics?id=" + id);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("StatisticsDetail");
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdMatchStatisticsDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatistics(UpdateMatchStatisticsDto updateMatchStatisticsDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMatchStatisticsDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7146/api/MatchStatistics", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("StatisticsDetail", new { matchId = updateMatchStatisticsDto.MatchId });
            return View();
        }
        public async Task<IActionResult> StatisticsList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/MatchStatistics");

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultMatchStatisticsDto>());

            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMatchStatisticsDto>>(jsonData);

            return View(values);
        }
    }
}