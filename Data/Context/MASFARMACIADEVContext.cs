﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProductsAPI.Data.Context.Entitys;


namespace ProductsAPI.Data.Context
{
    public partial class MASFARMACIADEVContext : DbContext
    {
        public MASFARMACIADEVContext()
        {
        }

        public MASFARMACIADEVContext(DbContextOptions<MASFARMACIADEVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategorysEntity> CategorysEntity { get; set; }
        public virtual DbSet<ClientsEntity> ClientsEntity { get; set; }
        public virtual DbSet<IdentificationsTypesEntity> IdentificationsTypesEntity { get; set; }
        public virtual DbSet<OrdersEntity> OrdersEntity { get; set; }
        public virtual DbSet<PostalCodesEntity> PostalCodesEntity { get; set; }
        public virtual DbSet<ProductsEntity> ProductsEntity { get; set; }
        public virtual DbSet<BuysEntity> BuysEntity { get; set; }
        public virtual DbSet<BuysDetailsEntity> BuysDetailsEntity { get; set; }
        public virtual DbSet<RecipesEntity> RecipesEntity { get; set; }
        public virtual DbSet<ResourcesEntity> ResourcesEntity { get; set; }
        public virtual DbSet<StatesEntity> StatesEntity { get; set; }
        public virtual DbSet<StatesOrdersEntity> StatesOrdersEntity { get; set; }
        public virtual DbSet<SubCategorysEntity> SubCategorysEntity { get; set; }
        public virtual DbSet<TypesOrdersEntity> TypesOrdersEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-20VCMA9\\UNDEFINEDLOCAL;Initial Catalog=MAS-FARMACIA-DEV;User Id=undefinedss;Password=Undefined.s.s.20;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategorysEntity>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.ToTable("CategorysEntity", "dbo");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientsEntity>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.ToTable("ClientsEntity", "dbo");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HomeHeigth).HasColumnName("home_heigth");

                entity.Property(e => e.HomeStreet)
                    .HasColumnName("home_street")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPostalCode).HasColumnName("id_postal_code");

                entity.Property(e => e.IdTypeIdentification).HasColumnName("id_type_identification");

                entity.Property(e => e.IdentificationNumber)
                    .IsRequired()
                    .HasColumnName("identification_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IdentificationsTypesEntity>(entity =>
            {
                entity.HasKey(e => e.IdTypeIdentification);

                entity.ToTable("identifications_types", "dbo");

                entity.Property(e => e.IdTypeIdentification).HasColumnName("id_type_identification");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrdersEntity>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.ToTable("OrdersEntity", "dbo");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdTypeOrder).HasColumnName("id_type_order");
            });

            modelBuilder.Entity<PostalCodesEntity>(entity =>
            {
                entity.HasKey(e => e.IdPostalCode);

                entity.ToTable("postal_codes", "dbo");

                entity.Property(e => e.IdPostalCode)
                    .HasColumnName("id_postal_code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postal_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductsEntity>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("ProductsEntity", "dbo");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.IdResoruce).HasColumnName("id_resoruce");

                entity.Property(e => e.IdSubCategory).HasColumnName("id_sub_category");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Recipe).HasColumnName("recipe");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<BuysEntity>(entity =>
            {
                entity.HasKey(e => e.IdBuy);

                entity.ToTable("buy", "dbo");

                entity.Property(e => e.IdBuy).HasColumnName("id_buy");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("total_amount")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UploadDate)
                    .HasColumnName("upload_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<BuysDetailsEntity>(entity =>
            {
                entity.HasKey(e => e.IdBuyDetail);

                entity.ToTable("BuysEntity_details", "dbo");

                entity.Property(e => e.IdBuyDetail).HasColumnName("id_buy_detail");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdBuy).HasColumnName("id_buy");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<RecipesEntity>(entity =>
            {
                entity.HasKey(e => e.IdRecipe);

                entity.ToTable("RecipesEntity", "dbo");

                entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResourcesEntity>(entity =>
            {
                entity.HasKey(e => e.IdResource);

                entity.ToTable("ResourcesEntity", "dbo");

                entity.Property(e => e.IdResource).HasColumnName("id_resource");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatesEntity>(entity =>
            {
                entity.HasKey(e => e.IdState);

                entity.ToTable("StatesEntity", "dbo");

                entity.Property(e => e.IdState).HasColumnName("id_state");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatesOrdersEntity>(entity =>
            {
                entity.HasKey(e => e.IdStateOrder);

                entity.ToTable("StatesEntity_OrdersEntity", "dbo");

                entity.Property(e => e.IdStateOrder).HasColumnName("id_state_order");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdState).HasColumnName("id_state");
            });

            modelBuilder.Entity<SubCategorysEntity>(entity =>
            {
                entity.HasKey(e => e.IdSubCategory);

                entity.ToTable("sub_CategorysEntity", "dbo");

                entity.Property(e => e.IdSubCategory).HasColumnName("id_sub_category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypesOrdersEntity>(entity =>
            {
                entity.HasKey(e => e.IdTypeOrder);

                entity.ToTable("types_OrdersEntity", "dbo");

                entity.Property(e => e.IdTypeOrder).HasColumnName("id_type_order");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}