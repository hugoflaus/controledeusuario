using System.ComponentModel.DataAnnotations;
using FluentResults;
using MediatR;

namespace GestaoAcesso.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<Result>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}