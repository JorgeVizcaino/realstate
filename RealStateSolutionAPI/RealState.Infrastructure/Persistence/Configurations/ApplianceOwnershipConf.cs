using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class ApplianceOwnershipConf : IEntityTypeConfiguration<ApplianceOwnership>
    {
        public void Configure(EntityTypeBuilder<ApplianceOwnership> builder)
        {
            builder.ToTable("ApplianceOwnership")
                .HasKey(b => b.Id);
        }
    }
}
