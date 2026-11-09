using Backend;

var list = new DoublyLinkedList<string>();
var option = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.Write("Ingrese el valor: ");
            list.Add(Console.ReadLine()!);
            break;
        case "2":
            Console.WriteLine(list);
            break;
        case "3":
            Console.WriteLine(list.ToStringReverse());
            break;
        case "4":
            list.SortDescending();
            Console.WriteLine("Lista ordenada descendentemente.");
            break;
        case "5":
            var modes = list.GetModes();
            if (modes.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else if (modes.Count == 1)
            {
                Console.WriteLine($"La moda es {modes[0]}.");
            }
            else
            {
                Console.WriteLine($"Las modas son {string.Join(", ", modes.Take(modes.Count - 1))} y {modes[^1]}.");
            }
            break;
        case "6":
            var graph = list.ToStringGraph();
            Console.Write(graph == string.Empty ? "La lista está vacía." + Environment.NewLine : graph);
            break;
        case "7":
            Console.Write("Ingrese el valor: ");
            var itemToSearch = Console.ReadLine()!;
            Console.WriteLine(list.Contains(itemToSearch)
                ? $"El elemento '{itemToSearch}' sí existe."
                : $"No existe el elemento '{itemToSearch}'.");
            break;
        case "8":
            Console.Write("Ingrese el valor: ");
            var itemToRemove = Console.ReadLine()!;
            Console.WriteLine(list.Remove(itemToRemove)
                ? $"Se eliminó una ocurrencia de '{itemToRemove}'."
                : $"No existe el elemento '{itemToRemove}'.");
            break;
        case "9":
            Console.Write("Ingrese el valor: ");
            var itemToRemoveAll = Console.ReadLine()!;
            var removed = list.RemoveAll(itemToRemoveAll);
            Console.WriteLine(removed == 0
                ? $"No existe el elemento '{itemToRemoveAll}'."
                : removed == 1
                    ? $"Se eliminó 1 ocurrencia de '{itemToRemoveAll}'."
                    : $"Se eliminaron {removed} ocurrencias de '{itemToRemoveAll}'.");
            break;
        case "0":
            Console.WriteLine("Hasta luego.");
            break;
        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine("1. Adicionar.");
    Console.WriteLine("2. Mostrar hacia adelante.");
    Console.WriteLine("3. Mostrar hacia atrás.");
    Console.WriteLine("4. Ordenar descendentemente.");
    Console.WriteLine("5. Mostrar la(s) moda(s).");
    Console.WriteLine("6. Mostrar gráfico.");
    Console.WriteLine("7. Existe.");
    Console.WriteLine("8. Eliminar una ocurrencia.");
    Console.WriteLine("9. Eliminar todas las ocurrencias.");
    Console.WriteLine("0. Salir.");
    Console.Write("¿Cuál es su opción? ");
    return Console.ReadLine()!;
}
