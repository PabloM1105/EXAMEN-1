// Examen, Pablo César Henández Monney

namespace TiendaAguaDePipa
{
    class Program
    {
        static List<string> nombres = new List<string>();
        static List<int> pequeñas = new List<int>();
        static List<int> medianas = new List<int>();
        static List<int> grandes = new List<int>();
        static List<double> totales = new List<double>();

        static void Main(string[] args)
        {
            byte op = 0;

            do
            {
                Console.Clear();
                Console.WriteLine(" TIENDA DE AGUA DE PIPA ");
                Console.WriteLine("1. Registrar compra");
                Console.WriteLine("2. Total de ventas");
                Console.WriteLine("3. Borrar una venta");
                Console.WriteLine("4. Modificar una venta");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Elija una opción:");

                byte.TryParse(Console.ReadLine(), out op);

                switch (op)
                {
                    case 1:
                        RegistrarCompra();
                        break;
                    case 2:
                        VerVentas();
                        break;
                    case 3:
                        BorrarVenta();
                        break;
                    case 4:
                        ModificarVenta();
                        break;
                    case 5:
                        Console.WriteLine("Cerrar");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta. Presione espacio para continuar.");
                        Console.ReadKey();
                        break;
                }

            } while (op != 5);

            Console.WriteLine("Gracias por comprar con nosotros, Adiós");
        }

        static void RegistrarCompra()
        {
            Console.Clear();
            Console.WriteLine(" REGISTRAR COMPRA ");

            string nombre;
            do
            {
                Console.Write("Nombre del cliente: ");
                nombre = Console.ReadLine();
            } while (!ValidarTexto(nombre));

            int p = LeerCantidad("¿Cuántas botellas pequeñas?: ");
            int m = LeerCantidad("¿Cuántas botellas medianas?: ");
            int g = LeerCantidad("¿Cuántas botellas grandes?: ");

            double total = p * 800 + m * 1200 + g * 1800;

            nombres.Add(nombre);
            pequeñas.Add(p);
            medianas.Add(m);
            grandes.Add(g);
            totales.Add(total);

            Console.WriteLine($"Venta registrada. Total: {total} colones");
            Console.WriteLine("Presione espacio para continuar.");
            Console.ReadKey();
        }

        static void VerVentas()
        {
            Console.Clear();
            Console.WriteLine(" TOTAL DE VENTAS ");

            if (nombres.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas.");
            }
            else
            {
                double totalGeneral = 0;

                for (int i = 0; i < nombres.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Cliente: {nombres[i]} - Total: {totales[i]} colones");
                    totalGeneral += totales[i];
                }

                Console.WriteLine($"\nTotal de ventas: {totalGeneral} colenes");
            }

            Console.WriteLine("Presione espacio para continuar.");
            Console.ReadKey();
        }

        static void BorrarVenta()
        {
            Console.Clear();
            Console.WriteLine(" BORRAR UNA VENTA ");

            if (nombres.Count == 0)
            {
                Console.WriteLine("No hay ventas para borrar.");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese el nombre del cliente a borrar: ");
            string nombre = Console.ReadLine();

            int index = nombres.FindIndex(n => n.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (index != -1)
            {
                nombres.RemoveAt(index);
                pequeñas.RemoveAt(index);
                medianas.RemoveAt(index);
                grandes.RemoveAt(index);
                totales.RemoveAt(index);

                Console.WriteLine("Venta borrada correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontro esa venta.");
            }

            Console.WriteLine("Presione espacio para continuar.");
            Console.ReadKey();
        }

        static void ModificarVenta()
        {
            Console.Clear();
            Console.WriteLine(" MODIFICAR UNA VENTA ");

            if (nombres.Count == 0)
            {
                Console.WriteLine("No hay ventas para modificar.");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese el nombre del cliente a modificar: ");
            string nombre = Console.ReadLine();

            int index = nombres.FindIndex(n => n.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (index != -1)
            {
                Console.WriteLine("Ingrese la modificación ");

                int p = LeerCantidad("¿Cuántas botellas pequeñas?: ");
                int m = LeerCantidad("¿Cuántas botellas medianas?: ");
                int g = LeerCantidad("¿Cuántas botellas grandes?: ");

                double total = p * 800 + m * 1200 + g * 1800;

                pequeñas[index] = p;
                medianas[index] = m;
                grandes[index] = g;
                totales[index] = total;

                Console.WriteLine("Venta modificada correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontro esa venta.");
            }

            Console.WriteLine("Presione espacio para continuar.");
            Console.ReadKey();
        }

        static int LeerCantidad(string mensaje)
        {
            int cantidad;
            string entrada;
            do
            {
                Console.Write(mensaje);
                entrada = Console.ReadLine();
            } while (!int.TryParse(entrada, out cantidad) || cantidad < 0);

            return cantidad;
        }

        static bool ValidarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c)) return false;
            }
            return true;
        }
    }
}