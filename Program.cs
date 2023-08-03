using System.Text;
using TaskList;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; // Set console output encoding to UTF-8
        TaskListManager taskList = new TaskListManager();

        Console.WriteLine("Witaj w aplikacji TO DO LIST! \n");

        taskList.LoadTasks(); // Load tasks from the file (if available)
        taskList.ShowMenu();
        taskList.SaveTasks(); // Save tasks before exiting
    }
}