
using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Business;
using DataTransferObject;

namespace QLKHO.Android
{
    [Activity(Label = "Đăng Ký", MainLauncher = true)]
    public class DangKyActivity : Activity
    {
        private readonly DangNhapBus _dangNhapBus = new DangNhapBus();
        private Button _btnDangKy;
        private EditText _txtTen, _txtSdt, _txtDiaChi, _txtEmail, _txtNgaySinh, _txtTaiKhoan, _txtMatKhau;
        private RadioButton _rdNam, _rdNu;
        private Spinner _spinner;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DangKy);

            _txtTen = FindViewById<EditText>(Resource.Id.txtTen);
            _txtSdt = FindViewById<EditText>(Resource.Id.txtSDT);
            _txtDiaChi = FindViewById<EditText>(Resource.Id.txtDiaChi);
            _txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            _txtNgaySinh = FindViewById<EditText>(Resource.Id.txtNgaySinh);
            _txtTaiKhoan = FindViewById<EditText>(Resource.Id.txtTaiKhoan);
            _txtMatKhau = FindViewById<EditText>(Resource.Id.txtMatKhau);

            _rdNam = FindViewById<RadioButton>(Resource.Id.rdNam);
            _rdNu = FindViewById<RadioButton>(Resource.Id.rdNu);

            _spinner = FindViewById<Spinner>(Resource.Id.spiner1);

            _btnDangKy = FindViewById<Button>(Resource.Id.btnDangKy);

            _btnDangKy.Click += BtnDangKy_Click;

            // Create your application here
        }
        private void BtnDangKy_Click(object sender, EventArgs e)
        {
            int maChucVu;
            var sp = "Quản trị viên";
            switch (sp)
            {
                case "Quản lý kho":
                    maChucVu = 2;
                    break;
                case "Quản lý bán hàng":
                    maChucVu = 3;
                    break;
                case "Quản trị viên":
                    maChucVu = 4;
                    break;
                default:
                    maChucVu = 1;
                    break;
            }
            var nhanVien = new NhanVienObject
            {
                TenNhanVien = _txtTen.Text,
                DiaChi = _txtDiaChi.Text,
                DienThoai = _txtSdt.Text,
                Email = _txtEmail.Text,
                GioiTinh = _rdNam.Checked ? 1 : 0,
                MaPhanQuyen = maChucVu,
                TaiKhoan = _txtTaiKhoan.Text,
                MatKhau = _txtMatKhau.Text,
                NgaySinh = DateTime.Now.ToString("yyyy-MM-dd")
            };
            _dangNhapBus.DangKy(nhanVien);
            Toast.MakeText(this, $"Đăng ký thành công {nhanVien.TenNhanVien}", ToastLength.Long).Show();
        }
    }
}