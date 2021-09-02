using FinanceTracker.Application.Common.Models;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.IO;

namespace FinanceTracker.API.EmailHandling
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        private async Task<Response<string>> SendEmail(UserEmailDto userEmailDto, EmailDetailsDto emailDetailsDto)
        {
            try
            {
                var sender = new SmtpSender(() => new SmtpClient()
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Host = _config.GetSection("Email:Host").Value, //"smtp.gmail.com",
                    Port = int.Parse(_config.GetSection("Email:Port").Value), //587,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_config.GetSection("Email:Sender").Value, _config.GetSection("Email:Password").Value)
                });

                Email.DefaultSender = sender;

                var email = await Email
                    .From(_config.GetSection("Email:Sender").Value, _config.GetSection("Email:SenderName").Value)
                    .To(userEmailDto.EmailTo, userEmailDto.NameTo)
                    .Subject(emailDetailsDto.Subject)
                    .Body(emailDetailsDto.Body, true)
                    .SendAsync();

                return email.Successful ?
                    Response.Success<string>(emailDetailsDto.SuccessMessage) :
                    Response.Fail("Exception", string.Join('.', email.ErrorMessages));
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

        public async Task<Response<string>> SendVerificationEmail(UserEmailDto emailDetails)
        {
            string firstName = GetUsersFirstName(emailDetails);

            var emailDetailsDto = new EmailDetailsDto
            {
                Body = GetVerificationEmailBody(firstName),
                SuccessMessage = $"An email was sent to {emailDetails.EmailTo}. Please, verify your account before login in.",
                Subject = "Please confirm your SpendWise account"
            };

            return await SendEmail(emailDetails, emailDetailsDto);
        }

        private static string GetVerificationEmailBody(string firstName)
        {
            var fileContent = ReadFile("./Assets/Confirmation - Verification Email.html");
            fileContent = fileContent.Replace("{{User_Name}}", firstName);
            return fileContent;
        }

        private static string GetUsersFirstName(UserEmailDto emailDetails)
        {
            var userName = emailDetails.NameTo;
            if (userName.Length > 2 && userName.Contains(" "))
            {
                userName = userName.Split(' ')[0];
            }

            return userName;
        }

        private static string ReadFile(string FileName)
        {
            using (StreamReader reader = File.OpenText(FileName))
            {
                string fileContent = reader.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(fileContent))
                {
                    return fileContent;
                }
            }
            return string.Empty;
        }
    }
}
