using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIBAM.Migrations
{
    /// <inheritdoc />
    public partial class updateproduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatalotoId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatalotoId",
                table: "Produtos");
        }
    }
}
