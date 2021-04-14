using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using AppApi.Models;

namespace AppApi.Data
{
    internal class DaoLanche : AcessoDados
    {
		internal int Incluir(Lanche lanche)
		{
			List<SqlParameter> parametros = new List<SqlParameter>
		{
			new SqlParameter("@ID_LANCHE", SqlDbType.Int, 4),
			new SqlParameter("@NM_LANCHE", lanche.Nome)
		};
			return Executar("Proc_Lanche_Incluir", parametros);
		}

		internal Lanche Consultar(int Id)
		{
			List<SqlParameter> parametros = new List<SqlParameter>
		{
			new SqlParameter("@ID_LANCHE", Id)
		};
			DataSet ds = Consultar("Proc_Lanche_Consultar", parametros);
			List<Lanche> lanche = Converter(ds);
			return lanche.FirstOrDefault();
		}

		internal List<Lanche> Listar()
		{
			List<SqlParameter> parametros = new List<SqlParameter>
		{
			new SqlParameter("@ID_LANCHE", "0")
		};
			DataSet ds = Consultar("Proc_Lanche_Consultar", parametros);
			return Converter(ds);
		}

		internal int Alterar(Lanche lanche)
		{
			List<SqlParameter> parametros = new List<SqlParameter>
		{
			new SqlParameter("@ID_LANCHE", lanche.Id),
			new SqlParameter("@NM_LANCHE", lanche.Nome)
		};
			return Executar("Proc_Lanche_Alterar", parametros);
		}

		internal void Excluir(int Id)
		{
			List<SqlParameter> parametros = new List<SqlParameter>
		{
			new SqlParameter("@ID_LANCHE", Id)
		};
			Executar("Proc_Lanche_Excluir", parametros);
		}

		private List<Lanche> Converter(DataSet ds)
		{
			List<Lanche> lista = new List<Lanche>();
			if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					Lanche lanche = new Lanche
					{
						Id = row.Field<int>("ID_LANCHE"),
						Nome = row.Field<string>("NM_LANCHE").Trim()
					};
					lista.Add(lanche);
				}
			}
			return lista;
		}
	}
}