namespace ChessLogic
{
  public class Queen(Player color) : Piece
  {
    public override PieceType Type => PieceType.Queen;
    public override Player Color { get; } = color;
    private static Direction[] dirs =
    [
      Direction.Up, 
      Direction.Down, 
      Direction.Left, 
      Direction.Right,
      Direction.UpLeft, 
      Direction.UpRight, 
      Direction.DownLeft, 
      Direction.DownRight 
    ];

    public override Queen Copy()
    {
      Queen copy = new(Color)
      {
        HasMoved = HasMoved
      };
      return copy;
    }

    public override IEnumerable<Move> GetMoves(Board board, Position from)
    {
      return MovePositionInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
    }
  }
}
