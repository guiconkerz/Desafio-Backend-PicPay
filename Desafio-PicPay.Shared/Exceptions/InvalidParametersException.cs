namespace Desafio_PicPay.Shared.Exceptions
{
    public class InvalidParametersException : Exception
    {
        private const string __message = "Data is invalid.";
        public InvalidParametersException(string message) : base(message) { }

        public static void ThrowIfNull(
            string? item,
            string message = __message)
        {
            if (string.IsNullOrEmpty(item) || string.IsNullOrWhiteSpace(item))
            {
                throw new InvalidParametersException(message);
            }
        }

        public static void ThrowIfNull(
            string?[] items,
            string message = __message)
        {
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item) || string.IsNullOrWhiteSpace(item))
                {
                    throw new InvalidParametersException(message);
                }
            }
        }

        public static void ThrowIfNull(
           object? item,
           string message = __message)
        {
            if (item is null)
            {
                throw new InvalidParametersException(message);
            }
        }
    }
}
