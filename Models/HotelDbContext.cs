using Microsoft.EntityFrameworkCore;

namespace HotelCodeFirst
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Filial> Filiais {get; set;} = null!;
        public DbSet<Quarto> Quartos {get; set;} = null!;
        public DbSet<Funcionario> Funcionarios {get; set;} = null!;
        public DbSet<Cliente> Clientes {get; set;} = null!;
        public DbSet<Reserva> Reservas {get; set;} = null!;
        public DbSet<Consumivel> Consumiveis {get; set;} = null!;
        public DbSet<ServicoLavanderia> ServicosLavanderia {get; set;} = null!;
        public DbSet<ServLavPrestado> ServLavPrestados {get; set;} = null!;
        public DbSet<Consumo> Consumo {get; set;} = null!;
        public DbSet<Conta> Conta {get; set;} = null!;
        public DbSet<Cargo> Cargos {get; set;} = null!;
        public DbSet<TipoQuarto> TiposQuarto {get; set;} = null!;
        public DbSet<FormaPagamento> FormasPagamento {get; set;} = null!;
        public DbSet<NotaFiscal> NotasFiscais {get; set;} = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=PEDRO-PC\SQLEXPRESS;Database=HotelDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        }
    }
}