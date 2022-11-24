using System;
using System.Data.OleDb;
using System.Data;
using Procwork.CodeGenerator;
using Npgsql;

namespace Procwork.Data
{
	/// <summary>
	/// Summary description for DataAccess.
	/// </summary>
	public class DataAccess
	{
		public DataAccess()
		{
		}

		public string GetConnectionString()
		{
			Configuracao configuracao = new Configuracao();
			
			//string strUsuario = configuracao.ObterParametroDoXML("usuario");
			//string strSenha = configuracao.ObterParametroDoXML("senha");
			//string strInstancia = configuracao.ObterParametroDoXML("instancia");
			
			string strSQLConnetionstring = "Host=localhost;Username=postgres;Password=cyber2010!;Database=dbdocstorage01;Port=5433;Pooling=true;SearchPath=public;IncludeErrorDetails=true";

            return strSQLConnetionstring;
		}

		public NpgsqlConnection GetConnection(string stringConexao_)
		{
            NpgsqlConnection conn = new NpgsqlConnection(stringConexao_);
			conn.Open();
			return conn;
		} 

		public void CloseConnection(NpgsqlConnection conn_)
		{
			conn_.Close();
		}

		public DataTable GetSelectCommand(NpgsqlConnection conn_, string select_)
		{
			
			DataTable dttDados = new DataTable();
            NpgsqlCommand cmd = new NpgsqlCommand(select_,conn_);
            NpgsqlDataAdapter dta = new NpgsqlDataAdapter(cmd);

			dta.Fill(dttDados);
			return dttDados;
		}

		public DataTable GetSelectCommand(string select_)
		{

            NpgsqlConnection conn = new NpgsqlConnection(this.GetConnectionString());

			DataTable dttDados = new DataTable();
            NpgsqlCommand cmd = new NpgsqlCommand(select_, conn);
            NpgsqlDataAdapter dta = new NpgsqlDataAdapter(cmd);

            dta.Fill(dttDados);
			return dttDados;
		}

		public NpgsqlDataReader GetSelectDataReader(NpgsqlConnection conn_, string select_)
		{
            NpgsqlCommand cmd = new NpgsqlCommand(select_,conn_);
            NpgsqlDataReader dtr = cmd.ExecuteReader();
			
			return dtr;
		}

		public NpgsqlDataReader GetSelectDataReader(string select_)
		{

            NpgsqlConnection conn = new NpgsqlConnection(this.GetConnectionString());
			
			conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(select_,conn);
            NpgsqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			
			return dtr;

		}



	}
}