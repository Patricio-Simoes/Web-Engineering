using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FP_02_2021_2022.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "isbn",
                table: "Livro",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isbn",
                table: "Livro");
        }
    }
}
