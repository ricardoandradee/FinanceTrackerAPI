﻿using AutoMapper;
using FinanceTracker.Application.Dtos.Accounts;
using FinanceTracker.Application.Dtos.Banks;
using FinanceTracker.Application.Dtos.Categories;
using FinanceTracker.Application.Dtos.Currencies;
using FinanceTracker.Application.Dtos.Expenses;
using FinanceTracker.Application.Dtos.TimeZones;
using FinanceTracker.Application.Dtos.Transactions;
using FinanceTracker.Application.Dtos.UserLoginHistories;
using FinanceTracker.Application.Dtos.Users;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User related mappings

            CreateMap<User, UserInfoForSignupDto>().ReverseMap();
            CreateMap<User, UserForDetailDto>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
            CreateMap<User, UserForUpdateDto>().ReverseMap();

            #endregion

            #region Category related mappings

            CreateMap<Category, CategoryToReturnDto>().ReverseMap();
            CreateMap<Category, CategoryForCreationDto>().ReverseMap();
            CreateMap<Category, CategoryForUpdateDto>().ReverseMap();

            #endregion

            #region Expense related mappings

            CreateMap<Expense, ExpenseToReturnDto>()
            .ForMember(dest => dest.CreatedDateString, opt =>
            {
                opt.MapFrom((s, d) => s.CreatedDate.ToString("MMM/yyyy"));
            })
            .ForMember(dest => dest.TransactionAmount, opt =>
            {
                opt.MapFrom((s, d) => s.Transaction?.Amount);
            })
            .ForMember(dest => dest.AccountId, opt =>
            {
                opt.MapFrom((s, d) => s.Transaction?.AccountId);
            }).ReverseMap();


            CreateMap<Expense, ExpenseForCreationDto>().ReverseMap();
            CreateMap<Expense, ExpenseForUpdateDto>().ReverseMap();

            #endregion

            #region Bank related mappings

            CreateMap<Bank, BankToReturnDto>().ReverseMap();

            CreateMap<Bank, BankForCreationDto>().ReverseMap();

            CreateMap<Bank, BankForUpdateDto>()
            .ForMember(dest => dest.AccountsForCreation, opt =>
            {
                opt.MapFrom((s, d) => s.Accounts);
            }).ReverseMap();

            #endregion

            #region Account related mappings

            CreateMap<Account, AccountToReturnDto>().ReverseMap();
            CreateMap<Account, AccountForCreationDto>().ReverseMap();
            CreateMap<Account, AccountForUpdateDto>().ReverseMap();
            CreateMap<Account, AccountToReturnIntoTransactionDto>().ReverseMap();

            #endregion

            #region Transaction related mappings

            CreateMap<Transaction, TransactionToReturnDto>().ReverseMap();
            CreateMap<Transaction, TransactionForCreationDto>().ReverseMap();
            CreateMap<Transaction, TransactionToReturnWithoutAccountDto>().ReverseMap();

            #endregion

            #region Currency related mappings

            CreateMap<Currency, CurrencyDto>().ReverseMap();
            CreateMap<Currency, CurrencyToReturnDto>().ReverseMap();

            #endregion

            #region TimeZone related mappings

            CreateMap<StateTimeZone, StateTimeZoneToReturnDto>().ReverseMap();

            #endregion

            #region UserLoginHistory related mappings

            CreateMap<UserLoginHistory, UserLoginHistoryForCreationDto>().ReverseMap();

            #endregion            
        }
    }
}
