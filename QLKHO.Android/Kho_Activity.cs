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
using static QLKHO.Android.MenuActivity;
using Android.Views.Animations;
using Android.Graphics;
using DataTransferObject;
using Business;


namespace QLKHO.Android
{
    [Activity(Label = "Danh Sách Kho Hàng")]
    public class Kho_Activity : Activity
    {
        ListView lvKho;
        EditText tenKho, diaChi, nhanVien;
        List<KhoObject> listKho = new List<KhoObject>();
        private readonly Kho_BUS _khoBus = new Kho_BUS();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);         

            SetContentView(Resource.Layout.DSKho);

            lvKho = FindViewById<ListView>(Resource.Id.lvKho);

            listKho = _khoBus.dsKho();

            Kho_Adapter adapter = new Kho_Adapter(this, listKho);
            lvKho.Adapter = adapter;

            //this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            //adding audio tab
            //AddTab("Kho", Resource.Drawable.Icon, new DS_Kho_Fragment());

            ////adding video tab 
            //AddTab("Chi Tiết", Resource.Drawable.Icon, new CT_Kho_Fragment());
            // Create your application here
            //lvKho = FindViewById<ListView>(Resource.Id.lvKho);
            //lvKho = FindViewById<ListView>(Resource.Id.lvKho);

            //var dskho = _khoBus.dsKho();
            //Kho_Adapter adapter = new Kho_Adapter(this, dskho);
            //lvKho.Adapter = adapter;

            lvKho.ItemClick += lvKho_ItemClick;



        }

        void AddTab(string tabText, int iconResourceId, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            // must set event handler for replacing tabs tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Replace(Resource.Id.fragmentContainerKho, fragment);
            };
            this.ActionBar.AddTab(tab);
        }

        private void lvKho_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //tenKho = FindViewById<EditText>(Resource.Id.TenKho);
            //diaChi = FindViewById<EditText>(Resource.Id.DiaChiKho);
            //  nhanVien = FindViewById<EditText>(Resource.Id.NhanVien);
            //    lvKho = FindViewById<ListView>(Resource.Id.lvKho);

            //Intent intent = new Intent(this, typeof(ThongKe_Activity));
            //Bundle bundle = new Bundle();

            //bundle.PutString("tenkho", listKho[e.Position].TenKho);
            //bundle.PutString("diachi", listKho[e.Position].DiaChi);
            //intent.PutExtra("datalist", bundle);

            //StartActivity(intent);


            Intent it = new Intent(this, typeof(CT_Kho_Activity));
            Bundle bundle = new Bundle();
            bundle.PutString("tenkho", listKho[e.Position].TenKho);
            bundle.PutString("diachi", listKho[e.Position].DiaChi);
            bundle.PutString("nhanvien", listKho[e.Position].DiaChi);
            it.PutExtra("dataKho", bundle);
            StartActivity(it);
            //var item = this.lvKho.GetItemAtPosition(e.Position);

            //Make a toast with the item name just to show it was clicked
            Toast.MakeText(this, "" + " Clicked!", ToastLength.Short).Show();

        }
        


    }
}