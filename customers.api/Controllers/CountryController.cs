using customers.domain;
using Microsoft.AspNetCore.Mvc;

namespace customers.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly Repository<Country> _repository;

        public CountryController(Repository<Country> repository)
        {
            _repository = repository;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _repository.GetAllAsync();
            return Ok(countries);
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            try
            {
                var country = await _repository.GetByIdAsync(id);
                return Ok(country);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Country
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            await _repository.AddAsync(country);
            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el de la entidad.");
            }

            try
            {
                await _repository.UpdateAsync(country);
                await _repository.SaveChangesAsync();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            try
            {
                var country = await _repository.GetByIdAsync(id);
                _repository.Remove(country);
                await _repository.SaveChangesAsync();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
