using AutoMapper;
using FinanceTracker.Application.Common.Exceptions;
using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Common.Models;
using FinanceTracker.Application.Dtos.Transactions;
using FinanceTracker.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Commands.Accounts
{
    public class PerformAccountTransactionCommand : IRequest<Response<TransactionToReturnDto>>
    {
        public TransactionForCreationDto TransactionForCreationDto { get; }
        public PerformAccountTransactionCommand(TransactionForCreationDto transactionForCreationDto)
        {
            TransactionForCreationDto = transactionForCreationDto;
        }

        public class PerformAccountTransactionHandler : IRequestHandler<PerformAccountTransactionCommand, Response<TransactionToReturnDto>>
        {
            private readonly ITransactionRepository _transactionRepository;
            private readonly IMapper _mapper;

            public PerformAccountTransactionHandler(ITransactionRepository transactionRepository, IMapper mapper)
            {
                _mapper = mapper;
                _transactionRepository = transactionRepository;
            }

            public async Task<Response<TransactionToReturnDto>> Handle(PerformAccountTransactionCommand request, CancellationToken cancellationToken)
            {
                var transactionOptions = new string[] { "Deposit", "Withdraw" };
                if (request.TransactionForCreationDto.Amount <= 0)
                {
                    return Response.Fail<TransactionToReturnDto>($"Amount: {request.TransactionForCreationDto.Amount} not allowed.");
                }
                else if (!transactionOptions.Contains(request.TransactionForCreationDto.Action))
                {
                    return Response.Fail<TransactionToReturnDto>($"Action: {request.TransactionForCreationDto.Action} is not supported.");
                }

                var transactionToCreate = _mapper.Map<Transaction>(request.TransactionForCreationDto);
                var transactionCreated = await _transactionRepository.PerformAccountTransaction(transactionToCreate);

                if (transactionCreated == null)
                {
                    throw new NotFoundException(nameof(Transaction));
                }

                return Response.Success(_mapper.Map<TransactionToReturnDto>(transactionCreated));
            }
        }
    }
}
