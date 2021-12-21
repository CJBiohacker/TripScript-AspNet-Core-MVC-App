using Microsoft.EntityFrameworkCore;

namespace Carlos.Models
{
    public class BancodeDados : DbContext
    {
        public BancodeDados(DbContextOptions<BancodeDados> options) : base(options) { }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Viagem> Viagems{ get; set; }
  
    }
}
