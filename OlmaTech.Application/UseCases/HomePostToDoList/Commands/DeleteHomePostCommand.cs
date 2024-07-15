﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.HomePostToDoList.Commands
{
    public class DeleteHomePostCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
