using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIBAM.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Catalogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ControlesCopy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Entonacao = table.Column<int>(type: "int", nullable: false),
                    Originalidade = table.Column<int>(type: "int", nullable: false),
                    Sentimento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Perspectiva = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PalavrasChave = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlesCopy", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MetasCampanha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdicaoCarrinho = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CadastroFrm = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Clickslink = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Compartilhamentos = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Desempenho = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Engajamento = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Interacao = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PermanenciaPag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Registro = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Seguidores = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Vendas = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Vizualizacoes = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetasCampanha", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicosAlvo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropostaValor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NivelConsciencia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OutrasInformacoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pais = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Regiao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdadeInicial = table.Column<int>(type: "int", nullable: false),
                    IdadeFinal = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NivelAcademico = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ocupacoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Interesses = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dores = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiferenciaisCompetitivos = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TamanhoMercado = table.Column<int>(type: "int", nullable: false),
                    ReceitaAnualMedia = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    TicketMedio = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicosAlvo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomeProd = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustoProd = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ValorVendaProd = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ValorVendaPromocional = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PercentualDesconto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LucroUnidade = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LinkProd = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaProd = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GrupoProd = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescricaoProd = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TagsProd = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescontoPix = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CatalogoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Catalogos_CatalogoId",
                        column: x => x.CatalogoId,
                        principalTable: "Catalogos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BriefingsCopy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoVenda = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Marca = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdeiaPromovida = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LinkSite = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LinkCatalogoProdServ = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SegmentoNegocio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubSegmentoNegocio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ELancamentoProdServ = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InformacoesProdServ = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ObjetivoGeral = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ObjetivoEspecifico = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observacoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DestinoCopy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MensagemTransmitida = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    metasCampanhasId = table.Column<int>(type: "int", nullable: true),
                    ArquivoImportado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BriefingsCopy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BriefingsCopy_MetasCampanha_metasCampanhasId",
                        column: x => x.metasCampanhasId,
                        principalTable: "MetasCampanha",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BriefingsPesquisa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TituloProjeto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ObjetivoGeral = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ObjetivosEspecificos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PerguntaPesquisa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Justificativa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContextoProblema = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PerfilPublicoId = table.Column<int>(type: "int", nullable: false),
                    Segmentacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CriteriosInclusaoExclusao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoPesquisa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetodosColetaDados = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FerramentasPlataformas = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TamanhoAmostra = table.Column<int>(type: "int", nullable: false),
                    TecnicasAnalise = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IndicadoresChave = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Orçamento = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RecursosHumanos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MateriaisFerramentas = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hipoteses = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImpactoEsperado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LimitacoesPesquisa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FontesReferencias = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ObservacoesAdicionais = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BriefingsPesquisa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BriefingsPesquisa_PublicosAlvo_PerfilPublicoId",
                        column: x => x.PerfilPublicoId,
                        principalTable: "PublicosAlvo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PromptsCopy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescricaoCopy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    briefingId = table.Column<int>(type: "int", nullable: false),
                    publicoAlvoId = table.Column<int>(type: "int", nullable: false),
                    controlesCopyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptsCopy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromptsCopy_BriefingsCopy_briefingId",
                        column: x => x.briefingId,
                        principalTable: "BriefingsCopy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromptsCopy_ControlesCopy_controlesCopyId",
                        column: x => x.controlesCopyId,
                        principalTable: "ControlesCopy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromptsCopy_PublicosAlvo_publicoAlvoId",
                        column: x => x.publicoAlvoId,
                        principalTable: "PublicosAlvo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EtapaCronograma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeEtapa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataInicioEtapa = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataTerminoEtapa = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BriefingPesquisaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaCronograma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtapaCronograma_BriefingsPesquisa_BriefingPesquisaId",
                        column: x => x.BriefingPesquisaId,
                        principalTable: "BriefingsPesquisa",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PromptsPesquisa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescricaoPrompt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModeloPesquisa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    briefingPesquisaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptsPesquisa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromptsPesquisa_BriefingsPesquisa_briefingPesquisaId",
                        column: x => x.briefingPesquisaId,
                        principalTable: "BriefingsPesquisa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BriefingsCopy_metasCampanhasId",
                table: "BriefingsCopy",
                column: "metasCampanhasId");

            migrationBuilder.CreateIndex(
                name: "IX_BriefingsPesquisa_PerfilPublicoId",
                table: "BriefingsPesquisa",
                column: "PerfilPublicoId");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaCronograma_BriefingPesquisaId",
                table: "EtapaCronograma",
                column: "BriefingPesquisaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CatalogoId",
                table: "Produtos",
                column: "CatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromptsCopy_briefingId",
                table: "PromptsCopy",
                column: "briefingId");

            migrationBuilder.CreateIndex(
                name: "IX_PromptsCopy_controlesCopyId",
                table: "PromptsCopy",
                column: "controlesCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_PromptsCopy_publicoAlvoId",
                table: "PromptsCopy",
                column: "publicoAlvoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromptsPesquisa_briefingPesquisaId",
                table: "PromptsPesquisa",
                column: "briefingPesquisaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtapaCronograma");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "PromptsCopy");

            migrationBuilder.DropTable(
                name: "PromptsPesquisa");

            migrationBuilder.DropTable(
                name: "Catalogos");

            migrationBuilder.DropTable(
                name: "BriefingsCopy");

            migrationBuilder.DropTable(
                name: "ControlesCopy");

            migrationBuilder.DropTable(
                name: "BriefingsPesquisa");

            migrationBuilder.DropTable(
                name: "MetasCampanha");

            migrationBuilder.DropTable(
                name: "PublicosAlvo");
        }
    }
}
