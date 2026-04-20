using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLigi.WebUI.Dtos.GameWeekDtos;
using PremierLigi.WebUI.Dtos.MatchDtos;
using PremierLigi.WebUI.Dtos.RefereeDtos;
using PremierLigi.WebUI.Dtos.SeasonDtos;
using PremierLigi.WebUI.Dtos.TeamDtos;
using System.Text;

namespace PremierLigi.WebUI.Controllers
{
    public class MatchController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MatchList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Match");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMatchDto>>(jsonData);
            return View(values);
        }

        private async Task LoadDropdowns(IHttpClientFactory factory)
        {
            var client = factory.CreateClient();

            var teamRes = await client.GetAsync("http://localhost:7146/api/Team");
            ViewBag.Teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(await teamRes.Content.ReadAsStringAsync());

            var seasonRes = await client.GetAsync("http://localhost:7146/api/Season");
            ViewBag.Seasons = JsonConvert.DeserializeObject<List<ResultSeasonDto>>(await seasonRes.Content.ReadAsStringAsync());

            var gwRes = await client.GetAsync("http://localhost:7146/api/GameWeek");
            ViewBag.GameWeeks = JsonConvert.DeserializeObject<List<ResultGameWeekDto>>(await gwRes.Content.ReadAsStringAsync());

            var refRes = await client.GetAsync("http://localhost:7146/api/Referee");
            ViewBag.Referees = JsonConvert.DeserializeObject<List<ResultRefereeDto>>(await refRes.Content.ReadAsStringAsync());
        }

        [HttpGet]
        public async Task<IActionResult> CreateMatch()
        {
            await LoadDropdowns(_httpClientFactory);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(CreateMatchDto createMatchDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMatchDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7146/api/Match", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("MatchList");
            return View();
        }

        public async Task<IActionResult> DeleteMatch(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("http://localhost:7146/api/Match?id=" + id);
            return RedirectToAction("MatchList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMatch(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Match/GetMatch?id=" + id);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("MatchList");
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdMatchDto>(jsonData);
            await LoadDropdowns(_httpClientFactory);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMatch(UpdateMatchDto updateMatchDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMatchDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7146/api/Match", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("MatchList");
            return View();
        }

        public async Task<IActionResult> Standings()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Match/Standings");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<dynamic>>(jsonData);
            return View(values);
        }
    }
}