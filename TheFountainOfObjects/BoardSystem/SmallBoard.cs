namespace BoardSystem;

public class SmallBoard : Board
{
    public override Point FountainPosition { get; set; }
    public override int Dimension { get; set; }

    public SmallBoard() : base(4)
    {
        FountainPosition = new(0, 2);
        AddEntityAt(GameEntity.Pit, new Point(1, 2));
        AddEntityAt(GameEntity.Maelstroms, new Point(3, 3));
        AddEntityAt(GameEntity.Amarok, new Point(3, 0));
    }
}

