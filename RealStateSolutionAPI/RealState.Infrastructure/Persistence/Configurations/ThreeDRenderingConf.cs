using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class ThreeDRenderingConf : IEntityTypeConfiguration<ThreeDRendering>
    {
        public void Configure(EntityTypeBuilder<ThreeDRendering> builder)
        {
            builder.ToTable("ThreeDRendering")
                .HasKey(x => x.ThreeDRenderingId);
        }
    }
}
