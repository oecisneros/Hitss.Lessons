namespace Hitss.Lessons
{
	internal static class Lesson01
	{
		private sealed class Closure
		{
			public int Counter { get; set; }
		}

		private static void Main()
		{
			Ejemplo1();
			//Ejemplo2();
			//Ejemplo2_1();
			//Ejemplo3();
			//Ejemplo3_1();
			//Ejemplo4();
			//Test();
		}

		#region Ejemplo1

		private static void Ejemplo1()
		{
			for (int i = 0; i < 10; i++)
			{
				PrintHello(i);
			}
		}

		#endregion Ejemplo1

		#region Ejemplo2

		private static void Ejemplo2()
		{
			var actions = new List<Action>();

			for (int i = 0; i < 10; i++)
			{
				actions.Add(() => PrintHello(i));
			}

			Run(actions);
		}

		private static void Ejemplo2_1()
		{
			var actions = new List<Action>();

			var closure = new Closure();
			for (closure.Counter = 0; closure.Counter < 10; closure.Counter++)
			{
				actions.Add(() => PrintHello(closure.Counter));
			}

			Run(actions);
		}

		#endregion Ejemplo2

		#region Ejemplo3

		private static void Ejemplo3()
		{
			var actions = new List<Action>();

			for (int i = 0; i < 10; i++)
			{
				var count = i;
				actions.Add(() => PrintHello(count));
			}

			Run(actions);
		}

		private static void Ejemplo3_1()
		{
			var actions = new List<Action>();

			for (int i = 0; i < 10; i++)
			{
				var closure = new Closure
				{
					Counter = i
				};

				actions.Add(() => PrintHello(closure.Counter));
			}

			Run(actions);
		}

		#endregion Ejemplo3

		#region Ejemplo4

		private static void Ejemplo4()
		{
			var actions = new List<Action>();

			foreach (var i in Enumerable.Range(0, 10))
			{
				actions.Add(() => PrintHello(i));
			}

			Run(actions);
		}

		#endregion Ejemplo4

		private static void PrintHello(int i)
		{
			Console.WriteLine($"Hello World, {i}");
		}

		private static void Run(IEnumerable<Action> actions)
		{
			foreach (var action in actions)
			{
				action();
			}
		}

		private static void Test()
		{
			var name = "Hitss";

			void print()
			{
				Console.WriteLine(name);
			}

			//  This will prevent using the variables from the containing method in the local function
			//static void error()
			//{
			//	Console.WriteLine(name);
			//}

			print();
		}
	}
}