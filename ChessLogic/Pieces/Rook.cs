
namespace ChessLogic
{
  public class Rook(Player color) : Piece
  {
    public override PieceType Type => PieceType.Rook;
    public override Player Color { get; } = color;
    private static Direction[] dirs =
    [
      Direction.Up, 
      Direction.Down, 
      Direction.Left, 
      Direction.Right 
    ];

    public override Rook Copy()
    {
      Rook copy = new(Color)
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
