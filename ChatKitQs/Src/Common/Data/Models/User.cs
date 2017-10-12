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

namespace ChatKitQs.Src.Common.Data.Models
{
    public class User : Java.Lang.Object, IUser
    {
        public bool Online { get; set; }
        public string Avatar { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}