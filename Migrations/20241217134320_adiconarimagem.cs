using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIBAM.Migrations
{
    /// <inheritdoc />
    public partial class adiconarimagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagens",
                table: "Produtos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagens",
                table: "Produtos");
        }
    }
}
