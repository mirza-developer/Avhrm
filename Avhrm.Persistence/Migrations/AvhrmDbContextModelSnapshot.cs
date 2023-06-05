﻿// <auto-generated />
using System;
using Avhrm.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Avhrm.Persistence.Migrations
{
    [DbContext(typeof(AvhrmDbContext))]
    partial class AvhrmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Avhrm.Core.Entities.VacationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("FromDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ToDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Verifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerifyDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("VacationRequest");
                });
#pragma warning restore 612, 618
        }
    }
}