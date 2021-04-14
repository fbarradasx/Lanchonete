using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AppApi.Models;

namespace AppApi.Data
{
    internal class DaoPromocao : AcessoDados
    {
		internal List<Promocao> Listar()
		{
			List<SqlParameter> parametros = new List<SqlParameter>();
			
			DataSet ds = Consultar("Proc_Promocao_Consultar", parametros);
			return Converter(ds);
		}

		
		private List<Promocao> Converter(DataSet ds)
		{
			List<Promocao> lista = new List<Promocao>();
			if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					Promocao promocao = new Promocao();
					promocao.IdIngrediente = row.Field<int>("ID_INGREDIENTE");
					promocao.IdIngredienteSem = row.Field<int>("ID_INGREDIENTE_SEM");
					promocao.Nome = row.Field<string>("NM_PROMOCAO");
					promocao.Quantidade = row.Field<int>("QT_INGREDIENTE");
					promocao.PorcaoDesconto = row.Field<int>("QT_PORCAO_DESCONTO");
					promocao.PorcentagemDesconto = row.Field<decimal>("VL_PORCAO_PORCENT_DESC");
					lista.Add(promocao);
				}
			}
			return lista;
		}
	}
}