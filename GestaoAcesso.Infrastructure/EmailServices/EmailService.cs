using System;
using System.Threading.Tasks;
using GestaoAcesso.Core.Models;
using GestaoAcesso.Core.Services;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace GestaoAcesso.Infrastructure.EmailServices
{
    public class EmailService : IEmailService
    {

        public IConfiguration Configuration { get; }
        public SmtpConfiguration smtp;
        public EmailService(IConfiguration configuration)
        {
            Configuration = configuration;
            smtp = new SmtpConfiguration();
            Configuration.GetSection("EmailSettings").Bind(smtp);
        }

        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
        {
            var mensagem = new Message(destinatario, assunto, usuarioId, code);
            var mensagemEmail = CriarCorpoEmail(mensagem);
            Enviar(mensagemEmail);
        }

        private MimeMessage CriarCorpoEmail(Message mensagem)
        {
            var mensagemEmail = new MimeMessage();
            mensagemEmail.From.Add(new MailboxAddress("Gestao de Acesso", smtp.From));
            mensagemEmail.To.AddRange(mensagem.Destinatario);
            mensagemEmail.Subject = mensagem.Assunto;
            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };
            return mensagemEmail;
        }

        private void Enviar(MimeMessage mensagemEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(smtp.SmtpServer, Int32.Parse(smtp.Port), true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(smtp.From, smtp.Password);
                    client.Send(mensagemEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }

    public class SmtpConfiguration
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public string Port { get; set; }
        public string Password { get; set; }

    }
}