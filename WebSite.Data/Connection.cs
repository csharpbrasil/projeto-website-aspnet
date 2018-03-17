using System;
using System.Data;
using System.Data.SqlClient;

namespace WebSite.Data
{
    public class Connection
    {
        private SqlConnection Conexao;

        /// <summary>
        /// Dados de conexao para SqlServer
        /// </summary>
        public string ConnectionString { get; set; }

        public Connection() { }

        /// <summary>
        /// Construtor que recebe como parametro a ConnectionString
        /// </summary>
        /// <param name="ConnectionString"></param>
        public Connection(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        /// <summary>
        /// Abre conexao
        /// </summary>
        public void AbrirConexao()
        {
            if (string.IsNullOrEmpty(this.ConnectionString)) throw new Exception("Não foi informado a ConnectionString.");

            if (Conexao == null)
            {
                Conexao = new SqlConnection();
                Conexao.ConnectionString = this.ConnectionString;
            }

            Conexao.Open();
        }

        /// <summary>
        /// Fecha conexao
        /// </summary>
        public void FechaConexao()
        {
            if (Conexao != null && Conexao.State == ConnectionState.Open)
            {
                Conexao.Close();
            }
        }

        /// <summary>
        /// Retorna os dados
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Retorna coleção de dados</returns>
        public IDataReader RetornaDados(string sql)
        {
            if (string.IsNullOrEmpty(sql)) throw new Exception("Não foi informado a query SQL.");
            if (Conexao == null || Conexao.State == ConnectionState.Closed) throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");

            SqlCommand command = new SqlCommand();
            command.Connection = this.Conexao;
            command.CommandText = sql;
            IDataReader reader = command.ExecuteReader();

            return reader;
        }

        /// <summary>
        /// Executa comando
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Retorna o total de linhas afetadas</returns>
        public int ExecutaComando(string sql)
        {
            if (string.IsNullOrEmpty(sql)) throw new Exception("Não foi informado a query SQL.");
            if (Conexao == null || Conexao.State == ConnectionState.Closed) throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");

            SqlCommand command = new SqlCommand();
            command.Connection = this.Conexao;
            command.CommandText = sql;
            int result = command.ExecuteNonQuery();

            return result;
        }
    }
}
