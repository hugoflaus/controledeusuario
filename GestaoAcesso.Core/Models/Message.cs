using System;
using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace GestaoAcesso.Core.Models
{
    public class Message
    {
        public Message(IEnumerable<string> destinatario, string assunto, int usuarioId, string code)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(string.Empty, d)));
            Assunto = assunto;
            Conteudo = $"https://localhost:5001/api/users/active?UsuarioId={usuarioId}&CodigoAtivacao={code}";
        }

        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
    }
}