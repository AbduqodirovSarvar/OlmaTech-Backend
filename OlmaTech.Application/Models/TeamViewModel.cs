﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Models
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }
        public LocalizableViewModel Firstname { get; set; } = null!;
        public LocalizableViewModel Lastname { get; set; } = null!;
        public LocalizableViewModel Position { get; set; } = null!;
        public string? Photo { get; set; }
        public string? Telegram { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Email { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
