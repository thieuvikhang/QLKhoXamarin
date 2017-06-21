using System.Collections.Generic;
using DataTransferObject;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Content;
using Square.Picasso;

namespace QLKHO.Android
{
    class HHAdapter : BaseAdapter
    {
        private DSHangHoaFragment activity;
        private List<HangHoaObject> hh;

        public override int Count
        {
            get
            {
                return hh.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return hh[position].IdHH;
        }

        public HHAdapter(DSHangHoaFragment activity, List<HangHoaObject> hh)
        {
            this.activity = activity;
            this.hh = hh;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
            var view = inflater.Inflate(Resource.Layout.Row, parent, false);

            var txtGiaNhap = view.FindViewById<TextView>(Resource.Id.GiaNhap);
            var txtTen = view.FindViewById<TextView>(Resource.Id.TenHH);
            var txtMoTa = view.FindViewById<TextView>(Resource.Id.MoTa);
            var icon = view.FindViewById<ImageView>(Resource.Id.icon);
            string ct = hh[position].HinhAnh;

            Picasso.With(Application.Context).Load(ct).Into(icon);
            txtGiaNhap.Text = string.Format("{0:c0}", hh[position].GiaNhap);
            txtTen.Text = hh[position].TenHangHoa;
            txtMoTa.Text = hh[position].MoTa;
            return view;
        }


    }
}