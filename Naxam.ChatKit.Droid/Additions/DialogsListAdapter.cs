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
using Android.Support.V7.Widget;
using Java.Lang;
using Com.Stfalcon.Chatkit.Commons.Models;

namespace Com.Stfalcon.Chatkit.Dialogs
{
    //partial class DialogsListAdapter : RecyclerView.Adapter
    //{
    //    partial class DialogViewHolder : BaseDialogViewHolder
    //    {
    //        public override void OnBind(Java.Lang.Object p0)
    //        {
    //            OnBindDialog(p0);
    //        }
    //    }
    //    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    //    {
    //        return OnCreateViewHolderX(parent, viewType);
    //    }
    //    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    //    {
    //        OnBindViewHolderX((BaseDialogViewHolder)holder, position);
    //    }
    //}
    public partial class DialogsListAdapter : RecyclerView.Adapter
    {
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            OnBindViewHolder((Com.Stfalcon.Chatkit.Dialogs.DialogsListAdapter.BaseDialogViewHolder)holder, position);
        }
        partial class DialogViewHolder : BaseDialogViewHolder
        {
            public override void OnBind(Java.Lang.Object p0)
            {
                OnBindDialog(p0);
            }
        }

    }
}