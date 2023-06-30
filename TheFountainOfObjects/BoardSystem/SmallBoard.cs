namespace BoardSystem;

public class SmallBoard : Board
{
    public override Point FountainPosition { get; set; }
    public SmallBoard() : base(Size.Small)
    {
        FountainPosition = new(0, 2);
        AddEntityAt(GameEntity.Pit, new Point(1, 2));
        AddEntityAt(GameEntity.Maelstroms, new Point(2, 3));
    }
}
