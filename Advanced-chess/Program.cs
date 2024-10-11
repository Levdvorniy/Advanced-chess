namespace ChessBoard
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = "pieces.txt";

			List<Piece> pieces = ReadPiecesFile(filePath);

			DrawBoard(pieces);
			CheckAttacks(pieces);
		}

		static List<Piece> ReadPiecesFile(string filePath)
		{
			List<Piece> pieces = new List<Piece>();
			HashSet<(int, int)> occupiedPositions = new HashSet<(int, int)>();

			if (File.Exists(filePath))
			{
				string[] lines = File.ReadAllLines(filePath);
				foreach (string line in lines)
				{
					pieces.Add(ParsePiece(line, occupiedPositions));
				}
			}
			else
			{
				Console.WriteLine("File not found: " + filePath);
				throw new FileNotFoundException();
			}

			return pieces;
		}

		static Piece ParsePiece(string line, HashSet<(int, int)> occupiedPositions)
		{
			string[] parts = line.Split(' ');
			if (parts.Length == 3 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
			{
				if (x >= 0 && x < 8 && y >= 0 && y < 8)
				{
					if (!occupiedPositions.Contains((x, y)))
					{
						Piece piece = parts[0].ToLower() switch
						{
							"king" => new King(x, y),
							"queen" => new Queen(x, y),
							"rook" => new Rook(x, y),
							"bishop" => new Bishop(x, y),
							"knight" => new Knight(x, y),
							"shadow" => new Shadow(x, y),
							_ => throw new NotImplementedException(),
						};

						if (piece != null)
						{
							occupiedPositions.Add((x, y));

							return piece;
						}
					}
					else
					{
						Console.WriteLine($"Position ({x}, {y}) is already occupied. Skipping {parts[0]}.");
						throw new NotImplementedException();
					}
				}
				else
				{
					Console.WriteLine($"Invalid coordinates for {parts[0]} at ({x}, {y}). Coordinates must be within the 8x8 board.");
					throw new NotImplementedException();
				}
			}
			Console.WriteLine($"Invalid piece.");
			throw new NotImplementedException();
		}
		static void DrawBoard(List<Piece> pieces)
		{
			char[,] board = new char[8, 8];

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					board[i, j] = '.';
				}
			}

			foreach (var piece in pieces)
			{
				char symbol = piece switch
				{
					King => 'K',
					Queen => 'Q',
					Rook => 'R',
					Bishop => 'B',
					Knight => 'N',
					Shadow => 'S',
					_ => '?'
				};
				board[piece.X, piece.Y] = symbol;
			}

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					Console.Write(board[i, j] + " ");
				}
				Console.WriteLine();
			}
		}

		static void CheckAttacks(List<Piece> pieces)
		{
			for (int i = 0; i < pieces.Count; i++)
			{
				for (int j = 0; j < pieces.Count; j++)
				{
					if (i != j && pieces[i].CanAttack(pieces[j], pieces))
					{
						Console.WriteLine($"{pieces[i].GetType().Name} at ({pieces[i].X}, {pieces[i].Y}) attacks {pieces[j].GetType().Name} at ({pieces[j].X}, {pieces[j].Y})");
					}
				}
			}
		}

		public static bool IsPathClear(int startX, int startY, int endX, int endY, List<Piece> pieces)
		{
			int dx = Math.Sign(endX - startX);
			int dy = Math.Sign(endY - startY);

			int currentX = startX + dx;
			int currentY = startY + dy;

			while (currentX != endX || currentY != endY)
			{
				foreach (var piece in pieces)
				{
					if (piece.X == currentX && piece.Y == currentY)
					{
						return false;
					}
				}
				currentX += dx;
				currentY += dy;
			}

			return true;
		}
	}
}

