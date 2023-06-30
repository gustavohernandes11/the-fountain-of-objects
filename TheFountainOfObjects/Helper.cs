using BoardSystem;

namespace Utilities;

static class Helper
{
    public static bool IsValidEnumValue<TEnum>(string value)
    {
        return Enum.TryParse(typeof(TEnum), value, true, out _);
    }

    public static Command GetPrompt(string text)
    {
        while (true)
        {
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? input = RemoveWhitespace(Console.ReadLine()!);

            if (!string.IsNullOrEmpty(input)
                && Enum.TryParse(input, true, out Command command))
            {
                Console.ForegroundColor = ConsoleColor.White;
                return command;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Invalid command.");
        }
    }
    public static string RemoveWhitespace(string input)
    {
        return new string(input.ToCharArray()
            .Where(c => !char.IsWhiteSpace(c))
            .ToArray());
    }
}
