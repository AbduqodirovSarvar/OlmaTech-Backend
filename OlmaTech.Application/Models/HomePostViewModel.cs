﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Models
{
    public class HomePostViewModel
    {
        public Guid Id { get; set; }
        public LocalizableViewModel Title { get; set; } = null!;
        public LocalizableViewModel Subtitle { get; set; } = null!;
        public LocalizableViewModel Description { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
