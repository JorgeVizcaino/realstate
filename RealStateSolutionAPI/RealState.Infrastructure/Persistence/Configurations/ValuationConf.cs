using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class ValuationConf : IEntityTypeConfiguration<Valuation>
    {
        public void Configure(EntityTypeBuilder<Valuation> builder)
        {
            builder.ToTable("Valuation")
                .HasKey(x => x.id);
        }
    }
}
