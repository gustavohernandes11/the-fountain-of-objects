namespace BoardSystem;

public class LargeBoard : Board
{
    public override Point FountainPosition { get; set; }
    public override int Dimension { get; set; }

    public LargeBoard() : base(8)
    {
        FountainPosition = new(6, 6);
        AddEntityAt(GameEntity.Pit, new Point(4, 1));
        AddEntityAt(GameEntity.Pit, new Point(3, 4));
        AddEntityAt(GameEntity.Pit, new Point(0, 5));
        AddEntityAt(GameEntity.Pit, new Point(7, 2));

        AddEntityAt(GameEntity.Maelstroms, new Point(2, 6));
        AddEntityAt(GameEntity.Maelstroms, new Point(7, 5));

        AddEntityAt(GameEntity.Amarok, new Point(7, 0));
        AddEntityAt(GameEntity.Amarok, new Point(6, 7));
        AddEntityAt(GameEntity.Amarok, new Point(3, 0));
    }

}

