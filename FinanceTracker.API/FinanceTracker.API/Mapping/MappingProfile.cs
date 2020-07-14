using AutoMapper;
using FinanceTracker.API.Dtos;
using FinanceTracker.API.Helpers;
using FinanceTracker.API.Models;

namespace FinanceTracker.API.Mapping
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
            CreateMap<CategoryForCreationDto, Category>().ReverseMap();
            CreateMap<CategoryForUpdateDto, Category>().ReverseMap();

            #endregion

            #region Payment related mappings

            CreateMap<Payment, PaymentToReturnDto>()
            .ForMember(dest => dest.CategoryName, opt =>
            {
                opt.MapFrom((s, d) => s.Category.Name);
            })
            .ForMember(dest => dest.CreatedDateString, opt =>
            {
                opt.MapFrom((s, d) => s.CreatedDate.HasValue ? s.CreatedDate.Value.ToString("MMM/yyyy") : string.Empty);
            }).ReverseMap();


            CreateMap<PaymentForCreationDto, Payment>().ReverseMap();
            CreateMap<PaymentForUpdateDto, Payment>().ReverseMap();

            #endregion

            #region Bank related mappings

            CreateMap<BankToReturnDto, Bank>().ReverseMap();
            CreateMap<BankForCreationDto, Bank>().ReverseMap();
            CreateMap<BankForUpdateDto, Bank>().ReverseMap();

            #endregion

            #region Account related mappings

            CreateMap<AccountToReturnDto, Account>().ReverseMap();
            CreateMap<AccountForCreationDto, Account>().ReverseMap();
            CreateMap<AccountForUpdateDto, Account>().ReverseMap();

            #endregion
        }
    }
}