using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Classes.BancoDados
{
    public class AibamDbContext : DbContext
    {
        public AibamDbContext(DbContextOptions<AibamDbContext> options) : base(options) { }

        public DbSet<PromptCopy> PromptsCopy { get; set; }
        public DbSet<PromptPesquisa> PromptsPesquisa { get; set; }
        public DbSet<BriefingCopy> BriefingsCopy { get; set; }
        public DbSet<BriefingPesquisa> BriefingsPesquisa { get; set; }
        public DbSet<Colecao> Colecoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<CatalogoProduto> CatalogoProdutos { get; set; }
        public DbSet<MetasCampanha> MetasCampanha {get;set;}
        public DbSet<PublicoAlvo> PublicosAlvo{get;set;}
        public DbSet<ControlesCopy> ControlesCopy {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=aibam_producao;User=coffeejazz;Password=@maiden08berry;",
                        new MySqlServerVersion(new Version(8, 0, 32)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    public class AibamDbContextFactory : IDesignTimeDbContextFactory<AibamDbContext>
    {
        public AibamDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AibamDbContext>();

            // Configure a string de conexão aqui
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=aibam_producao;User=coffeejazz;Password=@maiden08berry;",
                new MySqlServerVersion(new Version(8, 0, 32)));

            return new AibamDbContext(optionsBuilder.Options);
        }
        public AibamDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AibamDbContext>();

            // Configure a string de conexão aqui
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=aibam_producao;User=coffeejazz;Password=@maiden08berry;",
                new MySqlServerVersion(new Version(8, 0, 32)));

            return new AibamDbContext(optionsBuilder.Options);
        }
    }
}
