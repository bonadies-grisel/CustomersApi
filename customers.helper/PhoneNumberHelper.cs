using customers.data;
using customers.domain;
using System.Text.RegularExpressions;

namespace customers.helper
{
    public static class PhoneNumberHelper
    {
        /// <summary>
        /// Valida si la cadena ingresada es un número telefónico válido.
        /// El número debe contener únicamente dígitos.
        /// </summary>
        public static bool ValidateIsAPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && Regex.IsMatch(phoneNumber, @"^\d+$");
        }

        /// <summary>
        /// Agrega el código de país al número telefónico proporcionado.
        /// </summary>
        /// <param name="phoneNumber">El número telefónico sin código de país.</param>
        /// <param name="country">El país asociado al número telefónico.</param>
        /// <param name="phoneCodeQuery">Instancia de PhoneCodeQuery para realizar consultas.</param>
        public static string SetPhoneNumber(string phoneNumber, Country country)
        {
            var phoneCode = QueryFactory.GetPhoneCodeQuery().GetPhoneCodeByCountry(country);
           // var phoneCode = PhoneCodeQuery.GetPhoneCodeByCountry(country);

            if (phoneCode == null)
            {
                throw new KeyNotFoundException($"No se encontró un código telefónico para el país {country.CountryName}.");
            }

            if (!ValidateIsAPhoneNumber(phoneNumber))
            {
                throw new FormatException($"El número {phoneNumber} no es válido.");
            }

            return $"+{phoneCode.Code}{phoneNumber}";
        }
    }
}
