﻿using System;
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
    //TODO - Métodos para um CRUD deverá ser criado para a classe Produto.
    class Produto : AcessoDados
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal PrecoUnit { get; set; }
        public int QtdEstocada { get; set; }
        public int Ativo { get; set; }

        public Produto()
        {

        }

        public Produto(int id, string nomeProduto, decimal precoUnit, int qtdEstocada, int ativo)
        {
            Id = id;
            NomeProduto = nomeProduto;
            PrecoUnit = precoUnit;
            QtdEstocada = qtdEstocada;
            Ativo = ativo;
        }

        public Produto(string nomeProduto, decimal precoUnit, int qtdEstocada, int ativo)
        {
            NomeProduto = nomeProduto;
            PrecoUnit = precoUnit;
            QtdEstocada = qtdEstocada;
            Ativo = ativo;
        }

        public List<Produto> BuscarTodosProdutos()
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();

            DataSet ds = base.Consultar("VP_SP_BuscarTodosProdutos", parametros);

            List<Produto> produtos = Converter(ds);

            return produtos;
        }

        public static List<Produto> BuscarProduto(string texto, List<Produto> produtos)
        {
            List<Produto> produtosFiltro = new List<Produto>();
            try
            {
                produtosFiltro = (from p in produtos where p.NomeProduto.ToUpper().Contains(texto.ToUpper()) select p).ToList();
                return produtosFiltro;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Produto> BuscarProdutosPedido(int idPedido)
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>()
            {
                new MySqlParameter("idPedido", idPedido)
            };

            DataSet ds = base.Consultar("VP_SP_BuscarProdutosPedido", parametros);

            List<Produto> produtos = Converter(ds);

            return produtos;
        }
        public int InsereProduto()
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();

            parametros.Add(new MySqlParameter("NomeProduto", NomeProduto));
            parametros.Add(new MySqlParameter("PrecoUnit", PrecoUnit));
            parametros.Add(new MySqlParameter("QntEstocada", QtdEstocada));
            parametros.Add(new MySqlParameter("Ativo", Ativo));

            DataSet ds = base.Consultar("VP_SP_InsProduto", parametros);
            int id = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                int.TryParse(ds.Tables[0].Rows[0][0].ToString(), out id);
            }
            return id;
        }

        public string DesativarProduto()
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();

            parametros.Add(new MySqlParameter("ID", Id));

            DataSet ds = base.Consultar("VP_SP_DesativarProduto", parametros);
            string mensagem = "";

            if (ds.Tables[0].Rows.Count > 0)
            {
                mensagem = ds.Tables[0].Rows[0][0].ToString();
            }
            return mensagem;
        }

        private List<Produto> Converter(DataSet ds)
        {
            List<Produto> produtosConvertidos = new List<Produto>();
            if (ds != null &&
                ds.Tables != null &&
                ds.Tables.Count > 0 &&
                ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow linha in ds.Tables[0].Rows)
                {
                    produtosConvertidos.Add(new Produto((int)linha["Id"],
                                                    linha["NomeProduto"].ToString(),
                                                    Convert.ToDecimal(linha["PrecoUnit"]),
                                                    (int)linha["QtdEstocada"],
                                                    (int)linha["Ativo"]));
                }
            }
            return produtosConvertidos;
        }
    }
}