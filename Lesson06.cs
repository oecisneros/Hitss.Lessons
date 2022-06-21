namespace Hitss.Lessons
{
	internal static class Lesson06
	{
		private const string pokeArchivo = @"..\..\..\Resources\pokemon.csv";

		private static void Main()
		{
			Ejemplo1();
			//Ejemplo2();
			//Ejemplo3();
			//Ejemplo4();
			//Ejemplo5();
			//Ejemplo6();
		}

		#region Ejemplo1

		private static IEnumerable<int> ObtenerNumeros()
		{
			Console.WriteLine("Obtener números");
			return new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		}

		private static void Ejemplo1()
		{
			foreach (var i in ObtenerNumeros())
			{
				Console.WriteLine(i);
			}
		}

		#endregion Ejemplo1

		#region Ejemplo2

		// "IEnumerable as a book and an IEnumerator as a bookmark..." John Skeet
		private static void Ejemplo2()
		{
			IEnumerable<int> enumerable = ObtenerNumeros();

			// https://en.wikipedia.org/wiki/Iterator
			using IEnumerator<int> enumerator = enumerable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				int i = enumerator.Current;
				Console.WriteLine(i);
			}
		}

		#endregion Ejemplo2

		#region Ejemplo3

		// "There can be multiple bookmarks within a book at any one time..." John Skeet
		private static void Ejemplo3()
		{
			IEnumerable<int> enumerable = ObtenerNumeros();

			using IEnumerator<int> enumerator1 = enumerable.GetEnumerator();
			using IEnumerator<int> enumerator2 = enumerable.GetEnumerator();

			while (enumerator1.MoveNext())
			{
				int i = enumerator1.Current;
				if (i % 2 == 0)
				{
					if (enumerator2.MoveNext())
					{
						int j = enumerator2.Current;
						Console.WriteLine(j);
					}
				}
			}
		}

		#endregion Ejemplo3

		#region Ejemplo4

		private static void Ejemplo4()
		{
			var datos = ObtenerDatosPokemon();

			foreach (var pokeLinea in datos)
			{
				Console.WriteLine(pokeLinea);
			}
		}

		// https://en.wikipedia.org/wiki/Generator_(computer_programming)
		private static IEnumerable<string[]> ObtenerDatosPokemon()
		{
			//var e1 = File.ReadAllLines(pokeArchivo);
			//var e2 = Enumerable.Skip(e1, 1);
			//var e3 = Enumerable.Take(e2, 25);
			//return e3;

			return File
				.ReadLines(pokeArchivo)
				.Skip(1) // Skip the header
				.Take(25)
				.Select(x =>
				{
					//Console.WriteLine("uno");
					return x;
				})
				.Select(x =>
				{
					//Console.WriteLine("dos");
					Thread.Sleep(100);
					return x.Split(",");
				});
		}

		#endregion Ejemplo4

		#region Ejemplo5

		private static void Ejemplo5()
		{
			var datos = ObtenerDatosPokemon();

			Console.Write("Count: ");
			var count = datos.Count();
			Console.WriteLine(count);

			Console.Write("Max: ");
			var max = datos.Select(x => x[4]).Max();
			Console.WriteLine(max);

			Console.Write("Min: ");
			var min = datos.Select(x => x[4]).Min();
			Console.WriteLine(min);

			Console.Write("ToArray: ");
			var species = datos.Select(x => x[1]).ToArray();
			Console.WriteLine(species.Length);
		}

		#endregion Ejemplo5

		#region Ejemplo6

		private static void Ejemplo6()
		{
			ShowMemory("Init");

			var source = Enumerable.Range(0, 1_000_000).ToList();
			ShowMemory("After range");

			Console.WriteLine();
			Ejemplo6_1(source);

			Console.WriteLine();
			Ejemplo6_2(source);
		}

		private static void Ejemplo6_1(List<int> source)
		{
			var mapResult = source.Map(x => x * 2);
			ShowMemory("After map");

			var filterResult = mapResult.Filter(x => x % 2 == 0);
			ShowMemory("After filter");
		}

		private static void Ejemplo6_2(List<int> source)
		{
			var mapResult1 = source.Select(x => x * 2);
			ShowMemory("After select");

			var filterResult1 = mapResult1.Where(x => x % 2 == 0);
			ShowMemory("After Where");
		}

		private static void ShowMemory(string message)
		{
			Console.WriteLine($"{message} => {(GC.GetTotalMemory(true) / 1024):N} KB");
		}

		private static List<int> Map(this List<int> list, Func<int, int> func)
		{
			var newList = new List<int>();
			for (int i = 0; i < list.Count; i++)
			{
				newList.Add(func(i));
			}
			return newList;
		}

		private static List<int> Filter(this List<int> list, Func<int, bool> func)
		{
			var newList = new List<int>();
			for (int i = 0; i < list.Count; i++)
			{
				if (func(i))
				{
					newList.Add(i);
				}
			}
			return newList;
		}

		#endregion Ejemplo6
	}
}