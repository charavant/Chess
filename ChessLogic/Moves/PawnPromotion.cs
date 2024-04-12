namespace ChessLogic
{
  public class PawnPromotion : Move
  {
    public override MoveType Type => MoveType.PawnPromotion;

    public override Position FromPos  { get; }

    public override Position ToPos { get; }

    private readonly PieceType _newType;

    public PawnPromotion(Position from, Position to, PieceType newType)
    {
      FromPos = from;
      ToPos = to;
      _newType = newType;
    }

    private Piece CreatePromotionPiece(Player color)
    {
      return _newType switch
      {
        PieceType.Knight => new Knight(color),
        PieceType.Bishop => new Bishop(color),
        PieceType.Rook => new Rook(color),
        _ => new Queen(color)
      };
    }

    public override bool Execute(Board board)
    {
      Piece pawn = board[FromPos];
      board[FromPos] = null;

      Piece promotionPiece = CreatePromotionPiece(pawn.Color);
      promotionPiece.HasMoved = true;
      board[ToPos] = promotionPiece;

      return true;
    }
  }
}
