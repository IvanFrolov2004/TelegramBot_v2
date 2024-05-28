using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;




class Program
{
    static void Main(string[] args)
    {
        var client = new TelegramBotClient("6997160925:AAENvuJschyJH33bDpB4Ac8rGSiWIRsKLnU");
        client.StartReceiving(Update, Error);
        Console.ReadLine();
    }

    async static Task Update(ITelegramBotClient botclient, Update update, CancellationToken token)
    {
        var message = update.Message;

        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "start", "next" },
            new KeyboardButton[] { "open", "sendphoto" },
        })
        {
            ResizeKeyboard = true
        };

        ReplyKeyboardMarkup replyKeyboardMarkup2 = new(new[]
        {
            new KeyboardButton[] { "apros", "diff", "back" },
        })
        {
            ResizeKeyboard = true
        };

        if (message?.Text != null)
        {
            Console.WriteLine($"{message.Chat.Id} | {message.Chat.Username} | {message.Chat.FirstName} {message.Chat.LastName} | {message.Text} | {message.Date}");

            if (message.Text.ToLower().Contains("start"))
            {
                await botclient.SendTextMessageAsync(message.Chat.Id, "Hello", replyMarkup: replyKeyboardMarkup);
                return;
            }

            if (message.Text.ToLower().Contains("open"))
            {
                await botclient.SendTextMessageAsync(message.Chat.Id, "close", replyMarkup: replyKeyboardMarkup);
                return;
            }

            if (message.Text.ToLower().Contains("next"))
            {
                await botclient.SendTextMessageAsync(message.Chat.Id, "okey, choose a function", replyMarkup: replyKeyboardMarkup2);
                return;
            }

            if (message.Text.ToLower().Contains("back"))
            {
                await botclient.SendTextMessageAsync(message.Chat.Id, "okey", replyMarkup: replyKeyboardMarkup);
                return;
            }

            if (message.Text.ToLower().Contains("sendphoto"))
            {
                await botclient.SendTextMessageAsync(message.Chat.Id, "please send photo in document", replyMarkup: replyKeyboardMarkup);
                return;
            }
        }
    }
    private static async Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        Console.WriteLine($"An error occurred: {exception.Message}");
    }
}