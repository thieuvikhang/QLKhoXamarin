using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using System;

using System.Linq;

namespace QLKHO.Android
{
    [Activity(Label = "Menu")]
    public class MenuActivity : Activity
    {
        private TextView _txt1;
        GestureDetector gestureDetector;
        GestureListener gestureListener;

        ListView menuListView;
        MenuListAdapterClass objAdapterMenu;
        ImageView menuIconImageView;
        int intDisplayWidth;
        bool isSingleTapFired = false;
        TextView txtActionBarText;
        TextView txtPageName;
        TextView txtDescription;
        ImageView btnDescExpander;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.Main);

            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);
            FnInitialization();
            TapEvent();
            FnBindMenu();

            _txt1 = FindViewById<TextView>(Resource.Id.txt1);

            var it = Intent;
            var bundle = it.GetBundleExtra("data");
            _txt1.Text = bundle.GetString("TenNhanVien");
        }

        void TapEvent()
        {
            //title bar menu icon
            menuIconImageView.Click += delegate (object sender, EventArgs e)
            {
                if (!isSingleTapFired)
                {
                    FnToggleMenu();  //find definition in below steps
                    isSingleTapFired = false;
                }
            };
            //bottom expandable description window
            btnDescExpander.Click += delegate (object sender, EventArgs e)
            {
                FnDescriptionWindowToggle();
            };
        }

        void FnInitialization()
        {
            //gesture initialization
            gestureListener = new GestureListener();
            gestureListener.LeftEvent += GestureLeft; //find definition in below steps
            gestureListener.RightEvent += GestureRight;
            gestureListener.SingleTapEvent += SingleTap;
            gestureDetector = new GestureDetector(this, gestureListener);

            menuListView = FindViewById<ListView>(Resource.Id.menuListView);
            menuIconImageView = FindViewById<ImageView>(Resource.Id.menuIconImgView);
            txtActionBarText = FindViewById<TextView>(Resource.Id.txtActionBarText);
            txtPageName = FindViewById<TextView>(Resource.Id.txtPage);
            txtDescription = FindViewById<TextView>(Resource.Id.txtDescription);
            btnDescExpander = FindViewById<ImageView>(Resource.Id.btnImgExpander);

            //changed sliding menu width to 3/4 of screen width 
            Display display = this.WindowManager.DefaultDisplay;
            var point = new Point();
            display.GetSize(point);
            intDisplayWidth = point.X;
            intDisplayWidth = intDisplayWidth - (intDisplayWidth / 3);
            using (var layoutParams = (RelativeLayout.LayoutParams)menuListView.LayoutParameters)
            {
                layoutParams.Width = intDisplayWidth;
                layoutParams.Height = ViewGroup.LayoutParams.MatchParent;
                menuListView.LayoutParameters = layoutParams;
            }
        }

        void FnBindMenu()
        {
            string[] strMnuText = { GetString(Resource.String.ThongKe), GetString(Resource.String.TimKiem), GetString(Resource.String.HangHoa), GetString(Resource.String.Hello), GetString(Resource.String.Hello), GetString(Resource.String.Hello), GetString(Resource.String.Hello), GetString(Resource.String.Hello), GetString(Resource.String.Hello) };
            int[] strMnuUrl = { Resource.Drawable.ThongKe, Resource.Drawable.Search, Resource.Drawable.HangHoa, Resource.Drawable.Icon, Resource.Drawable.Icon, Resource.Drawable.Icon, Resource.Drawable.Icon, Resource.Drawable.Icon, Resource.Drawable.Icon };
            if (objAdapterMenu != null)
            {
                objAdapterMenu.actionMenuSelected -= FnMenuSelected;
                objAdapterMenu = null;
            }
            objAdapterMenu = new MenuListAdapterClass(this, strMnuText, strMnuUrl);
            objAdapterMenu.actionMenuSelected += FnMenuSelected;
            menuListView.Adapter = objAdapterMenu;
        }
        void FnMenuSelected(string strMenuText)
        {
            txtActionBarText.Text = strMenuText;
            txtPageName.Text = strMenuText;
            //selected action goes here
        }

        void GestureLeft()
        {
            if (!menuListView.IsShown)
                FnToggleMenu();
            isSingleTapFired = false;
        }
        void GestureRight()
        {
            if (menuListView.IsShown)
                FnToggleMenu();
            isSingleTapFired = false;
        }
        void SingleTap()
        {
            if (menuListView.IsShown)
            {
                FnToggleMenu();
                isSingleTapFired = true;
            }
            else
            {
                isSingleTapFired = false;
            }
        }
        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            gestureDetector.OnTouchEvent(ev);
            return base.DispatchTouchEvent(ev);
        }

        void FnToggleMenu()
        {
            Console.WriteLine(menuListView.IsShown);
            if (menuListView.IsShown)
            {
                menuListView.Animation = new TranslateAnimation(0f, -menuListView.MeasuredWidth, 0f, 0f);
                menuListView.Animation.Duration = 300;
                menuListView.Visibility = ViewStates.Gone;
            }
            else
            {
                menuListView.Visibility = ViewStates.Visible;
                menuListView.RequestFocus();
                menuListView.Animation = new TranslateAnimation(-menuListView.MeasuredWidth, 0f, 0f, 0f);//starting edge of layout 
                menuListView.Animation.Duration = 300;
            }
        }

        //bottom desription window sliding 
        void FnDescriptionWindowToggle()
        {
            if (txtDescription.IsShown)
            {
                txtDescription.Visibility = ViewStates.Gone;
                txtDescription.Animation = new TranslateAnimation(0f, 0f, 0f, txtDescription.MeasuredHeight);
                txtDescription.Animation.Duration = 300;
                btnDescExpander.SetImageResource(Resource.Drawable.Home);
            }
            else
            {
                txtDescription.Visibility = ViewStates.Visible;
                txtDescription.RequestFocus();
                txtDescription.Animation = new TranslateAnimation(0f, 0f, txtDescription.MeasuredHeight, 0f);
                txtDescription.Animation.Duration = 300;
                btnDescExpander.SetImageResource(Resource.Drawable.Home);
            }
        }

        //MenuListAdapterClass
        public class MenuListAdapterClass : BaseAdapter<string>
        {
            Activity _context;
            string[] _mnuText;
            int[] _mnuUrl;
            //action event to pass selected menu item to main activity
            internal event Action<string> actionMenuSelected;
            public MenuListAdapterClass(Activity context, string[] strMnu, int[] intImage)
            {
                _context = context;
                _mnuText = strMnu;
                _mnuUrl = intImage;
            }
            public override string this[int position]
            {
                get { return this._mnuText[position]; }
            }

            public override int Count
            {
                get { return this._mnuText.Count(); }
            }

            public override long GetItemId(int position)
            {
                return position;
            }
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                MenuListViewHolderClass objMenuListViewHolderClass;
                View view;
                view = convertView;
                if (view == null)
                {
                    view = _context.LayoutInflater.Inflate(Resource.Layout.MenuCustomLayout, parent, false);
                    objMenuListViewHolderClass = new MenuListViewHolderClass();

                    objMenuListViewHolderClass.txtMnuText = view.FindViewById<TextView>(Resource.Id.txtMnuText);
                    objMenuListViewHolderClass.ivMenuImg = view.FindViewById<ImageView>(Resource.Id.ivMenuImg);

                    objMenuListViewHolderClass.Initialize(view);
                    view.Tag = objMenuListViewHolderClass;
                }
                else
                {
                    objMenuListViewHolderClass = (MenuListViewHolderClass)view.Tag;
                }
                objMenuListViewHolderClass.viewClicked = () =>
                {
                    actionMenuSelected?.Invoke(_mnuText[position]);
                };
                objMenuListViewHolderClass.txtMnuText.Text = _mnuText[position];
                objMenuListViewHolderClass.ivMenuImg.SetImageResource(_mnuUrl[position]);
                return view;
            }
        }

        internal class MenuListViewHolderClass : Java.Lang.Object
        {
            internal Action viewClicked { get; set; }
            internal TextView txtMnuText;
            internal ImageView ivMenuImg;
            public void Initialize(View view)
            {
                view.Click += delegate
                {
                    viewClicked();
                };
            }

        }


    }
}