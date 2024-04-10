
namespace ChessLogic
{
  public class Pawn : Piece
  {
    public override PieceType Type => PieceType.Pawn;
    public override Player Color { get; }
    private readonly Direction forward;

    public Pawn(Player color)
    {
      Color = color;

      if (color == Player.White)
      {
        forward = Direction.Up;
      }
      else if (color == Player.Black)
      {
        forward = Direction.Down;
      }
    }

    public override Piece Copy()
    {
      Pawn copy = new(Color)
      {
        HasMoved = HasMoved
      };
      return copy;
    }

    private static bool CanMoveTo(Position pos, Board board)
    {
      return Board.IsInside(pos) && board.IsEmpty(pos);
    }

    private static bool CanCaptureAt(Position pos, Board board, Player color)
    {
      return Board.IsInside(pos) && !board.IsEmpty(pos) && board[pos].Color != color;
    }

    private IEnumerable<Move> ForwardMoves(Position from, Board board)
    {
      Position oneMovePos = from + forward;

      if (CanMoveTo(oneMovePos, board))
      {
        yield return new NormalMove(from, oneMovePos);
        Position twoMovePos = from + forward * 2;

        if (!HasMoved && CanMoveTo(twoMovePos, board))
        {
          yield return new NormalMove(from, twoMovePos);
        }
      }
    }

    private IEnumerable<Move> DiagonalMoves(Position from, Board board)
    {
      foreach (Direction dir in new Direction[] { Direction.Left, Direction.Right })
      {
        Position pos = from + forward + dir;

        if (CanCaptureAt(pos, board, Color))
        {
          yield return new NormalMove(from, pos);
        }
      }
    }

    public override IEnumerable<Move> GetMoves(Board board, Position position)
    {
      return ForwardMoves(position, board).Concat(DiagonalMoves(position, board));
    }
  }
}
