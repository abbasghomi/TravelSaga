using System;

namespace TravelSaga.Utils
{
    public enum ConsoleMessageType

    {
        Success,
        Fail,
        Warning,
        Info
    }

    public static class ConsoleExtensions
    {
        public static void WriteColored(this string message, ConsoleMessageType type)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = type switch
            {
                ConsoleMessageType.Success => ConsoleColor.Green,
                ConsoleMessageType.Fail => ConsoleColor.Red,
                ConsoleMessageType.Warning => ConsoleColor.Yellow,
                ConsoleMessageType.Info => ConsoleColor.Cyan,
                _ => previousColor
            };
            Console.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }
    }
}
