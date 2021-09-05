using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Email;
using FinanceTracker.Application.Email;
using FinanceTracker.Application.Utils;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Email
{
    public class SendPasswordResetEmailCommand : IRequest<Response<string>>
    {
        public string Email { get; }
        public SendPasswordResetEmailCommand(string email)
        {
            Email = email;
        }

        public class SendAccountVerificationEmailHandler : IRequestHandler<SendPasswordResetEmailCommand, Response<string>>
        {
            private readonly IEmailHandler _emailHandler;
            private readonly IFileHandler _fileHandler;
            private readonly IUserRepository _userRepository;

            public SendAccountVerificationEmailHandler(IEmailHandler emailHandler,
                IFileHandler fileHandler, IUserRepository userRepository)
            {
                _emailHandler = emailHandler;
                _fileHandler = fileHandler;
                _userRepository = userRepository;
            }

            public async Task<Response<string>> Handle(SendPasswordResetEmailCommand request, CancellationToken cancellationToken)
            {
                var userResponse = await _userRepository.SetUserConfirmationCodeByEmail(request.Email);
                if (!userResponse.Ok)
                {
                    return Response.Fail<string>(userResponse.Message);
                }

                var emailDetails = new UserEmailDto
                {
                    ConfirmationCode = userResponse.Data.ConfirmationCode ?? Guid.Empty,
                    EmailTo = userResponse.Data.Email,
                    NameTo = userResponse.Data.FullName,
                    UserId = userResponse.Data.Id
                };

                return await SendPasswordResetEmail(emailDetails);
            }

            private async Task<Response<string>> SendPasswordResetEmail(UserEmailDto emailDetails)
            {
                string userName = GetUsersFirstName(emailDetails);

                var emailDetailsDto = new EmailDetailsDto
                {
                    Body = GetVerificationEmailBody(userName, emailDetails.UserId, emailDetails.ConfirmationCode),
                    SuccessMessage = $"An email was sent to {emailDetails.EmailTo}. Please, use the link to reset your password.",
                    Subject = "Change your SpendWise password"
                };

                return await _emailHandler.SendEmail(emailDetails, emailDetailsDto);
            }

            private string GetVerificationEmailBody(string userName, int userId, Guid confirmationCode)
            {
                var fileContent = _fileHandler.ReadFile("./Assets/Password Reset Email.html");
                fileContent = fileContent.Replace("{{User_Name}}", userName);
                fileContent = fileContent.Replace("{{User_Id}}", userId.ToString());
                fileContent = fileContent.Replace("{{Confirmation_Code}}", confirmationCode.ToString());
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
