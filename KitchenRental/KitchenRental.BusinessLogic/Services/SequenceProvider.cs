using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace KitchenRental.BusinessLogic.Services
{
	public class SequenceProvider
	{
		public int Next()
		{
			var json = File.ReadAllText("sequence.txt");
			var sequence = JsonSerializer.Deserialize<List<int>>(json);

			var next = sequence.First();
			sequence.Remove(next);

			json = JsonSerializer.Serialize(sequence);
			File.WriteAllText("sequence.txt", json);

			return next;
		}

		public void Add(int id)
		{
			var json = File.ReadAllText("sequence.txt");
			var sequence = JsonSerializer.Deserialize<List<int>>(json);

			sequence.Add(id);

			json = JsonSerializer.Serialize(sequence);
			File.WriteAllText("sequence.txt", json);
		}
	}
}