using BotTg.Model;
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

        public static string GetOnOrOff(bool AutoMessage)
        {
            if (AutoMessage) return "Включена";
            else return "Отключена";
        }

        public static string GetTextModelUserOption(UserM user)
        {
            var rez = new StringBuilder();
            rez.Append($"Город - {user.City}.\n");
            rez.Append($"Время обновления - {user.Hour} часа.\n");
            rez.Append($"Автоматическая отправка смс - {GetOnOrOff(user.AutoMessage)}.\n");
            return rez.ToString();
        }
    }
}
