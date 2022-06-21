using static Hitss.Lessons.Helpers;

namespace Hitss.Lessons
{
	// https://en.wikipedia.org/wiki/Data_wrangling
	// https://github.com/udacity/AIPND/blob/master/Matplotlib/data/pokemon.csv
	internal static class Lesson05
	{
		private const string pokeArchivo = @"..\..\..\Resources\pokemon.csv";

		private static void Main()
		{
			Ejemplo1();
			//Ejemplo2();
			//Ejemplo3();
			//Ejemplo4();

			//Ejercicios();
		}

		#region Ejemplo1

		private static void Ejemplo1()
		{
			var name = "Bulbasaur";
			name.Do(Print);
		}

		#endregion Ejemplo1

		#region Ejemplo2

		private static void Ejemplo2()
		{
			var data = "Bulbasaur,88.1,1,65,65,45";
			var items = data.Split(",");

			var name = items[0];
			Print(name);
		}

		#endregion Ejemplo2

		#region Ejemplo3

		private static void Ejemplo3()
		{
			var number = double.Parse("14.5");
			Print(number);

			var data = "88.1,1,65,65,45";
			var items = data
				.Split(",");

			items.ForEach(Print);

			// Select: Projects each element of a sequence into a new form
			// 88.1 + 1 + 65 + 65 + 45 = 264.1
			items.
				Select(double.Parse) // String => Double
				.Sum()
				.Do(Print);
		}

		#endregion Ejemplo3

		#region Ejemplo4

		private static IEnumerable<string> ObtenerDatosPokemon()
		{
			return File
				.ReadLines(pokeArchivo)
				.Skip(1); // Skip the header
		}

		private static void Ejemplo4()
		{
			var pokemons = ObtenerDatosPokemon();
			pokemons.ForEach(Print);
		}

		#endregion Ejemplo4

		#region Ejercicios

		private static void Ejercicios()
		{
			var pokemones = ObtenerDatosPokemon();

			// Desplegar el nombre de todos los pokémones
			pokemones
				//.Select(split)
				//.Select(obtener nombre)
				.ForEach(Print);

			// Desplegar el nombre de todos los pokémones fuego
			pokemones
				//.Select(split)
				//.Where(es tipo fuego)
				//.Select(obtener nombre)
				.ForEach(Print);

			// Total de pokémones fuego
			pokemones
				//.Select(split)
				//.Where(es tipo fuego)
				//.Count()
				.Do(Print);

			// ¿Cuántos pokémones hay en la primera generación? 151

			// ¿Qué tipo de pokémon es "raichu"? Electric

			// Peso del pokémon más pesado = 999.9 kg

			// Altura del pokémon más alto = 14.5 m

			// Peso total de todos los pokémones = 49,849.29999999998 kg

			// Número de pokémonos voladores = 95

			// Desplegar el nombre de todos los pokémones en orden alfabético

			// Promedio altura = 1.162454 m

			// Promedio peso = 61.77113 kg
		}

		#endregion Ejercicios
	}
}