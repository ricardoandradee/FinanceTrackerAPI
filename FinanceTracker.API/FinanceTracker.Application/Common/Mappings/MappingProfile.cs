using AutoMapper;
using FinanceTracker.Application.Common.Extensions;
using FinanceTracker.Application.Dtos;
using FinanceTracker.Domain.Entities;
using System.Collections.Generic;

namespace FinanceTracker.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User related mappings

            CreateMap<User, UserForListDto>()
                 .ForMember(dest => dest.Age, opt =>
                 {
                     opt.MapFrom((s, d) => s.DateOfBirth.CalculateAge());
                 })
                .ReverseMap();
            CreateMap<User, UserForDetailedDto>()
                 .ForMember(dest => dest.Age, opt =>
                 {
                     opt.MapFrom((s, d) => s.DateOfBirth.CalculateAge());
                 })
                .ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();

            #endregion

            #region Category related mappings

            CreateMap<Category, CategoryToReturnDto>().ReverseMap();
            CreateMap<Category, CategoryForCreationDto>()
            .ForMember(dest => dest.UserId, opt =>
            {
                opt.MapFrom((s, d) => s.User.Id);
            }).ReverseMap();
            CreateMap<Category, CategoryForUpdateDto>().ReverseMap();

            #endregion

            #region Payment related mappings

            CreateMap<Payment, PaymentToReturnDto>()
            .ForMember(dest => dest.CategoryId, opt =>
            {
                opt.MapFrom((s, d) => s.Category.Id);
            })
            .ForMember(dest => dest.CategoryName, opt =>
            {
                opt.MapFrom((s, d) => s.Category?.Name);
            })
            .ForMember(dest => dest.CreatedDateString, opt =>
            {
                opt.MapFrom((s, d) => s.CreatedDate.ToString("MMM/yyyy"));
            }).ReverseMap();


            CreateMap<Payment, PaymentForCreationDto>()
            .ForMember(dest => dest.CategoryId, opt =>
            {
                opt.MapFrom((s, d) => s.Category.Id);
            }).ReverseMap();
            CreateMap<Payment, PaymentForUpdateDto>()
            .ForMember(dest => dest.CategoryId, opt =>
            {
                opt.MapFrom((s, d) => s.Category.Id);
            }).ReverseMap();

            #endregion

            #region Bank related mappings

            CreateMap<Bank, BankToReturnDto>().ReverseMap();

            CreateMap<Bank, BankForCreationDto>()
            .ForMember(dest => dest.UserId, opt =>
            {
                opt.MapFrom((s, d) => s.User.Id);
            }).ReverseMap();

            CreateMap<Bank, BankForUpdateDto>()
            .ForMember(dest => dest.AccountsForCreation, opt =>
            {
                opt.MapFrom((s, d) => s.Accounts);
            }).ReverseMap();

            #endregion

            #region Account related mappings

            CreateMap<Account, AccountToReturnDto>()
            .ForMember(dest => dest.BankId, opt =>
            {
                opt.MapFrom((s, d) => s.Bank.Id);
            }).ReverseMap();
            CreateMap<Account, AccountForCreationDto>()
            .ForMember(dest => dest.BankId, opt =>
            {
                opt.MapFrom((s, d) => s.Bank.Id);
            }).ReverseMap();
            CreateMap<Account, AccountForUpdateDto>().ReverseMap();
            CreateMap<Account, AccountToReturnIntoTransactionDto>().ReverseMap();

            #endregion

            #region Transaction related mappings

            CreateMap<Transaction, TransactionToReturnDto>().ReverseMap();
            CreateMap<Transaction, TransactionForCreationDto>()
            .ForMember(dest => dest.AccountId, opt =>
            {
                opt.MapFrom((s, d) => s.Account.Id);
            }).ReverseMap();
            CreateMap<Transaction, TransactionToReturnWithoutAccountDto>().ReverseMap();

            #endregion
        }
    }
}
