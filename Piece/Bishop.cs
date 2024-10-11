namespace ChessBoard
{
	class Bishop : Piece
	{
		public Bishop(int x, int y) : base(x, y) { }

		public override bool CanAttack(Piece other, List<Piece> pieces)
		{
			return Math.Abs(X - other.X) == Math.Abs(Y - other.Y) && Program.IsPathClear(X, Y, other.X, other.Y, pieces);
		}
	}
}