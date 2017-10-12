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

namespace ChatKitQs.Src.Utils
{
    public class AppUtils
    {
        public static void ShowToast(Context context, int text, bool isLong)
        {
            ShowToast(context, context.Resources.GetString(text), isLong);
        }

        public static void ShowToast(Context context, string text, bool isLong)
        {
            Toast.MakeText(context, text, isLong ? ToastLength.Short : ToastLength.Long).Show();
        }
    }
}