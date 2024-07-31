using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.AuthToDoList.Queries
{
    internal class GetEmailConfirmationCodeQueryHandler(
        IAppDbContext appDbContext,
        IEmailService emailService
        ) : IRequestHandler<GetEmailConfirmationCodeQuery, bool>
    {
        private readonly IEmailService _emailService = emailService;
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task<bool> Handle(GetEmailConfirmationCodeQuery request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken)
                                               ?? throw new Exception("User not found");

            await _emailService.SendConfirmationCodeForResetPasswordAsync(user.Email);
            return true;
        }
    }
}
