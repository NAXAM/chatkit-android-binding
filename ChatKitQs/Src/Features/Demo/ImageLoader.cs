using Android.Widget;
using Square.Picasso;
using Com.Stfalcon.Chatkit.Commons;

namespace ChatKitQs.Src.Features.Demo
{
    public class ImageLoader : Java.Lang.Object, IImageLoader
    {
        public void LoadImage(ImageView imageView, string url)
        {
            Picasso.With(imageView.Context).Load(url).Into(imageView);
        }
    }
}