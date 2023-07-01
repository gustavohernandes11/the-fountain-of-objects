using BoardSystem;
using MessageSystem;
namespace ManagerSystem;


public class GameStateVerifier
{
    Board Board { get; set; }
    public bool ShouldGameStillRun { get; set; }

    public GameStateVerifier(Board board)
    {
        Board = board;
        ShouldGameStillRun = true;
    }
    public void Verify()
    {
        if (!ShouldGameStillRun) return;

        CheckWinCondition();
        CheckMaelstroms();
        CheckPit();
        CheckAmarok();
        CheckEntitiesNearby();
        CheckFountain();
        CheckEntranceOfCavern();
    }

    void CheckWinCondition()
    {
        if (Board.PlayerPosition == new Point(0, 0) && Board.IsEnabledFountain)
        {
            Message.Win();
            ShouldGameStillRun = false;
        }
    }

    void CheckMaelstroms()
    {
        if (Board.HasEntityAt(GameEntity.Maelstroms, Board.PlayerPosition))
        {
            Message.AttackedByMaelstroms();
            Board.MoveEntityTo(GameEntity.Maelstroms, Board.PlayerPosition,
                new Point(Board.PlayerPosition.X + 2, Board.PlayerPosition.Y + 1));

            Board.MovePlayerTo(
                new Point(Board.PlayerPosition.X - 2, Board.PlayerPosition.Y - 1));
        }
    }
    void CheckPit()
    {
        if (Board.HasEntityAt(GameEntity.Pit, Board.PlayerPosition))
        {
            Message.FellIntoPit();
            ShouldGameStillRun = false;
            return;
        }
    }
    void CheckAmarok()
    {
        if (Board.HasEntityAt(GameEntity.Amarok, Board.PlayerPosition))
        {
            Message.AttackedByAmarok();
            ShouldGameStillRun = false;
            return;
        }
    }
    void CheckEntitiesNearby()
    {
        if (Board.HasEntityAdjacent(GameEntity.Amarok, Board.PlayerPosition))
            Message.AmarokNearby();

        if (Board.HasEntityAdjacent(GameEntity.Maelstroms, Board.PlayerPosition))
            Message.MaelstromsNearby();

        if (Board.HasEntityAdjacent(GameEntity.Pit, Board.PlayerPosition))
            Message.PitNearby();
    }
    void CheckFountain()
    {
        if (Board.PlayerPosition == Board.FountainPosition && !Board.IsEnabledFountain)
            Message.FoundFountain();
    }
    void CheckEntranceOfCavern()
    {
        if (Board.PlayerPosition == new Point(0, 0))
            Message.EntranceOfCavern();
    }
}

