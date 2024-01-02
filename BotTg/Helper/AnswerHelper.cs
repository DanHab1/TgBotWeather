using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTg.Helper
{
    public class AnswerHelper
    {
        public static string FirstLetterUpper(string text)
        {
            var charArr = text[0].ToString().ToUpper();
            return charArr + text.Remove(0, 1);
                        
        }
    }
}
