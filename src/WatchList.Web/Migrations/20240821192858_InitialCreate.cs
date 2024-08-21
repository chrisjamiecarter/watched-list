﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WatchList.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheatricalPerformance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheatricalPerformance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheatricalPerformance_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvShow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvShow_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Awful" },
                    { 2, "Disappointing" },
                    { 3, "Good" },
                    { 4, "Great" },
                    { 5, "Excellent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_RatingId",
                table: "Movie",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_TheatricalPerformance_RatingId",
                table: "TheatricalPerformance",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShow_RatingId",
                table: "TvShow",
                column: "RatingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "TheatricalPerformance");

            migrationBuilder.DropTable(
                name: "TvShow");

            migrationBuilder.DropTable(
                name: "Rating");
        }
    }
}
