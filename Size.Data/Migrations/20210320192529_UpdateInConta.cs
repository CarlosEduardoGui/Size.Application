using Microsoft.EntityFrameworkCore.Migrations;

namespace Size.Data.Migrations
{
    public partial class UpdateInConta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroConta",
                table: "Conta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroConta",
                table: "Conta");
        }
    }
}
