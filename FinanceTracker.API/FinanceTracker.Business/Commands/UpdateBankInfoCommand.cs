using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Business.Commands
{
    public class UpdateBankInfoCommand : IRequest<bool>
    {
        public int BankId { get; }
        public BankForUpdateDto BankForUpdateDto { get; }
        public UpdateBankInfoCommand(int bankId, BankForUpdateDto bankForUpdateDto)
        {
            BankId = bankId;
            BankForUpdateDto = bankForUpdateDto;
        }
    }
}
