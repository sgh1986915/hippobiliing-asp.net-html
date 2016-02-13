using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Notifications.Email
{

    internal sealed class EmailProvider
    {
        private static readonly SmtpSection Smtp;

        static EmailProvider()
        {
            Smtp = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
        }

        internal static void Send(string recipient, string subject, string message, bool isHtml = true)
        {
            ThreadPool.QueueUserWorkItem(t =>
            {
                var client = new SmtpClient();

                client.SendCompleted += SendCompletedCallback;

                var mail = new MailMessage(Smtp.From, recipient)
                {
                    IsBodyHtml = isHtml,
                    Body = message,
                    Subject = subject
                };
                client.SendAsync(mail, mail);

            });
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the message we sent
            var msg = (MailMessage)e.UserState;

            if (e.Cancelled)
            {
                // prompt user with "send cancelled" message 
            }
            if (e.Error != null)
            {
                // TODO Logo error
                // prompt user with error message 
            }

            // finally dispose of the message
            if (msg != null)
                msg.Dispose();
        }

    }
    
}
