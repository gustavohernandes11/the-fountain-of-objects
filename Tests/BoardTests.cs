using BoardSystem;
namespace TheFountainOfObjectsTests;

public class BoardTests
{

    [Fact]
    public void HasEntityAt_ReturnFalseWhenNot()
    {
        SmallBoard board = new SmallBoard();
        Point point = new Point(0, 0);
        var result = board.HasEntityAt(GameEntity.Amarok, point);
        Assert.False(result);
    }

    [Fact]
    public void HasEntityAt_ReturnTrueWhenDo()
    {
        SmallBoard board = new SmallBoard();
        Point point = new(0, 0);
        board.AddEntityAt(GameEntity.Amarok, point);
        var result = board.HasEntityAt(GameEntity.Amarok, point);

        Assert.True(result);
    }
    [Fact]
    public void AddEntityAt_ShouldAddProperly()
    {
        SmallBoard board = new SmallBoard();
        Point point = new(1, 1);
        var beforeAdd = board.HasEntityAt(GameEntity.Pit, point);
        board.AddEntityAt(GameEntity.Pit, point);
        var afterAdd = board.HasEntityAt(GameEntity.Pit, point);

        Assert.False(beforeAdd);
        Assert.True(afterAdd);
    }
    [Fact]
    public void AddEntityAt_ShouldNotAffectOtherPoints()
    {
        SmallBoard board = new SmallBoard();
        Point pointToBeAdded = new(1, 1);
        Point intactPoint = new(0, 0);

        var beforeAdd = board.HasEntityAt(GameEntity.Pit, intactPoint);
        board.AddEntityAt(GameEntity.Pit, pointToBeAdded);
        var afterAdd = board.HasEntityAt(GameEntity.Pit, pointToBeAdded);
        var anotherPlace = board.HasEntityAt(GameEntity.Pit, intactPoint);

        Assert.False(beforeAdd);
        Assert.True(afterAdd);
        Assert.False(anotherPlace);
    }

}
