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
using Java.Lang;

namespace Com.Stfalcon.Chatkit.Messages
{
    partial class MessageHolders
    {
        partial class BaseIncomingMessageViewHolder : Com.Stfalcon.Chatkit.Messages.MessageHolders.BaseMessageViewHolder
        {
            public override void OnBind(Java.Lang.Object p0)
            {
                OnBindMessage(p0);
            }
        }

        partial class BaseOutcomingMessageViewHolder : Com.Stfalcon.Chatkit.Messages.MessageHolders.BaseMessageViewHolder
        {
            public override void OnBind(Java.Lang.Object p0)
            {
                OnBindMessage(p0);
            }
        }

        partial class DefaultDateHeaderViewHolder : Com.Stfalcon.Chatkit.Messages.MessageHolders.IDefaultMessageViewHolder
        {
            public override void OnBind(Java.Lang.Object p0)
            {
                OnBindMessage((Java.Util.Date)p0);
            }
        }
    }
}