using Microsoft.AspNetCore.Mvc;
using Payments.Application.DTOS;
using Payments.Application.Interfaces.Services;

namespace Payments.API.Controllers
{
    [Route("api/v1/{controller}")]
    [ApiController]
    public class PaymentController: ControllerBase
    {
        public IPaymentService _paymentService { get; set; }

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
        {
            return Ok(await _paymentService.ProcessPayment(request));
        }
    }
}