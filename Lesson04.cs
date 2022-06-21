using System.Globalization;

namespace Hitss.Lessons
{
	internal static class Lesson04
	{
		private static void Main()
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US"); // fr-FR, es-MX

			Ejemplo1();
			//Ejemplo2();
			//Ejemplo3();
			//Ejemplo4();
			//Ejemplo5();

			//Exercise2_1();
		}

		#region Ejemplo1

		// New in C# 6
		private static int Add(int a, int b) => a + b;

		//private static int Add(int a, int b)
		//{
		//	return a + b;
		//}

		private delegate int Operation(int a, int b);

		private static void Ejemplo1()
		{
			Operation instancia1 = new(Add);

			Operation instancia2 = Add;

			Operation instancia3 = (int a, int b) => a + b;

			Operation instancia3_1 = (a, b) => a + b;

			Console.WriteLine(instancia1(2, 3));

			Console.WriteLine(instancia2(2, 3));

			Console.WriteLine(instancia3(2, 3));

			Console.WriteLine(instancia3_1(2, 3));
		}

		#endregion Ejemplo1

		#region Ejemplo2

		// Func is a delegate that points to a method that accepts one or more arguments and returns a value
		private static void Ejemplo2()
		{
			// Operation == Func<int, int, int>

			Func<int, int, int> instancia1 = new(Add);

			Func<int, int, int> instancia2 = Add;

			Func<int, int, int> instancia3 = (int a, int b) => a + b;

			Console.WriteLine(instancia1(2, 3));

			Console.WriteLine(instancia2(2, 3));

			Console.WriteLine(instancia3(2, 3));
		}

		// Exercise : Create the following operations using lambdas
		private static void Exercise2_1()
		{
			//Func<int, int, int> subtract = ???;

			//Func<int, int, int> multiply = ???;

			//Func<int, int, int> divide = ???;

			//Console.WriteLine(subtract(5, 3) == 2);

			//Console.WriteLine(multiply(5, 2) == 10);

			//Console.WriteLine(divide(4, 2) == 2);
		}

		#endregion Ejemplo2

		#region Ejemplo3

		public static string Map0(DateTime? dt, Func<DateTime, string> map)
		{
			if (dt.HasValue)
			{
				return map(dt.Value);
			}
			return "N/A";
		}

		private static void Ejemplo3()
		{
			DateTime? dt1 = DateTime.Now;
			DateTime? dt2 = null;

			Console.WriteLine(Map0(dt1, x => x.ToShortDateString()));

			Console.WriteLine(Map0(dt2, x => x.ToShortDateString()));
		}

		#endregion Ejemplo3

		#region Ejemplo4

		// Extension method
		public static string Map(this DateTime? dt, Func<DateTime, String> map)
		{
			return Map0(dt, map);
		}

		private static void Ejemplo4()
		{
			DateTime? dt1 = DateTime.Now;
			DateTime? dt2 = null;

			Console.WriteLine(dt1.Map(x => x.ToString("dddd, dd MMMM yyyy", CultureInfo.CurrentCulture)));

			Console.WriteLine(dt2.Map(x => x.ToString("dddd, dd MMMM yyyy", CultureInfo.CurrentCulture)));
		}

		#endregion Ejemplo4

		#region Ejemplo5

		private static string Format(DateTime dt)
		{
			return dt.ToString("dddd, dd MMMM yyyy", CultureInfo.CurrentCulture);
		}

		private static void Ejemplo5()
		{
			DateTime? dt1 = DateTime.Now;
			DateTime? dt2 = null;

			Console.WriteLine(dt1.Map(Format));

			Console.WriteLine(dt2.Map(Format));
		}

		#endregion Ejemplo5
	}
}