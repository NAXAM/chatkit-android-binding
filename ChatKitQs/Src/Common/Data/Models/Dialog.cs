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
using Com.Stfalcon.Chatkit.Commons.Models;
using Java.Lang;

namespace ChatKitQs.Src.Common.Data.Models
{
    public class Dialog : Java.Lang.Object, IDialog
    {
        public string DialogName { get; set; }

        public string DialogPhoto { get; set; }

        public string Id { get; set; }

        public Java.Lang.Object LastMessage { get; set; }

        public int UnreadCount { get; set; }

        public List<User> Users { get; set; }

        IList<IUser> IDialog.Users => throw new NotImplementedException();
    }
}