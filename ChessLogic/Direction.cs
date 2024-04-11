namespace ChessLogic
{
  public class Direction
  {
    public readonly static Direction North = new(-1, 0);
    public readonly static Direction South = new(1, 0);
    public readonly static Direction East = new(0, 1);
    public readonly static Direction West = new(0, -1);
    public readonly static Direction NorthEast = North + East;
    public readonly static Direction NorthWest = North + West;
    public readonly static Direction SouthEast = South + East;
    public readonly static Direction SouthWest = South + West;
    
    public int RowDelta { get; }
    public int ColumnDelta { get; }
    public Direction(int row, int column)
    {
      RowDelta = row;
      ColumnDelta = column;
    }

    public static Direction operator +(Direction dir1, Direction dir2)
    {
      return new Direction(dir1.RowDelta + dir2.RowDelta, dir1.ColumnDelta + dir2.ColumnDelta);
    }
    public static Direction operator *(Direction dir, int scalar)
    {
      return new Direction(dir.RowDelta * scalar, dir.ColumnDelta * scalar);
    }
  }
}
