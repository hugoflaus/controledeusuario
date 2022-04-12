using System.Web;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using GestaoAcesso.Core.Entity;
using GestaoAcesso.Core.Repositories.User;
using GestaoAcesso.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using GestaoAcesso.Core.Services;

namespace GestaoAcesso.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IEmailService emailService, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Usuario>(request);
            var usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            var resultado = await _userRepository.CreateUserAsync(usuarioIdentity, request.Password);

            if (resultado.Succeeded)
            {
                var code = await _userRepository.GenerateEmailConfirmationTokenAsync(usuarioIdentity);
                var encodeCode = HttpUtility.UrlEncode(code);

                _emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de ativação", usuarioIdentity.Id, encodeCode);

                return Result.Ok().WithSuccess(code);
            }

            return Result.Fail("Falha ao cadastrar usuário");

        }
    }
}