using Microsoft.EntityFrameworkCore.Migrations;

namespace PinyinCardApi.Migrations
{
    public partial class AudioLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "audio",
                table: "card");

            migrationBuilder.AddColumn<string>(
                name: "audio_ch",
                table: "card",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "audio_en",
                table: "card",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "audio_pt",
                table: "card",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "audio_ch",
                table: "card");

            migrationBuilder.DropColumn(
                name: "audio_en",
                table: "card");

            migrationBuilder.DropColumn(
                name: "audio_pt",
                table: "card");

            migrationBuilder.AddColumn<string>(
                name: "audio",
                table: "card",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: true);
        }
    }
}
