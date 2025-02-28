using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDo;
internal class Program
{
    public static List<string> TaskList { get; set; } = new List<string>();

    static void Main(string[] args)
    {
        int menuSelected = 0;
        do
        {
            menuSelected = ShowMainMenu();
            if ((Menu)menuSelected == Menu.Add)
            {
                ShowMenuAdd();
            }
            else if ((Menu)menuSelected == Menu.Remove)
            {
                ShowMenuRemove();
            }
            else if ((Menu)menuSelected == Menu.List)
            {
                ShowMenuTaskList();
            }
        } while ((Menu)menuSelected != Menu.Exit);
    }
    
    /// Show the options for task 
    public static int ShowMainMenu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ingrese la opción a realizar: ");
        Console.WriteLine("1. Nueva tarea");
        Console.WriteLine("2. Remover tarea");
        Console.WriteLine("3. Tareas pendientes");
        Console.WriteLine("4. Salir");

        string line = Console.ReadLine();
        return Convert.ToInt32(line);
    }

    public static void ShowMenuRemove()
    {
        try
        {
            Console.WriteLine("Ingrese el número de la tarea a remover: ");
            ListTasks();

            string line = Console.ReadLine();
            // Remove one position because the array is 0 based
            int indexToRemove = Convert.ToInt32(line) - 1;
            if(indexToRemove < 0 || indexToRemove >= TaskList.Count)
            {
                Console.WriteLine("Tarea no encontrada");
                return;
            }

            if (indexToRemove > -1 && TaskList.Count > 0)
            {                    
                string task = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {task} eliminada");                    
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Error al eliminar la tarea");
        }
    }

    public static void ShowMenuAdd()
    {
        try
        {
            Console.WriteLine("Ingrese el nombre de la tarea: ");
            string task = Console.ReadLine();
            TaskList.Add(task);
            Console.WriteLine("Tarea registrada");
        }
        catch (Exception)
        {
            Console.WriteLine("Error al agregar la tarea");
        }
    }

    public static void ShowMenuTaskList()
    {
        ListTasks();
    }

    public static void ListTasks() 
    {
        if (TaskList?.Count > 0 )
        {
            Console.WriteLine("----------------------------------------");
            var indexTask = 1;
            TaskList.ForEach(p=> Console.WriteLine($"{indexTask++}. {p}"));
            Console.WriteLine("----------------------------------------");                
        }
        else
        {
            Console.WriteLine("No hay tareas aún");
        }
    }
}
public enum Menu {
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
    

