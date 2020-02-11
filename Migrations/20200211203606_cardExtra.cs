using Microsoft.EntityFrameworkCore.Migrations;

namespace PinyinCardApi.Migrations
{
    public partial class cardExtra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "extra_ch",
                table: "card",
                type: "Json",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "extra_en",
                table: "card",
                type: "Json",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "extra_fr",
                table: "card",
                type: "Json",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "extra_it",
                table: "card",
                type: "Json",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "extra_pt",
                table: "card",
                type: "Json",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "extra_ch",
                table: "card");

            migrationBuilder.DropColumn(
                name: "extra_en",
                table: "card");

            migrationBuilder.DropColumn(
                name: "extra_fr",
                table: "card");

            migrationBuilder.DropColumn(
                name: "extra_it",
                table: "card");

            migrationBuilder.DropColumn(
                name: "extra_pt",
                table: "card");
        }
    }
}
