using System;
using System.Linq;

namespace Hitss.Lessons
{
	// Encapsulation
	// a) Information hiding
	// b) Prevents duplicate code (not trying to solve the same problem over an over again)
	// c) Protects from unnecessary changes (black box)
	internal static class Lesson02
	{
		private class Pedido
		{
			public int Tipo { get; set; }

			public string Descripcion { get; set; }

			public decimal Importe { get; set; }
		}

		private static decimal CalcularImportePesos(Pedido pedido)
		{
			return pedido.Tipo switch
			{
				1 => pedido.Importe, // Moneda nacional
				2 => pedido.Importe * 18.35m, // Dólares
				_ => pedido.Importe * (decimal)Math.PI // Otros
			};
		}

		private static Pedido[] ObtenerPedidos()
		{
			return new[]
			{
				new Pedido{ Tipo = 1, Descripcion = "Pedido 1", Importe = 10 },
				new Pedido{ Tipo = 2, Descripcion = "Pedido 2", Importe = 15 },
				new Pedido{ Tipo = 2, Descripcion = "Pedido 3", Importe = 20 },
				new Pedido{ Tipo = 1, Descripcion = "Pedido 4", Importe = 25 },
				new Pedido{ Tipo = 3, Descripcion = "Pedido 5", Importe = 30 },
			};
		}

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

		private static void Ejemplo1()
		{
			static int add(int a, int b)
			{
				return a + b;
			}

			Console.WriteLine(add(5, 5));

			static int add2(int a, int b) => a + b;

			Console.WriteLine(add2(5, 5));
		}

		#endregion Ejemplo1

		#region Ejemplo2

		private static void Ejemplo2()
		{
			var importe1 = CalcularImporte1();
			Console.WriteLine($"El importe total es {importe1:c}");

			var importe2 = CalcularImporte2();
			Console.WriteLine($"El importe total es {importe2:c}");

			var importeNacionales = CalcularImporteNacionales();
			Console.WriteLine($"El importe de pedidos nacionales es {importeNacionales:c}");
		}

		private static decimal CalcularImporte1()
		{
			var total = 0m;
			var pedidos = ObtenerPedidos();

			for (int i = 0; i < pedidos.Length; i++)
			{
				total += pedidos[i].Importe;
			}
			return total;
		}

		private static decimal CalcularImporte2()
		{
			var total = 0m;
			var pedidos = ObtenerPedidos();

			int i = pedidos.Length - 1;
			while (i > 0)
			{
				total += pedidos[i].Importe;
				i--;
			}
			return total;
		}

		private static decimal CalcularImporteNacionales()
		{
			var total = 0m;
			var pedidos = ObtenerPedidos();

			for (int i = pedidos.Length - 1; i >= 0; i--)
			{
				if (pedidos[i].Tipo == 1)
				{
					total += pedidos[i].Importe;
				}
			}
			return total;
		}

		#endregion Ejemplo2

		#region Ejemplo3

		//private static decimal CalcularXXX()
		//{
		//	var total = 0m; 1
		//	var arreglo = ObtenerXXX(); 2 <-
		//	for (int i = 0; i < arreglo.Length; i++) 3
		//	{
		//		total += arreglo[i].Propiedad; 4 <-
		//	}
		//	return total; 5
		//}

		private interface IObtenerImporte
		{
			decimal Obtener(Pedido pedido);
		}

		private static decimal Calcular(Pedido[] pedidos, IObtenerImporte operacion)
		{
			var total = 0m;
			for (int i = 0; i < pedidos.Length; i++)
			{
				total += operacion.Obtener(pedidos[i]);
			}
			return total;
		}

		private static void Ejemplo3()
		{
			var pedidos = ObtenerPedidos();

			var importeTotal = Calcular(pedidos, new ObtenerImporteSimple());
			Console.WriteLine($"El importe total es {importeTotal:c}");

			var importeTotalConIva = Calcular(pedidos, new ObtenerImporteIVA());
			Console.WriteLine($"El importe total con IVA es {importeTotalConIva:c}"); // importeTotal * 1.16m

			var importeTotalPesos = Calcular(pedidos, new ObtenerImportePesos());
			Console.WriteLine($"El importe total en moneda nacional es {importeTotalPesos:c}");
		}

		private class ObtenerImporteSimple :
			IObtenerImporte
		{
			public decimal Obtener(Pedido pedido)
			{
				return pedido.Importe;
			}
		}

		private class ObtenerImporteIVA :
			IObtenerImporte
		{
			public decimal Obtener(Pedido pedido)
			{
				return pedido.Importe * 1.16m;
			}
		}

		private class ObtenerImportePesos :
			IObtenerImporte
		{
			public decimal Obtener(Pedido pedido)
			{
				return CalcularImportePesos(pedido);
			}
		}

		#endregion Ejemplo3

		#region Ejemplo4

		private delegate decimal DelegadoObtenerImporte(Pedido pedido);

		private static void Ejemplo4()
		{
			static decimal obtenerImporte(Pedido pedido)
			{
				return pedido.Importe;
			}

			DelegadoObtenerImporte instancia1 = new DelegadoObtenerImporte(obtenerImporte);

			DelegadoObtenerImporte instancia2 = obtenerImporte;

			DelegadoObtenerImporte instancia3 = (Pedido pedido) => pedido.Importe;

			var pedido = new Pedido
			{
				Importe = 100m
			};

			Console.WriteLine(instancia1(pedido) == instancia2(pedido));
		}

		#endregion Ejemplo4

		#region Ejemplo5

		private static decimal Calcular(Pedido[] pedidos, DelegadoObtenerImporte operacion)
		{
			var total = 0m;
			for (int i = 0; i < pedidos.Length; i++)
			{
				total += operacion(pedidos[i]);
			}
			return total;
		}

		private static void Ejemplo5()
		{
			var pedidos = ObtenerPedidos();

			static decimal obtenerImporte(Pedido pedido) => pedido.Importe;

			var importeTotal = Calcular(pedidos, obtenerImporte);
			Console.WriteLine($"El importe total es {importeTotal:c}");

			var importeTotalConIva = Calcular(pedidos, (Pedido pedido) => pedido.Importe * 1.16m);
			Console.WriteLine($"El importe total con IVA es {importeTotalConIva:c}");

			var importeTotalPesos = Calcular(pedidos, CalcularImportePesos);
			Console.WriteLine($"El importe total en moneda nacional es {importeTotalPesos:c}");
		}

		#endregion Ejemplo5

		#region Ejemplo6

		private static void Ejemplo6()
		{
			var pedidos = ObtenerPedidos();

			// Importe en pesos

			var importeTotalPesos = pedidos
				.Select(CalcularImportePesos)
				.Sum();

			Console.WriteLine($"El importe total en moneda nacional es {importeTotalPesos:c}");

			static bool esNacional(Pedido pedido) => pedido.Tipo == 1;

			// Importe nacionales

			var importeNacionales = pedidos
				.Where(esNacional)
				.Select(CalcularImportePesos)
				.Sum();

			Console.WriteLine($"El importe de pedidos nacionales es {importeNacionales:c}");
		}

		#endregion Ejemplo6
	}
}