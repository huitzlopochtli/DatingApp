using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Api.Data;
using DatingApp.Api.DTOs;
using DatingApp.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]

    public class LocationController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public LocationController(IRepository repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> getCountries()
        {
            var countries = await _repository.GetAsync<Country>(filter: c => c.Cities.Count > 0,includeProperties: "Cities", orderBy: c => c.OrderBy(b => b.CountryName));
            var coutriesToReturn = _mapper.Map<IEnumerable<CountryDto>>(countries);
            foreach(var c in coutriesToReturn)
            {
                c.Cities = c.Cities.OrderBy(city => city.CityName);
            }

            return Ok(coutriesToReturn);
        }

        [HttpGet("countries/{id}")]
        public async Task<ActionResult> getCities(int id)
        {
            var cities = await _repository.GetAsync<City>(filter: c => c.CountryId == id);
            var citiesToReturn = _mapper.Map<IEnumerable<CityDto>>(cities);

            return Ok(citiesToReturn);
        }
    }
}