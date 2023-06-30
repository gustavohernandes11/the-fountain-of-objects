using BoardSystem;
using MessageSystem;
using Utilities;

namespace ManagerSystem;


class GameManager
{
    Board Board { get; set; }
    bool ShouldGameStillRun { get; set; }


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
            Command command = Helper.GetPrompt("What do you want to do?");
            Console.Clear();
            HandlePromptCommand(command);
            if (command == Command.Help) continue;
            round++;
        }
    }

    private void HandlePromptCommand(Command command)
    {
        Point destiny;
        Point target;

        switch (command)
        {
            case Command.Help:
                Message.Help();
                break;

            case Command.Exit:
                ShouldGameStillRun = false;
                break;

            case Command.EnableFountain:
                if (Board.PlayerPosition == Board.FountainPosition)
                {
                    Board.IsEnabledFountain = true;
                    Message.EnabledFountain();
                }
                else
                    Message.Display("You are not in the Fountain's room.", MessageType.Descritive);

                break;

            case Command.MoveEast:
                destiny = new(Board.PlayerPosition.X + 1, Board.PlayerPosition.Y);
                if (Board.IsValidPoint(destiny))
                    Board.PlayerPosition = destiny;

                else
                    Message.EdgeOfCavern();
                break;

            case Command.MoveWest:
                destiny = new(Board.PlayerPosition.X - 1, Board.PlayerPosition.Y);
                if (Board.IsValidPoint(destiny))
                    Board.PlayerPosition = destiny;

                else
                    Message.EdgeOfCavern();

                break;

            case Command.MoveNorth:
                destiny = new(Board.PlayerPosition.X, Board.PlayerPosition.Y + 1);
                if (Board.IsValidPoint(destiny))
                    Board.PlayerPosition = destiny;

                else
                    Message.EdgeOfCavern();

                break;

            case Command.MoveSouth:
                destiny = new(Board.PlayerPosition.X, Board.PlayerPosition.Y - 1);
                if (Board.IsValidPoint(destiny))
                    Board.PlayerPosition = destiny;

                else
                    Message.EdgeOfCavern();

                break;

            case Command.ShootNorth:
                target = new(Board.PlayerPosition.X, Board.PlayerPosition.Y + 1);
                ShootArrowAt(target);

                break;

            case Command.ShootSouth:
                target = new(Board.PlayerPosition.X, Board.PlayerPosition.Y - 1);
                ShootArrowAt(target);
                break;

            case Command.ShootWest:
                target = new(Board.PlayerPosition.X - 1, Board.PlayerPosition.Y);
                ShootArrowAt(target);
                break;

            case Command.ShootEast:
                target = new(Board.PlayerPosition.X + 1, Board.PlayerPosition.Y);
                ShootArrowAt(target);
                break;
        }
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

    private void ShootArrowAt(Point target)
    {
        if (!Board.IsValidPoint(target)) return;

        if (Board.IsEmpty(target))
        {
            Message.Miss();
        }
        else if (Board.HasEntityAt(GameEntity.Amarok, target))
        {
            Message.KilledAmarok();
            Board.RemoveEntityAt(GameEntity.Amarok, target);
        }
        else if (Board.HasEntityAt(GameEntity.Maelstroms, target))
        {
            Message.KilledMaelstrom();
            Board.RemoveEntityAt(GameEntity.Maelstroms, target);
        }
        Board.ArrowsAmount--;
    }

}


