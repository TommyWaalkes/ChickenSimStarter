using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ChickenSim.Models
{
    public partial class ChickenSimContext : DbContext
    {
        public ChickenSimContext()
        {
        }

        public ChickenSimContext(DbContextOptions<ChickenSimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chickens> Chickens { get; set; }
        public virtual DbSet<Farms> Farms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ChickenSim;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chickens>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color).HasMaxLength(15);

                entity.Property(e => e.Luck).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Smarts).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Speed).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Strength).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Chickens)
                    .HasForeignKey(d => d.FarmId)
                    .HasConstraintName("FK__Chickens__FarmId__25869641");
            });

            modelBuilder.Entity<Farms>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Seeds).HasColumnName("seeds");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
