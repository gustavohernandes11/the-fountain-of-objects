using ManagerSystem;

namespace MessageSystem;

class Message
{

    public static void Display(string text, MessageType type)
    {
        Console.ForegroundColor = GetColor(type);
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void EnabledFountain() => Display(enabledFountainMessage, MessageType.FountainAbout);
    public static void FoundFountain() => Display(foundFountainMessage, MessageType.FountainAbout);
    public static void EdgeOfCavern() => Display(edgeOfCavernMessage, MessageType.Narrative);
    public static void EntranceOfCavern() => Display(entranceOfCavernMessage, MessageType.LightAbout);
    public static void Divisor() => Display("----------------------------------------------------------------------------------", MessageType.Background);
    public static void Win() => Display("You win!", MessageType.Win);
    public static void Intro()
    {
        Display(introGoalMessage, MessageType.Narrative);
        Display("You can type 'help' if you don't know what to do.", MessageType.Descritive);
    }
    public static void Help() => Display(helpMessage, MessageType.Descritive);


    static readonly string introGoalMessage = "The cavern is a grid of rooms, and no natural or human-made light works within due to unnatural darkness. You can see nothing, but you can hear and smell your way through the caverns to find the Fountain of Objects, restore it, and escape to the exit.";
    static readonly string enabledFountainMessage = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
    static readonly string foundFountainMessage = "You hear water dripping in this room. The Fountain of Objects is here!";
    static readonly string edgeOfCavernMessage = "You have touched the edge of the cave. It is not possible to go in that direction.";
    static readonly string entranceOfCavernMessage = "You see light in this room coming from outside the cavern. This is the entrance.";
    static readonly string helpMessage = "I don't know, lol";
    static ConsoleColor GetColor(MessageType type)
    {
        return type switch
        {
            MessageType.Alert => ConsoleColor.Red,
            MessageType.Narrative => ConsoleColor.Magenta,
            MessageType.Descritive => ConsoleColor.White,
            MessageType.LightAbout => ConsoleColor.Yellow,
            MessageType.FountainAbout => ConsoleColor.Blue,
            MessageType.Input => ConsoleColor.Cyan,
            MessageType.Background => ConsoleColor.Black,
            MessageType.Win => ConsoleColor.Green,
            _ => ConsoleColor.White,
        };
    }
}

