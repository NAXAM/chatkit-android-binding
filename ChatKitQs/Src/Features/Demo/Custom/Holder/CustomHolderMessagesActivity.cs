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
using ChatKitQs.Src.Common.Data.Fixtures;
using Java.Lang;
using ChatKitQs.Src.Utils;
using ChatKitQs.Src.Features.Demo.Custom.Holder.Holders.Messages;

namespace ChatKitQs.Src.Features.Demo.Custom.Holder
{
    [Activity(Theme = "@style/BlueTheme")]
    public class CustomHolderMessagesActivity : DemoMessagesActivity,
        MessagesListAdapter.IOnMessageLongClickListener,
        MessageInputControl.IInputListener,
        MessageInputControl.IAttachmentsListener
    {
        public static void Open(Context context)
        {
            context.StartActivity(new Intent(context, typeof(CustomHolderMessagesActivity)));
        }

        private MessagesList messagesList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_custom_holder_messages);

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
                    .SetIncomingTextConfig(
                            Class.FromType(typeof(CustomIncomingTextMessageViewHolder)),
                            Resource.Layout.item_custom_incoming_text_message)
                    .SetOutcomingTextConfig(
                            Class.FromType(typeof(CustomOutcomingTextMessageViewHolder)),
                            Resource.Layout.item_custom_outcoming_text_message)
                    .SetIncomingImageConfig(
                            Class.FromType(typeof(CustomIncomingImageMessageViewHolder)),
                            Resource.Layout.item_custom_incoming_image_message)
                    .SetOutcomingImageConfig(
                            Class.FromType(typeof(CustomOutcomingImageMessageViewHolder)),
                            Resource.Layout.item_custom_outcoming_image_message);

            base.messagesAdapter = new MessagesListAdapter(base.senderId, holdersConfig, base.imageLoader);
            base.messagesAdapter.SetOnMessageLongClickListener(this);
            base.messagesAdapter.SetLoadMoreListener(this);
            messagesList.SetAdapter(base.messagesAdapter);
        }
    }
}