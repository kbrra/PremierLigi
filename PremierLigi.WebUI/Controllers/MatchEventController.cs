using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLigi.WebUI.Dtos.MatchEventDtos;
using System.Text;

namespace PremierLigi.WebUI.Controllers
{
    public class MatchEventController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchEventController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MatchEventList(int matchId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/MatchEvent/GetByMatch?matchId=" + matchId);
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMatchEventDto>>(jsonData);
            ViewBag.MatchId = matchId;
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateMatchEvent(int matchId)
        {
            ViewBag.MatchId = matchId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatchEvent(CreateMatchEventDto createMatchEventDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMatchEventDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7146/api/MatchEvent", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("MatchEventList", new { matchId = createMatchEventDto.MatchId });
            return View();
        }

        public async Task<IActionResult> DeleteMatchEvent(int id, int matchId)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("http://localhost:7146/api/MatchEvent?id=" + id);
            return RedirectToAction("MatchEventList", new { matchId = matchId });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMatchEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/MatchEvent/GetMatchEvent?id=" + id);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("MatchEventList");
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdMatchEventDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMatchEvent(UpdateMatchEventDto updateMatchEventDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMatchEventDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7146/api/MatchEvent", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("MatchEventList", new { matchId = updateMatchEventDto.MatchId });
            return View();
        }
    }
}