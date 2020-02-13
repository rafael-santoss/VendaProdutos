using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MySql.Data.MySqlClient;
using VendaProduto.Classes.Padrao;

namespace VendaProduto.Classes
{
    //TODO - Método para gerar um pedido deverá ser criado.
    class Pedido : AcessoDados
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public List<Produto> Produtos { get; set; }
        public decimal ValorTotal { get; set; }

        public Pedido()
        {

        }

        public Pedido(int id, DateTime data, List<Produto> produtos, decimal valorTotal)
        {
            Id = id;
            Data = data;
            Produtos = produtos;
            ValorTotal = valorTotal;
        }

        public Pedido(DateTime data, List<Produto> produtos, decimal valorTotal)
        {
            Data = data;
            Produtos = produtos;
            ValorTotal = valorTotal;
        }

        public List<Pedido> BuscarTodosPedidos()
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();

            DataSet ds = base.Consultar("VP_SP_BuscarTodosPedidos", parametros);

            List<Pedido> pedidos = Converter(ds);

            return pedidos;
        }

        private List<Pedido> Converter(DataSet ds)
        {
            List<Pedido> pedidosConvertidos = new List<Pedido>();
            if (ds != null &&
                ds.Tables != null &&
                ds.Tables.Count > 0 &&
                ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow linha in ds.Tables[0].Rows)
                {
                    pedidosConvertidos.Add(new Pedido((int)linha["Id"],
                                                    Convert.ToDateTime(linha["Data"]),
                                                    //Aqui você pode instanciar uma lista vazia ou já buscar tudo
                                                    new Produto().BuscarProdutosPedido((int)linha["Id"]),
                                                    Convert.ToDecimal(linha["ValorTotal"])));
                }
            }
            return pedidosConvertidos;
        }
    }

}