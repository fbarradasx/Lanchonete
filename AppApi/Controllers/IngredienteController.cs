using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppApi.Data;
using AppApi.Models;

namespace AppApi.Controllers
{
    public class IngredienteController : ApiController
    {
		public IEnumerable<Ingrediente> Listar()
		{
			DaoIngrediente repositorio = new DaoIngrediente();
			return repositorio.Listar();
		}

		public Ingrediente Consultar(int id)
		{
			DaoIngrediente repositorio = new DaoIngrediente();
			Ingrediente ingrediente = repositorio.Consultar(id);
			if (ingrediente == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return ingrediente;
		}

		public HttpResponseMessage Incluir(Ingrediente ingrediente)
		{
			DaoIngrediente repositorio = new DaoIngrediente();
			ingrediente.Id = repositorio.Incluir(ingrediente);
			HttpResponseMessage response = base.Request.CreateResponse(HttpStatusCode.Created, ingrediente);
			string uri = base.Url.Link("DefaultApi", new { id = ingrediente.Id });
			response.Headers.Location = new Uri(uri);
			return response;
		}

		public void Alterar(Ingrediente ingrediente)
		{
			DaoIngrediente repositorio = new DaoIngrediente();
			try
			{
				int resposta = repositorio.Alterar(ingrediente);
			}
			catch
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
		}

		public void Excluir(int id)
		{
			DaoIngrediente repositorio = new DaoIngrediente();
			try
			{
				repositorio.Excluir(id);
			}
			catch
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
		}
	}
}