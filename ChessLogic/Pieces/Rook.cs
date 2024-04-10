
namespace ChessLogic
{
  public class Rook : Piece
  {
    public override PieceType Type => PieceType.Rook;
    public override Player Color { get; }
    private static Direction[] dirs = new Direction[]
    { 
      Direction.Up, 
      Direction.Down, 
      Direction.Left, 
      Direction.Right 
    };

    public Rook(Player color)
    {
      Color = color;
    }

    public override Rook Copy()
    {
      Rook copy = new Rook(Color);
      copy.HasMoved = HasMoved;
      return copy;
    }

    public override IEnumerable<Move> GetMoves(Board board, Position from)
    {
      return MovePositionInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
    }
  }
}
