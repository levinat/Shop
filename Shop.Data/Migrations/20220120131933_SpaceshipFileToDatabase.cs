using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class SpaceshipFileToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Spaceship_SpaceshipId",
                table: "ExistingFilePath");

            migrationBuilder.DropIndex(
                name: "IX_ExistingFilePath_SpaceshipId",
                table: "ExistingFilePath");

            migrationBuilder.CreateTable(
                name: "FileToDatabase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ImageTitle = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true),
                    SpaceshipId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileToDatabase", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileToDatabase");

            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePath_SpaceshipId",
                table: "ExistingFilePath",
                column: "SpaceshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Spaceship_SpaceshipId",
                table: "ExistingFilePath",
                column: "SpaceshipId",
                principalTable: "Spaceship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
