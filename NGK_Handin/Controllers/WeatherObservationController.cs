using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGK_Handin3;
using NGK_Handin3.Models;

namespace NGK_Handin3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherObservationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WeatherObservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WeatherObservation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherObservation>>> GetWeatherObservations()
        {
            var observations = await _context.WeatherObservations.ToListAsync();
            List<WeatherObservation> returnlist = new List<WeatherObservation>();
            if (observations.Count > 0)
            {
                returnlist.Add(observations[observations.Count - 1]);
                returnlist.Add(observations[observations.Count - 2]);
                returnlist.Add(observations[observations.Count - 3]);
            }
            return returnlist;
        }

        // GET: api/WeatherObservation
        [HttpGet("{Date}")]
        public async Task<ActionResult<WeatherObservation>> GetWeatherObservation(DateTime Date)
        {
            var weatherObservation = await _context.WeatherObservations.FindAsync(DateTime.Now);

            if (weatherObservation == null)
            {
                return NotFound();
            }

            return weatherObservation;
        }

        // PUT: api/WeatherObservation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherObservation(int id, WeatherObservation weatherObservation)
        {
            if (id != weatherObservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherObservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherObservationExists(id))
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

        // POST: api/WeatherObservation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WeatherObservation>> PostWeatherObservation(WeatherObservation weatherObservation)
        {
            weatherObservation.Date = DateTime.Now;
            _context.WeatherObservations.Add(weatherObservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherObservation", new { id = weatherObservation.Id }, weatherObservation);
        }

        // DELETE: api/WeatherObservation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WeatherObservation>> DeleteWeatherObservation(int id)
        {
            var weatherObservation = await _context.WeatherObservations.FindAsync(id);
            if (weatherObservation == null)
            {
                return NotFound();
            }

            _context.WeatherObservations.Remove(weatherObservation);
            await _context.SaveChangesAsync();

            return weatherObservation;
        }

        private bool WeatherObservationExists(int id)
        {
            return _context.WeatherObservations.Any(e => e.Id == id);
        }
    }
}
