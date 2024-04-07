﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SeasonPass.Module.Postgres.Data;

#nullable disable

namespace SeasonPass.Module.Postgres.Migrations
{
    [DbContext(typeof(SeasonPassDbContext))]
    partial class SeasonPassDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SeasonPass.Module.Common.Models.Country", b =>
                {
                    b.Property<long>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("country_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CountryId"));

                    b.Property<string>("Alpha2Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("alpha2_code");

                    b.Property<string>("Alpha3Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("alpha3_code");

                    b.Property<string>("IsoName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("iso_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("NumericCode")
                        .HasColumnType("integer")
                        .HasColumnName("numeric_code");

                    b.HasKey("CountryId")
                        .HasName("pk_country");

                    b.ToTable("country", (string)null);
                });

            modelBuilder.Entity("SeasonPass.Module.SkiResorts.Models.LiftLocation", b =>
                {
                    b.Property<int>("LiftLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("lift_location_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LiftLocationId"));

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric")
                        .HasColumnName("latitude");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric")
                        .HasColumnName("longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long?>("SkiResortId")
                        .HasColumnType("bigint")
                        .HasColumnName("ski_resort_id");

                    b.HasKey("LiftLocationId")
                        .HasName("pk_lift_location");

                    b.HasIndex("SkiResortId")
                        .HasDatabaseName("ix_lift_location_ski_resort_id");

                    b.ToTable("lift_location", (string)null);
                });

            modelBuilder.Entity("SeasonPass.Module.SkiResorts.Models.SkiResort", b =>
                {
                    b.Property<long>("SkiResortId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ski_resort_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("SkiResortId"));

                    b.Property<long>("CountryId")
                        .HasColumnType("bigint")
                        .HasColumnName("country_id");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("text")
                        .HasColumnName("logo_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<float?>("Rating")
                        .HasColumnType("real")
                        .HasColumnName("rating");

                    b.Property<string>("Website")
                        .HasColumnType("text")
                        .HasColumnName("website");

                    b.HasKey("SkiResortId")
                        .HasName("pk_ski_resort");

                    b.HasIndex("CountryId")
                        .HasDatabaseName("ix_ski_resort_country_id");

                    b.ToTable("ski_resort", (string)null);
                });

            modelBuilder.Entity("SeasonPass.Module.SkiResorts.Models.LiftLocation", b =>
                {
                    b.HasOne("SeasonPass.Module.SkiResorts.Models.SkiResort", null)
                        .WithMany("Lifts")
                        .HasForeignKey("SkiResortId")
                        .HasConstraintName("fk_lift_location_ski_resort_ski_resort_id");
                });

            modelBuilder.Entity("SeasonPass.Module.SkiResorts.Models.SkiResort", b =>
                {
                    b.HasOne("SeasonPass.Module.Common.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_ski_resort_country_country_id");

                    b.OwnsOne("SeasonPass.Module.SkiResorts.Models.Elevation", "Elevation", b1 =>
                        {
                            b1.Property<long>("SkiResortId")
                                .HasColumnType("bigint")
                                .HasColumnName("ski_resort_id");

                            b1.Property<int>("BaseElevation")
                                .HasColumnType("integer")
                                .HasColumnName("elevation_base_elevation");

                            b1.Property<int>("TopElevation")
                                .HasColumnType("integer")
                                .HasColumnName("elevation_top_elevation");

                            b1.HasKey("SkiResortId");

                            b1.ToTable("ski_resort");

                            b1.WithOwner()
                                .HasForeignKey("SkiResortId")
                                .HasConstraintName("fk_ski_resort_ski_resort_ski_resort_id");
                        });

                    b.OwnsOne("SeasonPass.Module.SkiResorts.Models.LiftInfrastructure", "Infrastructure", b1 =>
                        {
                            b1.Property<long>("SkiResortId")
                                .HasColumnType("bigint")
                                .HasColumnName("ski_resort_id");

                            b1.Property<int?>("AerialCablecarCount")
                                .HasColumnType("integer")
                                .HasColumnName("infrastructure_aerial_cablecar_count");

                            b1.Property<int?>("CarpetLiftCount")
                                .HasColumnType("integer")
                                .HasColumnName("infrastructure_carpet_lift_count");

                            b1.Property<bool?>("CatSkiingAvailable")
                                .HasColumnType("boolean")
                                .HasColumnName("infrastructure_cat_skiing_available");

                            b1.Property<int?>("ChairliftCount")
                                .HasColumnType("integer")
                                .HasColumnName("infrastructure_chairlift_count");

                            b1.Property<int?>("CombinationLiftCount")
                                .HasColumnType("integer")
                                .HasColumnName("infrastructure_combination_lift_count");

                            b1.Property<int?>("FunicularCount")
                                .HasColumnType("integer")
                                .HasColumnName("infrastructure_funicular_count");

                            b1.Property<int?>("GondolaLiftCount")
                                .HasColumnType("integer")
                                .HasColumnName("infrastructure_gondola_lift_count");

                            b1.Property<bool?>("HeliSkiingAvailable")
                                .HasColumnType("boolean")
                                .HasColumnName("infrastructure_heli_skiing_available");

                            b1.Property<int?>("RopetowLiftCount")
                                .HasColumnType("integer")
                                .HasColumnName("infrastructure_ropetow_lift_count");

                            b1.Property<int?>("TbarLiftCount")
                                .HasColumnType("integer")
                                .HasColumnName("infrastructure_tbar_lift_count");

                            b1.HasKey("SkiResortId");

                            b1.ToTable("ski_resort");

                            b1.WithOwner()
                                .HasForeignKey("SkiResortId")
                                .HasConstraintName("fk_ski_resort_ski_resort_ski_resort_id");
                        });

                    b.OwnsOne("SeasonPass.Module.SkiResorts.Models.OperationInfo", "Operation", b1 =>
                        {
                            b1.Property<long>("SkiResortId")
                                .HasColumnType("bigint")
                                .HasColumnName("ski_resort_id");

                            b1.Property<TimeOnly?>("CloseHour")
                                .HasColumnType("time without time zone")
                                .HasColumnName("operation_close_hour");

                            b1.Property<TimeOnly?>("OpenHour")
                                .HasColumnType("time without time zone")
                                .HasColumnName("operation_open_hour");

                            b1.Property<string>("SeasonDuration")
                                .HasColumnType("text")
                                .HasColumnName("operation_season_duration");

                            b1.HasKey("SkiResortId");

                            b1.ToTable("ski_resort");

                            b1.WithOwner()
                                .HasForeignKey("SkiResortId")
                                .HasConstraintName("fk_ski_resort_ski_resort_ski_resort_id");
                        });

                    b.OwnsOne("SeasonPass.Module.SkiResorts.Models.SlopeInfo", "SlopeInfo", b1 =>
                        {
                            b1.Property<long>("SkiResortId")
                                .HasColumnType("bigint")
                                .HasColumnName("ski_resort_id");

                            b1.Property<float>("BlackSlopesLength")
                                .HasColumnType("real")
                                .HasColumnName("slope_info_black_slopes_length");

                            b1.Property<float>("BlueSlopesLength")
                                .HasColumnType("real")
                                .HasColumnName("slope_info_blue_slopes_length");

                            b1.Property<float>("RedSlopesLength")
                                .HasColumnType("real")
                                .HasColumnName("slope_info_red_slopes_length");

                            b1.Property<float>("SkiroutesLength")
                                .HasColumnType("real")
                                .HasColumnName("slope_info_skiroutes_length");

                            b1.HasKey("SkiResortId");

                            b1.ToTable("ski_resort");

                            b1.WithOwner()
                                .HasForeignKey("SkiResortId")
                                .HasConstraintName("fk_ski_resort_ski_resort_ski_resort_id");
                        });

                    b.OwnsOne("SeasonPass.Module.SkiResorts.Models.TicketPrices", "TicketPrices", b1 =>
                        {
                            b1.Property<long>("SkiResortId")
                                .HasColumnType("bigint")
                                .HasColumnName("ski_resort_id");

                            b1.Property<string>("Adults")
                                .HasColumnType("text")
                                .HasColumnName("ticket_prices_adults");

                            b1.Property<string>("Children")
                                .HasColumnType("text")
                                .HasColumnName("ticket_prices_children");

                            b1.Property<string>("Youth")
                                .HasColumnType("text")
                                .HasColumnName("ticket_prices_youth");

                            b1.HasKey("SkiResortId");

                            b1.ToTable("ski_resort");

                            b1.WithOwner()
                                .HasForeignKey("SkiResortId")
                                .HasConstraintName("fk_ski_resort_ski_resort_ski_resort_id");
                        });

                    b.Navigation("Country");

                    b.Navigation("Elevation");

                    b.Navigation("Infrastructure");

                    b.Navigation("Operation");

                    b.Navigation("SlopeInfo");

                    b.Navigation("TicketPrices");
                });

            modelBuilder.Entity("SeasonPass.Module.SkiResorts.Models.SkiResort", b =>
                {
                    b.Navigation("Lifts");
                });
#pragma warning restore 612, 618
        }
    }
}