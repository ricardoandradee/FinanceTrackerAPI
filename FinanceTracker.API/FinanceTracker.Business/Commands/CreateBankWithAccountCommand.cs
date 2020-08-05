using FinanceTracker.Business.Dtos;
using FinanceTracker.Business.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Business.Commands
{
    public class CreateBankWithAccountCommand : IRequest<BankToReturnDto>
    {
        public BankForCreationDto BankForCreationDto { get; }
        public CreateBankWithAccountCommand(BankForCreationDto bankForCreationDto)
        {
            BankForCreationDto = bankForCreationDto;
        }
    }
}
