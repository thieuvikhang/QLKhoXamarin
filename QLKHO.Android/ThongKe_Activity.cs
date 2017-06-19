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

namespace QLKHO.Android
{
    [Activity(Label = "Thống kê")]
    public class ThongKe_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            TextView textview1 = new TextView(this);
            textview1.Text = "Đây là tab thống kê";
            SetContentView(textview1);
            // Create your application here
        }
    }
}