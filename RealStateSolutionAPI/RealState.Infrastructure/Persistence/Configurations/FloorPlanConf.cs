using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class FloorPlanConf : IEntityTypeConfiguration<FloorPlan>
    {
        public void Configure(EntityTypeBuilder<FloorPlan> builder)
        {
            builder.ToTable("FloorPlan")
                .HasKey(x => x.IdFloorPlan);
        }
    }
}
