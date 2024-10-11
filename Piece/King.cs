namespace ChessBoard
{
	class King : Piece
	{
		public King(int x, int y) : base(x, y) { }

		public override bool CanAttack(Piece other, List<Piece> pieces)
		{
			return Math.Abs(X - other.X) <= 1 && Math.Abs(Y - other.Y) <= 1;
		}
	}
}