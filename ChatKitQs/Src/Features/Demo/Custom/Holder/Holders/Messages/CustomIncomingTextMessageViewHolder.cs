﻿using System;
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
    public class CustomIncomingTextMessageViewHolder : MessageHolders.IncomingTextMessageViewHolder
    {
        private View onlineIndicator;
        public CustomIncomingTextMessageViewHolder(View p0) : base(p0)
        {
            onlineIndicator = p0.FindViewById(Resource.Id.onlineIndicator);
        }
        public override void OnBind(Java.Lang.Object p0)
        {
            base.OnBind(p0);
            var message = (ChatKitQs.Src.Common.Data.Models.Message)p0;
            bool isOnline = ((ChatKitQs.Src.Common.Data.Models.User)message.User).Online;
            if (isOnline)
            {
                onlineIndicator.SetBackgroundResource(Resource.Drawable.shape_bubble_online);
            }
            else
            {
                onlineIndicator.SetBackgroundResource(Resource.Drawable.shape_bubble_offline);
            }
        }
    }
}