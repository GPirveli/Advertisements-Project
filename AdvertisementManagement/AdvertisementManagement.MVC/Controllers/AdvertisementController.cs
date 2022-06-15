using AdvertisementManagement.MVC.Models;
using AdvertisementManagement.MVC.Models.Requests;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdvertisementManagement.MVC.Controllers
{
    public class AdvertisementController : Controller
    {
        private string _baseUrl = "https://localhost:44315/api/advertisement";
        HttpClientHandler _clientHandler = new HttpClientHandler();

        [HttpGet]
        public async Task<IActionResult> ListAdvertisements()
        {
            var advertisements = new List<AdvertisementViewModel>();

            using(var httpClient = new HttpClient(_clientHandler))
            {
                using(var response = await httpClient.GetAsync(_baseUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    advertisements = JsonConvert.DeserializeObject<List<AdvertisementViewModel>>(apiResponse);
                }
            }
            return View(advertisements);
        }

        //[Route("Details/{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var advertisement = new AdvertisementViewModel();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync($"{_baseUrl}/advert/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    advertisement = JsonConvert.DeserializeObject<AdvertisementViewModel>(apiResponse);
                }
            }
            return View(advertisement);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdvertisementRequest advertisement)
        {
            var advertisementToCreate = new CreateAdvertisementRequest();

            using(var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(advertisement), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync($"{_baseUrl}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    advertisementToCreate = JsonConvert.DeserializeObject<CreateAdvertisementRequest>(apiResponse);
                }
            }
            return RedirectToAction("ListAdvertisements");
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var advertisementToUpdate = new AdvertisementViewModel();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync($"{_baseUrl}/advert/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    advertisementToUpdate = JsonConvert.DeserializeObject<AdvertisementViewModel>(apiResponse);
                }
            }

            return View(advertisementToUpdate.Adapt<UpdateAdvertisementRequest>());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateAdvertisementRequest advertisement)
        {
            var advertisementToUpdate = new UpdateAdvertisementRequest();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(advertisement), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync($"{_baseUrl}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    advertisementToUpdate = JsonConvert.DeserializeObject<UpdateAdvertisementRequest>(apiResponse);
                }
            }
            return RedirectToAction("ListAdvertisements");
        }

        [Route("SearchByTitle")]
        [HttpGet]
        public async Task<IActionResult> SearchByTitle(string title)
        {
            var advertisements = new List<AdvertisementViewModel>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync($"{_baseUrl}/search/{title}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    advertisements = JsonConvert.DeserializeObject<List<AdvertisementViewModel>>(apiResponse);
                }
            }
            return View("ListAdvertisements", advertisements);
        }
    }
}
