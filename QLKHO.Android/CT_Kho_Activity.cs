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
    [Activity(Label = "CT_Kho_Activity")]
    public class CT_Kho_Activity : Activity
    {
        private readonly Kho_BUS _khoBus = new Kho_BUS();
        EditText tenkho, diachi, nhanvien;
        Button btnthem, btnxoa, btnsua, btnclear;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CT_Kho);

            Bundle bundle = new Bundle();
            Intent it = Intent;

            bundle = it.GetBundleExtra("dataKho");

            tenkho = FindViewById<EditText>(Resource.Id.TenKho);
            diachi = FindViewById<EditText>(Resource.Id.DiaChiKho);
            nhanvien = FindViewById<EditText>(Resource.Id.NhanVien);

            btnthem = FindViewById<Button>(Resource.Id.save);
            btnxoa = FindViewById<Button>(Resource.Id.del);
            btnsua = FindViewById<Button>(Resource.Id.update);
            btnclear = FindViewById<Button>(Resource.Id.clear);

            //Bắt sự kiện click button....
            btnthem.Click += btnThem_Click;
            btnclear.Click += btnClear_Click;

            //Lấy text từ gói Bundle ra......
            tenkho.Text = bundle.GetString("tenkho");
            diachi.Text = bundle.GetString("diachi");
            nhanvien.Text = bundle.GetString("nhanvien");

            //Muốn viết thêm gì nữa thì viết vô đây....
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var k = new KhoObject
            {
                TenKho = tenkho.Text,
                DiaChi = diachi.Text,
                MaNhanVien = int.Parse(nhanvien.Text)
            };
            string msg = "";
            if (tenkho.Text.Trim() == "" || diachi.Text.Trim() == "" || nhanvien.Text.Trim() == "")
            {
                msg = "Các dòng phải được nhập";
                Toast.MakeText(this, msg, ToastLength.Long).Show();
            }
            else
            {
                if(_khoBus.themKho(k))
                {
                    msg = "Thêm thành công";
                }
                else
                {
                    msg = "Thất bại rồi em ơi";
                }
                Toast.MakeText(this, msg, ToastLength.Long).Show();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tenkho.Text = "";
            diachi.Text = "";
            nhanvien.Text = "";
        }
    }
}