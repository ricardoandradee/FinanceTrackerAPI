using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Email;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Email
{
    public class EmailHandler : IEmailHandler
    {
        private readonly IConfiguration _config;
        public EmailHandler(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Response<string>> SendEmail(UserEmailDto userEmailDto, EmailDetailsDto emailDetailsDto)
        {
            try
            {
                using MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_config.GetSection("Email:Sender").Value, _config.GetSection("Email:SenderName").Value);
                mail.To.Add(new MailAddress(userEmailDto.EmailTo, userEmailDto.NameTo));
                mail.Subject = emailDetailsDto.Subject;
                mail.Body = emailDetailsDto.Body;
                mail.IsBodyHtml = true;

                using SmtpClient smtp = new SmtpClient();
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Host = _config.GetSection("Email:Host").Value;
                smtp.Port = int.Parse(_config.GetSection("Email:Port").Value);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_config.GetSection("Email:Sender").Value, _config.GetSection("Email:Password").Value);
                await smtp.SendMailAsync(mail);

                return Response.Success(emailDetailsDto.SuccessMessage);

            }
            catch (SmtpException ex)
            {
                return Response.Fail("Exception", ex.Message);
            }
            catch (Exception ex)
            {
                return Response.Fail("Exception", ex.Message);
            }
        }
    }
}
