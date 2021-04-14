using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AppApi.Data
{
    internal class AcessoDados
    {
		private string stringDeConexao
		{
			get
			{
				ConnectionStringSettings conn = ConfigurationManager.ConnectionStrings["BancoDeDados"];
				if (conn != null)
				{
					return conn.ConnectionString;
				}
				return string.Empty;
			}
		}

		internal int Executar(string NomeProcedure, List<SqlParameter> parametros)
		{
			SqlCommand comando = new SqlCommand();
			SqlConnection conexao = (comando.Connection = new SqlConnection(stringDeConexao));
			comando.CommandType = CommandType.StoredProcedure;
			comando.CommandText = NomeProcedure;
			foreach (SqlParameter item in parametros)
			{
				comando.Parameters.Add(item);
			}
			conexao.Open();
			try
			{
				return Convert.ToInt32(comando.ExecuteScalar());
			}
			finally
			{
				conexao.Close();
			}
		}

		internal DataSet Consultar(string NomeProcedure, List<SqlParameter> parametros)
		{
			SqlCommand comando = new SqlCommand();
			SqlConnection conexao = (comando.Connection = new SqlConnection(stringDeConexao));
			comando.CommandType = CommandType.StoredProcedure;
			comando.CommandText = NomeProcedure;
			foreach (SqlParameter item in parametros)
			{
				comando.Parameters.AddWithValue(item.ParameterName, item.Value);
			}
			SqlDataAdapter adapter = new SqlDataAdapter(comando);
			DataSet ds = new DataSet();
			conexao.Open();
			try
			{
				adapter.Fill(ds);
			}
			finally
			{
				conexao.Close();
			}
			return ds;
		}

		internal int ConsultarId(string NomeProcedure)
		{
			SqlCommand comando = new SqlCommand();
			SqlConnection conexao = (comando.Connection = new SqlConnection(stringDeConexao));
			comando.CommandType = CommandType.StoredProcedure;
			comando.CommandText = NomeProcedure;
			SqlParameter retunvalue = comando.Parameters.Add("@MAX", SqlDbType.Int);
			retunvalue.Direction = ParameterDirection.Output;
			conexao.Open();

			int id = 0;

			try
			{
				comando.ExecuteNonQuery();
				id = (int)comando.Parameters["@MAX"].Value;
			}
			finally
			{
				conexao.Close();
			}
			return id;
		}
	}
}