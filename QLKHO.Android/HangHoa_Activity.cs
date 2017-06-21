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
namespace QLKHO.Android
{
    [Activity(Label = "HangHoa", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class HangHoaActivity : AppCompatActivity
    {
        MyAdapter adapter;
        PagerSlidingTabStrip tabs;
        ViewPager pager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HangHoa);
            adapter = new MyAdapter(SupportFragmentManager);
            pager = FindViewById<ViewPager>(Resource.Id.pager);
            tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);
            pager.Adapter = adapter;
            tabs.SetViewPager(pager);
            tabs.SetBackgroundColor(Color.Argb(255, 0, 149, 164));
        }
        public class MyAdapter : FragmentPagerAdapter
        {
            int tabCount = 2;
            public MyAdapter(SP4.FragmentManager fm) : base(fm)
            {

            }

            public override int Count
            {
                get
                {
                    return tabCount;
                }
            }

            public override ICharSequence GetPageTitleFormatted(int position)
            {
                ICharSequence cs;
                if (position == 0)
                    cs = new Java.Lang.String("Hàng hóa");
                else
                    cs = new Java.Lang.String("Chi tiết");
                return cs;
            }

            public override SP4.Fragment GetItem(int position)
            {
                return DSHangHoaFragment.NewInstance(position);
            }
        }
    }
}