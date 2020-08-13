using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations
{
    public class StateTimeZoneConfiguration : IEntityTypeConfiguration<StateTimeZone>
    {
        public void Configure(EntityTypeBuilder<StateTimeZone> builder)
        {

            builder.Property(u => u.UTC)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(u => u.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.TimeZoneInfoId)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
