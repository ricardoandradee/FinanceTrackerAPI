﻿using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceTracker.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.FullName)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(t => t.Currency);

            builder.Property(t => t.Email)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
