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
using ChatKitQs.Src.Features.Demo.Custom.Media.Holders;

namespace ChatKitQs.Src.Features.Demo.Custom.Media
{
    [Activity(Theme = "@style/BlueTheme")]
    public class CustomMediaMessagesActivity : DemoMessagesActivity,
        MessageInputControl.IInputListener,
        MessageInputControl.IAttachmentsListener,
        MessageHolders.IContentChecker,
        IDialogInterfaceOnClickListener
    {
        private const byte CONTENT_TYPE_VOICE = 1;

        public static void Open(Context context)
        {
            context.StartActivity(new Intent(context, typeof(CustomMediaMessagesActivity)));
        }

        private MessagesList messagesList;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_custom_media_messages);

            this.messagesList = FindViewById<MessagesList>(Resource.Id.messagesList);
            InitAdapter();

            MessageInputControl input = FindViewById<MessageInputControl>(Resource.Id.input);
            input.SetInputListener(this);
            input.SetAttachmentsListener(this);
        }


        public bool OnSubmit(ICharSequence input)
        {
            base.messagesAdapter.AddToStart(
                    MessagesFixtures.GetTextMessage(input.ToString()), true);
            return true;
        }


        public void OnAddAttachments()
        {
            new AlertDialog.Builder(this)
                    .SetItems(Resource.Array.view_types_dialog, this)
                    .Show();
        }


        public void OnClick(IDialogInterface dialog, int which)
        {
            switch (which)
            {
                case 0:
                    messagesAdapter.AddToStart(MessagesFixtures.GetImageMessage(), true);
                    break;
                case 1:
                    messagesAdapter.AddToStart(MessagesFixtures.GetVoiceMessage(), true);
                    break;
            }
        }

        public bool HasContentFor(Java.Lang.Object p0, sbyte p1)
        {
            var type = (sbyte)p1;
            var message = (ChatKitQs.Src.Common.Data.Models.Message)p0;
            switch (type)
            {
                case (sbyte)CONTENT_TYPE_VOICE:
                    return message.voice != null && !string.IsNullOrEmpty(message.voice.Url);
            }
            return false;
        }
        private void InitAdapter()
        {
            MessageHolders holders = new MessageHolders()
                    .RegisterContentType(
                            (sbyte)CONTENT_TYPE_VOICE,
                            Class.FromType(typeof(IncomingVoiceMessageViewHolder)),
                        Resource.Layout.item_custom_incoming_voice_message,
                        Class.FromType(typeof(OutcomingVoiceMessageViewHolder)),
                        Resource.Layout.item_custom_outcoming_voice_message,
                        this);


            base.messagesAdapter = new MessagesListAdapter(base.senderId, holders, base.imageLoader);
            base.messagesAdapter.EnableSelectionMode(this);
            base.messagesAdapter.SetLoadMoreListener(this);
            this.messagesList.SetAdapter(base.messagesAdapter);
        }
    }
}