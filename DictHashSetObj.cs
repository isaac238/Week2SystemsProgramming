namespace Week2.done {
	class Program {
		public static void Main(string[] args) {
			Dictionary<string, HashSet<Driver>> teams = new();
			teams.Add("McLaren", new HashSet<Driver>(){new Driver("Norris", 4), new Driver("Piastri", 81)});
			teams.Add("Ferrari", new HashSet<Driver>(){new Driver("Leclerc", 16), new Driver("Sainz", 55)});
			Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(teams));

		}

	}

	class Driver {
		public string name { get; set; } = "";
		public int number { get; set; }

		public Driver(string name, int number) {
			this.name = name;
			this.number = number;
		}
	}
}
