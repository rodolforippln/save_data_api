﻿// <auto-generated />
using System;
using ApiCatalogo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCatalogo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230409032726_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApiCatalogo.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("inCompanyId");

                    b.Property<string>("ReceiverDocument")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("chReceiverDocument");

                    b.Property<string>("ReceiverName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("chNome");

                    b.Property<string>("ReceiverStateRegistration")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("chReceiverStateRegistration");

                    b.HasKey("CompanyId");

                    b.ToTable("TB_Company", (string)null);
                });

            modelBuilder.Entity("ApiCatalogo.Models.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("chOrderId");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("inCompanyId");

                    b.Property<string>("OriginPartnerPointCode")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("chOriginPartnerPointCode");

                    b.Property<string>("OriginPointCode")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("chOriginPointCode");

                    b.Property<string>("OriginPostalCode")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("chOriginPostalCode");

                    b.HasKey("OrderId");

                    b.HasIndex("CompanyId");

                    b.ToTable("TB_Order", (string)null);
                });

            modelBuilder.Entity("ApiCatalogo.Models.Volume", b =>
                {
                    b.Property<int>("VolumeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("inVolumeId");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nuHeight");

                    b.Property<string>("Lenght")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nuLenght");

                    b.Property<string>("OrderId")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("chOrderId");

                    b.Property<string>("Pieces")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nuPieces");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nuWeight");

                    b.Property<string>("Width")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nuWidth");

                    b.HasKey("VolumeId");

                    b.HasIndex("OrderId");

                    b.ToTable("TB_Volume", (string)null);
                });

            modelBuilder.Entity("ApiCatalogo.Models.Order", b =>
                {
                    b.HasOne("ApiCatalogo.Models.Company", "Company")
                        .WithMany("Orders")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ApiCatalogo.Models.Volume", b =>
                {
                    b.HasOne("ApiCatalogo.Models.Order", "Order")
                        .WithMany("Volumes")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ApiCatalogo.Models.Company", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ApiCatalogo.Models.Order", b =>
                {
                    b.Navigation("Volumes");
                });
#pragma warning restore 612, 618
        }
    }
}
