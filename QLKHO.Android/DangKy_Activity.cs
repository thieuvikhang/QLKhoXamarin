
using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Business;
using DataTransferObject;
using Android.Content;

namespace QLKHO.Android
{
    [Activity(Label = "Đăng Ký", MainLauncher = true)]
    public class DangKyActivity : Activity
    {
        private readonly DangNhapBus _dangNhapBus = new DangNhapBus();
        private Button _btnDangKy, _dateSelectButton;
        private EditText _txtTen, _txtSdt, _txtDiaChi, _txtEmail, _txtTaiKhoan, _txtMatKhau;
        private RadioButton _rdNam, _rdBh, _rdQlbh, _rdQlk;
        private string _ngaySinh;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DangKy);

            _txtTen = FindViewById<EditText>(Resource.Id.txtTen);
            _txtSdt = FindViewById<EditText>(Resource.Id.txtSDT);
            _txtDiaChi = FindViewById<EditText>(Resource.Id.txtDiaChi);
            _txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            _txtTaiKhoan = FindViewById<EditText>(Resource.Id.txtTaiKhoan);
            _txtMatKhau = FindViewById<EditText>(Resource.Id.txtMatKhau);

            _rdNam = FindViewById<RadioButton>(Resource.Id.rdNam);
            _rdBh = FindViewById<RadioButton>(Resource.Id.rdBH);
            _rdQlbh = FindViewById<RadioButton>(Resource.Id.rdQLBH);
            _rdQlk = FindViewById<RadioButton>(Resource.Id.rdQLK);

            _btnDangKy = FindViewById<Button>(Resource.Id.btnDangKy);
            _dateSelectButton = FindViewById<Button>(Resource.Id.date_select_button);

            _btnDangKy.Click += BtnDangKy_Click;
            _dateSelectButton.Click += DateSelect_OnClick;
            // Create your application here
        }
        private void BtnDangKy_Click(object sender, EventArgs e)
        {
            var maChucVu = _rdBh.Checked ? 1 : _rdQlk.Checked ? 2 : _rdQlbh.Checked ? 3 : 4;
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
                NgaySinh = _ngaySinh
            };            
            if(_dangNhapBus.DangKy(nhanVien))
            {
                Toast.MakeText(this, $"Đăng ký thành công {nhanVien.TenNhanVien}", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(DangNhapActivity));
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "Đăng ký thất bại", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(DangKyActivity));
                StartActivity(intent);
            }
        }
        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            var frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _dateSelectButton.Text = time.ToString("dd-MM-yyyy");
                _ngaySinh = time.ToString("yyyy-MM-dd");
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}