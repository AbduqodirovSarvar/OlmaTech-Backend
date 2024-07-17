﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ProjectToDoList.Commands
{
    public class DeleteProjectCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
