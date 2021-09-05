using ApiCidades.Domain.Entities;
using System.Linq;

namespace ApiCidades.Data.Dtos.Request
{
    public static class CidadesRequestExtensions
    {
        public static IQueryable<Cidade> AplicaFiltro(this IQueryable<Cidade> query, CidadesRequest request)
        {
            if (request != null)
            {
                if (!string.IsNullOrEmpty(request.Nome))
                    query = query.Where(l => l.Nome.Contains(request.Nome));


                if (!string.IsNullOrEmpty(request.Estado))
                    query = query.Where(l => l.Estado.Contains(request.Estado));
            }

            return query;
        }
    }

    public class CidadesRequest
    {
        public string Nome { get; set; }
        public string Estado { get; set; }
    }
}
