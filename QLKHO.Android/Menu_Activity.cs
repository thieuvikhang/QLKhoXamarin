using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace QLKHO.Android
{
    [Activity(Label = "Menu")]
    public class MenuActivity : Activity
    {
        private TextView _txt1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            _txt1 = FindViewById<TextView>(Resource.Id.txt1);

            var it = Intent;
            var bundle = it.GetBundleExtra("data");
            _txt1.Text = bundle.GetString("TenNhanVien");
        }
    }
}