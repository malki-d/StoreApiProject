using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ex01.Models;

public partial class Store2163089401Context : DbContext
{
    public Store2163089401Context()
    {
    }

    public Store2163089401Context(DbContextOptions<Store2163089401Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Bag> Bags { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Srv2\\pupils;DataBase=Store_216308940__1;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bag>(entity =>
        {
            entity.ToTable("bags");

            entity.HasIndex(e => e.ProductId, "IX_bags_productId");

            entity.HasIndex(e => e.UserId, "IX_bags_userId");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Product).WithMany(p => p.Bags).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.User).WithMany(p => p.Bags).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasMany(d => d.Products).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryProduct",
                    r => r.HasOne<Product>().WithMany().HasForeignKey("Productsid"),
                    l => l.HasOne<Category>().WithMany().HasForeignKey("Categoriesid"),
                    j =>
                    {
                        j.HasKey("Categoriesid", "Productsid");
                        j.ToTable("CategoryProduct");
                        j.HasIndex(new[] { "Productsid" }, "IX_CategoryProduct_productsid");
                        j.IndexerProperty<int>("Categoriesid").HasColumnName("categoriesid");
                        j.IndexerProperty<string>("Productsid").HasColumnName("productsid");
                    });
        });

        modelBuilder.Entity<Child>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("children");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Colors).HasColumnName("colors");
            entity.Property(e => e.Desc).HasColumnName("desc");
            entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Sale).HasColumnName("sale");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
