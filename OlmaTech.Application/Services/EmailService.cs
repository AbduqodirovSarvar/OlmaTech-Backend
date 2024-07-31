using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OlmaTech.Application.Services
{
    public class EmailService : IEmailService
    {
        private static readonly Dictionary<string, string> ConfirmationCodes = [];

        public bool CheckConfirmationCodeforResetPassword(string email, string confirmationCode)
        {
            if (ConfirmationCodes[email] == confirmationCode.ToString())
            {
                ConfirmationCodes.Remove(email);
                return true;
            }
            return false;
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            var model = new
            {
                Name = "Test Email",
                Email = email,
                Message = body,
                Subject = subject,
            };

            body = $"<p>Email From: {model.Name} ({model.Email})</p><p>Message:</p><p>{model.Message}</p>";

            var message = new MailMessage();
            message.To.Add(new MailAddress(model.Email));
            message.From = new MailAddress("abduqodirovsarvar.2002@gmail.com");
            message.Subject = model.Subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("abduqodirovsarvar.2002@gmail.com", "hgjb mvzo nuji fcwb"),
                EnableSsl = true,
            };

            try
            {
                await smtp.SendMailAsync(message);
                Console.WriteLine("Message sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SendConfirmationCodeForResetPasswordAsync(string email)
        {
            try
            {
                int confirmationCode = RandomNumberGenerator.GetInt32(10000, 99999);
                await SendEmailAsync(email, "Confirmation Code for reset password", confirmationCode.ToString());
                ConfirmationCodes.Remove(email);
                ConfirmationCodes.Add(email, confirmationCode.ToString());
                return true;
            }
            catch { 
                return false;
            }
        }
    }
}
