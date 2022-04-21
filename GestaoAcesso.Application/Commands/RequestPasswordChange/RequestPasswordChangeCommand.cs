using System.ComponentModel.DataAnnotations;
using FluentResults;
using MediatR;

namespace GestaoAcesso.Application.Commands.RequestPasswordChange
{
    public class RequestPasswordChangeCommand : IRequest<Result>
    {
        [Required]
        public string Email { get; set; }
    }
}