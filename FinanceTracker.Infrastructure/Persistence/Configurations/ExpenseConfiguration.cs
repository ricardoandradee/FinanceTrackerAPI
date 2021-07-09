using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasOne(t => t.Category);
            builder.HasMany(t => t.Transactions);

            builder.HasOne(u => u.Currency)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.Establishment)
                .HasMaxLength(50);

            builder.Property(t => t.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(t => t.AmountPaid)
                .HasColumnType("decimal(18,2)");
        }
    }
}
