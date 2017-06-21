using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Graphics;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using System.Data;
using Android.Support.V4.App;
using SP4 = Android.Support.V4.App;
using Android.Support.V7.App;
using Java.Lang;
using com.refractored;
using Android.Support.V4.View;
using Android.App;
using Android.Widget;
using Square.Picasso;

namespace QLKHO.Android
{
    [Activity(Label = "Chi tiết", Theme = "@style/Theme.AppCompat.Light")]
    public class CTHHActivity : AppCompatActivity
    {
        TextView edtMaHH, edtGiaNhap, edtTenHang, edtSoluong, edtMoTa, edtTenLoai, edtTenNSX;
        ImageView imgIcon;
        string hinh;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ChiTietHH);

            edtMaHH = FindViewById<TextView>(Resource.Id.txtMaHH);
            edtGiaNhap = FindViewById<TextView>(Resource.Id.txtGiaNhap);
            imgIcon = FindViewById<ImageView>(Resource.Id.icon);
            edtTenHang = FindViewById<TextView>(Resource.Id.txtTenHang);
            edtSoluong = FindViewById<TextView>(Resource.Id.txtSoluong);
            edtMoTa = FindViewById<TextView>(Resource.Id.txtMoTa);
            edtTenLoai = FindViewById<TextView>(Resource.Id.txtTenLoai);
            edtTenNSX = FindViewById<TextView>(Resource.Id.txtTenNSX);

            Intent it = Intent;
            Bundle bundle = it.GetBundleExtra("data");
            if (bundle != null)
            {
                edtMaHH.Text = bundle.GetString("IdHH");
                edtGiaNhap.Text = bundle.GetString("MaHangHoa");
                edtTenHang.Text = bundle.GetString("TenHangHoa");
                hinh = bundle.GetString("HinhAnh");
                edtMoTa.Text = bundle.GetString("GiaNhap");
                edtTenLoai.Text = bundle.GetString("SoLuongTon");
                edtTenNSX.Text = bundle.GetString("MoTa");
                Picasso.With(Application.Context).Load(hinh).Into(imgIcon);
            }
        }
    }
}