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

        public static string getDurationString(int seconds)
        {
            Date date = new Date(seconds * 1000);
            SimpleDateFormat formatter = new SimpleDateFormat(seconds >= 3600 ? "HH:mm:ss" : "mm:ss");
            formatter.TimeZone = Java.Util.TimeZone.GetTimeZone("GMT");
            return formatter.Format(date);
        }
    }
}