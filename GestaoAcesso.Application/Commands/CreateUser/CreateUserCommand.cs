using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentResults;
using MediatR;

namespace GestaoAcesso.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Result>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}