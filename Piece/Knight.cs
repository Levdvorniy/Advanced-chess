namespace ChessBoard
{
	class Knight : Piece
	{
		public Knight(int x, int y) : base(x, y) { }

		public override bool CanAttack(Piece other, List<Piece> pieces)
		{
			int dx = Math.Abs(X - other.X);
			int dy = Math.Abs(Y - other.Y);
			return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
		}
	}
}