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
using Business;

namespace QLKHO.Android
{
    class DS_Kho_Fragment : Fragment
    {
        ListView lvKho;
        List<KhoObject> dsKho;
        private Kho_BUS _khoBUS = new Kho_BUS();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.DSKho, container, false);

            lvKho = view.FindViewById<ListView>(Resource.Id.lvKho);

            dsKho = _khoBUS.dsKho();

            Kho_Adapter adapter = new Kho_Adapter(this.Activity, dsKho);
            lvKho.Adapter = adapter;

            return view;

        }

        
    }
}