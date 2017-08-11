﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SamuraiApp.Data;
using System;

namespace DataPoints0917EFCore2Model.Migrations
{
    [DbContext(typeof(SamuraiContext))]
    partial class SamuraiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26423");

            modelBuilder.Entity("SamuraiApp.Domain.Entrance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionDescription");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("MovieMinute");

                    b.Property<int>("SamuraiFk");

                    b.Property<string>("SceneName");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiFk")
                        .IsUnique();

                    b.ToTable("Entrance");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("SamuraiId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Entrance", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Samurai")
                        .WithOne("Entrance")
                        .HasForeignKey("SamuraiApp.Domain.Entrance", "SamuraiFk")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamuraiApp.Domain.Quote", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Samurai")
                        .WithMany("Quotes")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamuraiApp.Domain.Samurai", b =>
                {
                    b.OwnsOne("SamuraiApp.Domain.PersonName", "SecretIdentity", b1 =>
                        {
                            b1.Property<int>("SamuraiId");

                            b1.Property<string>("First");

                            b1.Property<string>("Last");

                            b1.ToTable("Samurais");

                            b1.HasOne("SamuraiApp.Domain.Samurai")
                                .WithOne("SecretIdentity")
                                .HasForeignKey("SamuraiApp.Domain.PersonName", "SamuraiId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
