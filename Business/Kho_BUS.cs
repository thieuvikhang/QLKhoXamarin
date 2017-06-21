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
using DataTransferObject;
using DataAccess;

namespace Business
{
    public class Kho_BUS
    {
        private readonly Kho_DAL _khoDal = new Kho_DAL();
        public List<KhoObject> dsKho()
        {
            return _khoDal.danhSachKho();
        }
    }
}