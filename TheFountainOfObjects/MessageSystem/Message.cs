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

        public static void Intro()
        {
            Display("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.", MessageType.Narrative);
            Display("Light is visible only in the entrance, and no other light is seen anywhere in the caverns. You must navigate the Caverns with your other senses. Find the Fountain of Objects, activate it, and return to the entrance.", MessageType.Narrative);
            Display("You can type 'help' if you don't know what to do. Insert 'exit' to leave the game.", MessageType.Descritive);
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


        public static void Help()
        {
            string helpMessage = "You have the map to locate yourself and some valid commands you can type in the prompt. The goal is to find the Fountain Of Objects, enable it, and return to the exit of the cavern.";
            string validCommandsMessage = "move north, move south, move west, move east, enable fountain, shoot north, shoot south, shoot west, shoot east, exit, help";
            string monsterExplanation = "Be aware of the following creatures in the cave and use your bow when needed.:";
            string pitExplanation = "- Pits: If you enter a room with a pit, you will fall and die.";
            string maelstromExplanation = "- Maelstroms: If you hear their growling, they are nearby. They can teleport you to a new location.";
            string amarokExplanation = "- Amaroks: You can smell them rotten in the nearby rooms. They are dangerous creatures and will kill you if they find you.";

            Display(helpMessage, MessageType.Descritive);
            Display("The commands you can enter:", MessageType.Descritive);
            Display(validCommandsMessage, MessageType.Narrative);
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

        public static void Miss() =>
            Display("No different sound, his arrow apparently didn't hit anything...", MessageType.Narrative);

        public static void KilledAmarok() =>
            Display("A terrible sound comes from the direction you shot, you've killed an Amarok.", MessageType.Narrative);

        public static void KilledMaelstrom() =>
            Display("A cry of despair echoes in the cave. You killed a Maelstrom.", MessageType.Narrative);

        public static void NoArrows() =>
            Display("You have no more arrows.", MessageType.Descritive);


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
