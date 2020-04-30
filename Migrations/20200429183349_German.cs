using Microsoft.EntityFrameworkCore.Migrations;

namespace PinyinCardApi.Migrations
{
    public partial class German : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "audio_de",
                table: "card",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "extra_de",
                table: "card",
                type: "Json",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name_de",
                table: "card",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "audio_de",
                table: "card");

            migrationBuilder.DropColumn(
                name: "extra_de",
                table: "card");

            migrationBuilder.DropColumn(
                name: "name_de",
                table: "card");
        }
    }
}
