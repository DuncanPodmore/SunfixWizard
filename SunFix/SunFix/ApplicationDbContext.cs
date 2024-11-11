using Microsoft.EntityFrameworkCore;
using SunFix.Models;

namespace SunFix;
public class ApplicationDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ContactInfo> ContactInfos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<QuotePart> QuoteParts { get; set; }
    public DbSet<Part> Parts { get; set; }
    public DbSet<PartPreset> PartPresets { get; set; }
    public DbSet<PartPresetComponent> PartPresetComponents { get; set; }
    public DbSet<RoofSheet> RoofSheets { get; set; }
    public DbSet<RoofType> RoofTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Client-Project relationship
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Client)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.ClientId);

        // Configure Project-ContactInfo relationship
        modelBuilder.Entity<ContactInfo>()
            .HasOne(c => c.Project)
            .WithMany(p => p.ContactInfos)
            .HasForeignKey(c => c.ProjectId);

        // Configure Quote-Client relationship
        modelBuilder.Entity<Quote>()
            .HasOne(q => q.Client)
            .WithMany(c => c.Quotes)
            .HasForeignKey(q => q.ClientId);

        // Configure Quote-QuotePart relationship
        modelBuilder.Entity<QuotePart>()
            .HasOne(qp => qp.Quote)
            .WithMany(q => q.QuoteParts)
            .HasForeignKey(qp => qp.QuoteId);

        // Configure Part-PartPreset relationship
        modelBuilder.Entity<Part>()
            .HasOne(p => p.Preset)
            .WithMany(pp => pp.Parts)
            .HasForeignKey(p => p.PresetId);

        // Configure PartPreset-PartPresetComponent relationship
        modelBuilder.Entity<PartPresetComponent>()
            .HasOne(pc => pc.Part)
            .WithMany(p => p.PartPresetComponents)
            .HasForeignKey(pc => pc.PartId);

        // Configure RoofType-RoofSheet relationship
        modelBuilder.Entity<RoofSheet>()
            .HasOne(rs => rs.RoofType)
            .WithMany(rt => rt.RoofSheets)
            .HasForeignKey(rs => rs.RoofTypeId);

        base.OnModelCreating(modelBuilder);
    }
}
