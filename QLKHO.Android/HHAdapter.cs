using System.Collections.Generic;
using DataTransferObject;
using Android.App;
using Android.Views;
using Android.Widget;

namespace QLKHO.Android
{
    class HHAdapter : BaseAdapter
    {
        private Activity activity;
        private List<HangHoaObject> hh;
        private DSHangHoaFragment dSHangHoaFragment;
       

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
            return hh[position].idHH;
        }
        public HHAdapter(Activity activity, List<HangHoaObject> hh)
        {
            this.activity = activity;
            this.hh = hh;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.Row, parent, false);

            var txtMa = view.FindViewById<TextView>(Resource.Id.MaHH);
            var txtTen = view.FindViewById<TextView>(Resource.Id.TenHH);
            var txtMoTa = view.FindViewById<TextView>(Resource.Id.MoTa);
            var icon = view.FindViewById<ImageView>(Resource.Id.icon);

            txtMa.Text = hh[position].MaHangHoa.ToString();
            txtTen.Text = hh[position].TenHangHoa;
            txtMoTa.Text = hh[position].MoTa;
            icon.SetBackgroundResource(Resource.Drawable.Icon);
            return view;
        }
    }
}