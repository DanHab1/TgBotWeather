using BotTg.Model;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTg.Db
{
    public class DbContextApp : DbContext
    {
        public DbContextApp() : base("conString")
        {

        }
        public DbSet<UserM> Users { get; set; }
        
    }
}
