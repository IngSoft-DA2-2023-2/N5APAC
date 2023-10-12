namespace PAC.Exceptions
{
    public class ExcepcionArgumentosIncorrectos
    {
        public class ExcepcionArgumentosIncorrectos : Exception
        {
            public ExcepcionArgumentosIncorrectos() : base() { }

            public ExcepcionArgumentosIncorrectos(string message) : base(message) { }

            public ExcepcionArgumentosIncorrectos(string message, Exception innerException) : base(message, innerException) { }
        }
    }
}