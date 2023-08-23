﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KDT.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230823042634_firsttt")]
    partial class firsttt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArzeshAfzode")
                        .HasColumnType("int");

                    b.Property<int>("FiGhablArzeshAfzode")
                        .HasColumnType("int");

                    b.Property<int>("GheymatNahaei")
                        .HasColumnType("int");

                    b.Property<string>("Hesab")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HesabId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MabdaHaml")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeghdarBargiri")
                        .HasColumnType("int");

                    b.Property<string>("NameMahsol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSherkat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameVasete")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoeForosh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SherkatId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShomarePish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Takhfif")
                        .HasColumnType("int");

                    b.Property<DateTime>("TarikhEtebar")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TarikhSabt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Tarikhsodor")
                        .HasColumnType("datetime2");

                    b.Property<int>("Tedad")
                        .HasColumnType("int");

                    b.Property<string>("Tonazh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("DolarDoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Fi")
                        .HasColumnType("int");

                    b.Property<int>("GheymatNahaei")
                        .HasColumnType("int");

                    b.Property<string>("Hesab")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Komision")
                        .HasColumnType("int");

                    b.Property<int>("MablaghGhabelEzhar")
                        .HasColumnType("int");

                    b.Property<string>("MaghsadHaml")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MeghdarBargiri")
                        .HasColumnType("int");

                    b.Property<string>("NameKharidar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameMahsol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameVasete")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SharayetTahvil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SherkatId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShomarePish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TarikhEtebar")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TarikhSabt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Tarikhsodor")
                        .HasColumnType("datetime2");

                    b.Property<int>("Tonazh")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("dolarDocs");
                });

            modelBuilder.Entity("Hesab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameBank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameShobe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShomareShaba")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("hesabs");
                });

            modelBuilder.Entity("KharidarDolar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("kharidarDolars");
                });

            modelBuilder.Entity("Mahsol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameMahsol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("mahsols");
                });

            modelBuilder.Entity("MahsolSa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameMahsol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("mahsolSas");
                });

            modelBuilder.Entity("Sherkat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codeposti")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSherkat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Neshani")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShenaseMeli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShomareSabt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sherkats");
                });
#pragma warning restore 612, 618
        }
    }
}