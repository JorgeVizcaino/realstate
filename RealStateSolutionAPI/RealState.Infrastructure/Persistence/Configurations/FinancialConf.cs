using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class FinancialConf : IEntityTypeConfiguration<Financial>
    {
        public void Configure(EntityTypeBuilder<Financial> builder)
        {
            builder.ToTable("Financial")
                .HasKey(x => x.Id);

            builder.Property(e => e.capRate).HasColumnType("decimal(18,2)");
            builder.Property(e => e.listPrice).HasColumnType("decimal(18,2)");
            builder.Property(e => e.salePrice).HasColumnType("decimal(18,2)");
            builder.Property(e => e.marketValue).HasColumnType("decimal(18,2)");
            builder.Property(e => e.monthlyHoa).HasColumnType("decimal(18,2)");
            builder.Property(e => e.monthlyManagementFees).HasColumnType("decimal(18,2)");
            builder.Property(e => e.monthlyRent).HasColumnType("decimal(18,2)");
            builder.Property(e => e.netYield).HasColumnType("decimal(18,2)");
            builder.Property(e => e.turnOverFee).HasColumnType("decimal(18,2)");
            builder.Property(e => e.rehabCosts).HasColumnType("decimal(18,2)");
            builder.Property(e => e.rehabDate).HasColumnType("decimal(18,2)");
            builder.Property(e => e.yearlyInsuranceCost).HasColumnType("decimal(18,2)");
            builder.Property(e => e.yearlyPropertyTaxes).HasColumnType("decimal(18,2)");
        }
    }
}
