
namespace ChessLogic
{
  internal class Knight(Player color) : Piece
  {
    public override PieceType Type => PieceType.Knight;
    public override Player Color { get; } = color;

    public override Knight Copy()
    {
      Knight copy = new(Color)
      {
        HasMoved = HasMoved
      };
      return copy;
    }

    private static IEnumerable<Position> PotentialToPositions(Position from)
    {
      foreach(Direction vDir in new Direction[] { Direction.Up, Direction.Down })
      {
        foreach(Direction hDir in new Direction[] { Direction.Left, Direction.Right })
        {
          yield return from + vDir * 2 + hDir;
          yield return from + hDir * 2 + vDir;
        }
      }
    }

    private IEnumerable<Position> MovePositions(Board board, Position from)
    {
      return PotentialToPositions(from).Where(pos => Board.IsInside(pos) && (board.IsEmpty(pos) || board[pos].Color != Color));
    }

    public override IEnumerable<Move> GetMoves(Board board, Position position)
    {
      return MovePositions(board, position).Select(to => new NormalMove(position, to));
    }
  }
}
