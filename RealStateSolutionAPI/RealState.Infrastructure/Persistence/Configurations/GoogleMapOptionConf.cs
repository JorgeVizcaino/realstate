using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class GoogleMapOptionConf : IEntityTypeConfiguration<GoogleMapOption>
    {
        public void Configure(EntityTypeBuilder<GoogleMapOption> builder)
        {
            builder.ToTable("GoogleMapOption")
                .HasKey(x => x.Id);
        }
    }
}
