using System;

namespace LinkedListsWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            int option;

            do
            {
                Console.WriteLine("\n=======================");
                Console.WriteLine("         MENÚ       ");
                Console.WriteLine("=======================");
                Console.WriteLine("1. Adicionar");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atrás");
                Console.WriteLine("4. Ordenar descendentemente");
                Console.WriteLine("5. Mostrar la(s) moda(s)");
                Console.WriteLine("6. Mostrar gráfico");
                Console.WriteLine("7. Existe");
                Console.WriteLine("8. Eliminar una ocurrencia");
                Console.WriteLine("9. Eliminar todas las ocurrencias");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    continue;
                }

                Console.WriteLine();
                switch (option)
                {
                    case 1:
                        Console.Write("Ingrese: ");
                        string input = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(input))
                        {
                            string[] values = input.Split(',');
                            foreach (var val in values)
                            {
                                string item = val.Trim();
                                if (!string.IsNullOrEmpty(item))
                                {
                                    list.Add(item);
                                }
                            }
                            Console.WriteLine("¡Elementos adicionados");
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida.");
                        }
                        break;
                    case 2:
                        Console.Write("Lista hacia adelante: ");
                        list.DisplayForward();
                        break;
                    case 3:
                        Console.Write("Lista hacia atrás: ");
                        list.DisplayBackward();
                        break;
                    case 4:
                        list.SortDescending();
                        Console.Write("Lista ordenada descendentemente: ");
                        list.DisplayForward();
                        Console.WriteLine("La lista ha sido ordenada descendentemente (punteros invertidos).");
                        break;
                    case 5:
                        list.DisplayModes();
                        break;
                    case 6:
                        Console.WriteLine("Gráfico de ocurrencias:");
                        list.DisplayChart();
                        break;
                    case 7:
                        Console.Write("Ingrese el valor a buscar: ");
                        string searchVal = Console.ReadLine();
                        if (searchVal != null) searchVal = searchVal.Trim();
                        if (list.Exists(searchVal))
                            Console.WriteLine($"Sí, el valor '{searchVal}' existe en la lista.");
                        else
                            Console.WriteLine($"No, el valor '{searchVal}' no existe en la lista.");
                        break;
                    case 8:
                        if (list.DeleteFirst())
                        {
                            Console.Write("Lista actual: ");
                            list.DisplayForward();
                            Console.WriteLine("¡Primer elemento eliminado automáticamente con éxito!");
                        }
                        else
                        {
                            Console.WriteLine("La lista está vacía, no hay elementos para eliminar.");
                        }
                        break;
                    case 9:
                        list.ClearList();
                        Console.WriteLine("¡Toda la lista ha sido borrada con éxito!");
                        break;
                    case 0:
                        Console.WriteLine("Saliendo de la aplicación...");
                        break;
                    default:
                        Console.WriteLine("Opción fuera de rango. Intente nuevamente.");
                        break;
                }
            } while (option != 0);
        }
    }
}