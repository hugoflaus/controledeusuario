using AutoMapper;
using GestaoAcesso.Application.Commands.CreateUser;
using GestaoAcesso.Core.Entity;
using Microsoft.AspNetCore.Identity;

namespace GestaoAcesso.Application.Mapping
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUserCommand, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}