namespace BoardSystem;

public class MediumBoard : Board
{
    public override Point FountainPosition { get; set; }
    public MediumBoard() : base(Size.Medium)
    {
        FountainPosition = new(3, 5);
        AddEntityAt(GameEntity.Pit, new Point(4, 1));
        AddEntityAt(GameEntity.Pit, new Point(3, 4));

        AddEntityAt(GameEntity.Maelstroms, new Point(4, 3));

        AddEntityAt(GameEntity.Amarok, new Point(0, 5));
        AddEntityAt(GameEntity.Amarok, new Point(3, 0));
    }
}

