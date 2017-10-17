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
using Java.Lang;
using ChatKitQs.Src.Common.Data.Fixtures;
using ChatKitQs.Src.Utils;
using ChatKitQs.Src.Common.Data.Models;
using static Com.Stfalcon.Chatkit.Messages.MessageHolders;

namespace ChatKitQs.Src.Features.Demo.Def
{
    [Activity(Theme = "@style/BlueTheme")]
    public class DefaultMessagesActivity : DemoMessagesActivity,
        MessageInputControl.IInputListener,
        MessageInputControl.IAttachmentsListener
    {
        public static void Open(Context context)
        {
            context.StartActivity(new Intent(context, typeof(DefaultMessagesActivity)));
        }

        private MessagesList messagesList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_default_messages);

            this.messagesList = FindViewById<MessagesList>(Resource.Id.messagesList);
            InitAdapter();

            MessageInputControl input = FindViewById<MessageInputControl>(Resource.Id.input);
            input.SetInputListener(this);
        }


        public bool OnSubmit(ICharSequence input)
        {
            base.messagesAdapter.AddToStart(
                    MessagesFixtures.GetTextMessage(input.ToString()), true);
            return true;
        }


        public void OnAddAttachments()
        {
            base.messagesAdapter.AddToStart(
                    MessagesFixtures.GetImageMessage(), true);
        }

        private void InitAdapter()
        {
            base.messagesAdapter = new MessagesListAdapter(base.senderId, base.imageLoader);
            base.messagesAdapter.EnableSelectionMode(this);
            base.messagesAdapter.SetLoadMoreListener(this);
            
            base.messagesAdapter.RegisterViewClickListener(Resource.Id.messageUserAvatar, new OnMessageViewClickListener()
            {
                MessageViewClickCommand = (view, message) =>
                {
                    AppUtils.ShowToast(this, message.User.Name + " avatar click", false);
                }
            });

            this.messagesList.SetAdapter(base.messagesAdapter);
        }
        class OnMessageViewClickListener : Java.Lang.Object, MessagesListAdapter.IOnMessageViewClickListener
        {
            public Action<View, ChatKitQs.Src.Common.Data.Models.Message> MessageViewClickCommand { get; set; }
            public void OnMessageViewClick(View p0, Java.Lang.Object p1)
            {
                MessageViewClickCommand?.Invoke(p0, (ChatKitQs.Src.Common.Data.Models.Message)p1);
            }
        }
    }
}