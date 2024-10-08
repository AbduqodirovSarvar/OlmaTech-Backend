﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlmaTech.Application.Abstractions;
using System.Net.Mime;

namespace OlmaTech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class FileController(IFileService fileService) : ControllerBase
    {
        private readonly IFileService _fileService = fileService;

        [HttpGet("{fileName}")]
        public IActionResult GetFile([FromRoute] string fileName)
        {
            var filePath = _fileService.GetFilePath(fileName);

            if (filePath == null || !System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            string contentType = GetContentType(fileName);

            return PhysicalFile(filePath, contentType);
        }

        [HttpGet("download/{fileName}")]
        public IActionResult DownloadFile([FromRoute] string fileName)
        {
            var fileStream = _fileService.GetFileByFileName(fileName);

            if (fileStream == null)
            {
                return NotFound();
            }

            string contentType = GetContentType(fileName);

            return File(fileStream, contentType, fileName);
        }

        private static string GetContentType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLowerInvariant();

            return extension switch
            {
                ".png" => "image/png",
                ".jpg" or ".jpeg" => MediaTypeNames.Image.Jpeg,
                ".pdf" => MediaTypeNames.Application.Pdf,
                _ => MediaTypeNames.Application.Octet,
            };
        }
    }
}
