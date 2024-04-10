namespace ChessLogic
{
  public class Bishop : Piece
  {
    public override PieceType Type => PieceType.Bishop;
    public override Player Color { get; }
    private static Direction[] dirs = new Direction[]
    { 
      Direction.UpLeft, 
      Direction.UpRight, 
      Direction.DownLeft, 
      Direction.DownRight 
    };

    public Bishop(Player color)
    {
      Color = color;
    }

    public override Bishop Copy()
    {
      Bishop copy = new Bishop(Color);
      copy.HasMoved = HasMoved;
      return copy;
    }

    public override IEnumerable<Move> GetMoves(Board board, Position from)
    {
      return MovePositionInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
    }
  }
}
