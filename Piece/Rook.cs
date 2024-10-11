namespace ChessBoard
{
	class Rook : Piece
	{
		public Rook(int x, int y) : base(x, y) { }

		public override bool CanAttack(Piece other, List<Piece> pieces)
		{
			return (X == other.X || Y == other.Y) && Program.IsPathClear(X, Y, other.X, other.Y, pieces);
		}
	}
}