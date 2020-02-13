using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VendaProduto.Classes;

namespace VendaProduto.Adapters
{
    class AdaptadorProdutosPedido : BaseAdapter<Produto>
    {
        private Context _context;
        private List<Produto> _produtos;

        public AdaptadorProdutosPedido(Context context, List<Produto> produto)
        {
            _context = context;
            _produtos = produto;
        }

        public override Produto this[int position]
        {
            get { return _produtos[position]; }
        }


        public override int Count
        {
            get { return _produtos.Count; }
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
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.row_produtosPedido, null, false);
            }

            TextView txtRowProdutoPedido = row.FindViewById<TextView>(Resource.Id.txtRowProdutoPedido);
            TextView txtRowPrecoUnitProdutoPedido = row.FindViewById<TextView>(Resource.Id.txtRowPrecoUnitProdutoPedido);

            txtRowProdutoPedido.Text = _produtos[position].NomeProduto;
            txtRowPrecoUnitProdutoPedido.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", _produtos[position].PrecoUnit);

            return row;
        }
    }
}