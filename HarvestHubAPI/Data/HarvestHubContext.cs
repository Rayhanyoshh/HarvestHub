using HarvestHubAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class HarvestHubContext : DbContext
{
    public HarvestHubContext(DbContextOptions<HarvestHubContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<FarmSite> FarmSites { get; set; }
    public DbSet<FarmField> FarmFields { get; set; }
    public DbSet<Crop> Crops { get; set; }
    public DbSet<WorkTaskType> WorkTaskTypes { get; set; }
    public DbSet<WorkTask> WorkTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {
        base.OnModelCreating(modelBuilder);

        // Relasi User ke FarmSite
        modelBuilder.Entity<User>()
            .HasOne(u => u.FarmSite)
            .WithMany(fs => fs.Users)
            .HasForeignKey(u => u.FarmSiteId);


        // Relasi FarmSite ke FarmField
        modelBuilder.Entity<FarmField>()
            .HasOne(ff => ff.FarmSite)
            .WithMany(fs => fs.FarmFields)
            .HasForeignKey(ff => ff.FarmSiteId);

        // Relasi FarmField ke Crop
        modelBuilder.Entity<FarmField>()
            .HasOne(ff => ff.PrimaryCrop)
            .WithMany(c => c.FarmFields)
            .HasForeignKey(ff => ff.PrimaryCropId);




        // Relasi FarmField ke WorkTask
        modelBuilder.Entity<WorkTask>()
            .HasOne(wt => wt.FarmField)
            .WithMany(ff => ff.WorkTasks)
            .HasForeignKey(wt => wt.FarmFieldId);

        // Relasi WorkTask ke WorkTaskType
        modelBuilder.Entity<WorkTask>()
            .HasOne(wt => wt.WorkTaskType)
            .WithMany(wtt => wtt.WorkTasks)
            .HasForeignKey(wt => wt.WorkTaskTypeCode);
    }

}
