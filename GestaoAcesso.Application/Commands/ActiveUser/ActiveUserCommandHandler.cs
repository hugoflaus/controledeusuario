using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GestaoAcesso.Core.Repositories.User;
using MediatR;

namespace GestaoAcesso.Application.Commands.ActiveUser
{
    public class ActiveUserCommandHandler : IRequestHandler<ActiveUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;

        public ActiveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(ActiveUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = await _userRepository.GetUserByIdAsync(request.UsuarioId);
            var identityResult = await _userRepository.ActiveUser(identityUser, request.CodigoAtivacao);

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta do usuário");
        }
    }
}