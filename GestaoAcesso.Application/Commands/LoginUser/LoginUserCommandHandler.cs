using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GestaoAcesso.Core.Repositories.Login;
using GestaoAcesso.Core.Repositories.Roles;
using GestaoAcesso.Core.Repositories.User;
using GestaoAcesso.Core.Services;
using MediatR;

namespace GestaoAcesso.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result>
    {
        private readonly ILoginUserRepository _loginUserRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(ILoginUserRepository loginUserRepository, IUserRepository userRepository, IRoleRepository roleRepository, IAuthService authService)
        {
            _loginUserRepository = loginUserRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _authService = authService;
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
                var token = _authService.CreateToken(user, _roleRepository.GetRolesAsync(user));

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login Falhou");
        }
    }
}