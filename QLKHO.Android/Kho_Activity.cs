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


namespace QLKHO.Android
{
    [Activity(Label = "Danh Sách Kho Hàng")]
    public class Kho_Activity : Activity
    {
        ListView lvKho;
        EditText tenKho, diaChi, nhanVien;
        List<KhoObject> listKho;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           

            SetContentView(Resource.Layout.Kho);

           

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            //adding audio tab
            AddTab("Kho", Resource.Drawable.Icon, new DS_Kho_Fragment());

            //adding video tab 
            AddTab("Chi Tiết", Resource.Drawable.Icon, new CT_Kho_Fragment());
            // Create your application here

            //lvKho.ItemClick += lvKho_Click;          

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

        private void lvKho_Click(object sender, AdapterView.ItemClickEventArgs e)
        {
            tenKho = FindViewById<EditText>(Resource.Id.TenKho);
            diaChi = FindViewById<EditText>(Resource.Id.DiaChiKho);
            nhanVien = FindViewById<EditText>(Resource.Id.NhanVien);
            lvKho = FindViewById<ListView>(Resource.Id.lvKho);

            Bundle bundle = new Bundle();
            tenKho.Text = listKho[e.Position].TenKho;
            diaChi.Text = listKho[e.Position].DiaChi;
            nhanVien.Text = (listKho[e.Position].MaNhanVien).ToString();   
        }

        

    }
}