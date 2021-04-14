using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using AppApi.Models;

namespace AppApi.Data
{
    internal class DaoIngrediente : AcessoDados
    {
		internal int Incluir(Ingrediente ingrediente)
		{
			List<SqlParameter> parametros = new List<SqlParameter>
		{
			new SqlParameter("@ID_INGREDIENTE", SqlDbType.Int, 4),
			new SqlParameter("@NM_INGREDIENTE", ingrediente.Nome),
			new SqlParameter("@VL_INGREDIENTE", ingrediente.Valor)
		};
			return Executar("Proc_Ingrediente_Incluir", parametros);
		}

		internal Ingrediente Consultar(int Id)
		{
			List<SqlParameter> parametros = new List<SqlParameter>
		{
			new SqlParameter("@ID_INGREDIENTE", Id)
		};
			DataSet ds = Consultar("Proc_Ingrediente_Consultar", parametros);
			List<Ingrediente> ingrediente = Converter(ds);
			return ingrediente.FirstOrDefault();
		}

		internal List<Ingrediente> Listar()
		{
			List<SqlParameter> parametros = new List<SqlParameter>
		{
			new SqlParameter("@ID_INGREDIENTE", "0")
		};
			DataSet ds = Consultar("Proc_Ingrediente_Consultar", parametros);
			return Converter(ds);
		}

		internal int Alterar(Ingrediente ingrediente)
		{
			List<SqlParameter> parametros = new List<SqlParameter>
		{
			new SqlParameter("@ID_INGREDIENTE", ingrediente.Id),
			new SqlParameter("@NM_INGREDIENTE", ingrediente.Nome),
			new SqlParameter("@VL_INGREDIENTE", ingrediente.Valor)
		};
			return Executar("Proc_Ingrediente_Alterar", parametros);
		}

		internal void Excluir(int Id)
		{
			List<SqlParameter> parametros = new List<SqlParameter>
		{
			new SqlParameter("@ID_INGREDIENTE", Id)
		};
			Executar("Proc_Ingrediente_Excluir", parametros);
		}

		private List<Ingrediente> Converter(DataSet ds)
		{
			List<Ingrediente> lista = new List<Ingrediente>();
			if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					Ingrediente ingrediente = new Ingrediente
					{
						Id = row.Field<int>("ID_INGREDIENTE"),
						Nome = row.Field<string>("NM_INGREDIENTE"),
						Valor = row.Field<decimal>("VL_INGREDIENTE")
					};
					lista.Add(ingrediente);
				}
			}
			return lista;
		}
	}
}