using ApiCidades.Domain.Entities;
using System.Linq;

namespace ApiCidades.Data.Dtos.Request
{
    public static class ClientesRequestExtensions
    {
        public static IQueryable<Cliente> AplicaFiltro(this IQueryable<Cliente> query, ClientesRequest request)
        {
            if (request != null)
            {
                if (!string.IsNullOrEmpty(request.NomeCompleto))
                {
                    query = query.Where(l => l.NomeCompleto.Contains(request.NomeCompleto));
                }
            }
            return query;
        }
    }

    public class ClientesRequest
    {
       public string NomeCompleto { get; set; }        
    }
}
