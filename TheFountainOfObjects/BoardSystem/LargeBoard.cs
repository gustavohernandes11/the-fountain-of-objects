namespace BoardSystem;

public class LargeBoard : Board
{
    public override Point FountainPosition { get; set; }

    public LargeBoard() : base(Size.Large)
    {
        FountainPosition = new(6, 6);
        AddEntityAt(GameEntity.Pit, new Point(4, 1));
        AddEntityAt(GameEntity.Pit, new Point(3, 4));
        AddEntityAt(GameEntity.Pit, new Point(7, 7));
        AddEntityAt(GameEntity.Pit, new Point(5, 2));

        AddEntityAt(GameEntity.Maelstroms, new Point(7, 6));
        AddEntityAt(GameEntity.Maelstroms, new Point(4, 2));

        AddEntityAt(GameEntity.Amarok, new Point(7, 0));
        AddEntityAt(GameEntity.Amarok, new Point(6, 7));
        AddEntityAt(GameEntity.Amarok, new Point(3, 3));
    }

}

