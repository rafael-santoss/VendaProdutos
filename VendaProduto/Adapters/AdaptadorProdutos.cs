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
    class AdaptadorProdutos : BaseAdapter<Produto>
    {
        private Context _context;
        private List<Produto> _produtos;

        public AdaptadorProdutos(Context context, List<Produto> produto)
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
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.row_produto, null, false);
            }

            TextView txtRowProduto = row.FindViewById<TextView>(Resource.Id.txtRowProduto);
            TextView txtRowPrecoUnit = row.FindViewById<TextView>(Resource.Id.txtRowPrecoUnit);
            TextView txtRowQtdEstoque = row.FindViewById<TextView>(Resource.Id.txtRowQtdEstoque);

            txtRowProduto.Text = _produtos[position].NomeProduto;
            txtRowPrecoUnit.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", _produtos[position].PrecoUnit);
            txtRowQtdEstoque.Text = _produtos[position].QtdEstocada.ToString();

            return row;
        }
    }
}