using Microsoft.EntityFrameworkCore.Migrations;

namespace PinyinCardApi.Migrations
{
    public partial class CategoryParentCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "parent_category_id",
                table: "category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_category_parent_category_id",
                table: "category",
                column: "parent_category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_category_category_parent_category_id",
                table: "category",
                column: "parent_category_id",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_category_parent_category_id",
                table: "category");

            migrationBuilder.DropIndex(
                name: "IX_category_parent_category_id",
                table: "category");

            migrationBuilder.DropColumn(
                name: "parent_category_id",
                table: "category");
        }
    }
}
