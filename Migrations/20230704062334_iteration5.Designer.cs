﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentMeetingPlanner.Data;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    [DbContext(typeof(SacramentMeetingPlannerContext))]
    [Migration("20230704062334_iteration5")]
    partial class iteration5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Hymn", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Hymn");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SacramentMeeting", b =>
                {
                    b.Property<int>("sacramentMeetingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("closingHymnId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("closingPrayer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("conductor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<int>("openingHymnId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("openingPrayer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("restHymnId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sacramentHymnId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("specialMusicalNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("wardName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("sacramentMeetingId");

                    b.HasIndex("closingHymnId");

                    b.HasIndex("openingHymnId");

                    b.HasIndex("restHymnId");

                    b.HasIndex("sacramentHymnId");

                    b.ToTable("SacramentMeeting");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("sacramentMeetingId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("topic")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("sacramentMeetingId");

                    b.ToTable("Speaker");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SacramentMeeting", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "closingHymn")
                        .WithMany()
                        .HasForeignKey("closingHymnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "openingHymn")
                        .WithMany()
                        .HasForeignKey("openingHymnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "restHymn")
                        .WithMany()
                        .HasForeignKey("restHymnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "sacramentHymn")
                        .WithMany()
                        .HasForeignKey("sacramentHymnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("closingHymn");

                    b.Navigation("openingHymn");

                    b.Navigation("restHymn");

                    b.Navigation("sacramentHymn");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.SacramentMeeting", null)
                        .WithMany("speakers")
                        .HasForeignKey("sacramentMeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SacramentMeeting", b =>
                {
                    b.Navigation("speakers");
                });
#pragma warning restore 612, 618
        }
    }
}