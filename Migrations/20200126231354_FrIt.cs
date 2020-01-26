using Microsoft.EntityFrameworkCore.Migrations;

namespace PinyinCardApi.Migrations
{
    public partial class FrIt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name_fr",
                table: "category",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name_it",
                table: "category",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "audio_fr",
                table: "card",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "audio_it",
                table: "card",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name_fr",
                table: "card",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name_it",
                table: "card",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name_fr",
                table: "category");

            migrationBuilder.DropColumn(
                name: "name_it",
                table: "category");

            migrationBuilder.DropColumn(
                name: "audio_fr",
                table: "card");

            migrationBuilder.DropColumn(
                name: "audio_it",
                table: "card");

            migrationBuilder.DropColumn(
                name: "name_fr",
                table: "card");

            migrationBuilder.DropColumn(
                name: "name_it",
                table: "card");
        }
    }
}
