﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.AuthToDoList.Queries
{
    public class GetEmailConfirmationCodeQuery : IRequest<bool>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
