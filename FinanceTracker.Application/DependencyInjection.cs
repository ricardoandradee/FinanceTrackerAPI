using AutoMapper;
using FinanceTracker.Application.Common.Mappings;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FinanceTracker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // Updated MediatR registration to use RegisterServicesFromAssembly for newer MediatR versions
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
