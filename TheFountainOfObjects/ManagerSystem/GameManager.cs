using BoardSystem;
using MessageSystem;
using Utilities;

namespace ManagerSystem;

public class GameManager
{
    Board Board { get; set; }
    GameStateVerifier GameStateVerifier { get; set; }

    public GameManager(Board board)
    {
        Board = board;
        GameStateVerifier = new(board);
    }

    public void Init()
    {
        int round = 0;
        Console.Clear();
        Message.Intro();

        do
        {
            Message.Divisor();
            GameStateVerifier.Verify();
            if (!GameStateVerifier.ShouldGameStillRun) break;
            Board.DisplayBoard();
            DisplayPlayerStatus();
            string input = Helper.GetPrompt("What do you want to do?");
            Console.Clear();
            HandleCommand(input);
            round++;
        }
        while (GameStateVerifier.ShouldGameStillRun);
    }

    private void HandleCommand(string? input)
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
                GameStateVerifier.ShouldGameStillRun = false;
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

    private void DisplayPlayerStatus()
    {
        Message.Display($"You are in the room at (Row={Board.PlayerPosition.X}, Column={Board.PlayerPosition.Y}) | Arrows: {Board.ArrowsAmount}", MessageType.Descritive);
    }
}

