using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Email;
using FinanceTracker.Application.Email;
using FinanceTracker.Application.Utils;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Email
{
    public class SendAccountVerificationEmailCommand : IRequest<Response<string>>
    {
        public UserEmailDto UserEmailDto { get; }
        public SendAccountVerificationEmailCommand(UserEmailDto userEmailDto)
        {
            UserEmailDto = userEmailDto;
        }

        public class SendAccountVerificationEmailHandler : IRequestHandler<SendAccountVerificationEmailCommand, Response<string>>
        {
            private readonly IEmailHandler _emailHandler;
            private readonly IFileHandler _fileHandler;

            public SendAccountVerificationEmailHandler(IEmailHandler emailHandler,
                IFileHandler fileHandler)
            {
                _emailHandler = emailHandler;
                _fileHandler = fileHandler;
            }

            public async Task<Response<string>> Handle(SendAccountVerificationEmailCommand request, CancellationToken cancellationToken)
            {
                return await SendVerificationEmail(request.UserEmailDto);
            }

            private async Task<Response<string>> SendVerificationEmail(UserEmailDto emailDetails)
            {
                string firstName = GetUsersFirstName(emailDetails);

                var emailDetailsDto = new EmailDetailsDto
                {
                    Body = GetVerificationEmailBody(firstName),
                    SuccessMessage = $"An email was sent to {emailDetails.EmailTo}. Please, verify your account before login in.",
                    Subject = "Please confirm your SpendWise account"
                };

                return await _emailHandler.SendEmail(emailDetails, emailDetailsDto);
            }

            private string GetVerificationEmailBody(string firstName)
            {
                var fileContent = _fileHandler.ReadFile("./Assets/Confirmation - Verification Email.html");
                fileContent = fileContent.Replace("{{User_Name}}", firstName);
                return fileContent;
            }

            private string GetUsersFirstName(UserEmailDto emailDetails)
            {
                var userName = emailDetails.NameTo;
                if (userName.Length > 2 && userName.Contains(" "))
                {
                    userName = userName.Split(' ')[0];
                }

                return userName;
            }
        }

    }
}
