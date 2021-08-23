using ApiCidades.Models;
using System.Linq;

namespace ApiCidades.Filtro
{
    public static class ClientesFiltroExtensions
    {
        public static IQueryable<Cidade> AplicaFiltro(this IQueryable<Cidade> query, CidadesFiltro filtro)
        {
            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Nome))
                    query = query.Where(l => l.Nome.Contains(filtro.Nome));


                if (!string.IsNullOrEmpty(filtro.Estado))
                    query = query.Where(l => l.Estado.Contains(filtro.Estado));
            }

            return query;
        }
    }

    public class CidadesFiltro
    {
        public string Nome { get; set; }
        public string Estado { get; set; }
    }
}
