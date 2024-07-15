﻿using MediatR;
using Microsoft.AspNetCore.Http;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.HomePostToDoList.Commands
{
    public class UpdateHomePostCommand : IRequest<HomePost>
    {
        [Required]
        public Guid Id { get; set; }
        // Title
        public string? TitleUz { get; set; } = null;
        public string? TitleEn { get; set; } = null;
        public string? TitleRu { get; set; } = null;
        public string? TitleUzRu { get; set; } = null;

        // SubTitle
        public string? SubtitleUz { get; set; } = null;
        public string? SubitleEn { get; set; } = null;
        public string? SubtitleRu { get; set; } = null;
        public string? SubtitleUzRu { get; set; } = null;

        // Description
        public string? DescriptionUz { get; set; } = null;
        public string? DescriptionEn { get; set; } = null;
        public string? DescriptionRu { get; set; } = null;
        public string? DescriptionUzRu { get; set; } = null;

        public IFormFile? Photo { get; set; } = null;
    }
}
