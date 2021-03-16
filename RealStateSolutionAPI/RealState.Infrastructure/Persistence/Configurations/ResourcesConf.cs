using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class ResourcesConf : IEntityTypeConfiguration<Resources>
    {
        public void Configure(EntityTypeBuilder<Resources> builder)
        {
            builder.ToTable("Resources")
                .HasKey(x => x.Id);
        }
    }
}
