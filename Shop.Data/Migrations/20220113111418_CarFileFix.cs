using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class CarFileFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Car_CarId1",
                table: "ExistingFilePath");

            migrationBuilder.DropIndex(
                name: "IX_ExistingFilePath_CarId1",
                table: "ExistingFilePath");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "ExistingFilePath");

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "ExistingFilePath",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePath_CarId",
                table: "ExistingFilePath",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Car_CarId",
                table: "ExistingFilePath",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExistingFilePath_Car_CarId",
                table: "ExistingFilePath");

            migrationBuilder.DropIndex(
                name: "IX_ExistingFilePath_CarId",
                table: "ExistingFilePath");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "ExistingFilePath");

            migrationBuilder.AddColumn<Guid>(
                name: "CarId1",
                table: "ExistingFilePath",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExistingFilePath_CarId1",
                table: "ExistingFilePath",
                column: "CarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExistingFilePath_Car_CarId1",
                table: "ExistingFilePath",
                column: "CarId1",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
