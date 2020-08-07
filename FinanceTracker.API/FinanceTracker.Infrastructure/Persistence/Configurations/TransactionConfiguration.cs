using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(u => u.Account)
                .WithMany(u => u.Transactions)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.Action)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(255)
                .IsRequired();


            builder.HasOne(s => s.Account);
        }
    }
}
