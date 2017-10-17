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

namespace ChatKitQs.Src.Features.Demo.Custom.Layout
{
    [Activity(Theme = "@style/BlueTheme")]
    public class CustomLayoutMessagesActivity : DemoMessagesActivity,
        MessagesListAdapter.IOnMessageLongClickListener,
        MessagesListAdapter.IOnMessageClickListener,
        MessageInputControl.IInputListener,
        MessageInputControl.IAttachmentsListener
    {
        public static void Open(Context context)
        {
            context.StartActivity(new Intent(context, typeof(CustomLayoutMessagesActivity)));
        }

        private MessagesList messagesList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_custom_layout_messages);

            messagesList = FindViewById<MessagesList>(Resource.Id.messagesList);
            InitAdapter();

            MessageInputControl input = FindViewById<MessageInputControl>(Resource.Id.input);
            input.SetInputListener(this);
            input.SetAttachmentsListener(this);
        }


        public bool OnSubmit(ICharSequence input)
        {
            messagesAdapter.AddToStart(
                    MessagesFixtures.GetTextMessage(input.ToString()), true);
            return true;
        }


        public void OnAddAttachments()
        {
            messagesAdapter.AddToStart(MessagesFixtures.GetImageMessage(), true);
        }



        public void OnMessageLongClick(Java.Lang.Object p0)
        {
            AppUtils.ShowToast(this, Resource.String.on_log_click_message, false);
        }


        private void InitAdapter()
        {
            MessageHolders holdersConfig = new MessageHolders()
                    .SetIncomingTextLayout(Resource.Layout.item_custom_incoming_text_message)
                    .SetOutcomingTextLayout(Resource.Layout.item_custom_outcoming_text_message)
                    .SetIncomingImageLayout(Resource.Layout.item_custom_incoming_image_message)
                    .SetOutcomingImageLayout(Resource.Layout.item_custom_outcoming_image_message);

            base.messagesAdapter = new MessagesListAdapter(base.senderId, holdersConfig, base.imageLoader);
            base.messagesAdapter.SetOnMessageLongClickListener(this);
            base.messagesAdapter.SetOnMessageClickListener(this);
            base.messagesAdapter.SetLoadMoreListener(this);
            messagesList.SetAdapter(base.messagesAdapter);
        }

        public void OnMessageClick(Java.Lang.Object p0)
        {

        }
    }
}