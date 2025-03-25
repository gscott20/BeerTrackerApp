using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BeerTrackerAPI.Data;

public partial class BeerTrackerDbContext : DbContext
{
    public BeerTrackerDbContext()
    {
    }

    public BeerTrackerDbContext(DbContextOptions<BeerTrackerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerGameBeer> PlayerGameBeers { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warni//ng To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("Server=GARRETTSPC\\SQLEXPRESS01;Database=BeerTrackerDb;Trusted_Connection=true;MultipleActiveResultSets=true;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Beers__3214EC07A7167765");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Games__3214EC0774E1BCCA");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Opponent).HasMaxLength(250);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Players__3214EC07B1F57F50");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<PlayerGameBeer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayerGa__3214EC074B65771A");

            entity.Property(e => e.TotalBeer).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Beer).WithMany(p => p.PlayerGameBeers)
                .HasForeignKey(d => d.BeerId)
                .HasConstraintName("FK_PlayerGameBeers_ToTableBeer");

            entity.HasOne(d => d.Game).WithMany(p => p.PlayerGameBeers)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK_PlayerGameBeers_ToTableGame");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
