using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ecommerce.Data.Models;

namespace Ecommerce.Data
{
    public partial class p1mvcecommerceSQLDbContext : DbContext
    {
        public p1mvcecommerceSQLDbContext()
        {
        }

        public p1mvcecommerceSQLDbContext(DbContextOptions<p1mvcecommerceSQLDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<FavoriteStore> FavoriteStores { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:p1-mvcecommerceserver.database.windows.net,1433;Initial Catalog=p1-mvcecommerceSQLDb;Persist Security Info=False;User ID=p1-mvcecommerece1125007;Password=SyzygySigil007!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Usrname, "UQ__Accounts__11792DE47A0B556D")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Accounts__AB6E6164C7A9B3AB")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("lname");

                entity.Property(e => e.Membership)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("membership");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(100)
                    .HasColumnName("pwd");

                entity.Property(e => e.Usrname)
                    .HasMaxLength(50)
                    .HasColumnName("usrname");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId).HasColumnName("cartId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Carts__accountId__18EBB532");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Carts__productId__19DFD96B");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Carts__storeId__1BC821DD");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasIndex(e => e.DiscountName, "UQ__Discount__4FCC33EFDA3BD09C")
                    .IsUnique();

                entity.Property(e => e.DiscountId).HasColumnName("discountId");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.DiscountName)
                    .HasMaxLength(50)
                    .HasColumnName("discountName");

                entity.Property(e => e.PriceModifier).HasColumnName("priceModifier");
            });

            modelBuilder.Entity<FavoriteStore>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FavoriteStore");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Favorited)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("favorited");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.HasOne(d => d.Account)
                    .WithMany()
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__FavoriteS__accou__1332DBDC");

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__FavoriteS__store__123EB7A3");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.StoreQuantity).HasColumnName("storeQuantity");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Inventori__produ__7F2BE32F");

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Inventori__store__7E37BEF6");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.CreatedAtTime).HasColumnName("createdAtTime");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quanity).HasColumnName("quanity");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Orders__accountI__0F624AF8");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Orders__productI__0E6E26BF");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__storeId__0D7A0286");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PK__Products__DDDF4BE6F2642559");

                entity.HasIndex(e => e.Text, "UQ__Products__E0F915BC573D8015")
                    .IsUnique();

                entity.Property(e => e.Sku).HasColumnName("sku");

                entity.Property(e => e.Make)
                    .HasMaxLength(50)
                    .HasColumnName("make");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Text)
                    .HasMaxLength(400)
                    .HasColumnName("text");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.SessionId)
                    .ValueGeneratedNever()
                    .HasColumnName("sessionId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.CartId).HasColumnName("cartId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Sessions__accoun__1EA48E88");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__Sessions__cartId__1F98B2C1");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasIndex(e => e.Address, "UQ__Stores__751C8E540695E6BF")
                    .IsUnique();

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasMaxLength(10)
                    .HasColumnName("state");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
