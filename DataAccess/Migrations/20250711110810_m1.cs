using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ankets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ankets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sorulars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soru = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AnketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sorulars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sorulars_ankets_AnketId",
                        column: x => x.AnketId,
                        principalTable: "ankets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cevaplars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cevap = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SorularId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cevaplars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cevaplars_sorulars_SorularId",
                        column: x => x.SorularId,
                        principalTable: "sorulars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cevaplars_SorularId",
                table: "cevaplars",
                column: "SorularId");

            migrationBuilder.CreateIndex(
                name: "IX_sorulars_AnketId",
                table: "sorulars",
                column: "AnketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cevaplars");

            migrationBuilder.DropTable(
                name: "sorulars");

            migrationBuilder.DropTable(
                name: "ankets");
        }
    }
}
