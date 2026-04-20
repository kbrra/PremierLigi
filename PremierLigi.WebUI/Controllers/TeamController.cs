using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLigi.WebUI.Dtos.StadiumDtos;
using PremierLigi.WebUI.Dtos.TeamDtos;
using System.Text;

namespace PremierLigi.WebUI.Controllers
{
    public class TeamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TeamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TeamList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Team");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsonData);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateTeam()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Stadium");
            var jsonData = await response.Content.ReadAsStringAsync();
            ViewBag.Stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(jsonData);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTeamDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7146/api/Team", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("TeamList");
            return View();
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("http://localhost:7146/api/Team?id=" + id);
            return RedirectToAction("TeamList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Team/GetTeam?id=" + id);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("TeamList");
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdTeamDto>(jsonData);

            var stadiumRes = await client.GetAsync("http://localhost:7146/api/Stadium");
            var stadiumJson = await stadiumRes.Content.ReadAsStringAsync();
            ViewBag.Stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(stadiumJson);

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTeamDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7146/api/Team", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("TeamList");
            return View();
        }
    }
}