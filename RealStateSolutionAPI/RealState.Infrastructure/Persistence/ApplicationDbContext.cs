using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RealState.Application.common.Interfaces;
using RealState.Application.Common.Interfaces;
using RealState.Domain.Common;
using RealState.Domain.Entities;
using RealState.Infrastructure.Identity;

namespace RealState.Infrastructure.Persistence
{
    public class ApplicationDbContext : KeyApiAuthorizationDbContext<ApplicationUser, ApplicationRol, string>,
        IApplicationDbContext 
    {
        //ApiAuthorizationDbContext
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
            , IOptions<OperationalStoreOptions> operationalStoreOptions
            , ICurrentUserService currentUserService)
            : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }
        
        public DbSet<Address> Address { get; set; }
        public DbSet<ApplianceOwnership> ApplianceOwnership { get; set; }
        public DbSet<Audios> Audios { get; set; }
        public DbSet<Diligences> Diligences { get; set; }
        public DbSet<Financial> Financial { get; set; }
        public DbSet<FloorPlan> FloorPlan { get; set; }
        public DbSet<GoogleMapOption> GoogleMapOption { get; set; }
        public DbSet<Lease> Lease { get; set; }
        public DbSet<LeaseSummary> LeaseSummary { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Physical> Physical { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<ThreeDRendering> ThreeDRendering { get; set; }
        public DbSet<UtilitiesOwnership> UtilitiesOwnership { get; set; }
        public DbSet<Valuation> Valuation { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifyBy = _currentUserService.UserId;
                        entry.Entity.Modified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}