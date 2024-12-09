using System.ComponentModel.DataAnnotations;

namespace customers.domain
{
    public class Customer : Generic32
    {
        public Customer() { }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Surname { get; set; } = string.Empty;

        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public string Birthday { get; set; } = string.Empty; // Podría ser DateTime

        [Required(ErrorMessage = "El CUIT es obligatorio.")]
        public string CUIT { get; set; } = string.Empty;

        public string? Address { get; set; }
        public City? City { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();
    }
}
