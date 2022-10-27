using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Models
{
    public class Payment: Register
    {
        public decimal Value { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public int Pending { get; set; }
    }
}