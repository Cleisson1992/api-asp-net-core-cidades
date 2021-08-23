using ApiCidades.Models;
using System.Linq;

namespace Cidades.API.Filtro
{
    public static class ClientesFiltroExtensions
    {
        public static IQueryable<Cliente> AplicaFiltro(this IQueryable<Cliente> query, ClientesFiltro filtro)
        {
            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.NomeCompleto))
                {
                    query = query.Where(l => l.NomeCompleto.Contains(filtro.NomeCompleto));
                }
            }
            return query;
        }
    }

    public class ClientesFiltro
    {
       public string NomeCompleto { get; set; }        
    }
}
