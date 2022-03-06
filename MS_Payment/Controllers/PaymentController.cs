using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Payment.Domain;
using MS_Payment.Service;
using System;

namespace MS_Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostPayment(PaymentRequest request)
        {
            try
            {
                var response = _service.PostPaymentService(request);
                return Ok(response);
            }
            catch (Exception)
            {
            }

            return StatusCode(500, "Internal Server Error");
        }
    }
}
