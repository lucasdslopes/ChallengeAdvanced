using InovaX.Database.Mappings;
using InovaXSprint.Models;
using Microsoft.EntityFrameworkCore;

namespace InovaXSprint.Database
{
    public class FIAPDbContext : DbContext
    {
        public DbSet<Usuario> Users { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Distribuidor> Distribuidores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        public FIAPDbContext(DbContextOptions<FIAPDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new AvaliacaoMapping());
            modelBuilder.ApplyConfiguration(new DistribuidorMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new PessoaFisicaMapping());
            modelBuilder.ApplyConfiguration(new PessoaJuridicaMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new ServicoMapping());
            modelBuilder.ApplyConfiguration(new TelefoneMapping());

            base.OnModelCreating(modelBuilder);
        }
    }

    // Aqui está o código para adicionar o MigrationsAssembly explicitamente
    public static class DbContextOptionsExtensions
    {
        public static DbContextOptionsBuilder UseConfiguredOracle(
            this DbContextOptionsBuilder options, string connectionString)
        {
            return options.UseOracle(connectionString, b => b.MigrationsAssembly("InovaX.API"));
        }
    }
}
