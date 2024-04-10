
namespace ChessLogic
{
  public class King : Piece
  {
    public override PieceType Type => PieceType.King;
    public override Player Color { get; }
    private static readonly Direction[] dirs =
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

    public King(Player color)
    {
      Color = color;
    }

    public override King Copy()
    {
      var copy = new King(Color) { HasMoved = HasMoved };
      return copy;
    }

    private IEnumerable<Position> MovePositions(Position from, Board board)
    {
      foreach (Direction dir in dirs)
      {
        Position to = from + dir;
        if (Board.IsInside(to))
        {
          continue;
        }

        if (board.IsEmpty(to) || board[to].Color != Color)
        {
          yield return to;
        }
      }
    }

    public override IEnumerable<Move> GetMoves(Board board, Position from)
    {
      foreach (Position to in MovePositions(from,board))
      {
        yield return new NormalMove(from, to);
      }
    }

    public override bool CanCaptureOpponentKing(Position from, Board board)
    {
      return MovePositions(from, board).Any(to =>
      {
        Piece piece = board[to];
        return piece != null && piece.Type == PieceType.King && piece.Color == Color.Opponent();
      });
    }
  }
}
