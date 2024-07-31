using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OlmaTech.Application.Abstractions;
using OlmaTech.Application.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Extentions
{
    public static class DepencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DepencyInjection).Assembly);
            });

            services.AddTransient(typeof(EnumNameResolver<>));

            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IFileService, FileService>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
