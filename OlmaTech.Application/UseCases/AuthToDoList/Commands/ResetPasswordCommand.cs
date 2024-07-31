using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OlmaTech.Application.UseCases.AuthToDoList.Commands
{
    public class ResetPasswordCommand : IRequest<bool>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
        [Required]
        [PasswordPropertyText]
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        public string ConfirmationCode { get; set; } = null!;
    }
}
