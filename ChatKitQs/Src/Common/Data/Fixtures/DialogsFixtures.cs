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
using ChatKitQs.Src.Common.Data.Models;

namespace ChatKitQs.Src.Common.Data.Fixtures
{
    public class DialogsFixtures : FixturesData
    {
        private DialogsFixtures()
        {
            throw new AssertionError();
        }

        public static List<Models.Dialog> GetDialogs()
        {
            List<Models.Dialog> chats = new List<Models.Dialog>();

            for (int i = 0; i < 20; i++)
            {
                Calendar calendar = Calendar.Instance;
                calendar.Add(Calendar.DayOfMonth, -(i * i));
                calendar.Add(Calendar.Minute, -(i * i));

                chats.Add(GetDialog(i, calendar.Time));
            }

            return chats;
        }

        public static Models.Dialog GetDialog(int i, Date lastMessageCreatedAt)
        {
            List<User> users = getUsers();
            return new Models.Dialog()
            {
                Id = GetRandomId(),
                DialogName = users.Count > 1 ? groupChatTitles[users.Count - 2] : users[0].Name,
                DialogPhoto = users.Count > 1 ? groupChatImages[users.Count - 2] : GetRandomAvatar(),
                Users = users,
                LastMessage = getMessage(lastMessageCreatedAt),
                UnreadCount = i < 3 ? 3 - i : 0
            };
        }

        public static List<User> getUsers()
        {
            List<User> users = new List<User>();
            int usersCount = 1 + rnd.NextInt(4);

            for (int i = 0; i < usersCount; i++)
            {
                users.Add(getUser());
            }

            return users;
        }

        public static User getUser()
        {
            return new User()
            {
                Id = GetRandomId(),
                Name = GetRandomName(),
                Avatar = GetRandomAvatar(),
                Online = GetRandomBoolean()
            };
        }

        public static Models.Message getMessage(Date date)
        {
            return new Models.Message()
            {
                Id = GetRandomId(),
                User = getUser(),
                Text = GetRandomMessage(),
                CreatedAt = date
            };
        }
    }
}