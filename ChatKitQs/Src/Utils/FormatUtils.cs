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
using Java.Util;
using Java.Text;

namespace ChatKitQs.Src.Utils
{
    public class FormatUtils
    {
        private FormatUtils()
        {
            throw new AssertionError();
        }

        public static string GetDurationString(int seconds)
        { 
            DateTime posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
            DateTime time = posixTime.AddSeconds(seconds);
            return time.ToString(seconds >= 3600 ? "HH:mm:ss" : "mm:ss");
        }
    }
}