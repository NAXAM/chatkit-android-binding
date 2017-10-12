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
using Android.Support.V4.App;

namespace ChatKitQs.Src.Features.Main.Adapter
{
    class MainActivityPagerAdapter : FragmentStatePagerAdapter
    {
        public const int ID_DEFAULT = 0;
        public const int ID_STYLED = 1;
        public const int ID_CUSTOM_LAYOUT = 2;
        public const int ID_CUSTOM_VIEW_HOLDER = 3;
        public const int ID_CUSTOM_CONTENT = 4;

        private Context context;

        public MainActivityPagerAdapter(Context context, Android.Support.V4.App.FragmentManager fm) : base(fm)
        {
            this.context = context;
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            string title = null;
            string description = null;
            switch (position)
            {
                case ID_DEFAULT:
                    title = context.GetString(Resource.String.sample_title_default);
                    description = context.GetString(Resource.String.sample_subtitle_default);
                    break;
                case ID_STYLED:
                    title = context.GetString(Resource.String.sample_title_attrs);
                    description = context.GetString(Resource.String.sample_subtitle_attrs);
                    break;
                case ID_CUSTOM_LAYOUT:
                    title = context.GetString(Resource.String.sample_title_layout);
                    description = context.GetString(Resource.String.sample_subtitle_layout);
                    break;
                case ID_CUSTOM_VIEW_HOLDER:
                    title = context.GetString(Resource.String.sample_title_holder);
                    description = context.GetString(Resource.String.sample_subtitle_holder);
                    break;
                case ID_CUSTOM_CONTENT:
                    title = context.GetString(Resource.String.sample_title_custom_content);
                    description = context.GetString(Resource.String.sample_subtitle_custom_content);
                    break;
            }
            return DemoCardFragment.NewInstance(position, title, description);
        }
        public override int Count => 5;
    }
}