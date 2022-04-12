using System.Threading.Tasks;

namespace GestaoAcesso.Core.Services
{
    public interface IEmailService
    {
        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code);
    }
}