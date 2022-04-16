﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SushiBarDatabaseImplement;

namespace SushiBarDatabaseImplement.Migrations
{
    [DbContext(typeof(SushiBarDatabase))]
    [Migration("20220416212246_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.DishIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DishIngredients");
                });

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.StorageFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerFLM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StorageFacilities");
                });

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.StorageFacilityIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("StorageFacilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("StorageFacilityId");

                    b.ToTable("StorageFacilityIngredients");
                });

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.DishIngredient", b =>
                {
                    b.HasOne("SushiBarDatabaseImplement.Models.Dish", "Dish")
                        .WithMany("DishIngredients")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SushiBarDatabaseImplement.Models.Ingredient", "Ingredient")
                        .WithMany("DishIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("SushiBarDatabaseImplement.Models.Dish", "Dish")
                        .WithMany("Orders")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.StorageFacilityIngredient", b =>
                {
                    b.HasOne("SushiBarDatabaseImplement.Models.Ingredient", "Ingredient")
                        .WithMany("StorageFacilityIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SushiBarDatabaseImplement.Models.StorageFacility", "StorageFacility")
                        .WithMany("StorageFacilityIngredients")
                        .HasForeignKey("StorageFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("StorageFacility");
                });

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.Dish", b =>
                {
                    b.Navigation("DishIngredients");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.Ingredient", b =>
                {
                    b.Navigation("DishIngredients");

                    b.Navigation("StorageFacilityIngredients");
                });

            modelBuilder.Entity("SushiBarDatabaseImplement.Models.StorageFacility", b =>
                {
                    b.Navigation("StorageFacilityIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
