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
using Java.Util;

namespace ChatKitQs.Src.Common.Data.Models
{
    public class Message : Java.Lang.Object, IMessage, IMessageContentTypeImage, IMessageContentType
    {
        public Date CreatedAt { get; set; }

        public string Id { get; set; }

        public string Text { get; set; }

        public IUser User { get; set; }

        public string ImageUrl { get; set; }

        public Image image { get; set; }

        public Voice voice { get; set; }

        public string Status => "sent";

        public class Image
        {
            public string Url { get; set; }
        }

        public class Voice
        {
            public string Url { get; set; }
            public int Duration { get; set; }
        }
    }
}