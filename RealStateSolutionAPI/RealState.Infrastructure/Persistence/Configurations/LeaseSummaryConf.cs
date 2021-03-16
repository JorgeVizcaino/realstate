using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class LeaseSummaryConf : IEntityTypeConfiguration<LeaseSummary>
    {
        public void Configure(EntityTypeBuilder<LeaseSummary> builder)
        {
            builder.ToTable("LeaseSummary")
                .HasKey(x => x.Id);

            builder.Property(e => e.marketedRent).HasColumnType("decimal(18,2)");
            builder.Property(e => e.petFeeAmount).HasColumnType("decimal(18,2)");
        }
    }
}
