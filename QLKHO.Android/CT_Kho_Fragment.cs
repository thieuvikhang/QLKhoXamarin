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

namespace QLKHO.Android
{
    class CT_Kho_Fragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.CT_Kho, container, false);
            var tenKho = view.FindViewById<TextView>(Resource.Id.TenKho);
            tenKho.Text = "Hello??";
            return view;
        }
    }
}