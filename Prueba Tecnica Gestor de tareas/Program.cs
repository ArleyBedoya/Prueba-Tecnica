using System;
using System.Collections.Generic;

namespace GestorDeTareas
{
    class Tarea
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public Tarea(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Estado = "En proceso";
        }
    }
    class Program
    {
        static List<Tarea> tareas = new List<Tarea>();

        static void AgregarTarea()
        {
            Console.Write("Nombre de la tarea: ");
            string nombre = Console.ReadLine();
            Console.Write("Descripción de la tarea: ");
            string descripcion = Console.ReadLine();
            Tarea tarea = new Tarea(nombre, descripcion);
            tareas.Add(tarea);
        }

        static void ListarTareas()
        {
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
                return;
            }

            for (int i = 0; i < tareas.Count; i++)
            {
                Tarea tarea = tareas[i];
                Console.WriteLine($"[{i + 1}] Nombre de la tarea: {tarea.Nombre}");
                Console.WriteLine($"Descripción: {tarea.Descripcion}");
                Console.WriteLine($"Estado: {tarea.Estado}");
                Console.WriteLine("--------------------");
            }
        }

        static void MarcarTareaComoCompletada()
        {
            ListarTareas();
            if (tareas.Count == 0) return;

            Console.Write("Seleccione la tarea a marcar como completada: ");
            int indice = Convert.ToInt32(Console.ReadLine()) - 1;
            if (indice >= 0 && indice < tareas.Count)
            {
                tareas[indice].Estado = "Completada";
                Console.WriteLine("Tarea marcada como completada.");
            }
            else
            {
                Console.WriteLine("Tarea no encontrada.");
            }
        }

        static void EliminarTarea()
        {
            ListarTareas();
            if (tareas.Count == 0) return;

            Console.Write("Seleccione la tarea a eliminar: ");
            int indice = Convert.ToInt32(Console.ReadLine()) - 1;
            if (indice >= 0 && indice < tareas.Count)
            {
                tareas.RemoveAt(indice);
                Console.WriteLine("Tarea eliminada.");
            }
            else
            {
                Console.WriteLine("Tarea no encontrada.");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Agregar tarea");
                Console.WriteLine("2. Listar tareas");
                Console.WriteLine("3. Marcar tarea como completada");
                Console.WriteLine("4. Eliminar tarea");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarTarea();
                        break;
                    case 2:
                        ListarTareas();
                        break;
                    case 3:
                        MarcarTareaComoCompletada();
                        break;
                    case 4:
                        EliminarTarea();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
