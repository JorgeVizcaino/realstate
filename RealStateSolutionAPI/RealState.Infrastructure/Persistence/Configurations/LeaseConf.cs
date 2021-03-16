using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class LeaseConf : IEntityTypeConfiguration<Lease>
    {
        public void Configure(EntityTypeBuilder<Lease> builder)
        {
            builder.ToTable("Lease")
                .HasKey(x => x.Id);
        }
    }
}
