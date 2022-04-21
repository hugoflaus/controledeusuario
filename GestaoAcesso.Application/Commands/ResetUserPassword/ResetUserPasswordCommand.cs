using System.ComponentModel.DataAnnotations;
using FluentResults;
using MediatR;

namespace GestaoAcesso.Application.Commands.ResetUserPassword
{
    public class ResetUserPasswordCommand : IRequest<Result>
    {
        [Required]
        public string Email { get; set; }
    }
}