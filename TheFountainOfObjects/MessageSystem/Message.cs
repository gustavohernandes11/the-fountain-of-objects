using ManagerSystem;

namespace MessageSystem
{
    class Message
    {
        public static void Display(string text, MessageType type)
        {
            Console.ForegroundColor = GetColor(type);
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void EnabledFountain() =>
            Display("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", MessageType.FountainAbout);

        public static void FoundFountain() =>
            Display("You hear water dripping in this room. The Fountain of Objects is here!", MessageType.FountainAbout);

        public static void EdgeOfCavern() =>
            Display("You have touched the edge of the cave. It is not possible to go in that direction.", MessageType.Narrative);

        public static void EntranceOfCavern() =>
            Display("You see light in this room coming from outside the cavern. This is the entrance.", MessageType.LightAbout);

        public static void Divisor() =>
            Display("----------------------------------------------------------------------------------", MessageType.Background);

        public static void Win() =>
            Display("You win!", MessageType.Win);

        public static void Intro()
        {
            Display("The cavern is a grid of rooms, and no natural or human-made light works within due to unnatural darkness. You can see nothing, but you can hear and smell your way through the caverns to find the Fountain of Objects, restore it, and escape to the exit.", MessageType.Narrative);
            Display("You can type 'help' if you don't know what to do. Insert 'exit' to leave the game.", MessageType.Descritive);
        }

        public static void Help()
        {
            string helpMessage = "You have the map to locate yourself and some valid commands you can type in the prompt. The goal is to find the Fountain Of Objects, enable it, and return to the exit of the cavern.";
            string validCommandsMessage = "move north, move south, move west, move east, enable fountain, exit, help";
            string monsterExplanation = "Be aware of the following creatures in the cavern:";
            string pitExplanation = "- Pits: If you enter a room with a pit, you will fall and die.";
            string maelstromExplanation = "- Maelstroms: If you hear their growling, they are nearby. They can teleport you to a new location.";
            string amarokExplanation = "- Amaroks: You can smell their rotten stench in nearby rooms. They are dangerous creatures.";

            Display(helpMessage, MessageType.Descritive);
            Display("The commands you can enter:", MessageType.Descritive);
            Display(validCommandsMessage, MessageType.Descritive);
            Display(monsterExplanation, MessageType.Descritive);
            Display(pitExplanation, MessageType.Descritive);
            Display(maelstromExplanation, MessageType.Descritive);
            Display(amarokExplanation, MessageType.Descritive);
        }


        public static void PitNearby() =>
            Display("You feel a draft. There is a pit in a nearby room.", MessageType.Narrative);

        public static void FellIntoPit() =>
            Display("You fell into a pit. You are dead!", MessageType.Alert);

        public static void MaelstromsNearby() =>
            Display("You hear the growling and groaning of a maelstrom nearby.", MessageType.Narrative);

        public static void AttackedByMaelstroms() =>
            Display("You have been attacked by a Maelstrom and have been teleported to a new location.", MessageType.Alert);

        public static void AmarokNearby() =>
            Display("You can smell the rotten stench of an Amarok in a nearby room.", MessageType.Narrative);

        public static void AttackedByAmarok() =>
            Display("You have been attacked by a Amarok", MessageType.Alert);


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
}
