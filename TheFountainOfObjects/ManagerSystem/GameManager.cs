using BoardSystem;
using MessageSystem;
using Utilities;

namespace ManagerSystem;


public class GameManager
{
    Board Board { get; set; }
    public bool ShouldGameStillRun { get; set; }


    public GameManager(Board board)
    {
        Board = board;
        ShouldGameStillRun = true;
    }

    public void Init()
    {
        int round = 0;
        Console.Clear();
        Message.Intro();

        while (ShouldGameStillRun)
        {
            Message.Divisor();
            VerifyGameState();
            if (!ShouldGameStillRun) break;
            Board.DisplayBoard();
            DisplayPlayerStatus();
            string? input = Helper.GetPrompt("What do you want to do?")!.Trim();
            Console.Clear();
            HandlePromptCommand(input);
            // if (command == Command.Help) continue;
            round++;
        }
    }

    private void HandlePromptCommand(string? input)
    {
        if (input == null) return;

        ICommand command;

        switch (input)
        {
            case "move north":
                command = new MoveNorthCommand();
                break;

            case "move south":
                command = new MoveSouthCommand();
                break;

            case "move west":
                command = new MoveWestCommand();
                break;

            case "move east":
                command = new MoveEastCommand();
                break;

            case "shoot north":
                command = new ShootNorthCommand();
                break;

            case "shoot south":
                command = new ShootSouthCommand();
                break;

            case "shoot west":
                command = new ShootWestCommand();
                break;

            case "shoot east":
                command = new ShootEastCommand();
                break;

            case "enable fountain":
                command = new EnableFountainCommand();
                break;

            case "exit":
                ShouldGameStillRun = false;
                return;

            case "help":
                command = new HelpCommand();
                break;

            default:
                command = new InvalidCommand();
                break;
        }

        command.Run(Board);


    }

    private void VerifyGameState()
    {
        if (ShouldGameStillRun == false)
            return;

        if (Board.PlayerPosition == new Point(0, 0) && Board.IsEnabledFountain)
        {
            Message.Win();
            ShouldGameStillRun = false;
            return;
        }

        if (Board.HasEntityAt(GameEntity.Maelstroms, Board.PlayerPosition))
        {
            Message.AttackedByMaelstroms();
            Board.MoveEntityTo(GameEntity.Maelstroms, Board.PlayerPosition,
                new Point(Board.PlayerPosition.X + 2, Board.PlayerPosition.Y + 1));

            Board.MovePlayerTo(
                new Point(Board.PlayerPosition.X - 2, Board.PlayerPosition.Y - 1));
        }

        if (Board.HasEntityAt(GameEntity.Pit, Board.PlayerPosition))
        {
            Message.FellIntoPit();
            ShouldGameStillRun = false;
            return;
        }

        if (Board.HasEntityAt(GameEntity.Amarok, Board.PlayerPosition))
        {
            Message.AttackedByAmarok();
            ShouldGameStillRun = false;
            return;
        }

        if (Board.HasEntityAdjacent(GameEntity.Amarok, Board.PlayerPosition))
            Message.AmarokNearby();

        if (Board.HasEntityAdjacent(GameEntity.Maelstroms, Board.PlayerPosition))
            Message.MaelstromsNearby();

        if (Board.HasEntityAdjacent(GameEntity.Pit, Board.PlayerPosition))
            Message.PitNearby();

        if (Board.PlayerPosition == Board.FountainPosition && !Board.IsEnabledFountain)
            Message.FoundFountain();

        if (Board.PlayerPosition == new Point(0, 0))
            Message.EntranceOfCavern();
    }

    private void DisplayPlayerStatus()
    {
        Message.Display($"You are in the room at (Row={Board.PlayerPosition.X}, Column={Board.PlayerPosition.Y}) | Arrows: {Board.ArrowsAmount}", MessageType.Descritive);
    }
}


