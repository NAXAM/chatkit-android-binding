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

namespace ChatKitQs.Src.Features.Demo.Custom.Holder.Holders.Messages
{
    public class CustomOutcomingTextMessageViewHolder : MessageHolders.OutcomingTextMessageViewHolder
    {
        public CustomOutcomingTextMessageViewHolder(View p0) : base(p0)
        {
        }

        public override void OnBind(Java.Lang.Object p0)
        {
            base.OnBind(p0);
            var message = (ChatKitQs.Src.Common.Data.Models.Message)p0;
            Time.Text = message.Status + " " + Time.Text;
        }
    }
}