using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace SunfixBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartPreset> PartPresets { get; set; }
        public DbSet<PartPresetItem> PartPresetItems { get; set; }
        public DbSet<RoofSheet> RoofSheets { get; set; }
        public DbSet<RoofType> RoofTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoofSheet>()
                .HasOne(rs => rs.RoofType)
                .WithMany(rt => rt.RoofSheets)
                .HasForeignKey(rs => rs.RoofTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data Example (optional)
            modelBuilder.Entity<RoofType>().HasData(
                new RoofType { RoofTypeId = 1, Name = "Trapezoidal" },
                new RoofType { RoofTypeId = 2, Name = "Flat" }
            );

            modelBuilder.Entity<RoofSheet>().HasData(
                new RoofSheet { RoofSheetId = 1, Name = "Corrugated Sheet", RoofTypeId = 1 }
            );
        }
    }
}
