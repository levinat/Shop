using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class Spaceship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SpaceshipId",
                table: "ExistingFilePath",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Spaceship",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    EnginePower = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    LaunchDate = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifieAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceship", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePath_ProductId",
                table: "ExistingFilePath",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePath_SpaceshipId",
                table: "ExistingFilePath",
                column: "SpaceshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Product_ProductId",
                table: "ExistingFilePath",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Spaceship_SpaceshipId",
                table: "ExistingFilePath",
                column: "SpaceshipId",
                principalTable: "Spaceship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Product_ProductId",
                table: "ExistingFilePath");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Spaceship_SpaceshipId",
                table: "ExistingFilePath");

            migrationBuilder.DropTable(
                name: "Spaceship");

            migrationBuilder.DropIndex(
                name: "IX_ExistingFilePath_ProductId",
                table: "ExistingFilePath");

            migrationBuilder.DropIndex(
                name: "IX_ExistingFilePath_SpaceshipId",
                table: "ExistingFilePath");

            migrationBuilder.DropColumn(
                name: "SpaceshipId",
                table: "ExistingFilePath");
        }
    }
}
