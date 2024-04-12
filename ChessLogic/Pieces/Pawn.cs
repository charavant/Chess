
using ChessLogic.Moves;

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
        forward = Direction.North;
      }
      else if (color == Player.Black)
      {
        forward = Direction.South;
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

    private static IEnumerable<Move> PromotionMoves(Position from, Position to)
    {
      yield return new PawnPromotion(from, to, PieceType.Knight);
      yield return new PawnPromotion(from, to, PieceType.Bishop);
      yield return new PawnPromotion(from, to, PieceType.Rook);
      yield return new PawnPromotion(from, to, PieceType.Queen);
    }

    private IEnumerable<Move> ForwardMoves(Position from, Board board)
    {
      Position oneMovePos = from + forward;

      if (CanMoveTo(oneMovePos, board))
      {
        if (oneMovePos.Row == 0 || oneMovePos.Row == 7)
        {
          foreach (Move promMove in PromotionMoves(from, oneMovePos))
          {
            yield return promMove;
          }
        }
        else
        {
          yield return new NormalMove(from, oneMovePos);
        }
        Position twoMovePos = from + forward * 2;

        if (!HasMoved && CanMoveTo(twoMovePos, board))
        {
          yield return new DoublePawn(from, twoMovePos);
        }
      }
    }

    private IEnumerable<Move> DiagonalMoves(Position from, Board board)
    {
      foreach (Direction dir in new Direction[] { Direction.West, Direction.East })
      {
        Position to = from + forward + dir;

        if(to == board.GetPawnSkipPosition(Color.Opponent()))
        {
          yield return new EnPassant(from, to);
        }
        else if (CanCaptureAt(to, board, Color))
        {
          if (to.Row == 0 || to.Row == 7)
          {
            foreach (Move promMove in PromotionMoves(from, to))
            {
              yield return promMove;
            }
          }
          else
          {
            yield return new NormalMove(from, to);
          }
        }
      }
    }

    public override IEnumerable<Move> GetMoves(Board board, Position position)
    {
      return ForwardMoves(position, board).Concat(DiagonalMoves(position, board));
    }

    public override bool CanCaptureOpponentKing(Position from, Board board)
    {
      return DiagonalMoves(from, board).Any(move =>
      {
        Piece piece = board[move.ToPos];
        return piece != null && piece.Type == PieceType.King;
      });
    }
  }
}
