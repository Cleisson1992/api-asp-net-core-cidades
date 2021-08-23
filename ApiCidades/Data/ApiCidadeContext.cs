using ApiCidades.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCidades.Data
{
    public class ApiCidadeContext : DbContext
    {
        public ApiCidadeContext(DbContextOptions<ApiCidadeContext> opt) : base (opt) { }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
