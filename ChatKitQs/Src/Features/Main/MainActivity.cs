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
using Android.Support.V7.App;
using ChatKitQs.Src.Features.Main.Adapter;
using Android.Support.V4.View;
using Me.Relex;
using ChatKitQs.Src.Features.Demo.Def;
using ChatKitQs.Src.Features.Demo.Styled;
using ChatKitQs.Src.Features.Demo.Custom.Layout;
using ChatKitQs.Src.Features.Demo.Custom.Holder;
using ChatKitQs.Src.Features.Demo.Custom.Media;

namespace ChatKitQs.Src.Features.Main
{
    [Activity(Theme = "@style/BlueTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, DemoCardFragment.OnActionListener
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            ViewPager pager = FindViewById<ViewPager>(Resource.Id.pager);
            pager.Adapter = new MainActivityPagerAdapter(this, SupportFragmentManager);
            pager.PageMargin = ((int)Resources.GetDimension(Resource.Dimension.card_padding) / 4);
            pager.OffscreenPageLimit = 3;

            CircleIndicator indicator = FindViewById<CircleIndicator>(Resource.Id.indicator);
            indicator.SetViewPager(pager);

        }
        public void OnAction(int id)
        {
            switch (id)
            {
                case MainActivityPagerAdapter.ID_DEFAULT:
                    DefaultDialogsActivity.Open(this);
                    break;
                case MainActivityPagerAdapter.ID_STYLED:
                    StyledDialogsActivity.Open(this);
                    break;
                case MainActivityPagerAdapter.ID_CUSTOM_LAYOUT:
                    CustomLayoutDialogsActivity.Open(this);
                    break;
                case MainActivityPagerAdapter.ID_CUSTOM_VIEW_HOLDER:
                    CustomHolderDialogsActivity.Open(this);
                    break;
                case MainActivityPagerAdapter.ID_CUSTOM_CONTENT:
                    CustomMediaMessagesActivity.Open(this);
                    break;
            }
        }
    }
}