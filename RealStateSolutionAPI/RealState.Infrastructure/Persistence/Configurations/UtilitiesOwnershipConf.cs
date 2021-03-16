using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class UtilitiesOwnershipConf : IEntityTypeConfiguration<UtilitiesOwnership>
    {
        public void Configure(EntityTypeBuilder<UtilitiesOwnership> builder)
        {
            builder.ToTable("UtilitiesOwnership")
                .HasKey(x => x.Id);
        }
    }
}
