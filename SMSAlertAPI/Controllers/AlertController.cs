using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMSAlertAPI.Models;

namespace SMSAlertAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        public SMTPSender sender;
        private string _jsonString;

        public AlertController(IConfiguration configuration)
        {
            sender = new SMTPSender(configuration);
            _jsonString = "";
        }

        [HttpPost("SendSMS")]
        public async Task<IActionResult> SendSMS([FromBody] MessagePayload msg)
        {
            try
            {
                await sender.SendMessage(msg.Recipient, msg.Subject, msg.Body);
                _jsonString = JsonConvert.SerializeObject("To: " + msg.Recipient + ": " + msg.Subject + " - " + msg.Body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

            return Ok(_jsonString);
        }

    }
}
