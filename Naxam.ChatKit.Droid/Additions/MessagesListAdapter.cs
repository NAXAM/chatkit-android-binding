using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Stfalcon.Chatkit.Commons;
using Java.Lang;

namespace Com.Stfalcon.Chatkit.Messages
{
    public partial class MessagesListAdapter : global::Android.Support.V7.Widget.RecyclerView.Adapter
    {
        partial class DefaultDateHeaderViewHolder : ViewHolder, MessageHolders.IDefaultMessageViewHolder
        {
            public override void OnBind(Java.Lang.Object p0)
            {
                OnBindMessage((Java.Util.Date)p0);
            }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        { 
            OnBindViewHolder((Com.Stfalcon.Chatkit.Commons.ViewHolder)holder, position);
        }
    }
}