using System;
using System.Collections.Generic;

namespace Hitss.Lessons
{
	internal static class Helpers
	{
		public static void Print<T>(T source)
		{
			Console.WriteLine(source.ToString());
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (var item in source)
			{
				action(item);
			}
		}

		public static void Do<T>(this T source, Action<T> action)
		{
			action(source);
		}
	}
}