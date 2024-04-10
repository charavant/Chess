using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.Moves
{
  public class NormalMove : Move
  {
    public override MoveType Type => MoveType.Normal;

    public override Position FromPos { get; }

    public override Position ToPos { get; }

    public NormalMove(Position from, Position to)
    {
      FromPos = from;
      ToPos = to;
    }

    public override void Execute(Board board)
    {
      board[ToPos] = board[FromPos];
      board[FromPos] = null;
    }
  }
}
