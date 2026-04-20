using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLigi.WebUI.Dtos.StadiumDtos;
using System.Text;

namespace PremierLigi.WebUI.Controllers
{
    public class StadiumController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StadiumController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> StadiumList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Stadium");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(jsonData);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateStadium()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStadium(CreateStadiumDto createStadiumDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createStadiumDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7146/api/Stadium", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("StadiumList");
            return View();
        }

        public async Task<IActionResult> DeleteStadium(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("http://localhost:7146/api/Stadium?id=" + id);
            return RedirectToAction("StadiumList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStadium(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Stadium/GetStadium?id=" + id);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("StadiumList");
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdStadiumDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStadium(UpdateStadiumDto updateStadiumDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateStadiumDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7146/api/Stadium", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("StadiumList");
            return View();
        }
    }
}