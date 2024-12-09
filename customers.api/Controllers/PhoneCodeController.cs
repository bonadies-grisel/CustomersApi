using customers.domain;
using customers.data;
using Microsoft.AspNetCore.Mvc;

namespace customers.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneCodeController : ControllerBase
    {
        private readonly Repository<PhoneCode> _repository;

        public PhoneCodeController(Repository<PhoneCode> repository)
        {
            _repository = repository;
        }

        // GET: api/PhoneCode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneCode>>> GetPhoneCodes()
        {
            var phoneCodes = await _repository.GetAllAsync();
            return Ok(phoneCodes);
        }

        // GET: api/PhoneCode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneCode>> GetPhoneCode(int id)
        {
            try
            {
                var phoneCode = await _repository.GetByIdAsync(id);
                return Ok(phoneCode);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/PhoneCode
        [HttpPost]
        public async Task<ActionResult<PhoneCode>> PostPhoneCode(PhoneCode phoneCode)
        {
            await _repository.AddAsync(phoneCode);
            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhoneCode), new { id = phoneCode.Id }, phoneCode);
        }

        // PUT: api/PhoneCode/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneCode(int id, PhoneCode phoneCode)
        {
            if (id != phoneCode.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el de la entidad.");
            }

            try
            {
                await _repository.UpdateAsync(phoneCode);
                await _repository.SaveChangesAsync();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/PhoneCode/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneCode(int id)
        {
            try
            {
                var phoneCode = await _repository.GetByIdAsync(id);
                _repository.Remove(phoneCode);
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
