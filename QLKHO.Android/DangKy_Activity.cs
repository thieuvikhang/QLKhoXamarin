
using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Business;
using DataTransferObject;
using Android.Content;

namespace QLKHO.Android
{
<<<<<<< HEAD
    [Activity(Label = "Đăng Ký")]
=======
    [Activity(Label = "Đăng Ký" /*,MainLauncher = true*/)]
>>>>>>> a65ef3976497add46214cb421aa723bf9dd70e08
    public class DangKyActivity : Activity
    {
        private readonly DangNhapBus _dangNhapBus = new DangNhapBus();
        private Button _btnDangKy, _dateSelectButton;
        private EditText _txtTen, _txtSdt, _txtDiaChi, _txtEmail, _txtTaiKhoan, _txtMatKhau;
        private RadioButton _rdNam, _rdNu, _rdBH, _rdQLBH, _rdQLK, _rdAdmin;
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
            _rdNu = FindViewById<RadioButton>(Resource.Id.rdNu);
            _rdBH = FindViewById<RadioButton>(Resource.Id.rdBH);
            _rdQLBH = FindViewById<RadioButton>(Resource.Id.rdQLBH);
            _rdQLK = FindViewById<RadioButton>(Resource.Id.rdQLK);
            _rdAdmin = FindViewById<RadioButton>(Resource.Id.rdAdmin);

            _btnDangKy = FindViewById<Button>(Resource.Id.btnDangKy);

            _btnDangKy.Click += BtnDangKy_Click;
            
            _dateSelectButton = FindViewById<Button>(Resource.Id.date_select_button);
            _dateSelectButton.Click += DateSelect_OnClick;

            // Create your application here
        }
        private void BtnDangKy_Click(object sender, EventArgs e)
        {
            int maChucVu = _rdBH.Checked ? 1 : _rdQLK.Checked ? 2 : _rdQLBH.Checked ? 3 : 4;
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
                Toast.MakeText(this, $"Đăng ký thất bại", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(DangKyActivity));
                StartActivity(intent);
            }
        }
        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _dateSelectButton.Text = time.ToString("dd-MM-yyyy");
                _ngaySinh = time.ToString("yyyy-MM-dd");
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}