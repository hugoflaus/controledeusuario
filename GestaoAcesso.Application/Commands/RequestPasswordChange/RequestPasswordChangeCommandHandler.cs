using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GestaoAcesso.Application.Commands.RequestPasswordChange;
using GestaoAcesso.Core.Repositories.User;
using MediatR;

namespace GestaoAcesso.Application.Commands.RequestPasswordChange
{
    public class RequestPasswordChangeCommandHandler : IRequestHandler<RequestPasswordChangeCommand, Result>
    {
        private readonly IUserRepository _userRepository;

        public RequestPasswordChangeCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(RequestPasswordChangeCommand request, CancellationToken cancellationToken)
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