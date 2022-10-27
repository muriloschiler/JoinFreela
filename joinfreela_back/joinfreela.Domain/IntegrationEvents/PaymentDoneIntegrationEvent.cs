namespace joinfreela.Domain.IntegrationsEvents
{
    public class PaymentDoneIntegrationEvent
    {
        public int PaymentId { get; set; }

        public PaymentDoneIntegrationEvent(int paymentId)
        {
            PaymentId = paymentId;
        }
    }
}