using customers.domain;
using customers.helper;
using customers.exceptions;
using Customers.Exceptions;

namespace customers.bussiness
{
    public static class CustomerB
    {
        public static void ValidateCustomer(string ctx, Customer customer)
        {  
            List<ValidationError> errors = new List<ValidationError>();

            if (!CustomerHelper.IsValidCUIT(customer.CUIT))
                errors.Add(new ValidationError(ctx, customer.CUIT.GetType().ToString(), $" CUIT inválido"));
            if (!CustomerHelper.IsAValidEmail(customer.Email))
                errors.Add(new ValidationError(ctx, customer.Email.GetType().ToString(), $" Mail inválido"));
            if (!CustomerHelper.IsAValidBirthdayDate(customer.Birthday))
                errors.Add(new ValidationError(ctx, customer.Birthday.GetType().ToString(), $" Fecha de nacimiento inválido"));

            if (errors.Count() > 0) throw new CustomerValidationException("Formato inválido en: ", errors);
        }
    }
}
