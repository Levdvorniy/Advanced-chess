namespace ChessBoard
{
	abstract class Piece
	{
		public int X { get; set; }
		public int Y { get; set; }

		protected Piece(int x, int y)
		{
			X = x;
			Y = y;
		}

		public abstract bool CanAttack(Piece other, List<Piece> pieces);
	}
}