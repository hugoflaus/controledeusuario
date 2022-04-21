using System.ComponentModel.DataAnnotations;
using FluentResults;
using MediatR;

namespace GestaoAcesso.Application.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Result>
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}