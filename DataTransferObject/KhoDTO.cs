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

namespace DataTransferObject
{
    public class KhoObject
    {
        public int item { get; set; }
        public int MaKho { get; set; }
        public string TenKho { get; set; }
        public string DiaChi { get; set; }
        public int MaNhanVien { get; set; }
    }
}