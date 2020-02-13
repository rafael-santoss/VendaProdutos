using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VendaProduto.Classes;
using System.Globalization;

namespace VendaProduto.Adapters
{
    class AdaptadorPedidos : BaseAdapter<Pedido>
    {
        private Context _context;
        private List<Pedido> _pedidos;

        public AdaptadorPedidos(Context context, List<Pedido> pedidos)
        {
            _context = context;
            _pedidos = pedidos;
        }

        public override Pedido this[int position]
        {
            get { return _pedidos[position]; }
        }
            

        public override int Count 
        {
            get { return _pedidos.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.row_pedido, null, false);
            }

            TextView txtRowNumPedido = row.FindViewById<TextView>(Resource.Id.txtRowNumPedido);
            TextView txtRowDataPedido = row.FindViewById<TextView>(Resource.Id.txtRowDataPedido);
            TextView txtRowValorPedido = row.FindViewById<TextView>(Resource.Id.txtRowValorPedido);
            
            txtRowNumPedido.Text = _pedidos[position].Id.ToString();
            txtRowDataPedido.Text = _pedidos[position].Data.ToString("dd/MM/yyyy");
            txtRowValorPedido.Text =  String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", _pedidos[position].ValorTotal);

            return row;
        }
    }
}