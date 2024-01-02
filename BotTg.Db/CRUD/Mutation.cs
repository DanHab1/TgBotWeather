using BotTg.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTg.Db.CRUD
{
    public static class Mutation
    {
        public static UserM CreateOrUpdateUser(long userId, string city, int hour = 2)
        {
            using (var context = new DbContextApp())
            {
                var user = context.Users.FirstOrDefault(x => x.UserId == userId);
                if (user != null)
                {
                    user.City = city;
                    user.Hour = hour;
                    context.Users.AddOrUpdate(user);
                    context.SaveChanges();
                    return user;
                }
                else
                {
                    var userNew = new UserM()
                    {
                        City = city,
                        UserId = userId,
                        Hour = hour
                    };
                    context.Users.Add(userNew);
                    context.SaveChanges();
                    return userNew;
                }
            }
        }

        public static void UpdateAutoMessage(long userId, bool isAuto)
        {
            using (var context = new DbContextApp())
            {
                var user = context.Users.FirstOrDefault(x => x.UserId == userId);
                user.AutoMessage = isAuto;
                context.Users.AddOrUpdate(user);
                context.SaveChanges();
            }
        }
    }
}
