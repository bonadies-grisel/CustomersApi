using customers.domain;
using Microsoft.AspNetCore.Mvc;

namespace customers.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly Repository<City> _repository;

        public CityController(Repository<City> repository)
        {
            _repository = repository;
        }

        // GET: api/City
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _repository.GetAllAsync();
            return Ok(cities);
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            try
            {
                var city = await _repository.GetByIdAsync(id);
                return Ok(city);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/City
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            await _repository.AddAsync(city);
            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCity), new { id = city.Id }, city);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el de la entidad.");
            }

            try
            {
                await _repository.UpdateAsync(city);
                await _repository.SaveChangesAsync();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                var city = await _repository.GetByIdAsync(id);
                _repository.Remove(city);
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
