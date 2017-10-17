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
using Com.Stfalcon.Chatkit.Messages;
using Com.Stfalcon.Chatkit.Utils;
using Java.Lang;
using Java.Util;
using ChatKitQs.Src.Common.Data.Fixtures;
using Com.Stfalcon.Chatkit.Messages;

namespace ChatKitQs.Src.Features.Demo.Styled
{
    [Activity(Theme = "@style/BlueTheme")]
    public class StyledMessagesActivity : DemoMessagesActivity,
        MessageInput.IInputListener,
        MessageInput.IAttachmentsListener,
        DateFormatter.IFormatter
    {
        public static void Open(Context context)
        {
            context.StartActivity(new Intent(context, typeof(StyledMessagesActivity)));
        }

        private MessagesList messagesList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_styled_messages);

            messagesList = FindViewById<MessagesList>(Resource.Id.messagesList);
            InitAdapter();

            MessageInput input = FindViewById<MessageInput>(Resource.Id.input);
            input.SetInputListener(this);
            input.SetAttachmentsListener(this);
        }

        public bool OnSubmit(ICharSequence p0)
        {
            messagesAdapter.AddToStart(
                MessagesFixtures.GetTextMessage(p0.ToString()), true);
            return true;
        }
        public void OnAddAttachments()
        {
            messagesAdapter.AddToStart(MessagesFixtures.GetImageMessage(), true);
        }
        public string Format(Date p0)
        {
            if (DateFormatter.IsToday(p0))
            {
                return GetString(Resource.String.date_header_today);
            }
            else if (DateFormatter.IsYesterday(p0))
            {
                return GetString(Resource.String.date_header_yesterday);
            }
            else
            {
                return DateFormatter.Format(p0, DateFormatter.Template.StringDayMonthYear);
            }
        }
        private void InitAdapter()
        {
            base.messagesAdapter = new MessagesListAdapter(base.senderId, base.imageLoader);
            base.messagesAdapter.EnableSelectionMode(this);
            base.messagesAdapter.SetLoadMoreListener(this);
            base.messagesAdapter.SetDateHeadersFormatter(this);
            messagesList.SetAdapter(base.messagesAdapter);
        }

    }
}