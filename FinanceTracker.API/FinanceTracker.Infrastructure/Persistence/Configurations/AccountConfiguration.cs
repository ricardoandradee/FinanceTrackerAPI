using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(u => u.Bank)
                .WithMany(u => u.Accounts)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Number)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasOne(t => t.Currency);
        }
    }
}
