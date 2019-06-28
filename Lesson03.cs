using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Hitss.Lessons
{
	// https://es.wikipedia.org/wiki/Sucesi%C3%B3n_de_Fibonacci
	internal static class Lesson03
	{
		// https://es.wikipedia.org/wiki/Factorial
		private static int Factorial(int x)
		{
			return x switch
			{
				0 => 1,
				_ => Factorial(x - 1) * x
			};
		}

		private static int Fibonacci(int x)
		{
			// This code has two problems...
			// Can you find them?
			return x switch
			{
				0 => 0,
				1 => 1,
				_ => Fibonacci(x - 1) + Fibonacci(x - 2)
			};
		}

		private static int Fibonacci2(int x)
		{
			Thread.Sleep(300);
			return Fibonacci(x);
		}

		private static void Main()
		{
			//Ejemplo1();
			//Ejemplo2();
			//Ejemplo3();
			Ejemplo4();
		}

		#region Ejemplo1

		private static void Ejemplo1()
		{
			Console.WriteLine($"El número fibonacci de 12 es {Fibonacci(12)}"); // 144
		}

		#endregion Ejemplo1

		#region Ejemplo2

		private static void Ejemplo2()
		{
			Console.WriteLine("Fibonacci without cache");

			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(Fibonacci2(12));
			}
		}

		#endregion Ejemplo2

		#region Ejemplo3

		private static void Ejemplo3()
		{
			Console.WriteLine("Fibonacci with cache");

			var fibonacciCache = Memoize(Fibonacci2);
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(fibonacciCache(12));
			}
		}

		#endregion Ejemplo3

		#region Ejemplo4

		private static void Ejemplo4()
		{
			Console.WriteLine("Factorial with cache");

			var factorialCache = Memoize(Factorial);
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(factorialCache(5));
			}
		}

		#endregion Ejemplo4

		// https://en.wikipedia.org/wiki/Memoization
		// Is an optimization technique used primarily to speed up computer programs
		// by storing the results of expensive function calls and returning the cached result
		// when the same inputs occur again
		private static Func<int, int> Memoize(Func<int, int> factory)
		{
			var cache = new ConcurrentDictionary<int, int>();

			return (int key) =>
			{
				return cache.GetOrAdd(key, factory);
			};
		}
	}
}