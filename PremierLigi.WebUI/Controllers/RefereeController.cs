using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremierLigi.WebUI.Dtos.RefereeDtos;
using System.Text;

namespace PremierLigi.WebUI.Controllers
{
    public class RefereeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RefereeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> RefereeList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Referee");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultRefereeDto>>(jsonData);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateReferee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReferee(CreateRefereeDto createRefereeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createRefereeDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:7146/api/Referee", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("RefereeList");
            return View();
        }

        public async Task<IActionResult> DeleteReferee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("http://localhost:7146/api/Referee?id=" + id);
            return RedirectToAction("RefereeList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReferee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7146/api/Referee/GetReferee?id=" + id);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("RefereeList");
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdRefereeDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReferee(UpdateRefereeDto updateRefereeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateRefereeDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:7146/api/Referee", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("RefereeList");
            return View();
        }
    }
}