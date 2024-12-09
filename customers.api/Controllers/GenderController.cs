using customers.domain;
using Microsoft.AspNetCore.Mvc;

namespace customers.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly Repository<Gender> _repository;

        public GenderController(Repository<Gender> repository)
        {
            _repository = repository;
        }

        // GET: api/Gender
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGenders()
        {
            var genders = await _repository.GetAllAsync();
            return Ok(genders);
        }

        // GET: api/Gender/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGender(int id)
        {
            try
            {
                var gender = await _repository.GetByIdAsync(id);
                return Ok(gender);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Gender
        [HttpPost]
        public async Task<ActionResult<Gender>> PostGender(Gender gender)
        {
            // Asegúrate de que el ID no esté configurado explícitamente
            await _repository.AddAsync(gender);
            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGender), new { id = gender.Id }, gender);
        }

        // PUT: api/Gender/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGender(int id, Gender gender)
        {
            if (id != gender.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el de la entidad.");
            }

            try
            {
                await _repository.UpdateAsync(gender);
                await _repository.SaveChangesAsync();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Gender/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            try
            {
                var gender = await _repository.GetByIdAsync(id);
                _repository.Remove(gender);
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
