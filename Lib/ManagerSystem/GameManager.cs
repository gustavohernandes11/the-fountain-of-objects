using BoardSystem;
using MessageSystem;
using Utilities;

namespace ManagerSystem;


class GameManager
{
    Board Current { get; set; }
    bool ShouldGameStillRun { get; set; }
    bool IsEnabledFountain { get; set; }
    Point PlayerPosition { get; set; }
    Point FountainPosition { get; set; }


    public GameManager(Board board)
    {
        Current = board;
        ShouldGameStillRun = true;
        IsEnabledFountain = false;
        PlayerPosition = new Point(0, 0);
        FountainPosition = new(0, 2);
    }

    public void Init()
    {
        Message.Intro();
        while (ShouldGameStillRun)
        {
            Message.Divisor();
            DisplayPlayerPosition();
            Command command = Helper.GetPrompt("What do you want to do?");
            HandlePromptCommand(command);
            VerifyGameState();
        }
    }

    private void HandlePromptCommand(Command command)
    {
        Point destiny;

        switch (command)
        {
            case Command.Help:
                Message.Help();
                break;

            case Command.Exit:
                ShouldGameStillRun = false;
                break;

            case Command.EnableFountain:
                if (PlayerPosition == FountainPosition)
                {
                    IsEnabledFountain = true;
                    Message.EnabledFountain();
                }
                else
                    Message.Display("You are not in the Fountain's room.", MessageType.Descritive);

                break;

            case Command.MoveEast:
                destiny = new(PlayerPosition.X + 1, PlayerPosition.Y);
                if (Current.IsValidPoint(destiny))
                    PlayerPosition = destiny;

                else
                    Message.EdgeOfCavern();
                break;

            case Command.MoveWest:
                destiny = new(PlayerPosition.X - 1, PlayerPosition.Y);
                if (Current.IsValidPoint(destiny))
                    PlayerPosition = destiny;

                else
                    Message.EdgeOfCavern();

                break;

            case Command.MoveNorth:
                destiny = new(PlayerPosition.X, PlayerPosition.Y + 1);
                if (Current.IsValidPoint(destiny))
                    PlayerPosition = destiny;

                else
                    Message.EdgeOfCavern();

                break;

            case Command.MoveSouth:
                destiny = new(PlayerPosition.X, PlayerPosition.Y - 1);
                if (Current.IsValidPoint(destiny))
                    PlayerPosition = destiny;

                else
                    Message.EdgeOfCavern();

                break;
        }
    }

    private void VerifyGameState()
    {
        if (ShouldGameStillRun == false) {
            return;
        }
        if (PlayerPosition == new Point(0, 0) && IsEnabledFountain)
        {
            Message.Win();
            ShouldGameStillRun = false;
            return;
        }

        if (PlayerPosition == FountainPosition && !IsEnabledFountain)
            Message.FoundFountain();

        if (PlayerPosition == new Point(0, 0))
            Message.EntranceOfCavern();
    }

    private void DisplayPlayerPosition()
    {
        Message.Display($"You are in the room at (Row={PlayerPosition.X}, Column={PlayerPosition.Y}).", MessageType.Descritive);
    }
    private void DisplayHelp()
    {
        Message.Display($"Deus ajuda quem cedo madruga.", MessageType.Descritive);
    }
}


