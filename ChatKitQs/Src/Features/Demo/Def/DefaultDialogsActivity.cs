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

namespace ChatKitQs.Src.Features.Demo.Def
{
    [Activity(Theme = "@style/BlueTheme")]
    public class DefaultDialogsActivity : DemoDialogsActivity
    {
        private List<Dialog> dialogs;

        public static void Open(Context context)
        {
            context.StartActivity(new Intent(context, typeof(DefaultDialogsActivity)));
        }

        private DialogsList dialogsList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_default_dialogs);

            dialogsList = FindViewById<DialogsList>(Resource.Id.dialogsList);
            InitAdapter();
        }


        public void OnDialogClick(Dialog dialog)
        {
            DefaultMessagesActivity.Open(this);
        }

        private void InitAdapter()
        {
            base.dialogsAdapter = new DialogsListAdapter(base.imageLoader);
            base.dialogsAdapter.SetItems(DialogsFixtures.GetDialogs());

            base.dialogsAdapter.SetOnDialogLongClickListener(this);
            base.dialogsAdapter.SetOnDialogLongClickListener(this);

            dialogsList.SetAdapter(base.dialogsAdapter);
        }

        //for example
        private void OnNewMessage(string dialogId, ChatKitQs.Src.Common.Data.Models.Message message)
        {
            bool isUpdated = dialogsAdapter.UpdateDialogWithMessage(dialogId, message);
            if (!isUpdated)
            {
                //Dialog with this ID doesn't exist, so you can create new Dialog or update all dialogs list
            }
        }

        //for example
        private void OnNewDialog(Dialog dialog)
        {
            dialogsAdapter.AddItem(dialog);
        }
    }
}