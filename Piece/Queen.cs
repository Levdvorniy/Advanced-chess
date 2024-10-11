namespace ChessBoard
{
	class Queen : Piece
	{
		public Queen(int x, int y) : base(x, y) { }

		public override bool CanAttack(Piece other, List<Piece> pieces)
		{
			return (X == other.X || Y == other.Y || Math.Abs(X - other.X) == Math.Abs(Y - other.Y)) && Program.IsPathClear(X, Y, other.X, other.Y, pieces);
		}
	}
}