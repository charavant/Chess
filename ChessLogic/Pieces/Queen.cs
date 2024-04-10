namespace ChessLogic
{
  public class Queen : Piece
  {
    public override PieceType Type => PieceType.Queen;
    public override Player Color { get; }
    private static Direction[] dirs = new Direction[]
    { 
      Direction.Up, 
      Direction.Down, 
      Direction.Left, 
      Direction.Right,
      Direction.UpLeft, 
      Direction.UpRight, 
      Direction.DownLeft, 
      Direction.DownRight 
    };
    public Queen(Player color)
    {
      Color = color;
    }

    public override Queen Copy()
    {
      Queen copy = new Queen(Color);
      copy.HasMoved = HasMoved;
      return copy;
    }

    public override IEnumerable<Move> GetMoves(Board board, Position from)
    {
      return MovePositionInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
    }
  }
}
