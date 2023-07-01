namespace Utilities;

static class Helper
{
    public static bool IsValidEnumValue<TEnum>(string value)
    {
        return Enum.TryParse(typeof(TEnum), value, true, out _);
    }

    public static string? GetPrompt(string text)
    {
        while (true)
        {
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.White;
                return input;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Invalid command.");
        }
    }
}
