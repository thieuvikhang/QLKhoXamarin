using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace QLKHO.Android
{
    class CTHHFragment:Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.ChiTietHH, container, false);
            var sampleTextView = view.FindViewById<TextView>(Resource.Id.name);
            sampleTextView.Text = "This is CT Fragment Sample";
            return view;
        }
    }
}