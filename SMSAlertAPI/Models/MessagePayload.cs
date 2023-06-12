
namespace SMSAlertAPI.Models
{
    public class MessagePayload
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public MessagePayload() 
        {
            Recipient = "";
            Subject = "";
            Body = "";
        }
    }
}
