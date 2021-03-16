using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class PhysicalConf : IEntityTypeConfiguration<Physical>
    {
        public void Configure(EntityTypeBuilder<Physical> builder)
        {
            builder.ToTable("Physical")
                .HasKey(x => x.Id);
        }
    }
}
