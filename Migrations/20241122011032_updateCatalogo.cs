using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIBAM.Migrations
{
    /// <inheritdoc />
    public partial class updateCatalogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AtivoInativo",
                table: "Catalogos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "CustoMedio",
                table: "Catalogos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Catalogos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Catalogos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "LucroMedio",
                table: "Catalogos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Catalogos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoCount",
                table: "Catalogos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtivoInativo",
                table: "Catalogos");

            migrationBuilder.DropColumn(
                name: "CustoMedio",
                table: "Catalogos");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Catalogos");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Catalogos");

            migrationBuilder.DropColumn(
                name: "LucroMedio",
                table: "Catalogos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Catalogos");

            migrationBuilder.DropColumn(
                name: "ProdutoCount",
                table: "Catalogos");
        }
    }
}
