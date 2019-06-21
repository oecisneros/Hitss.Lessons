using System;
using System.Collections.Generic;
using System.Linq;

namespace Hitss.Lessons
{
	internal static class Lesson01
	{
		private static void Main()
		{
			//var x = 0;
			//Action a1 = () => PrintHello(x);
			//a1();

			Ejemplo1();
			Ejemplo2();
			Ejemplo3();
			Ejemplo4();
		}

		private static void Ejemplo1()
		{
			for (int i = 0; i < 10; i++)
			{
				PrintHello(i);
			}
		}

		private static void Ejemplo2()
		{
			var actions = new List<Action>();

			for (int i = 0; i < 10; i++)
			{
				actions.Add(() => PrintHello(i));
			}

			Run(actions);
		}

		private static void Ejemplo3()
		{
			var actions = new List<Action>();

			for (int i = 0; i < 10; i++)
			{
				var count = i;
				actions.Add(() => PrintHello(i));
			}

			Run(actions);
		}

		private static void Ejemplo4()
		{
			var actions = new List<Action>();

			foreach (var i in Enumerable.Range(0, 10))
			{
				actions.Add(() => PrintHello(i));
			}

			Run(actions);
		}

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
			var name = "Kurama";

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