using System;
using System.Collections.Generic;
using EcommerceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Data.DbContexts;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BodyType> BodyTypes { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<FuelType> FuelTypes { get; set; }

    public virtual DbSet<ManufacturingCountry> ManufacturingCountries { get; set; }

    public virtual DbSet<ProductList> ProductLists { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BodyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BodyType__3214EC0791930BE2");

            entity.HasIndex(e => e.Name, "UQ__BodyType__737584F693648C25").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cars__3214EC07A65DD53B");

            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);

            entity.HasOne(d => d.BodyType).WithMany(p => p.Cars)
                .HasForeignKey(d => d.BodyTypeId)
                .HasConstraintName("FK__Cars__BodyTypeId__46E78A0C");

            entity.HasOne(d => d.Color).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK__Cars__ColorId__47DBAE45");

            entity.HasOne(d => d.FuelType).WithMany(p => p.Cars)
                .HasForeignKey(d => d.FuelTypeId)
                .HasConstraintName("FK__Cars__FuelTypeId__45F365D3");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Colors__3214EC071588BEBD");

            entity.HasIndex(e => e.Name, "UQ__Colors__737584F67A254EDE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<FuelType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FuelType__3214EC0745205F2E");

            entity.HasIndex(e => e.Name, "UQ__FuelType__737584F6490D86B8").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<ManufacturingCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Manufact__3214EC076C1B568A");

            entity.HasIndex(e => e.Name, "UQ__Manufact__737584F68235700A").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(35);
        });

        modelBuilder.Entity<ProductList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductL__3214EC07F2CF9627");

            entity.HasOne(d => d.Car).WithMany(p => p.ProductLists)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__ProductLi__CarId__6FE99F9F");

            entity.HasOne(d => d.Seller).WithMany(p => p.ProductLists)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__ProductLi__Selle__70DDC3D8");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sellers__3214EC07C9F379BC");

            entity.HasIndex(e => e.CompanyName, "UQ__Sellers__9BCE05DCCE93865A").IsUnique();

            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.ContactNumber).HasMaxLength(50);

            entity.HasOne(d => d.ManufacturingCountry).WithMany(p => p.Sellers)
                .HasForeignKey(d => d.ManufacturingCountryId)
                .HasConstraintName("FK__Sellers__Manufac__59063A47");

            entity.HasOne(d => d.User).WithMany(p => p.Sellers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sellers__UserId__5629CD9C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0749ED81B4");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E430350B02").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
