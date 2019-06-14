using System;
using System.Collections.Generic;
using System.Linq;

namespace Hitss.Lessons
{
	internal static class Lesson01
	{
		private static void Example1()
		{
			for (int i = 0; i < 10; i++)
			{
				PrintHello(i);
			}
		}

		private static void Example2()
		{
			var actions = new List<Action>();

			for (int i = 0; i < 10; i++)
			{
				actions.Add(() => PrintHello(i));
			}

			Run(actions);
		}

		private static void Example3()
		{
			var actions = new List<Action>();

			for (int i = 0; i < 10; i++)
			{
				var count = i;
				actions.Add(() => PrintHello(i));
			}

			Run(actions);
		}

		private static void Example4()
		{
			var actions = new List<Action>();

			foreach (var i in Enumerable.Range(0, 10))
			{
				actions.Add(() => PrintHello(i));
			}

			Run(actions);
		}

		private static void Main()
		{
			//var x = 0;
			//Action a1 = () => PrintHello(x);
			//a1();

			Example1();
			//Example2();
			//Example3();
			//Example4();
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