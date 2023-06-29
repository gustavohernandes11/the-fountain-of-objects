namespace BoardSystem;

public class Board
{
    int Dimension { get; set; }

    Dictionary<Point, List<GameEntity>> Content { get; set; }

    readonly List<GameEntity> emptyEntityList = new();

    public Board(int dimension)
    {
        Dimension = dimension;
        Content = new Dictionary<Point, List<GameEntity>>();

        for (int i = 0; i < Dimension; i++)
        {
            for (int j = 0; j < Dimension; j++)
            {
                Content.Add(new Point(i, j), emptyEntityList);
            }
        }

    }

    public void DisplayBoard()
    {
        foreach (var square in Content)
        {
            Console.WriteLine($"position: {square.Key}");
            foreach (var element in square.Value)
            {
                Console.WriteLine(element);
            }
        }
    }
    
    public List<GameEntity> GetEntitiesAt(Point point)
    {
        _ = Content.TryGetValue(point, out List<GameEntity>? valueFound);
        return valueFound ?? emptyEntityList;
    }

    public bool IsValidPoint(Point point) =>
        Content.TryGetValue(point, out _);

    public bool HasEntityAt(GameEntity entity, Point point) =>
        IsValidPoint(point) && Content[point].Contains(entity);

    public void AddEntityAt(GameEntity entity, Point point) =>
        Content[point].Add(entity);

    public bool HasEntityAdjacent(GameEntity entity, Point point)
    {
        if (
            HasEntityAt(entity, new Point(point.X - 1, point.Y - 1)) ||
            HasEntityAt(entity, new Point(point.X, point.Y - 1)) ||
            HasEntityAt(entity, new Point(point.X + 1, point.Y - 1)) ||

            HasEntityAt(entity, new Point(point.X - 1, point.Y + 1)) ||
            HasEntityAt(entity, new Point(point.X, point.Y + 1)) ||
            HasEntityAt(entity, new Point(point.X + 1, point.Y + 1)) ||

            HasEntityAt(entity, new Point(point.X - 1, point.Y)) ||
            HasEntityAt(entity, new Point(point.X + 1, point.Y))

        ) { return true; }
        return false;
    }

    public bool IsEmpty(Point point) =>
        IsValidPoint(point) && Content[point].Count > 0;

    public void Set(GameEntity entity, Point point)
    {
        if (IsValidPoint(point)) Content[point] = new List<GameEntity>() { entity };
    }

    public bool MoveEntityTo(GameEntity entity, Point initial, Point destiny)
    {
        if (HasEntityAt(entity, initial) && IsValidPoint(destiny))
        {
            Content[initial].Remove(entity);
            AddEntityAt(entity, destiny);
            return true;
        }
        return false;
    }

}

