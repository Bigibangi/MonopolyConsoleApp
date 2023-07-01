using Microsoft.EntityFrameworkCore;
using Model;

public class ApplicationContext : DbContext {
    public DbSet<Box> Boxes => Set<Box>();
    public DbSet<Pallete> Pallets => Set<Pallete>();
    public DbSet<PalleteBoxes> Connections => Set<PalleteBoxes>();

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new BoxConfiguration());
        modelBuilder.ApplyConfiguration(new PalleteConfiguration());
    }
}