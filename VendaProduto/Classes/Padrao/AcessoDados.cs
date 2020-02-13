using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace VendaProduto.Classes.Padrao
{
    internal class AcessoDados
    {
        
        private string StringDeConexao
        {
            get
            {
                        //String para MySQL Server
                return "Server=10.27.47.51;Database=VendaProduto;Uid=admin;Pwd=123";
                 
                //String para SQL Server
                //"Data Source=10.27.47.51;Initial Catalog=PraticaCarro;User Id=sa;Password=123456";
            }
        }

        internal void Executar(string nomeProcedure, List<MySqlParameter> parametros)
        {
            MySqlCommand comando = new MySqlCommand();
            MySqlConnection conexao = new MySqlConnection(StringDeConexao);
            comando.Connection = conexao;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = nomeProcedure;

            foreach (var item in parametros)
                comando.Parameters.Add(item);

            conexao.Open();
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        internal DataSet Consultar(string nomeProcedure, List<MySqlParameter> parametros)
        {
            MySqlCommand comando = new MySqlCommand();
            MySqlConnection conexao = new MySqlConnection(StringDeConexao);

            comando.Connection = conexao;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = nomeProcedure;
            foreach (var item in parametros)
            {
                comando.Parameters.Add(item);
            }

            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataSet ds = new DataSet();

            conexao.Open();

            try
            {
                adapter.Fill(ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }

            return ds;
        }

    }
}