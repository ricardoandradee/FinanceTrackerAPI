using FinanceTracker.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Business.Commands
{
    public class UpdateAccountCommand : IRequest<bool>
    {
        public int AccountId { get; }
        public AccountForUpdateDto AccountForUpdateDto { get; set; }
        public UpdateAccountCommand(AccountForUpdateDto accountForUpdateDto, int accountId)
        {
            AccountId = accountId;
            AccountForUpdateDto = accountForUpdateDto;
        }
    }
}
