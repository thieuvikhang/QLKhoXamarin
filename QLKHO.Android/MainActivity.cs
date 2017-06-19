using Android.App;
using Android.Widget;
using Android.OS;

namespace QLKHO.Android
{
    [Activity(Label = "Quản Lý Kho")]
    public class MainActivity : Activity
    {

        EditText txt1;
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);


            //txt1 = FindViewById<EditText>(Resource.Id.txt1);
            //Intent it = new Intent();
            ////Bundle bundle = new Bundle(); 
            //    bundle = it.GetBundleExtra("data");
            //txt1.Text = bundle.GetString("user");
            //// Set our view from the "main" layout resource
            //// SetContentView (Resource.Layout.Main);
        }
    }
}

