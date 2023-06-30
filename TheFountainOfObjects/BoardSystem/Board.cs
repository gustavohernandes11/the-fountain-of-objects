namespace BoardSystem;


public abstract class Board
{
    public bool IsEnabledFountain { get; set; }
    Size Size { get; set; }
    int Dimension { get; set; }
    public Point PlayerPosition { get; set; }
    public abstract Point FountainPosition { get; set; }

    Dictionary<Point, List<GameEntity>> Content { get; set; }
    readonly Dictionary<Size, int> dimentionsPerSize = new()
        {
            { Size.Small, 4 },
            { Size.Medium, 6 },
            { Size.Large, 8 }
        };



    public Board(Size size)
    {
        PlayerPosition = new Point(0, 0);
        FountainPosition = new(0, 2);
        IsEnabledFountain = false;
        Size = size;
        Dimension = dimentionsPerSize[Size];

        Content = new Dictionary<Point, List<GameEntity>>();

        for (int i = 0; i < Dimension; i++)
        {
            for (int j = 0; j < Dimension; j++)
            {
                List<GameEntity> emptyEntityList = new();
                Content.Add(new Point(i, j), emptyEntityList);
            }
        }

    }

    public void DisplayBoard()
    {
        string room = "■ ";
        string highlightedRoom = "P ";
        string[] rows = new string[Dimension];

        for (int i = 0; i < Dimension; i++)
        {
            for (int j = 0; j < Dimension; j++)
            {
                if (PlayerPosition.X == j && PlayerPosition.Y == i)
                {
                    rows[i] += highlightedRoom;
                }
                else
                {
                    rows[i] += room;
                }
            }
        }
        Array.Reverse(rows);
        Console.WriteLine("");
        foreach (var row in rows)
        {
            Console.WriteLine(row);
        }
        Console.WriteLine("");
    }

    public List<GameEntity> GetEntitiesAt(Point point)
    {
        _ = Content.TryGetValue(point, out List<GameEntity>? valueFound);
        List<GameEntity> emptyEntityList = new();
        return valueFound ?? emptyEntityList;
    }

    public bool IsValidPoint(Point point) =>
        Content.TryGetValue(point, out _);

    public bool HasEntityAt(GameEntity entity, Point point) =>
        IsValidPoint(point) && Content[point].Contains(entity);

    public void AddEntityAt(GameEntity entity, Point point)
    {
        if (IsValidPoint(point))
        {
            if (!Content.ContainsKey(point))
            {
                Content[point] = new List<GameEntity>();
            }

            Content[point].Add(entity);
        }
    }

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

    public void MoveEntityTo(GameEntity entity, Point initial, Point destiny)
    {
        if (!HasEntityAt(entity, initial)) throw new Exception("This entity is not in this position.");

        if (!IsValidPoint(destiny))
        {
            if (destiny.X > Dimension - 1)
            {
                destiny = new Point(destiny.X - Dimension - 1, destiny.Y);
            };
            if (destiny.Y > Dimension - 1)
            {
                destiny = new Point(destiny.X, destiny.Y - Dimension - 1);
            };
        }

        Content[initial].Remove(entity);
        AddEntityAt(entity, destiny);
    }
    public void MovePlayerTo(Point point)
    {
        if (IsValidPoint(point))
        {
            PlayerPosition = point;
        }
        else
        {
            point = AdjustPoint(point);
            PlayerPosition = point;
        }
    }
    Point AdjustPoint(Point point)
    {
        if (point.X > Dimension - 1)
        {
            point = new Point(point.X - Dimension - 1, point.Y);
        };
        if (point.Y > Dimension - 1)
        {
            point = new Point(point.X, point.Y - Dimension - 1);
        };

        if (point.X < 0)
        {
            point = new Point(point.X + Dimension, point.Y);
        };
        if (point.Y < 0)
        {
            point = new Point(point.X, point.Y + Dimension);
        };
        return point;
    }
}

