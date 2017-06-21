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
using DataTransferObject;

namespace QLKHO.Android
{
    class Kho_Adapter:BaseAdapter
    {
        private Activity activity;
        private List<KhoObject> kho;
        private DS_Kho_Fragment dsKhoFrament;

        public override int Count
        {
            get
            {
                return kho.Count;
            }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return kho[position].item;
        }
        public Kho_Adapter(Activity activity, List<KhoObject> kho)
        {
            this.activity = activity;
            this.kho = kho;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.Row_Kho, parent,false);

            var txtMaKho = view.FindViewById<TextView>(Resource.Id.MaKho);
            var txtTenKho = view.FindViewById<TextView>(Resource.Id.TenKho);
            var txtDiaChiKho = view.FindViewById<TextView>(Resource.Id.DiaChiKho);
            var hinhanh = view.FindViewById<ImageView>(Resource.Id.icon);

            txtMaKho.Text = kho[position].MaKho.ToString();
            txtTenKho.Text = kho[position].TenKho;
            txtDiaChiKho.Text = kho[position].DiaChi;
            hinhanh.SetBackgroundResource(Resource.Drawable.HangHoa);
            return view;
        }
    }
}