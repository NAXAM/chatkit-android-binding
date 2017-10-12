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
using Com.Stfalcon.Chatkit.Dialogs;
using Java.Lang;

namespace ChatKitQs.Src.Features.Demo.Custom.Holder.Holders.Dialogs
{
    public class CustomDialogViewHolder : DialogsListAdapter.DialogViewHolder
    {
        private View onlineIndicator;
        public CustomDialogViewHolder(View p0) : base(p0)
        {
            onlineIndicator = p0.FindViewById(Resource.Id.onlineIndicator);
        }

        public override void OnBind(Java.Lang.Object p0)
        {
            base.OnBind(p0);
            var dialog = (ChatKitQs.Src.Common.Data.Models.Dialog)p0;
            if (dialog.Users.Count > 1)
            {
                onlineIndicator.Visibility = ViewStates.Gone;
            }
            else
            {
                bool isOnline = dialog.Users[0].Online;
                onlineIndicator.Visibility = ViewStates.Visible;
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
}