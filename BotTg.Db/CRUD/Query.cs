using BotTg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTg.Db.CRUD
{
    public class Query
    {
        public static UserM GetUser(long userId)
        {
            using(var context = new DbContextApp())
            {
                var user = context.Users.FirstOrDefault(x => x.UserId == userId);
                return user;
            }
        }

        public static List<UserM> GetUserAutoMessage()
        {
            using (var context = new DbContextApp())
            {
                var user = context.Users.Where(x => x.AutoMessage == true).ToList();
                return user;
            }
        }

    }
}
