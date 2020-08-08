using AutoMapper;
using FinanceTracker.Application.Common.Extensions;
using FinanceTracker.Application.Dtos.Accounts;
using FinanceTracker.Application.Dtos.Banks;
using FinanceTracker.Application.Dtos.Categories;
using FinanceTracker.Application.Dtos.Payments;
using FinanceTracker.Application.Dtos.Transactions;
using FinanceTracker.Application.Dtos.Users;
using FinanceTracker.Domain.Entities;

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
            CreateMap<Category, CategoryForCreationDto>().ReverseMap();
            CreateMap<Category, CategoryForUpdateDto>().ReverseMap();

            #endregion

            #region Payment related mappings

            CreateMap<Payment, PaymentToReturnDto>()
            .ForMember(dest => dest.CategoryName, opt =>
            {
                opt.MapFrom((s, d) => s.Category?.Name);
            })
            .ForMember(dest => dest.CreatedDateString, opt =>
            {
                opt.MapFrom((s, d) => s.CreatedDate.ToString("MMM/yyyy"));
            }).ReverseMap();


            CreateMap<Payment, PaymentForCreationDto>().ReverseMap();
            CreateMap<Payment, PaymentForUpdateDto>().ReverseMap();

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
        }
    }
}
