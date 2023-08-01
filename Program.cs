using TaskList;

internal class Program
{
    private static void Main(string[] args)
    {
        List taskList = new List();

        Console.WriteLine("Witaj w aplikacji TO DO LIST! \n");

        taskList.ShowMenu();

        Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
        Console.ReadKey();
    }
}