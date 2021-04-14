using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppApi.Data;
using AppApi.Models;

namespace AppApi.Controllers
{
    public class PedidoController : ApiController
    {
		public int PegarId()
		{
			DaoPedido repositorio = new DaoPedido();
			return repositorio.PegarId();
		}

		public HttpResponseMessage Incluir(Pedido pedido)
		{
			DaoPedido repositorio = new DaoPedido();
			pedido.Id = repositorio.Incluir(pedido);

			HttpResponseMessage response = base.Request.CreateResponse(HttpStatusCode.Created, pedido);
			string uri = base.Url.Link("DefaultApi", new { id = pedido.Id });
			response.Headers.Location = new Uri(uri);
			return response;
		}

		public IEnumerable<ListaPedido> Listar(int id)
		{
			DaoPedido repositorio = new DaoPedido();
			return repositorio.Listar(id);
		}

		public void Excluir(Pedido pedido)
		{
			DaoPedido repositorio = new DaoPedido();
			try
			{
				repositorio.Excluir(pedido);
			}
			catch
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
		}
	}
}