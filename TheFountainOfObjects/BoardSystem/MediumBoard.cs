namespace BoardSystem;

public class MediumBoard : Board
{
    public override Point FountainPosition { get; set; }
    public override int Dimension { get; set; }

    public MediumBoard() : base(6)
    {
        FountainPosition = new(3, 5);
        AddEntityAt(GameEntity.Pit, new Point(1, 4));
        AddEntityAt(GameEntity.Pit, new Point(3, 2));

        AddEntityAt(GameEntity.Maelstroms, new Point(5, 3));

        AddEntityAt(GameEntity.Amarok, new Point(0, 5));
        AddEntityAt(GameEntity.Amarok, new Point(3, 0));
    }
}

