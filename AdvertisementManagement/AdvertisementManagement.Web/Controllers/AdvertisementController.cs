using AdvertisementManagement.Service.Abstractions;
using AdvertisementManagement.Service.Models;
using AdvertisementManagement.Web.Models.DTOs;
using AdvertisementManagement.Web.Models.Requests;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _service;

        public AdvertisementController(IAdvertisementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<AdvertisementDTO>> GetAllAsync()
        {
            var advertisements = await _service.GetAllAsync();
            return advertisements.Adapt<List<AdvertisementDTO>>();
        }
        
        [Route("advert/{id}")]
        [HttpGet("{id}")]
        public async Task<AdvertisementDTO> GetAsync(int id)
        {
            var advertisement = await _service.GetAsync(id);
            return advertisement.Adapt<AdvertisementDTO>();
        }

        [Route("search/{title}")]
        [HttpGet("{title}")]
        public async Task<List<AdvertisementDTO>> GetByTitleAsync(string title)
        {
            var advertisement = await _service.GetByTitleAsync(title);
            return advertisement.Adapt<List<AdvertisementDTO>>();
        }

        [Route("description/{id}")]
        [HttpGet("{id}")]
        public async Task<string> GetDescriptionAsync(int id)
        {
            return await _service.GetDescriptionAsync(id);
        }

        [Route("phone/{id}")]
        [HttpGet("{id}")]
        public async Task<string> GetPhoneNumberAsync(int id)
        {
            return await _service.GetPhoneNumberAsync(id);
        }

        [Route("image/{id}")]
        [HttpGet("{id}")]
        public async Task<string> GetImageAsync(int id)
        {
            return await _service.GetImageAsync(id);
        }

        [Route("title/{id}")]
        [HttpGet("{id}")]
        public async Task<string> GetTitleAsync(int id)
        {
            return await _service.GetTitleAsync(id);
        }

        [HttpPost]
        public async Task CreateAsync(CreateAdvertisementRequest advertisement)
        {
            await _service.CreateAsync(advertisement.Adapt<AdvertisementServiceModel>());
        }

        [HttpPut]
        public async Task UpdateAsync(UpdateAdvertisementRequest advertisement)
        {
            await _service.UpdateAsync(advertisement.Adapt<AdvertisementServiceModel>());
        }
    }
}
