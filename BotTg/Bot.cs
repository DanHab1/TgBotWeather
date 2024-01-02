using Telegram.Bot;
using Telegram.Bot.Types;
using Newtonsoft.Json;
using Telegram.Bot.Polling;
using BotTg.Helper;
using BotTg.Db.CRUD;
using BotTg.Model;
using Telegram.Bot.Types.Enums;

namespace BotTg
{
    public class Bot
    {
        private static ITelegramBotClient bot = new TelegramBotClient("6235591095:AAEKavGZMlgRXvRi_lEfEWoGzwcOVJfFeWs");

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(JsonConvert.SerializeObject(update));
            
            var message = update.Message;
            if (update.Type != UpdateType.Message || update.Message == null || message.Type != MessageType.Text)
            {
                return;
            }
            else
            {
                try
                {
                    var api = new WeatherApi();
                    var textMessage = message?.Text?.ToLower();
                    var answer = await api.GetWeather(message?.Text);
                    switch (textMessage)
                    {
                        case "/start":
                            await botClient.SendTextMessageAsync(message.Chat,
                                "Приветствую тебя!\nЯ бот погоды!\nНапиши название города и я скажу тебе погоду на текущий момент.\nДля установки значения напишите 'город - запомни'");
                            Mutation.CreateOrUpdateUser(message.From.Id, "Казань");
                            return;
                        case "/option":
                            await botClient.SendTextMessageAsync(message.Chat,
                                    "Текущие настройки:\n" + AnswerHelper.GetTextModelUserOption(Query.GetUser(message.From.Id)));
                            return;
                        }

                    if (textMessage.Contains(" - запомни"))
                    {
                        var user = Mutation.CreateOrUpdateUser(message.From.Id, textMessage.Split(" - ")[0]);
                        Mutation.UpdateAutoMessage(message.From.Id, true);
                        await botClient.SendTextMessageAsync(message.Chat,
                            $"Я запомнил город {AnswerHelper.FirstLetterUpper(user.City)}.\nБуду каждые 2 часа направлять Вам погоду по данному городу.\nДля отмены напишите 'stop'");
                    }
                    else if (textMessage.Contains("stop"))
                    {
                        Mutation.UpdateAutoMessage(message.From.Id, false);
                        await botClient.SendTextMessageAsync(message.Chat,
                            $"Автоматическая отправка сообщения остановлена.");
                    }
                    else
                    {
                        if (answer != "")
                        {
                            await botClient.SendTextMessageAsync(message.Chat, answer);
                        }
                        else await botClient.SendTextMessageAsync(message.Chat,
                                "Вы точно ввели наименование города правильно? Попробуйте еще раз.");
                    }
                }
                catch(Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Мне плохо... Какая-то ошибка вылезла:\n" + ex.Message);
                }

            }       
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(JsonConvert.SerializeObject(exception));
        }

        public static void Main(string[] args)
        {
            Console.WriteLine($"{bot.GetMeAsync().Result.FirstName} - запущен");
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
                );
            CreateAnswer.AutoWeatherAnswer(bot);
            Console.ReadLine();
        }

    }
}






