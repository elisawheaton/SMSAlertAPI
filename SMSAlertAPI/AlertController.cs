using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; 

namespace SMSAlertAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        public SMTPSender sender; 
        private string _jsonString; 

        public AlertController(IConfiguration configuration)
        {
            sender = new SMTPSender(); 
            _jsonString = ""; 
        }

        [HttpGet("SendSMS/{recipient}/{subject}/{body}")]
        public async Task<IActionResult> SendSMS(string recipient, string subject, string body)
        {
            try
            {   
                await sender.SendMessage(recipient, subject, body);
                _jsonString = JsonConvert.SerializeObject( "To: " + recipient + ": " + subject + " - " + body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

            return Ok(_jsonString);
        }

    }
}
