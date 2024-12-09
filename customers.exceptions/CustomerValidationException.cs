using customers.exceptions;

namespace Customers.Exceptions
{
    [Serializable]
    public class CustomerValidationException : Exception
    {
        /// <summary>
        /// Lista de errores de validación asociados al cliente.
        /// </summary>
        public IEnumerable<ValidationError> ValidationErrors { get; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CustomerValidationException"/>.
        /// </summary>
        /// <param name="message">El mensaje de error.</param>
        /// <param name="validationErrors">La lista de errores de validación.</param>
        public CustomerValidationException(string message, IEnumerable<ValidationError> validationErrors)
            : base(message)
        {
            ValidationErrors = validationErrors;

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CustomerValidationException"/> con datos de serialización.
        /// </summary>
        protected CustomerValidationException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
            ValidationErrors = (IEnumerable<ValidationError>)info.GetValue(nameof(ValidationErrors), typeof(IEnumerable<ValidationError>));
        }

        /// <summary>
        /// Sobrescribe el método para serializar la excepción.
        /// </summary>
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(ValidationErrors), ValidationErrors, typeof(IEnumerable<ValidationError>));
        }

        /// <summary>
        /// Devuelve una representación detallada de los errores.
        /// </summary>
        /// <returns>Un string con el detalle de los errores.</returns>
        public override string ToString()
        {
            var errorDetails = string.Join(Environment.NewLine, ValidationErrors.Select(x => x.Message));
            return $"{base.ToString()}{Environment.NewLine}{Environment.NewLine}{errorDetails}";
        }
    }
}
