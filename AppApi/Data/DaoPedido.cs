using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AppApi.Models;

namespace AppApi.Data
{
    internal class DaoPedido : AcessoDados
    {
		internal int Incluir(Pedido pedido)
		{
			List<SqlParameter> parametros = new List<SqlParameter>();
			parametros.Add(new SqlParameter("@ID_PEDIDO", pedido.Id));
			parametros.Add(new SqlParameter("@ID_LANCHE", pedido.IdLanche));
			parametros.Add(new SqlParameter("@QT_LANCHE", pedido.Quantidade));
			parametros.Add(new SqlParameter("@VL_LANCHE", pedido.Valor));
			return Executar("Proc_Pedido_Incluir", parametros);
		}

		internal int PegarId()
		{
			return ConsultarId("Proc_Pedido_Pegar_Id");
		}

		internal List<ListaPedido> Listar(int id)
		{
			List<SqlParameter> parametros = new List<SqlParameter>();

			parametros.Add(new SqlParameter("@ID_PEDIDO", id));

			DataSet ds = Consultar("Proc_Pedido_Consultar", parametros);
			return Converter(ds);
		}

		internal void Excluir(Pedido pedido)
		{
			List<SqlParameter> parametros = new List<SqlParameter>();

			parametros.Add(new SqlParameter("@ID_PEDIDO", pedido.Id));
			parametros.Add(new SqlParameter("@ID_LANCHE", pedido.IdLanche));

			Executar("Proc_Pedido_Excluir", parametros);
		}

		private List<ListaPedido> Converter(DataSet ds)
		{
			List<ListaPedido> lista = new List<ListaPedido>();
			if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					ListaPedido listaPedido = new ListaPedido
					{
						ID_PEDIDO = row.Field<int>("ID_PEDIDO"),
						ID_LANCHE = row.Field<int>("ID_LANCHE"),
						NM_LANCHE = row.Field<string>("NM_LANCHE").Trim(),
						QT_LANCHE = row.Field<int>("QT_LANCHE"),
						VL_TOTAL = row.Field<decimal>("VL_TOTAL")
					};
					lista.Add(listaPedido);
				}
			}
			return lista;
		}
	}
}