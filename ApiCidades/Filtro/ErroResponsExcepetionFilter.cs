using ApiCidades.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCidades.Filtro
{
    public class ErroResponsExcepetionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(ErroResponse.From(context.Exception)) { StatusCode = 500 };
        }
    }
}
