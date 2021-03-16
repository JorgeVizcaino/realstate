using System.Threading;
using System.Threading.Tasks;
using RealState.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RealState.Application.common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Address> Address { get; set; }
        DbSet<ApplianceOwnership> ApplianceOwnership { get; set; }
        DbSet<Audios> Audios { get; set; }
        DbSet<Diligences> Diligences { get; set; }
        DbSet<Financial> Financial { get; set; }
        DbSet<FloorPlan> FloorPlan { get; set; }
        DbSet<GoogleMapOption> GoogleMapOption { get; set; }
        DbSet<Lease> Lease { get; set; }
        DbSet<LeaseSummary> LeaseSummary { get; set; }
        DbSet<Photo> Photo { get; set; }
        DbSet<Physical> Physical { get; set; }
        DbSet<Property> Property { get; set; }
        DbSet<Resources> Resources { get; set; }
        DbSet<Score> Score { get; set; }
        DbSet<ThreeDRendering> ThreeDRendering { get; set; }
        DbSet<UtilitiesOwnership> UtilitiesOwnership { get; set; }
        DbSet<Valuation> Valuation { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}