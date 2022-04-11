using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using FluentResults;
using MediatR;

namespace GestaoAcesso.Application.Commands.ActiveUser
{
    public class ActiveUserCommand : IRequest<Result>
    {
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public string CodigoAtivacao { get; set; }
    }
}