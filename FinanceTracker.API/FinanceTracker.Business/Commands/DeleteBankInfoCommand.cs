using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Business.Commands
{
    public class DeleteBankInfoCommand : IRequest<bool>
    {
        public int BankId { get; }
        public DeleteBankInfoCommand(int bankId)
        {
            BankId = bankId;
        }
    }
}
