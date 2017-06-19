
using Android.App;
using Android.OS;

namespace QLKHO.Android
{
    [Activity(Label = "HangHoa", MainLauncher = true, Icon = "@drawable/icon")]
    public class HangHoa : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.HangHoa);
            
            // Create your application here
            //enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            //adding audio tab
            AddTab("Hàng hóa", Resource.Drawable.Icon, new DSHangHoaFragment());

            //adding video tab 
            AddTab("Video", Resource.Drawable.Icon, new CTHHFragment());
        }
        void AddTab(string tabText, int iconResourceId, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            // must set event handler for replacing tabs tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, fragment);
            };

            this.ActionBar.AddTab(tab);
        }
    }
}