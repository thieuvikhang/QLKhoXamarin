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
using Business;
using DataTransferObject;

namespace QLKHO.Android
{
    class DSHangHoaFragment:Fragment
    {
        ListView lvHangHoa;
        List<HangHoaObject> lstHH;
        private HangHoa_BUS _hhBUS = new HangHoa_BUS();
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.DSHangHoa, container, false);

            lvHangHoa = view.FindViewById<ListView>(Resource.Id.lvhanghoa);

            lstHH = _hhBUS.ListHangHoa();
            HHAdapter adapter = new HHAdapter(this.Activity, lstHH);
            lvHangHoa.Adapter = adapter;

            return view;
        }
    }
}