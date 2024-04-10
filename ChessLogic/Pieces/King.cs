
namespace ChessLogic
{
  public class King(Player color) : Piece
  {
    public override PieceType Type => PieceType.King;
    public override Player Color { get; } = color;
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

    public override King Copy()
    {
      King copy = new(Color)
      {
        HasMoved = HasMoved
      };
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

        if(board.IsEmpty(to) || board[to].Color != Color)
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
  }
}
