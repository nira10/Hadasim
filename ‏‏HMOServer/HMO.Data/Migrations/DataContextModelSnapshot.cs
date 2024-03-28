﻿// <auto-generated />
using System;
using HMOServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HMO.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HMO.Core.Entities.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CityIDID")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("StreetIDID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CityIDID");

                    b.HasIndex("StreetIDID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("HMO.Core.Entities.Cities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("HMO.Core.Entities.Illness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PatientIdID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Positive")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Recovery")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientIdID");

                    b.ToTable("Illness");
                });

            modelBuilder.Entity("HMO.Core.Entities.Patient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AddressID")
                        .HasColumnType("int");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("HMO.Core.Entities.Producer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Producer");
                });

            modelBuilder.Entity("HMO.Core.Entities.Streets", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CitiesID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CitiesID");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("HMO.Core.Entities.Vaccination", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientIdID")
                        .HasColumnType("int");

                    b.Property<int>("ProducerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PatientIdID");

                    b.HasIndex("ProducerID");

                    b.ToTable("Vaccination");
                });

            modelBuilder.Entity("HMO.Core.Entities.Address", b =>
                {
                    b.HasOne("HMO.Core.Entities.Cities", "CityID")
                        .WithMany()
                        .HasForeignKey("CityIDID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMO.Core.Entities.Streets", "StreetID")
                        .WithMany()
                        .HasForeignKey("StreetIDID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityID");

                    b.Navigation("StreetID");
                });

            modelBuilder.Entity("HMO.Core.Entities.Illness", b =>
                {
                    b.HasOne("HMO.Core.Entities.Patient", "PatientId")
                        .WithMany()
                        .HasForeignKey("PatientIdID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PatientId");
                });

            modelBuilder.Entity("HMO.Core.Entities.Patient", b =>
                {
                    b.HasOne("HMO.Core.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("HMO.Core.Entities.Streets", b =>
                {
                    b.HasOne("HMO.Core.Entities.Cities", null)
                        .WithMany("Streets")
                        .HasForeignKey("CitiesID");
                });

            modelBuilder.Entity("HMO.Core.Entities.Vaccination", b =>
                {
                    b.HasOne("HMO.Core.Entities.Patient", "PatientId")
                        .WithMany("Vaccinations")
                        .HasForeignKey("PatientIdID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMO.Core.Entities.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PatientId");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("HMO.Core.Entities.Cities", b =>
                {
                    b.Navigation("Streets");
                });

            modelBuilder.Entity("HMO.Core.Entities.Patient", b =>
                {
                    b.Navigation("Vaccinations");
                });
#pragma warning restore 612, 618
        }
    }
}
