namespace week2.tougher1 {
	class Program {
		public static int x;
		public static int y;
		public static int count;

		static void Main(string[] args) {
			bool visited = false;
			HashSet<Tuple<int, int>> visitedSet = new();
			Random random = new();
			
			while (!visited) {
				int number = random.Next(1, 5);
				switch (number) {
					case 1:
						x++;
						break;
					case 2:
						x--;
						break;
					case 3:
						y++;
						break;
					case 4:
						y--;
						break;
				}
				Tuple<int, int> tuple = new(x, y);
				Console.WriteLine(tuple);
				count++;
				if (visitedSet.Contains(tuple)) {
					visited = true;
					Console.WriteLine("Visited");
					break;
				}
				visitedSet.Add(tuple);

			}
			Console.WriteLine($"Moves: {count}");
		}
	}
}
