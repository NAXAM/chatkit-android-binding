﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.App;
using Com.Stfalcon.Chatkit.Dialogs;
using ChatKitQs.Src.Utils;
using ChatKitQs.Src.Common.Data.Models;
using Java.Lang;

namespace ChatKitQs.Src.Features.Demo
{
    public class DemoDialogsActivity : AppCompatActivity, DialogsListAdapter.IOnDialogClickListener, DialogsListAdapter.IOnDialogLongClickListener
    {
        protected DialogsListAdapter dialogsAdapter;
        protected ImageLoader imageLoader;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            imageLoader = new ImageLoader();
            
        }

        public void OnDialogLongClick(Java.Lang.Object p0)
        {
            AppUtils.ShowToast(
                    this,
                    ((Dialog)p0).DialogName,
                    false);
        }

        public virtual void OnDialogClick(Java.Lang.Object p0)
        {
        }
    }
}