﻿namespace ChessLogic
{
  internal class Knight : Piece
  {
    public override PieceType Type => PieceType.Knight;
    public override Player Color { get; }

    public Knight(Player color)
    {
      Color = color;
    }

    public override Knight Copy()
    {
      Knight copy = new Knight(Color);
      copy.HasMoved = HasMoved;
      return copy;
    }
  }
}
