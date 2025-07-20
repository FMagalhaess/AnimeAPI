using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AnimeAPI.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    #region DbSets

    public DbSet<Anime> Animes { get; set; } = null!;

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Anime>(entity =>
        {
            entity.ToTable("Animes");

            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id)
                .ValueGeneratedNever();
            
            entity.OwnsOne(a => a.Name, name =>
            {
                name.Property(n => n.Tittle)
                    .HasColumnName("Name")
                    .HasMaxLength(Name.MaxLength)
                    .IsRequired();
            });
            
            entity.OwnsOne(a => a.Director, director =>
            {
                director.Property(d => d.DirectorName)
                    .HasColumnName("Director")
                    .HasMaxLength(Director.MaxLength)
                    .IsRequired();
            });
            
            entity.OwnsOne(a => a.Summary, summary =>
            {
                summary.Property(s => s.SummaryText)
                    .HasColumnName("Summary")
                    .HasMaxLength(Summary.MaxLength)
                    .IsRequired();
            });
        });
    }
}