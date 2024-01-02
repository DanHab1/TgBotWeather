using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTg.Model
{
    public class UserM
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int Hour { get; set; }
        public long UserId { get; set; }
        public bool AutoMessage { get; set; }
    }
}
