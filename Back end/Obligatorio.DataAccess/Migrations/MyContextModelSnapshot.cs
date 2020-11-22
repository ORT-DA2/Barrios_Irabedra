﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Obligatorio.DataAccess.Context;

namespace Obligatorio.DataAccess.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Obligatorio.Domain.Accommodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FullCapacity")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerNight")
                        .HasColumnType("float");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("TouristSpotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TouristSpotId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("Obligatorio.Domain.AuxiliaryObjects.ImageWrapper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("ImageWrappers");
                });

            modelBuilder.Entity("Obligatorio.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Obligatorio.Domain.DomainEntities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Obligatorio.Domain.DomainEntities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccommodationForReservationId")
                        .HasColumnType("int");

                    b.Property<int>("ActualReservationStatus")
                        .HasColumnType("int");

                    b.Property<int>("Adults")
                        .HasColumnType("int");

                    b.Property<int>("Babies")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Information")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kids")
                        .HasColumnType("int");

                    b.Property<string>("NewStatusDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("Retirees")
                        .HasColumnType("int");

                    b.Property<int>("TotalGuests")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationForReservationId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Obligatorio.Domain.DomainEntities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("acccommodationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("acccommodationId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Obligatorio.Domain.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Obligatorio.Domain.TouristSpot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("TouristSpots");
                });

            modelBuilder.Entity("Obligatorio.Domain.TouristSpotCategory", b =>
                {
                    b.Property<int>("TouristSpotId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("TouristSpotId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("TouristSpotCategories");
                });

            modelBuilder.Entity("Obligatorio.Domain.Accommodation", b =>
                {
                    b.HasOne("Obligatorio.Domain.TouristSpot", "TouristSpot")
                        .WithMany()
                        .HasForeignKey("TouristSpotId");
                });

            modelBuilder.Entity("Obligatorio.Domain.AuxiliaryObjects.ImageWrapper", b =>
                {
                    b.HasOne("Obligatorio.Domain.Accommodation", null)
                        .WithMany("Images")
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Obligatorio.Domain.DomainEntities.Reservation", b =>
                {
                    b.HasOne("Obligatorio.Domain.Accommodation", "AccommodationForReservation")
                        .WithMany()
                        .HasForeignKey("AccommodationForReservationId");
                });

            modelBuilder.Entity("Obligatorio.Domain.DomainEntities.Review", b =>
                {
                    b.HasOne("Obligatorio.Domain.Accommodation", null)
                        .WithMany("Reviews")
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Obligatorio.Domain.Accommodation", "acccommodation")
                        .WithMany()
                        .HasForeignKey("acccommodationId");
                });

            modelBuilder.Entity("Obligatorio.Domain.TouristSpot", b =>
                {
                    b.HasOne("Obligatorio.Domain.Region", null)
                        .WithMany("TouristSpots")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Obligatorio.Domain.TouristSpotCategory", b =>
                {
                    b.HasOne("Obligatorio.Domain.Category", "Category")
                        .WithMany("TouristSpotCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obligatorio.Domain.TouristSpot", "TouristSpot")
                        .WithMany("TouristSpotCategories")
                        .HasForeignKey("TouristSpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
