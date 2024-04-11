namespace ChessLogic
{
  public class Queen(Player color) : Piece
  {
    public override PieceType Type => PieceType.Queen;
    public override Player Color { get; } = color;
    private static Direction[] dirs =
    [
      Direction.North, 
      Direction.South, 
      Direction.East, 
      Direction.West,
      Direction.NorthEast, 
      Direction.NorthWest, 
      Direction.SouthEast, 
      Direction.SouthWest
    ];

    public override Piece Copy()
    {
      Queen copy = new(Color)
      {
        HasMoved = HasMoved
      };
      return copy;
    }

    public override IEnumerable<Move> GetMoves(Board board, Position from)
    {
      return MovePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
    }
  }
}
