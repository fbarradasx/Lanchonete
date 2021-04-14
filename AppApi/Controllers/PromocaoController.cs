using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppApi.Data;
using AppApi.Models;

namespace AppApi.Controllers
{
    public class PromocaoController : ApiController
    {
        public List<Promocao> Listar()
        {
            DaoPromocao repositorio = new DaoPromocao();
            return repositorio.Listar();
        }

    }
}