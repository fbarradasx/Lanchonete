using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppApi.Data;
using AppApi.Models;

namespace AppApi.Controllers
{
    public class LancheController : ApiController
    {
		public IEnumerable<Lanche> Listar()
		{
			DaoLanche repositorio = new DaoLanche();
			return repositorio.Listar();
		}

		public Lanche Consultar(int id)
		{
			DaoLanche repositorio = new DaoLanche();
			Lanche lanche = repositorio.Consultar(id);
			if (lanche == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return lanche;
		}

		public HttpResponseMessage Incluir(Lanche lanche)
		{
			DaoLanche repositorio = new DaoLanche();
			lanche.Id = repositorio.Incluir(lanche);
			HttpResponseMessage response = base.Request.CreateResponse(HttpStatusCode.Created, lanche);
			string uri = base.Url.Link("DefaultApi", new { id = lanche.Id });
			response.Headers.Location = new Uri(uri);
			return response;
		}

		public void Alterar(Lanche lanche)
		{
			DaoLanche repositorio = new DaoLanche();
			try
			{
				int resposta = repositorio.Alterar(lanche);
			}
			catch
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
		}

		public void Excluir(int id)
		{
			DaoLanche repositorio = new DaoLanche();
			try
			{
				repositorio.Excluir(id);
			}
			catch
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
		}

		public IEnumerable<LancheIngrediente> BuscarIngredientes(int id)
		{
			DaoLancheIngrediente repositorio = new DaoLancheIngrediente();
			return repositorio.BuscarIngredientes(id);
		}
	}
}