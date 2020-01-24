using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PinyinCardApi.Migrations
{
    public partial class CreatedUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "category",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "category");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "category");
        }
    }
}
