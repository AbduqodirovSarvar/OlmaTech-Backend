using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Abstractions
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string body);
        Task<bool> SendConfirmationCodeForResetPasswordAsync(string email);
        bool CheckConfirmationCodeforResetPassword(string email, string confirmationCode);
    }
}
