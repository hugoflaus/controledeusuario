using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GestaoAcesso.Core.Repositories.Login;
using GestaoAcesso.Core.Repositories.User;
using MediatR;

namespace GestaoAcesso.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result>
    {
        private readonly ILoginUserRepository _loginUserRepository;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(ILoginUserRepository loginUserRepository, IUserRepository userRepository)
        {
            _loginUserRepository = loginUserRepository;
            _userRepository = userRepository;
        }
        public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                return Result.Fail("Usuario não encontrado");
            }

            var resultado = await _loginUserRepository.LoginUserAsync(user.UserName, request.Password);
            if (resultado.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Login Falhou");
        }
    }
}