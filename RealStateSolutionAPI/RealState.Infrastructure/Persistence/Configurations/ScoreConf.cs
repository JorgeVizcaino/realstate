using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class ScoreConf : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("Score")
                .HasKey(x => x.Id);

            builder.Property(e => e.overallScore).HasColumnType("decimal(18,2)");
            builder.Property(e => e.qualityScore).HasColumnType("decimal(18,2)");
            builder.Property(e => e.walkabilityScore).HasColumnType("decimal(18,2)");
        }
    }
}
