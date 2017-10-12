using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Java.Lang;

namespace ChatKitQs.Src.Features.Main.Adapter
{
    public class DemoCardFragment : Fragment, View.IOnClickListener
    {
        private static string ARG_ID = "id";
        private static string ARG_TITLE = "title";
        private static string ARG_DESCRIPTION = "description";

        private int id;
        private string title, description;
        private OnActionListener actionListener;

        public DemoCardFragment()
        {

        }

        public static DemoCardFragment NewInstance(int id, string title, string description)
        {
            DemoCardFragment fragment = new DemoCardFragment();
            Bundle args = new Bundle();
            args.PutInt(ARG_ID, id);
            args.PutString(ARG_TITLE, title);
            args.PutString(ARG_DESCRIPTION, description);
            fragment.Arguments = args;
            return fragment;
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (Arguments != null)
            {
                this.id = Arguments.GetInt(ARG_ID);
                this.title = Arguments.GetString(ARG_TITLE);
                this.description = Arguments.GetString(ARG_DESCRIPTION);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.fragment_demo_card, container, false);

            TextView tvTitle = v.FindViewById<TextView>(Resource.Id.tvTitle);
            TextView tvDescription = v.FindViewById<TextView>(Resource.Id.tvDescription);
            Button button = v.FindViewById<Button>(Resource.Id.button);

            tvTitle.Text = title;
            tvDescription.Text = description;
            button.SetOnClickListener(this);

            return v;
        }


        public void OnClick(View view)
        {
            switch (view.Id)
            {
                case Resource.Id.button:
                    OnAction();
                    break;
            }
        }

        public void OnAction()
        {
            if (actionListener != null)
            {
                actionListener.OnAction(this.id);
            }
        }


        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            if (context is OnActionListener)
            {
                actionListener = (OnActionListener)context;
            }
            else
            {
                throw new RuntimeException(context.ToString()
                        + " must implement OnActionListener");
            }
        }


        public override void OnDetach()
        {
            base.OnDetach();
            actionListener = null;
        }

        public interface OnActionListener
        {
            void OnAction(int id);
        }
    }
}