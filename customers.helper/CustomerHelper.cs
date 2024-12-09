using System.Net.Mail;

namespace customers.helper
{

    public static class CustomerHelper
    {
        /// <summary>
        /// Valida si la dirección de correo electrónico tiene un formato correcto.
        /// </summary>
        public static bool IsAValidEmail(string email)
        {
            bool isValidEmail = false;

            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return isValidEmail = true;
            }
            catch (Exception)
            {
                return isValidEmail;
            }
        }

        /// <summary>
        /// Valida si el CUIT tiene un formato válido.
        /// </summary>
        public static bool IsValidCUIT(string CUIT)
        {
            return !string.IsNullOrEmpty(CUIT) && CUIT.Length == 11;
        }

        /// <summary>
        /// Valida si la fecha de nacimiento tiene el formato correcto (DD/MM/AAAA).
        /// </summary>
        public static bool IsAValidBirthdayDate(string date)
        {
            return DateTime.TryParseExact(
                date,
                "dd/MM/yyyy",
                null,
                System.Globalization.DateTimeStyles.None,
                out _
            );
        }
    }
}
