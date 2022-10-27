namespace Payments.Domain.Domain
{
    public class PaymentDoneIntegrationEvent
    {
        public int ContractId { get; set; }

        public PaymentDoneIntegrationEvent(int contractId)
        {
            this.ContractId = contractId;
        }
    }
}