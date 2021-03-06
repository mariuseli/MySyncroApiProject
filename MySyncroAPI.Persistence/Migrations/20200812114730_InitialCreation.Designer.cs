﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySyncroAPI.Persistence;

namespace MySyncroAPI.Persistence.Migrations
{
    [DbContext(typeof(MySyncroAPIDatabaseContext))]
    [Migration("20200812114730_InitialCreation")]
    partial class InitialCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("MySyncroAPI.Domain.MyContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MySyncSessionId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RefId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MySyncSessionId");

                    b.ToTable("MyContacts");
                });

            modelBuilder.Entity("MySyncroAPI.Domain.MySyncSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RefId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SessionItemsCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SessionName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SyncSessions");
                });

            modelBuilder.Entity("MySyncroAPI.Domain.MyContact", b =>
                {
                    b.HasOne("MySyncroAPI.Domain.MySyncSession", "MySyncSession")
                        .WithMany("SyncedContactList")
                        .HasForeignKey("MySyncSessionId");
                });
#pragma warning restore 612, 618
        }
    }
}
