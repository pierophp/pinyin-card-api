using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PinyinCardApi.Migrations
{
    public partial class Card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "card",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_en = table.Column<string>(maxLength: 255, nullable: true),
                    name_pt = table.Column<string>(maxLength: 255, nullable: true),
                    name_cht = table.Column<string>(maxLength: 255, nullable: true),
                    name_chs = table.Column<string>(maxLength: 255, nullable: true),
                    image = table.Column<string>(maxLength: 255, nullable: true),
                    audio = table.Column<string>(maxLength: 255, nullable: true),
                    category_id = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card", x => x.id);
                    table.ForeignKey(
                        name: "FK_card_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_card_category_id",
                table: "card",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "card");
        }
    }
}
