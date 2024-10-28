using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ktthuchanh.Models;

public partial class QlxemayContext : DbContext
{
    public QlxemayContext()
    {
    }

    public QlxemayContext(DbContextOptions<QlxemayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Xemay> Xemays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-VC1H556C;Initial Catalog=QLXemay;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Xemay>(entity =>
        {
            entity.HasKey(e => e.Idxe).HasName("PK__Xemay__B771806ACBE8C5BC");

            entity.ToTable("Xemay");

            entity.Property(e => e.Idxe)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Anh)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Mausac)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Mota)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Tenxe)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
