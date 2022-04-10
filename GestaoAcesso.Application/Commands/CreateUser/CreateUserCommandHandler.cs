using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using GestaoAcesso.Core.Entity;
using GestaoAcesso.Core.Repositories.User;
using GestaoAcesso.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GestaoAcesso.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Usuario>(request);
            var usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            var resultado = await _userRepository.CreateUserAsync(usuarioIdentity, request.Password);

            if (resultado.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao cadastrar usuário");

        }
    }
}