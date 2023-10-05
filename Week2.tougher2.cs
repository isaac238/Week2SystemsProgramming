// Uses a list with object (Line 11)
namespace Week2.tougher2 {
	public enum Attending {
		Yes,
		Maybe,
		No
	}

	class Program {
		public static void Main(string[] args) {
			List<Guest> guests = new List<Guest>(){ new Guest("Bob", false, Attending.Yes), new Guest("Alice", true, Attending.Maybe), new Guest("Joe", false, Attending.No) };
			while (true) {
				Console.WriteLine(@"
1. display the guest list
2. add guests to the list (make sure names are all unique)
3. update guests responses (turn a Maybe to a No, or whatever)
4. query how many guests are definitely attended
5. query how many guests could potentially attend (Yes + Maybe)
6. query how many vegetarian vs non-vegetarians are attending
				");

				Console.Write("Please enter a number (1,...,6): ");
				string input = Console.ReadLine() ?? "";

				switch(input) {
					case "1":
						DisplayGuestList(guests);
						break;
					case "2":
						AddGuestToList(guests);
						break;
					case "3":
						EditGuest(guests);
						break;
					case "4":
						GetAttending(guests);
						break;
					case "5":
						MaybeAttending(guests);
						break;
					case "6":
						DietaryAttendance(guests);
						break;
				}
				Console.Write("Press any key to continue...");
				Console.ReadLine();
				Console.Clear();

			}
		}

		public static void DisplayGuestList(List<Guest> guests) {
			guests.ForEach(guest => Console.WriteLine(guest.Formatted()));
		}

		public static void AddGuestToList(List<Guest> guests) {
			Console.Write("Please enter a name: ");
			string name = Console.ReadLine() ?? "";

			if (guests.Any(guest => guest.name == name)) {
				Console.WriteLine("Name already exists");
				return;
			}

			Console.Write("Please enter a vegetarian status (true/false): ");
			bool vegetarian = bool.Parse(Console.ReadLine() ?? "");

			Console.Write("Please enter an attending status (Yes, Maybe, No): ");
			string attending = Console.ReadLine() ?? "";

			Guest newGuest = new Guest(name, vegetarian, Attending.Maybe);

			if (Enum.TryParse<Attending>(attending, out Attending result)) {
				newGuest.attending = result;
			} else {
				Console.WriteLine("Invalid attending status enter (Yes, Maybe, No)");
				return;
			}

			guests.Add(newGuest);
		}

		public static void EditGuest(List<Guest> guests) {
			DisplayGuestList(guests);
			Console.Write("Please enter a name: ");
			string name = Console.ReadLine() ?? "";

			if (!guests.Any(guest => guest.name == name)) {
				Console.WriteLine("Guest does not exist");
				return;
			}

			Guest guest = guests.Find(guest => guest.name == name) ?? new Guest("", false, Attending.Maybe);
			Console.Clear();
			Console.WriteLine(guest.Formatted());

			Console.Write("Please enter a vegetarian status (true/false): ");
			bool vegetarian = bool.Parse(Console.ReadLine() ?? guest.vegetarian.ToString());

			Console.Write("Please enter an attending status (true/false): ");
			string attending = Console.ReadLine() ?? guest.attending.ToString();

			if (Enum.TryParse<Attending>(attending, out Attending result)) {
				guest.attending = result;
			} else {
				Console.WriteLine("Invalid attending status enter (Yes, Maybe, No)");
				return;
			}

			guest.vegetarian = vegetarian;

			Console.WriteLine(guest.Formatted());
			
		}

		public static void GetAttending(List<Guest> guests) {
			DisplayGuestList(guests);
			Console.WriteLine($"There are {guests.Count(guest => guest.attending == Attending.Yes)} guests attending");
		}

		public static void MaybeAttending(List<Guest> guests) {
			DisplayGuestList(guests);
			Console.WriteLine($"There are {guests.Count(guest => guest.attending == Attending.Yes || guest.attending == Attending.Maybe)} guests potentially attending");
		}

		public static void DietaryAttendance(List<Guest> guests) {
			DisplayGuestList(guests);
			Console.WriteLine($"There are {guests.Count(guest => guest.vegetarian)} vegetarians attending");
			Console.WriteLine($"There are {guests.Count(guest => !guest.vegetarian)} non-vegetarians attending");
		}
	}

	class Guest {
		public string name { get; set; }
		public bool vegetarian { get; set; }
		public Attending attending { get; set; } = Attending.Maybe;

		public Guest(string name, bool vegetarian, Attending attending) {
			this.name = name;
			this.vegetarian = vegetarian;
			this.attending = attending;
		}

		public string Formatted() {
			return @$"-------------------------------
Name: {name}
Vegetarian: {vegetarian}
Attending: {attending}
";
		}
	}
}
