using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GestaoAcesso.Core.Repositories.User;
using MediatR;

namespace GestaoAcesso.Application.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Result>
    {
        private readonly IUserRepository _userRepository;

        public ResetPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var userIdentity = await _userRepository.GetUserByEmailAsync(request.Email);

            var resultadoIdentity = await _userRepository.ResetPassword(userIdentity, request.Token, request.Password);

            if (resultadoIdentity.Succeeded)
                return Result.Ok().WithSuccess("Senha redefinida com sucesso");

            return Result.Fail("Houve um erro na operação");

        }
    }
}