﻿using OlmaTech.Domain.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Domain.Abstractions
{
    public abstract class EntityBase : IEntityBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
