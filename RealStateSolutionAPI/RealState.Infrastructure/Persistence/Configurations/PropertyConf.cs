
using RealState.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RealState.Infrastructure.Persistence.Configurations
{
    public class PropertyConf : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property", "DBO")
                .HasKey(x => x.PropertyId);

        }
    }
}
