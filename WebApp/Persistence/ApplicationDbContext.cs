using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WebApp.Models;
using WebApp.Persistence.Models;

namespace WebApp.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<LineDbModel> Lines { get; set; }
        public DbSet<StationDbModel> Stations { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StationLineDbModel>()
                .HasKey(c => new { c.StationId, c.LineId });

            modelBuilder.Entity<StationDbModel>()
                .HasMany(sl => sl.StationLines)
                .WithRequired()
                .HasForeignKey(s => s.StationId);

            modelBuilder.Entity<LineDbModel>()
                .HasMany(sl => sl.StationLines)
                .WithRequired()
                .HasForeignKey(l => l.LineId);
        }
    }
}