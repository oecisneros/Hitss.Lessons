using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Hitss.Lessons
{
	internal static class Lesson03
	{
		// https://es.wikipedia.org/wiki/Sucesi%C3%B3n_de_Fibonacci
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

		// https://es.wikipedia.org/wiki/Factorial
		private static int Factorial(int x)
		{
			return x switch
			{
				0 => 1,
				_ => Factorial(x - 1) * x
			};
		}

		private static int SlowFibonacci(int x)
		{
			Thread.Sleep(300);
			return Fibonacci(x);
		}

		private static void Main()
		{
			Ejemplo1();
			//Ejemplo2();
			//Ejemplo3();
			//Ejemplo4();
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
				Console.WriteLine(SlowFibonacci(12));
			}
		}

		#endregion Ejemplo2

		#region Ejemplo3

		private static void Ejemplo3()
		{
			Console.WriteLine("Fibonacci with cache");

			var fastFibonacci = Memoize(SlowFibonacci);
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(fastFibonacci(12));
			}
		}

		#endregion Ejemplo3

		#region Ejemplo4

		// https://en.wikipedia.org/wiki/Decorator_pattern
		private interface IFactorialGenerator
		{
			int Generate(int x);
		}

		private class SlowFactorialGenerator :
			IFactorialGenerator
		{
			public int Generate(int x)
			{
				Thread.Sleep(300);
				return Factorial(x);
			}
		}

		private class FastFactorialDecorator :
			IFactorialGenerator
		{
			private IFactorialGenerator _generator;
			private readonly ConcurrentDictionary<int, int> _cache;

			public FastFactorialDecorator(IFactorialGenerator generator)
			{
				_generator = generator;
				_cache = new ConcurrentDictionary<int, int>();
			}

			public int Generate(int x)
			{
				return _cache.GetOrAdd(x, _generator.Generate);
			}
		}

		private static void Ejemplo4()
		{
			Console.WriteLine("Factorial without cache");

			var slowFactorial = new SlowFactorialGenerator();
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(slowFactorial.Generate(5));
			}

			Console.WriteLine("Factorial with cache");

			IFactorialGenerator fastFactorial = new FastFactorialDecorator(slowFactorial);
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(fastFactorial.Generate(5));
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