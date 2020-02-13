using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using VendaProduto.Adapters;
using VendaProduto.Classes;
using ToolbarV7 = Android.Support.V7.Widget.Toolbar;

namespace VendaProduto.Activities
{
    /// <summary>
    /// Activity que exibirá os produtos de um pedido selecionado.
    /// A activity está pronta.
    /// </summary>
    [Activity()]
    public class ProdutoPedidoActivity : AppCompatActivity
    {
        ToolbarV7 tlbProdutoPedido;
        ListView lstProdutosPedido;
        Pedido pedidoSelecionado;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_produtosPedido);

            lstProdutosPedido = FindViewById<ListView>(Resource.Id.lstProdutosPedido);
            tlbProdutoPedido = FindViewById<ToolbarV7>(Resource.Id.tlbProdutoPedido);

            pedidoSelecionado = JsonConvert.DeserializeObject<Pedido>(Intent.GetStringExtra("produtosPedido"));

            SetSupportActionBar(tlbProdutoPedido);
            SupportActionBar.Title = "Pedido número: " + pedidoSelecionado.Id;

            AdaptadorProdutosPedido adp = new AdaptadorProdutosPedido(this, pedidoSelecionado.Produtos);
            lstProdutosPedido.Adapter = adp;
        }
    }
}