namespace customers.exceptions
{
    public class ValidationError
    {
        public string Method { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }

        public ValidationError(string method, string field, string message)
        {
            Method = method;
            Field = field;
            Message = message;
        }

    }
}
