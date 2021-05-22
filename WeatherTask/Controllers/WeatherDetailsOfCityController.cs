using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherDetailsWebAPI.Models;

namespace WeatherDetailsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDetailsOfCityController : ControllerBase
    {
        private readonly WeatherDetailsOfCityDbContext _context;

        public WeatherDetailsOfCityController(WeatherDetailsOfCityDbContext context)
        {
            _context = context;
        }

        // GET: api/WeatherDetailsOfCity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherDetailsOfCity>>> Getweathers()
        {
            return await _context.weathers.ToListAsync();
        }

        // GET: api/WeatherDetailsOfCity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherDetailsOfCity>> GetWeatherDetailsOfCity(string id)
        {
            var weatherDetailsOfCity = await _context.weathers.FindAsync(id);

            if (weatherDetailsOfCity == null)
            {
                return NotFound();
            }

            return weatherDetailsOfCity;
        }

        // PUT: api/WeatherDetailsOfCity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherDetailsOfCity(string id, WeatherDetailsOfCity weatherDetailsOfCity)
        {
            if (id != weatherDetailsOfCity.city)
            {
                return BadRequest();
            }

            _context.Entry(weatherDetailsOfCity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherDetailsOfCityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeatherDetailsOfCity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherDetailsOfCity>> PostWeatherDetailsOfCity(WeatherDetailsOfCity weatherDetailsOfCity)
        {
            _context.weathers.Add(weatherDetailsOfCity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WeatherDetailsOfCityExists(weatherDetailsOfCity.city))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWeatherDetailsOfCity", new { id = weatherDetailsOfCity.city }, weatherDetailsOfCity);
        }

        // DELETE: api/WeatherDetailsOfCity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherDetailsOfCity(string id)
        {
            var weatherDetailsOfCity = await _context.weathers.FindAsync(id);
            if (weatherDetailsOfCity == null)
            {
                return NotFound();
            }

            _context.weathers.Remove(weatherDetailsOfCity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherDetailsOfCityExists(string id)
        {
            return _context.weathers.Any(e => e.city == id);
        }
    }
}
