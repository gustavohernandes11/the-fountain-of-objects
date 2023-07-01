using ManagerSystem;
using MessageSystem;
namespace BoardSystem
{
    public interface ICommand
    {
        public void Run(Board board);
    }

    public interface IGameStateCommand
    {
        public void Run(GameStateVerifier gameStateVerifier);
    }

    public class HelpCommand : ICommand
    {
        public void Run(Board board)
        {
            Message.Help();
        }
    }

    public class MoveNorthCommand : ICommand
    {
        public void Run(Board board)
        {
            Point destiny = new(board.PlayerPosition.X, board.PlayerPosition.Y + 1);
            if (board.IsValidPoint(destiny))
                board.PlayerPosition = destiny;

            else
                Message.EdgeOfCavern();
        }

    }

    public class MoveSouthCommand : ICommand
    {
        public void Run(Board board)
        {
            Point destiny = new(board.PlayerPosition.X, board.PlayerPosition.Y - 1);
            if (board.IsValidPoint(destiny))
                board.PlayerPosition = destiny;

            else
                Message.EdgeOfCavern();
        }

    }
    public class MoveWestCommand : ICommand
    {
        public void Run(Board board)
        {
            Point destiny = new(board.PlayerPosition.X - 1, board.PlayerPosition.Y);
            if (board.IsValidPoint(destiny))
                board.PlayerPosition = destiny;

            else
                Message.EdgeOfCavern();
        }

    }
    public class MoveEastCommand : ICommand
    {
        public void Run(Board board)
        {
            Point destiny = new(board.PlayerPosition.X + 1, board.PlayerPosition.Y);
            if (board.IsValidPoint(destiny))
                board.PlayerPosition = destiny;

            else
                Message.EdgeOfCavern();
        }

    }
    public class ShootNorthCommand : ICommand
    {
        public void Run(Board board)
        {
            Point target = new(board.PlayerPosition.X, board.PlayerPosition.Y + 1);
            board.ShootArrowAt(target);

        }

    }
    public class ShootSouthCommand : ICommand
    {
        public void Run(Board board)
        {
            Point target = new(board.PlayerPosition.X, board.PlayerPosition.Y - 1);
            board.ShootArrowAt(target);
        }

    }
    public class ShootWestCommand : ICommand
    {
        public void Run(Board board)
        {
            Point target = new(board.PlayerPosition.X - 1, board.PlayerPosition.Y);
            board.ShootArrowAt(target);
        }

    }
    public class ShootEastCommand : ICommand
    {
        public void Run(Board board)
        {
            Point target = new(board.PlayerPosition.X + 1, board.PlayerPosition.Y);
            board.ShootArrowAt(target);
        }

    }
    public class EnableFountainCommand : ICommand
    {
        public void Run(Board board)
        {
            if (board.PlayerPosition == board.FountainPosition)
            {
                board.IsEnabledFountain = true;
                Message.EnabledFountain();
            }
            else
                Message.Display("You are not in the Fountain's room.", MessageType.Descritive);

        }

    }
    public class ExitCommand : IGameStateCommand
    {
        public void Run(GameStateVerifier gameStateVerifier)
        {
            gameStateVerifier.ShouldGameStillRun = false;
        }

    }
    public class InvalidCommand : ICommand
    {
        public void Run(Board board)
        {
            Message.Display("Invalid command.", MessageType.Descritive);
        }

    }
}
