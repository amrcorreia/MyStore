﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Helpers
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration _configuration;

        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMail(string to, string subject, string body)
        {
            var nameFrom = _configuration["Mail:NameFrom"];
            var from = _configuration["Mail:From"];
            var smtp = _configuration["Mail:Smtp"];
            var port = _configuration["Mail:Port"];
            var password = _configuration["Mail:Password"];

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(nameFrom, from));
            message.To.Add(new MailboxAddress(to, to));
            message.Subject = subject;

            var bodybuilder = new BodyBuilder
            {
                HtmlBody = body
            };
            message.Body = bodybuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(smtp, int.Parse(port), false);
                client.Authenticate(from, password);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void SendEmailPlusAttachment(string to, string subject, string body, byte[] pdf)
        {
            var nameFrom = _configuration["Mail:NameFrom"];
            var from = _configuration["Mail:From"];
            var smtp = _configuration["Mail:Smtp"];
            var port = _configuration["Mail:Port"];
            var pw = _configuration["Mail:Password"];

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(nameFrom, from));
            message.To.Add(new MailboxAddress(to, to));

            message.Subject = subject;

            var bodybuilder = new BodyBuilder
            {
                HtmlBody = body
            };
            bodybuilder.Attachments.Add($"order_{DateTime.Now}.pdf", pdf);

            message.Body = bodybuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(smtp, int.Parse(port), false);
                client.Authenticate(from, pw);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        //public void SendEmailPlusAttachment(string to, string subject, string body, byte[] pdf)
        //{
        //    var nameFrom = _configuration["Mail:NameFrom"];
        //    var from = _configuration["Mail:From"];
        //    var smtp = _configuration["Mail:Smtp"];
        //    var port = _configuration["Mail:Port"];
        //    var pw = _configuration["Mail:Password"];

        //    var message = new MimeMessage();
        //    message.From.Add(new MailboxAddress(nameFrom, from));
        //    message.To.Add(new MailboxAddress(to, to));

        //    message.Subject = subject;

        //    var bodybuilder = new BodyBuilder
        //    {
        //        HtmlBody = body
        //    };
        //    bodybuilder.Attachments.Add($"order_{DateTime.Now}.pdf", pdf);

        //    message.Body = bodybuilder.ToMessageBody();

        //    using (var client = new SmtpClient())
        //    {
        //        client.Connect(smtp, int.Parse(port), false);
        //        client.Authenticate(from, pw);
        //        client.Send(message);
        //        client.Disconnect(true);
        //    }
        //}
    }
}
