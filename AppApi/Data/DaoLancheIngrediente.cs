using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AppApi.Models;

namespace AppApi.Data
{
    internal class DaoLancheIngrediente : AcessoDados
    {
		internal List<LancheIngrediente> BuscarIngredientes(int idLanche)
		{
			List<SqlParameter> parametros = new List<SqlParameter>
		{
			new SqlParameter("@ID_LANCHE", idLanche)
		};
			DataSet ds = Consultar("Proc_LancheIngrediente_Buscar", parametros);
			return Converter(ds);
		}

		private List<LancheIngrediente> Converter(DataSet ds)
		{
			List<LancheIngrediente> lista = new List<LancheIngrediente>();
			if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					LancheIngrediente lancheIngredientes = new LancheIngrediente
					{
						idLanche = row.Field<int>("ID_LANCHE"),
						idIngrediente = row.Field<int>("ID_INGREDIENTE"),
						NomeIngrediente = row.Field<string>("NM_INGREDIENTE").Trim(),
						QtPorcao = row.Field<int>("QT_PORCAO"),
						ValorIngrediente = row.Field<decimal>("VL_INGREDIENTE")
					};
					lista.Add(lancheIngredientes);
				}
			}
			return lista;
		}
	}
}