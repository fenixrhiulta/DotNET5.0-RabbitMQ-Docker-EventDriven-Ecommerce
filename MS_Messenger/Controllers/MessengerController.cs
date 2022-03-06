using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Messenger.Domain;
using MS_Messenger.Service;
using System;

namespace MS_Messenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessengerController : ControllerBase
    {
        private readonly IMessengerService _service;

        public MessengerController(IMessengerService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostSendPaymentEmail(SendPaymentEmailRequest request)
        {
            try
            {
                var response = _service.PostSendPaymentEmailService(request);
                return Ok(response);
            }
            catch (Exception)
            {
            }

            return StatusCode(500, "Internal Server Error");
        }
    }
}