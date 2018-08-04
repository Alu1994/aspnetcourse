﻿// <auto-generated />
using System;
using Lecture1_EntityFramework_Basics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lecture1_EntityFramework_Basics.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180804170805_firstUseOfModelCreating")]
    partial class firstUseOfModelCreating
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lecture1_EntityFramework_Basics.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Lecture1_EntityFramework_Basics.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Lecture1_EntityFramework_Basics.Domain.Product", b =>
                {
                    b.HasOne("Lecture1_EntityFramework_Basics.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
