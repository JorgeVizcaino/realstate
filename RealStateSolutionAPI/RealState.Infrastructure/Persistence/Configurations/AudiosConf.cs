using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class AudiosConf : IEntityTypeConfiguration<Audios>
    {
        public void Configure(EntityTypeBuilder<Audios> builder)
        {
            builder.ToTable("Audios")
                .HasKey(b => b.Id);
        }
    }
}
