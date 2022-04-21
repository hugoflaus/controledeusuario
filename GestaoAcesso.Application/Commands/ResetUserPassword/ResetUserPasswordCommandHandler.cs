using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GestaoAcesso.Core.Repositories.User;
using MediatR;

namespace GestaoAcesso.Application.Commands.ResetUserPassword
{
    public class ResetUserPasswordCommandHandler : IRequestHandler<ResetUserPasswordCommand, Result>
    {
        private readonly IUserRepository _userRepository;

        public ResetUserPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(ResetUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var userIdentity = await _userRepository.GetUserByEmailAsync(request.Email);

            if (userIdentity != null)
            {
                var codigoRecuperacao = await _userRepository.GenerateResetToken(userIdentity);
                return Result.Ok().WithSuccess(codigoRecuperacao);
            }

            return Result.Fail("Falaha ao solicitar redefinição");

        }
    }
}