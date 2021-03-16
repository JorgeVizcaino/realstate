using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class DiligencesConf : IEntityTypeConfiguration<Diligences>
    {
        public void Configure(EntityTypeBuilder<Diligences> builder)
        {
            builder.ToTable("Diligences")
                .HasKey(b => b.Id);
        }
    }
}
