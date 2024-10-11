namespace ChessBoard
{
	class Shadow : Piece
	{
		private List<(int, int)> shadows = new List<(int, int)>();

		public Shadow(int x, int y) : base(x, y) { }

		public override bool CanAttack(Piece other, List<Piece> pieces)
		{
			return (X == other.X || Y == other.Y || Math.Abs(X - other.X) == Math.Abs(Y - other.Y)) && 
				!shadows.Contains((other.X, other.Y)) && Program.IsPathClear(X, Y, other.X, other.Y, pieces);
		}

		public void LeaveShadow(int targetX, int targetY)
		{
			int dx = Math.Sign(targetX - X);
			int dy = Math.Sign(targetY - Y);

			int currentX = X + dx;
			int currentY = Y + dy;

			while (currentX != targetX || currentY != targetY)
			{
				shadows.Add((currentX, currentY));
				currentX += dx;
				currentY += dy;
			}
		}
	}
}