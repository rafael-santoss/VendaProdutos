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
using VendaProduto.Classes;

namespace VendaProduto.Activities
{
    [Activity(MainLauncher = true, Theme = "@style/Splash", NoHistory = true)]
    public class SplashScreen : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Já no splash, uma lista de pedido está sendo buscada
            //e para cada pedido, uma lista de produto também é buscada (pedidos.Produtos)
            List<Pedido> pedidos = new Pedido().BuscarTodosPedidos();

            Intent tlPrincipal = new Intent(this, typeof(PrincipalActivity));
            tlPrincipal.PutExtra("listaPedidos", JsonConvert.SerializeObject(pedidos));
            StartActivity(tlPrincipal);
        }
    }
}