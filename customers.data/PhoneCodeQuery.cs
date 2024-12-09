using customers.domain;
using System.Linq;

namespace customers.data
{
    public class PhoneCodeQuery : Repository<Customer>
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Inicializa una nueva instancia de la clase PhoneCodeQuery.
        /// </summary>
        public PhoneCodeQuery(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Obtiene el código telefónico asociado a un país específico.
        /// </summary>
   
        public PhoneCode GetPhoneCodeByCountry(Country country)
        {
            string countryName = country.CountryName;
            PhoneCode countryCode = _context.PhoneCode
                                            .Where(p => p.Country.ToString() == countryName)
                                            .FirstOrDefault();

            return countryCode;
        }
    }
}
