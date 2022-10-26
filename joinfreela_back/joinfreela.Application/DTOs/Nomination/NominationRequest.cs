using joinfreela.Application.DTOs.Common.Base;

namespace joinfreela.Application.DTOs.Nomination
{
    public class NominationRequest:RegisterRequest
    {
        public int JobId { get; set; }
    }
}