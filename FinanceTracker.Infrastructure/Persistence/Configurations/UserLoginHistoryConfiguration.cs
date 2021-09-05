using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations
{
    public class UserLoginHistoryConfiguration : IEntityTypeConfiguration<UserLoginHistory>
    {
        public void Configure(EntityTypeBuilder<UserLoginHistory> builder)
        {
            builder.Property(t => t.IPAddress)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.GeoLocation)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.IsSuccessful)
                .IsRequired();
        }
    }
}
