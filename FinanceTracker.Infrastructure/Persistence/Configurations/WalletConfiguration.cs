using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {

            builder.HasOne(u => u.User)
                .WithMany(u => u.Wallets)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.Name)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
