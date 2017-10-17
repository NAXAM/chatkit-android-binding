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
using ChatKitQs.Src.Common.Data.Models;
using Java.Util;

namespace ChatKitQs.Src.Common.Data.Fixtures
{
    public class MessagesFixtures : FixturesData
    {
        private MessagesFixtures()
        {
            throw new AssertionError();
        }

        public static ChatKitQs.Src.Common.Data.Models.Message GetImageMessage()
        {
            ChatKitQs.Src.Common.Data.Models.Message message = new ChatKitQs.Src.Common.Data.Models.Message()
            {
                Id = GetRandomId(),
                User = GetUser(),
                Text = null,
                CreatedAt = new Date()
            };
            message.ImageUrl = GetRandomImage();
            message.MessageImage = new ChatKitQs.Src.Common.Data.Models.Message.Image()
            {
                Url = GetRandomImage()
            };
            return message;
        }

        public static ChatKitQs.Src.Common.Data.Models.Message GetVoiceMessage()
        {
            ChatKitQs.Src.Common.Data.Models.Message message = new ChatKitQs.Src.Common.Data.Models.Message()
            {
                Id = GetRandomId(),
                User = GetUser(),
                Text = null,
                CreatedAt = new Date()
            };
            message.MessageVoice = new ChatKitQs.Src.Common.Data.Models.Message.Voice()
            {
                Url = "http://example.com",
                Duration = rnd.NextInt(200) + 30
            };
            return message;
        }

        public static ChatKitQs.Src.Common.Data.Models.Message GetTextMessage()
        {
            return GetTextMessage(GetRandomMessage());
        }

        public static ChatKitQs.Src.Common.Data.Models.Message GetTextMessage(string text)
        {
            return new ChatKitQs.Src.Common.Data.Models.Message
            {
                Id = GetRandomId(),
                User = GetUser(),
                Text = text,
                CreatedAt = new Date()
            };
        }

        public static List<ChatKitQs.Src.Common.Data.Models.Message> GetMessages(Date startDate)
        {
            List<ChatKitQs.Src.Common.Data.Models.Message> messages = new List<ChatKitQs.Src.Common.Data.Models.Message>();
            for (int i = 0; i < 10/*days count*/; i++)
            {
                int countPerDay = rnd.NextInt(5) + 1;

                for (int j = 0; j < countPerDay; j++)
                {
                    ChatKitQs.Src.Common.Data.Models.Message message;
                    if (i % 2 == 0 && j % 3 == 0)
                    {
                        message = GetImageMessage();
                    }
                    else
                    {
                        message = GetTextMessage();
                    }

                    Calendar calendar = Calendar.Instance;
                    if (startDate != null) calendar.Time = startDate;
                    calendar.Add(Calendar.DayOfMonth, -(i * i + 1));

                    message.CreatedAt = calendar.Time;
                    messages.Add(message);
                }
            }
            return messages;
        }

        private static User GetUser()
        {
            bool even = rnd.NextBoolean();
            return new User()
            {
                Id = even ? "0" : "1",
                Name = even ? names[0] : names[1],
                Avatar = even ? avatars[0] : avatars[1],
                Online = true
            };
        }
    }
}