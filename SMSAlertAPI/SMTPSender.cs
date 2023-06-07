using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace SMSAlertAPI
{
    public class SMTPSender
    {
        private readonly string server;
        private readonly int port;
        private readonly string username;
        private readonly string password;
        private readonly SmtpClient client;
        private IConfiguration config; 

        public SMTPSender(IConfiguration configuration) 
        {
            config = configuration;
            server = config["SMTPConfiguration:Server"];
            port = int.Parse(config["SMTPConfiguration:Port"]);
            username = config["SMTPConfiguration:Username"];
            password = config["SMTPConfiguration:Password"];

            client = new SmtpClient(server, port);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(username, password);
            client.EnableSsl = true;
        }

        public async Task SendMessage(string recipient = "", string subject = "", string body = "") 
        {
            // Create message 
            MailMessage message = new MailMessage(username, recipient);
            message.Subject = subject;
            message.Body = body;

            // Send the email
            await client.SendMailAsync(message);

            return; 
        }

        //AT&T: <phoneNumber>@txt.att.net
        //Verizon: <phoneNumber>@vtext.com
        //T-Mobile: <phoneNumber>@tmomail.net
        //Sprint: <phoneNumber>@messaging.sprintpcs.com
    }
}
