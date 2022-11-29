using Npgsql;
using ProductivityTools.CodeGenerator;
using System.Data;

namespace ProductivityTools.Data
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
            //CodeGenerator.Configuration configuracao = new CodeGenerator.Configuration();

            //string strUsuario = configuracao.ObterParametroDoXML("usuario");
            //string strSenha = configuracao.ObterParametroDoXML("senha");
            //string strInstancia = configuracao.ObterParametroDoXML("instancia");

            string strConnetionstring = CustomConfiguration.GetConnectionString();

            return strConnetionstring;
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
            NpgsqlCommand cmd = new NpgsqlCommand(select_, conn_);
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
            NpgsqlCommand cmd = new NpgsqlCommand(select_, conn_);
            NpgsqlDataReader dtr = cmd.ExecuteReader();

            return dtr;
        }

        public NpgsqlDataReader GetSelectDataReader(string select_)
        {

            NpgsqlConnection conn = new NpgsqlConnection(this.GetConnectionString());

            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(select_, conn);
            NpgsqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dtr;

        }



    }
}
