using LoggingEmailApp.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoggingEmailApp.Services
{
    public class EmailService
    {
        private readonly SendGridMessage _message;
        private readonly SendGridClient _client;

        public EmailService(string apiKey, string senderEmail = "info@cyberadmin.com", string senderName =  "Admin")
        {
            _message = new SendGridMessage { From = new EmailAddress(senderEmail, senderName) };
            _client = new SendGridClient(apiKey);
        }

        public void SendMail(EmailMessage msg, bool isHtml, string fileName, Byte[] fileBytes)
        {
            _message.AddTo(msg.Recipient);
            _message.Subject = msg.Subject;

            if (!isHtml) _message.PlainTextContent = msg.Message;
            _message.HtmlContent = msg.Message;
            if(!string.IsNullOrEmpty(fileName))
            {
                string fileContents = Convert.ToBase64String(fileBytes);
                _message.AddAttachment(fileName, fileContents);
            }

            _client.SendEmailAsync(_message);
        }
    }
}