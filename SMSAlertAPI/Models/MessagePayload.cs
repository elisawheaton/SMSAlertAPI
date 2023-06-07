using Microsoft.AspNetCore.SignalR;
using System.Text.Json.Serialization;

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
        MessagePayload(string rec = "", string sub = "", string bod = "") 
        {
            Recipient = rec;
            Subject = sub;
            Body = bod; 
        }
    }
}
