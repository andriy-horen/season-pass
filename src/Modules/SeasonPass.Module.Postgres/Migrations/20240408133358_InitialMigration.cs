using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SeasonPass.Module.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    country_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    iso_name = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    alpha2_code = table.Column<string>(type: "text", nullable: false),
                    alpha3_code = table.Column<string>(type: "text", nullable: false),
                    numeric_code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "ski_resort",
                columns: table => new
                {
                    ski_resort_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    rating = table.Column<float>(type: "real", nullable: true),
                    website = table.Column<string>(type: "text", nullable: true),
                    logo_url = table.Column<string>(type: "text", nullable: true),
                    external_url = table.Column<string>(type: "text", nullable: true),
                    elevation_base = table.Column<int>(type: "integer", nullable: true),
                    elevation_top = table.Column<int>(type: "integer", nullable: true),
                    slope_info_blue_slopes_length = table.Column<float>(type: "real", nullable: true),
                    slope_info_red_slopes_length = table.Column<float>(type: "real", nullable: true),
                    slope_info_black_slopes_length = table.Column<float>(type: "real", nullable: true),
                    slope_info_skiroutes_length = table.Column<float>(type: "real", nullable: true),
                    infrastructure_aerial_cablecar_count = table.Column<int>(type: "integer", nullable: true),
                    infrastructure_funicular_count = table.Column<int>(type: "integer", nullable: true),
                    infrastructure_gondola_lift_count = table.Column<int>(type: "integer", nullable: true),
                    infrastructure_chairlift_count = table.Column<int>(type: "integer", nullable: true),
                    infrastructure_combination_lift_count = table.Column<int>(type: "integer", nullable: true),
                    infrastructure_tbar_lift_count = table.Column<int>(type: "integer", nullable: true),
                    infrastructure_ropetow_lift_count = table.Column<int>(type: "integer", nullable: true),
                    infrastructure_carpet_lift_count = table.Column<int>(type: "integer", nullable: true),
                    infrastructure_heli_skiing = table.Column<bool>(type: "boolean", nullable: true),
                    infrastructure_cat_skiing = table.Column<bool>(type: "boolean", nullable: true),
                    operation_open_hour = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    operation_close_hour = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    operation_season_duration = table.Column<string>(type: "text", nullable: true),
                    ticket_prices_adults = table.Column<string>(type: "text", nullable: true),
                    ticket_prices_youth = table.Column<string>(type: "text", nullable: true),
                    ticket_prices_children = table.Column<string>(type: "text", nullable: true),
                    country_id = table.Column<long>(type: "bigint", nullable: false),
                    country2_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ski_resort", x => x.ski_resort_id);
                    table.ForeignKey(
                        name: "fk_ski_resort_country_country2_id",
                        column: x => x.country2_id,
                        principalTable: "country",
                        principalColumn: "country_id");
                    table.ForeignKey(
                        name: "fk_ski_resort_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lift_location",
                columns: table => new
                {
                    lift_location_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    ski_resort_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lift_location", x => x.lift_location_id);
                    table.ForeignKey(
                        name: "fk_lift_location_ski_resort_ski_resort_id",
                        column: x => x.ski_resort_id,
                        principalTable: "ski_resort",
                        principalColumn: "ski_resort_id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_country_alpha2_code",
                table: "country",
                column: "alpha2_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_country_alpha3_code",
                table: "country",
                column: "alpha3_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_lift_location_ski_resort_id",
                table: "lift_location",
                column: "ski_resort_id");

            migrationBuilder.CreateIndex(
                name: "ix_ski_resort_country_id",
                table: "ski_resort",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_ski_resort_country2_id",
                table: "ski_resort",
                column: "country2_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lift_location");

            migrationBuilder.DropTable(
                name: "ski_resort");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
