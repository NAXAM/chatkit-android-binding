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
using Com.Stfalcon.Chatkit.Dialogs;
using ChatKitQs.Src.Common.Data.Fixtures;
using Java.Lang;

namespace ChatKitQs.Src.Features.Demo.Custom.Layout
{
    [Activity(Theme = "@style/BlueTheme")]
    public class CustomLayoutDialogsActivity : DemoDialogsActivity
    {
        public static void Open(Context context)
        {
            context.StartActivity(new Intent(context, typeof(CustomLayoutDialogsActivity)));
        }

        private DialogsList dialogsList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_custom_layout_dialogs);

            dialogsList = FindViewById<DialogsList>(Resource.Id.dialogsList);
            InitAdapter();
        }

        public override void OnDialogClick(Java.Lang.Object p0)
        {
            CustomLayoutMessagesActivity.Open(this);
        }

        private void InitAdapter()
        {
            base.dialogsAdapter = new DialogsListAdapter(Resource.Layout.item_custom_dialog, base.imageLoader);
            base.dialogsAdapter.SetItems(DialogsFixtures.GetDialogs());

            base.dialogsAdapter.SetOnDialogLongClickListener(this);
            base.dialogsAdapter.OnDialogClickListener = this;
            base.dialogsAdapter.ImageLoader = base.imageLoader;
            dialogsList.SetAdapter(base.dialogsAdapter);
        }
    }
}