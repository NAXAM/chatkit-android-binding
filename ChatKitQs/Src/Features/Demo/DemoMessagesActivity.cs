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
using Android.Support.V7.App;
using Com.Stfalcon.Chatkit.Messages;
using Com.Stfalcon.Chatkit.Commons;
using ChatKitQs.Src.Common.Data.Models;
using ChatKitQs.Src.Common.Data.Fixtures;
using Java.Util;
using ChatKitQs.Src.Utils;
using Java.Lang;
using Square.Picasso;
using Java.Text;

namespace ChatKitQs.Src.Features.Demo
{
    public abstract class DemoMessagesActivity : AppCompatActivity, MessagesListAdapter.ISelectionListener, MessagesListAdapter.IOnLoadMoreListener
    {
        private static int TOTAL_MESSAGES_COUNT = 100;

        protected string senderId = "0";
        protected ImageLoader imageLoader;
        protected MessagesListAdapter messagesAdapter;

        private IMenu menu;
        private int selectionCount;
        private Date lastLoadedDate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            imageLoader = new ImageLoader();
        }



        protected override void OnStart()
        {
            base.OnStart();
            messagesAdapter.AddToStart(MessagesFixtures.GetTextMessage(), true);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            this.menu = menu;
            MenuInflater.Inflate(Resource.Menu.chat_actions_menu, menu);
            OnSelectionChanged(0);
            return true;
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_delete:
                    messagesAdapter.DeleteSelectedMessages();
                    break;
                case Resource.Id.action_copy:
                    messagesAdapter.CopySelectedMessagesText(this, GetMessageStringFormatter(), true);
                    AppUtils.ShowToast(this, Resources.GetString(Resource.String.copied_message), true);
                    break;
            }
            return true;
        }


        public override void OnBackPressed()
        {
            if (selectionCount == 0)
            {
                base.OnBackPressed();
            }
            else
            {
                messagesAdapter.UnselectAllItems();
            }
        }


        public void OnLoadMore(int page, int totalitemscount)
        {
            if (totalitemscount < TOTAL_MESSAGES_COUNT)
            {
                LoadMessages();
            }
        }


        public void OnSelectionChanged(int count)
        {
            this.selectionCount = count;
            menu.FindItem(Resource.Id.action_delete).SetVisible(count > 0);
            menu.FindItem(Resource.Id.action_copy).SetVisible(count > 0);
        }

        protected void LoadMessages()
        {
            new Handler().PostDelayed(() =>
                {
                    List<ChatKitQs.Src.Common.Data.Models.Message> messages = MessagesFixtures.GetMessages(lastLoadedDate);
                    lastLoadedDate = messages[messages.Count - 1].CreatedAt;
                    messagesAdapter.AddToEnd(messages, false);
                }, 1000);
        }
        private Formatter GetMessagestringFormatter()
        {
            return new Formatter();
        }

        private Formatter GetMessageStringFormatter()
        {
            return new Formatter()
            {

            };
        }

        public class Formatter : Java.Lang.Object, MessagesListAdapter.IFormatter
        {
            public string Format(Java.Lang.Object p0)
            {
                var message = (Common.Data.Models.Message)p0;
                string createdAt = new SimpleDateFormat("MMM d, EEE 'at' h:mm a", Locale.Default)
                        .Format(message.CreatedAt);

                string text = message.Text;
                if (text == null) text = "[attachment]";

                return string.Format("%s: %s (%s)",
                        message.User.Name, text, createdAt);
            }
        }
    }
}