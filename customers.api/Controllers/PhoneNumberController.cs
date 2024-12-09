using customers.domain;
using customers.helper;
using Microsoft.AspNetCore.Mvc;

namespace customers.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly Repository<PhoneNumber> _repository;

        public PhoneNumberController(Repository<PhoneNumber> repository)
        {
            _repository = repository;
        }

        // GET: api/PhoneNumber
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneNumber>>> GetPhoneNumbers()
        {
            var phoneNumbers = await _repository.GetAllAsync();
            return Ok(phoneNumbers);
        }

        // GET: api/PhoneNumber/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneNumber>> GetPhoneNumber(int id)
        {
            try
            {
                var phoneNumber = await _repository.GetByIdAsync(id);
                return Ok(phoneNumber);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/PhoneNumber
        [HttpPost]
        public async Task<ActionResult<PhoneNumber>> PostPhoneNumber(PhoneNumber phoneNumber)
        {
            if (PhoneNumberHelper.ValidateIsAPhoneNumber(phoneNumber.Phone))
            {

                await _repository.AddAsync(phoneNumber);
                await _repository.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPhoneNumber), new { id = phoneNumber.Id }, phoneNumber);
            }
            else
            {
                return BadRequest(new
                {
                    Message = "El número telefónico no es válido. Por favor, ingrese un número que contenga solo dígitos.",
                    ErrorCode = 666
                });
            }
        }

        // PUT: api/PhoneNumber/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneNumber(int id, PhoneNumber phoneNumber)
        {
            if (id != phoneNumber.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el de la entidad.");
            }

            try
            {
                await _repository.UpdateAsync(phoneNumber);
                await _repository.SaveChangesAsync();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/PhoneNumber/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneNumber(int id)
        {
            try
            {
                var phoneNumber = await _repository.GetByIdAsync(id);
                _repository.Remove(phoneNumber);
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
