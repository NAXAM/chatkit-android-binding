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
using Com.Stfalcon.Chatkit.Utils;
using Java.Util;
using Com.Stfalcon.Chatkit.Dialogs;
using ChatKitQs.Src.Common.Data.Fixtures;

namespace ChatKitQs.Src.Features.Demo.Styled
{
    [Activity(Theme = "@style/BlueTheme")]
    public class StyledDialogsActivity : DemoDialogsActivity, DateFormatter.IFormatter
    {
        public static void Open(Context context)
        {
            context.StartActivity(new Intent(context, typeof(StyledDialogsActivity)));
        }

        private DialogsList dialogsList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_styled_dialogs);

            dialogsList = FindViewById<DialogsList>(Resource.Id.dialogsList);
            InitAdapter();
        }


        public override void OnDialogClick(Java.Lang.Object dialog)
        {
            StyledMessagesActivity.Open(this);
        }


        public string Format(Date date)
        {
            if (DateFormatter.IsToday(date))
            {
                return DateFormatter.Format(date, DateFormatter.Template.Time);
            }
            else if (DateFormatter.IsYesterday(date))
            {
                return GetString(Resource.String.date_header_yesterday);
            }
            else if (DateFormatter.IsCurrentYear(date))
            {
                return DateFormatter.Format(date, DateFormatter.Template.StringDayMonth);
            }
            else
            {
                return DateFormatter.Format(date, DateFormatter.Template.StringDayMonthYear);
            }
        }

        private void InitAdapter()
        {
            base.dialogsAdapter = new DialogsListAdapter(base.imageLoader);
            base.dialogsAdapter.SetItems(DialogsFixtures.GetDialogs());

            base.dialogsAdapter.SetOnDialogLongClickListener(this);
            base.dialogsAdapter.OnDialogClickListener = this;
            base.dialogsAdapter.SetDatesFormatter(this);
            base.dialogsAdapter.ImageLoader = base.imageLoader;
            dialogsList.SetAdapter(base.dialogsAdapter);
        }
    }
}