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
        partial class BaseIncomingMessageViewHolder
        {
            public override void OnBind(Java.Lang.Object p0)
            {
                OnBindMessage(p0);
            }
        }
        partial class BaseOutcomingMessageViewHolder
        {
            public override void OnBind(Java.Lang.Object p0)
            {
                OnBindMessage(p0);
            }
        }
        public partial class DefaultDateHeaderViewHolder
        {
            public override void OnBind(Java.Lang.Object p0)
            {
                OnBindMessage((Java.Util.Date)p0);
            }
        }
        public partial class IncomingImageMessageViewHolder
        {
            public override void OnBind(Java.Lang.Object p0)
            {
                base.OnBind(p0);
                OnBindMessage(p0);
            }
        }
        public partial class OutcomingImageMessageViewHolder
        {
            public override void OnBind(Java.Lang.Object p0)
            {
                base.OnBind(p0);
                OnBindMessage(p0);
            }
        }
    }
}