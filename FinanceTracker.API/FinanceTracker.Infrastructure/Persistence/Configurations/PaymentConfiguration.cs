using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasOne(t => t.Category);

            builder.HasMany(t => t.Transactions);

            builder.Property(t => t.Address)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Establishment)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Currency)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(t => t.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(t => t.AmountPaid)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
