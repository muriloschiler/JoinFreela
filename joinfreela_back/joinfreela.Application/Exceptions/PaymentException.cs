namespace joinfreela.Application.Exceptions
{
    public class PaymentException: Exception
    {
        public PaymentException(string message):base(message)
        {}
        public PaymentException():base("Pagamento não realizado por problemas no servidor")
        {}
    }
}