using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;
using SP4 = Android.Support.V4.App;
using System.Data;
using Java.Lang;
using DataTransferObject;
using Business;

namespace QLKHO.Android
{
    class DSHangHoaFragment : Fragment
    {
        private int position;
        List<HangHoaObject> lstHangHoa;
        ListView lvHangHoa;
        private HangHoa_BUS _hhBUS = new HangHoa_BUS();
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            position = Arguments.GetInt("position");
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View root = inflater.Inflate(Resource.Layout.DSHangHoa, container, false);
            if (position == 0)
            {
                root = inflater.Inflate(Resource.Layout.DSHangHoa, container, false);
                lvHangHoa = root.FindViewById<ListView>(Resource.Id.lvhanghoa);

                lstHangHoa = _hhBUS.ListHangHoa();
                HHAdapter adapter = new HHAdapter(this, _hhBUS.ListHangHoa());
                lvHangHoa.Adapter = adapter;
                ViewCompat.SetElevation(root, 50);
                lvHangHoa.ItemClick += Lvbill_ItemClick;
            }
            else
            {
                root = null;
            }


            return root;
        }

        internal static DSHangHoaFragment NewInstance(int position)
        {
            var f = new DSHangHoaFragment();
            var b = new Bundle();
            b.PutInt("position", position);
            f.Arguments = b;
            return f;
        }

        private void Lvbill_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent it = new Intent();
            it.SetClass(Activity, typeof(CTHHActivity));
            Bundle bundle = new Bundle();
            bundle.PutString("IdHH", lstHangHoa[e.Position].IdHH.ToString());
            bundle.PutString("MaHangHoa", lstHangHoa[e.Position].MaHangHoa.ToString());
            bundle.PutString("TenHangHoa", lstHangHoa[e.Position].TenHangHoa);
            bundle.PutString("HinhAnh", lstHangHoa[e.Position].HinhAnh);
            bundle.PutString("GiaNhap", lstHangHoa[e.Position].GiaNhap.ToString());
            bundle.PutString("SoLuongTon", "" + lstHangHoa[e.Position].SoLuongTon.ToString());
            bundle.PutString("MoTa", "" + lstHangHoa[e.Position].MoTa.ToString());
            bundle.PutString("MaLoaiHang", "" + lstHangHoa[e.Position].MaHangHoa.ToString());
            bundle.PutString("MaNSX", "" + lstHangHoa[e.Position].MaNSX.ToString());

            it.PutExtra("data", bundle);
            StartActivity(it);
        }
    }
}