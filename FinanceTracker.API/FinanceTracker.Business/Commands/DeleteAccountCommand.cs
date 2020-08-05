using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Business.Commands
{
    public class DeleteAccountCommand : IRequest<bool>
    {
        public int AccountId { get; }
        public DeleteAccountCommand(int accountId)
        {
            AccountId = accountId;
        }
    }
}
