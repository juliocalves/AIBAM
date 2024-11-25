﻿// <auto-generated />
using System;
using AIBAM.Classes.BancoDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AIBAM.Migrations
{
    [DbContext(typeof(AibamDbContext))]
    [Migration("20241115204539_updateproduto")]
    partial class updateproduto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AIBAM.Classes.BriefingCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArquivoImportado")
                        .HasColumnType("longtext");

                    b.Property<string>("DestinoCopy")
                        .HasColumnType("longtext");

                    b.Property<string>("ELancamentoProdServ")
                        .HasColumnType("longtext");

                    b.Property<string>("IdeiaPromovida")
                        .HasColumnType("longtext");

                    b.Property<string>("InformacoesProdServ")
                        .HasColumnType("longtext");

                    b.Property<string>("LinkCatalogoProdServ")
                        .HasColumnType("longtext");

                    b.Property<string>("LinkSite")
                        .HasColumnType("longtext");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext");

                    b.Property<string>("MensagemTransmitida")
                        .HasColumnType("longtext");

                    b.Property<string>("ObjetivoEspecifico")
                        .HasColumnType("longtext");

                    b.Property<string>("ObjetivoGeral")
                        .HasColumnType("longtext");

                    b.Property<string>("Observacoes")
                        .HasColumnType("longtext");

                    b.Property<string>("SegmentoNegocio")
                        .HasColumnType("longtext");

                    b.Property<string>("SubSegmentoNegocio")
                        .HasColumnType("longtext");

                    b.Property<string>("TipoVenda")
                        .HasColumnType("longtext");

                    b.Property<int?>("metasCampanhasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("metasCampanhasId");

                    b.ToTable("BriefingsCopy");
                });

            modelBuilder.Entity("AIBAM.Classes.BriefingPesquisa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContextoProblema")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CriteriosInclusaoExclusao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FerramentasPlataformas")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FontesReferencias")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Hipoteses")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImpactoEsperado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("IndicadoresChave")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Justificativa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LimitacoesPesquisa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MateriaisFerramentas")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MetodosColetaDados")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ObjetivoGeral")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ObjetivosEspecificos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ObservacoesAdicionais")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Orçamento")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("PerfilPublicoId")
                        .HasColumnType("int");

                    b.Property<string>("PerguntaPesquisa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RecursosHumanos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Segmentacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TamanhoAmostra")
                        .HasColumnType("int");

                    b.Property<string>("TecnicasAnalise")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoPesquisa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TituloProjeto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PerfilPublicoId");

                    b.ToTable("BriefingsPesquisa");
                });

            modelBuilder.Entity("AIBAM.Classes.BriefingPesquisa+EtapaCronograma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BriefingPesquisaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInicioEtapa")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataTerminoEtapa")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeEtapa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BriefingPesquisaId");

                    b.ToTable("EtapaCronograma");
                });

            modelBuilder.Entity("AIBAM.Classes.Catalogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Catalogos");
                });

            modelBuilder.Entity("AIBAM.Classes.ControlesCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Entonacao")
                        .HasColumnType("int");

                    b.Property<int>("Originalidade")
                        .HasColumnType("int");

                    b.Property<string>("PalavrasChave")
                        .HasColumnType("longtext");

                    b.Property<string>("Perspectiva")
                        .HasColumnType("longtext");

                    b.Property<string>("Sentimento")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ControlesCopy");
                });

            modelBuilder.Entity("AIBAM.Classes.MetasCampanha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AdicaoCarrinho")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CadastroFrm")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Clickslink")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Compartilhamentos")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Desempenho")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Engajamento")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Interacao")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("PermanenciaPag")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Registro")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Seguidores")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Vendas")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Vizualizacoes")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("MetasCampanha");
                });

            modelBuilder.Entity("AIBAM.Classes.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("CatalogoId")
                        .HasColumnType("int");

                    b.Property<int>("CatalotoId")
                        .HasColumnType("int");

                    b.Property<string>("CategoriaProd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("CustoProd")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("DescontoPix")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("DescricaoProd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GrupoProd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LinkProd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("LucroUnidade")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("NomeProd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PercentualDesconto")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TagsProd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("ValorVendaProd")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("ValorVendaPromocional")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("CatalogoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("AIBAM.Classes.PromptCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoCopy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("briefingId")
                        .HasColumnType("int");

                    b.Property<int>("controlesCopyId")
                        .HasColumnType("int");

                    b.Property<int>("publicoAlvoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("briefingId");

                    b.HasIndex("controlesCopyId");

                    b.HasIndex("publicoAlvoId");

                    b.ToTable("PromptsCopy");
                });

            modelBuilder.Entity("AIBAM.Classes.PromptPesquisa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoPrompt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ModeloPesquisa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("briefingPesquisaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("briefingPesquisaId");

                    b.ToTable("PromptsPesquisa");
                });

            modelBuilder.Entity("AIBAM.Classes.PublicoAlvo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("DiferenciaisCompetitivos")
                        .HasColumnType("longtext");

                    b.Property<string>("Dores")
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext");

                    b.Property<string>("Genero")
                        .HasColumnType("longtext");

                    b.Property<int>("IdadeFinal")
                        .HasColumnType("int");

                    b.Property<int>("IdadeInicial")
                        .HasColumnType("int");

                    b.Property<string>("Interesses")
                        .HasColumnType("longtext");

                    b.Property<string>("NivelAcademico")
                        .HasColumnType("longtext");

                    b.Property<string>("NivelConsciencia")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("Ocupacoes")
                        .HasColumnType("longtext");

                    b.Property<string>("OutrasInformacoes")
                        .HasColumnType("longtext");

                    b.Property<string>("Pais")
                        .HasColumnType("longtext");

                    b.Property<string>("PropostaValor")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("ReceitaAnualMedia")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Regiao")
                        .HasColumnType("longtext");

                    b.Property<int>("TamanhoMercado")
                        .HasColumnType("int");

                    b.Property<decimal?>("TicketMedio")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("PublicosAlvo");
                });

            modelBuilder.Entity("AIBAM.Classes.BriefingCopy", b =>
                {
                    b.HasOne("AIBAM.Classes.MetasCampanha", "metasCampanhas")
                        .WithMany()
                        .HasForeignKey("metasCampanhasId");

                    b.Navigation("metasCampanhas");
                });

            modelBuilder.Entity("AIBAM.Classes.BriefingPesquisa", b =>
                {
                    b.HasOne("AIBAM.Classes.PublicoAlvo", "PerfilPublico")
                        .WithMany()
                        .HasForeignKey("PerfilPublicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerfilPublico");
                });

            modelBuilder.Entity("AIBAM.Classes.BriefingPesquisa+EtapaCronograma", b =>
                {
                    b.HasOne("AIBAM.Classes.BriefingPesquisa", null)
                        .WithMany("Cronograma")
                        .HasForeignKey("BriefingPesquisaId");
                });

            modelBuilder.Entity("AIBAM.Classes.Produto", b =>
                {
                    b.HasOne("AIBAM.Classes.Catalogo", null)
                        .WithMany("ProdutoList")
                        .HasForeignKey("CatalogoId");
                });

            modelBuilder.Entity("AIBAM.Classes.PromptCopy", b =>
                {
                    b.HasOne("AIBAM.Classes.BriefingCopy", "briefing")
                        .WithMany()
                        .HasForeignKey("briefingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AIBAM.Classes.ControlesCopy", "controlesCopy")
                        .WithMany()
                        .HasForeignKey("controlesCopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AIBAM.Classes.PublicoAlvo", "publicoAlvo")
                        .WithMany()
                        .HasForeignKey("publicoAlvoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("briefing");

                    b.Navigation("controlesCopy");

                    b.Navigation("publicoAlvo");
                });

            modelBuilder.Entity("AIBAM.Classes.PromptPesquisa", b =>
                {
                    b.HasOne("AIBAM.Classes.BriefingPesquisa", "briefingPesquisa")
                        .WithMany()
                        .HasForeignKey("briefingPesquisaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("briefingPesquisa");
                });

            modelBuilder.Entity("AIBAM.Classes.BriefingPesquisa", b =>
                {
                    b.Navigation("Cronograma");
                });

            modelBuilder.Entity("AIBAM.Classes.Catalogo", b =>
                {
                    b.Navigation("ProdutoList");
                });
#pragma warning restore 612, 618
        }
    }
}
