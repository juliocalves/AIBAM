using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIBAM.Migrations
{
    /// <inheritdoc />
    public partial class updateColecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colecoes_PublicosAlvo_PublicoAlvoId",
                table: "Colecoes");

            migrationBuilder.AlterColumn<int>(
                name: "PublicoAlvoId",
                table: "Colecoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoCount",
                table: "Colecoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Colecoes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Colecoes_PublicosAlvo_PublicoAlvoId",
                table: "Colecoes",
                column: "PublicoAlvoId",
                principalTable: "PublicosAlvo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colecoes_PublicosAlvo_PublicoAlvoId",
                table: "Colecoes");

            migrationBuilder.AlterColumn<int>(
                name: "PublicoAlvoId",
                table: "Colecoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoCount",
                table: "Colecoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Colecoes",
                keyColumn: "Descricao",
                keyValue: null,
                column: "Descricao",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Colecoes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Colecoes_PublicosAlvo_PublicoAlvoId",
                table: "Colecoes",
                column: "PublicoAlvoId",
                principalTable: "PublicosAlvo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
