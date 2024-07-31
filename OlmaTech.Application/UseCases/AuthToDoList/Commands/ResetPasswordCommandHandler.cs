using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.AuthToDoList.Commands
{
    public class ResetPasswordCommandHandler(
        IAppDbContext appDbContext,
        IEmailService emailService,
        IHashService hashService
        ) : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IEmailService _emailService = emailService;
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IHashService _hashService = hashService;

        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken)
                                                ?? throw new Exception("User not found");

            if(request.Password != request.ConfirmPassword)
            {
                throw new Exception("Password did not confirm");
            }

            if(!_emailService.CheckConfirmationCodeforResetPassword(user.Email, request.ConfirmationCode))
            {
                throw new Exception("Confirmation code is not correct");
            }

            user.PasswordHash = _hashService.GetHash(request.Password);

            return (await _appDbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
