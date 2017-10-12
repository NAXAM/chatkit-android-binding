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
using Java.Security;
using Java.Lang;
using Java.Util;

namespace ChatKitQs.Src.Common.Data.Fixtures
{
    public abstract class FixturesData
    {
        public static SecureRandom rnd = new SecureRandom();

        public static List<string> avatars = new List<string>()
        {
             "http://i.imgur.com/pv1tBmT.png",
             "http://i.imgur.com/R3Jm1CL.png",
             "http://i.imgur.com/ROz4Jgh.png",
             "http://i.imgur.com/Qn9UesZ.png",
        };


        public static List<string> groupChatImages = new List<string>()
        {
             "http://i.imgur.com/hRShCT3.png",
             "http://i.imgur.com/zgTUcL3.png",
             "http://i.imgur.com/mRqh5w1.png",
        };

        public static List<string> groupChatTitles = new List<string>()
        {
             "Samuel, Michelle",
             "Jordan, Jordan, Zoe",
             "Julia, Angel, Kyle, Jordan",
        };

        public static List<string> names = new List<string>()
        {
             "Samuel Reynolds",
             "Kyle Hardman",
             "Zoe Milton",
             "Angel Ogden",
             "Zoe Milton",
             "Angelina Mackenzie",
             "Kyle Oswald",
             "Abigail Stevenson",
             "Julia Goldman",
             "Jordan Gill",
             "Michelle Macey",
        };

        public static List<string> messages = new List<string>()
        {
             "Hello!",
             "This is my phone number - +1 (234) 567-89-01",
             "Here is my e-mail - myemail@example.com",
             "Hey! Check out this awesome link! www.github.com",
             "Hello! No problem. I can today at 2 pm. And after we can go to the office.",
             "At first, for some time, I was not able to answer him one word",
             "At length one of them called out in a clear, polite, smooth dialect, not unlike in sound to the Italian",
             "By the bye, Bob, said Hopkins",
             "He made his passenger captain of one, with four of the men; and himself, his mate, and five more, went in the other; and they contrived their business very well, for they came up to the ship about midnight.",
             "So saying he unbuckled his baldric with the bugle",
             "Just then her head struck against the roof of the hall: in fact she was now more than nine feet high, and she at once took up the little golden key and hurried off to the garden door.",
        };

        public static List<string> images = new List<string>()
        {
             "https://habrastorage.org/getpro/habr/post_images/e4b/067/b17/e4b067b17a3e414083f7420351db272b.jpg",
             "http://www.designboom.com/wp-content/uploads/2015/11/stefano-boeri-architetti-vertical-forest-residential-tower-lausanne-switzerland-designboom-01.jpg"
        };


        public static string GetRandomId()
        {
            return Long.ToString(UUID.RandomUUID().LeastSignificantBits);
        }

        public static string GetRandomAvatar()
        {
            return avatars[rnd.NextInt(avatars.Count)];
        }

        public static string GetRandomGroupChatImage()
        {
            return groupChatImages[rnd.NextInt(groupChatImages.Count)];
        }

        public static string GetRandomGroupChatTitle()
        {
            return groupChatTitles[rnd.NextInt(groupChatTitles.Count)];
        }

        public static string GetRandomName()
        {
            return names[rnd.NextInt(names.Count)];
        }

        public static string GetRandomMessage()
        {
            return messages[rnd.NextInt(messages.Count)];
        }

        public static string GetRandomImage()
        {
            return images[rnd.NextInt(images.Count)];
        }

        public static bool GetRandomBoolean()
        {
            return rnd.NextBoolean();
        }
    }
}