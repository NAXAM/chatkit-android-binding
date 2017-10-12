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
using ChatKitQs.Src.Features.Demo.Custom.Holder.Holders.Dialogs;
using ChatKitQs.Src.Common.Data.Fixtures;

namespace ChatKitQs.Src.Features.Demo.Custom.Holder
{
    [Activity(Theme = "@style/BlueTheme")]
    public class CustomHolderDialogsActivity : DemoDialogsActivity
    {
        public static void Open(Context context)
        {
            context.StartActivity(new Intent(context, typeof(CustomHolderDialogsActivity)));
        }

        private DialogsList dialogsList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_custom_holder_dialogs);

            dialogsList = FindViewById<DialogsList>(Resource.Id.dialogsList);
            InitAdapter();
        }


        public void onDialogClick(Dialog dialog)
        {
            CustomHolderMessagesActivity.Open(this);
        }

        private void InitAdapter()
        {
            base.dialogsAdapter = new DialogsListAdapter(Resource.Layout.item_custom_dialog_view_holder, Java.Lang.Class.FromType(typeof(CustomDialogViewHolder)), base.imageLoader);

            base.dialogsAdapter.SetItems(DialogsFixtures.GetDialogs());

            base.dialogsAdapter.SetOnDialogLongClickListener(this);
            base.dialogsAdapter.SetOnDialogLongClickListener(this);

            dialogsList.SetAdapter(base.dialogsAdapter);
        }
    }
}