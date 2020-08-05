using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Business.Commands
{
    public class CreateAccountCommand : IRequest<AccountToReturnDto>
    {
        public AccountForCreationDto AccountForCreationDto { get; }
        public CreateAccountCommand(AccountForCreationDto accountForCreationDto)
        {
            AccountForCreationDto = accountForCreationDto;
        }
    }
}
