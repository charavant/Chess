namespace ChessLogic
{
  public class Direction
  {
    public readonly static Direction Up = new(-1, 0);
    public readonly static Direction Down = new(1, 0);
    public readonly static Direction Left = new(0, -1);
    public readonly static Direction Right = new(0, 1);
    public readonly static Direction UpLeft = Up + Left;
    public readonly static Direction UpRight = Up + Right;
    public readonly static Direction DownLeft = Right + Left;
    public readonly static Direction DownRight = Down + Right;
    
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
