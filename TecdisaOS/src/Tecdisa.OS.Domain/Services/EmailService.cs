using System.Net;
using System.Net.Mail;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Domain.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(OrdemDeServico os, Programador programador)
        {
            var fromAddress = new MailAddress("vinicius.mamore@gmail.com", "Vinicius Mamoré");
            var toAddress = new MailAddress(programador.Email, programador.Nome);

            const string fromPassword = "mamore9874123";
            const string subject = "Novo Atendimento!";
            string body = $"Cliente: {os.ClienteNome}\n" +
                        $"Técnico: {os.TecnicoId}\n " +
                        "--------- Problema --------\n" +
                        $"{os.Problema}\n" +
                        "-------- Observação --------\n" +
                        $"{os.Observacao}\n" +
                        $"Data: {os.DataCadastro.ToShortDateString()}";



            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
