﻿// <auto-generated />
using ECommerce.Catalog.Data.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Catalog.Data.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20230213143001_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Catalog.Data.Entities.ProductEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ECommerce.Catalog.Data.Entities.ProductEntity", b =>
                {
                    b.OwnsOne("ECommerce.Catalog.Data.Entities.Money", "Price", b1 =>
                        {
                            b1.Property<long>("ProductEntityId")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProductEntityId");

                            b1.ToTable("Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductEntityId");
                        });

                    b.Navigation("Price");
                });
#pragma warning restore 612, 618
        }
    }
}