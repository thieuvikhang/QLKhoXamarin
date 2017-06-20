
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Business;

namespace QLKHO.Android
{
    [Activity(Label = "Đăng Nhập"/*, MainLauncher = true*/)]
    public class DangNhapActivity : Activity
    {
        private readonly DangNhapBus _dangNhapBus = new DangNhapBus();
        private EditText _edtUserName, _edtPassWord;
        private Button _btnDangNhap;
        private string _msg = "";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DangNhap);

            _edtUserName = FindViewById<EditText>(Resource.Id.edtUserName);
            _edtPassWord = FindViewById<EditText>(Resource.Id.edtPassWord);
            _btnDangNhap = FindViewById<Button>(Resource.Id.btnDangNhap);

            _btnDangNhap.Click += BtnDangNhap_Click;
        }

        private void BtnDangNhap_Click(object sender, System.EventArgs e)
        {
            var dn = _dangNhapBus.DangNhap(_edtUserName.Text.Trim(), _edtPassWord.Text.Trim());
            if(dn == null)
            {
                _msg = "Lỗi";
            }
            else
            {
                //Android.Content intent = new Android.Content.Intent(this, typeof(MainActivity));
                var intent = new Intent(this, typeof(MenuActivity));
                var bundle = new Bundle();

                bundle.PutString("TenNhanVien", dn.TenNhanVien);
                bundle.PutString("PhanQuyen", dn.MaPhanQuyen.ToString());
                bundle.PutString("UserName", dn.TaiKhoan);

                intent.PutExtra("data", bundle);
                StartActivity(intent);
                Clear();
                _msg = "Thành Công";
            }
            Toast.MakeText(this, _msg, ToastLength.Long).Show();
        }
        public void Clear()
        {
            _edtUserName.Text = "";
            _edtPassWord.Text = "";
        }
    }
}