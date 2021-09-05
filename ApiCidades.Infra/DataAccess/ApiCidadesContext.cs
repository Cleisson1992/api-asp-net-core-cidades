using ApiCidades.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCidades.Infra.DataAccess
{
    public class ApiCidadesContext : DbContext
    {
        public ApiCidadesContext(DbContextOptions<ApiCidadesContext> opt) : base(opt) { }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
