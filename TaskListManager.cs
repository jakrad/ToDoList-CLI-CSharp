using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    internal class TaskListManager
    {
        private List<string> tasks = new List<string>();
        private const string FilePath = "tasks.txt"; // Path to the file to store tasks


        public void ShowMenu()
        {
            while (true)
            {
                // Wyświetlenie opcji menu

                Console.WriteLine("Wybierz opcję: \n");
                Console.WriteLine("1. Pokaż listę zadań");
                Console.WriteLine("2. Dodaj nowe zadanie");
                Console.WriteLine("3. Usuń zadanie");
                Console.WriteLine("4. Edytuj zadanie");
                Console.WriteLine("5. Wyjdź z aplikacji");

                // Pobranie wyboru użytkownika

                string choice = Console.ReadLine();

                // Obsługa wyboru użytkownika

                switch (choice)
                {
                    case "1":
                        ShowTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        EditTask();
                        break;
                    case "5":
                        Console.WriteLine("Dziękuję za skorzystanie z aplikacji TO DO LIST.");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Wybierz 1, 2, 3 lub 4.");
                        break;
                }

            }
        }

        public void ShowTasks() { 
            if (tasks.Count == 0) {
                Console.WriteLine("\nBrak zadań na liście. Spróbuj dodać jakieś zadanie.");
            }
            else
            {
                Console.WriteLine($"\nMasz {tasks.Count} zadań na liście. Oto one: ");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {tasks[i]}");
                }
                Console.WriteLine('\n');
            }
        }

        public void AddTask() {
            Console.WriteLine("Podaj treść nowego zadania: ");
            string newTask = Console.ReadLine();
            tasks.Add(newTask);
            Console.WriteLine("Twoje zadanie zostało dodane do listy.");
        }
        public void DeleteTask() 
        { 
            Console.WriteLine("Wybierz, które zadanie chcesz usunąć:");
            ShowTasks();
            if (tasks.Count == 0) { return; }

            Console.WriteLine("Podaj numer zadania do usunięcia: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber))
            {
                if (taskNumber >=1 && taskNumber <= tasks.Count)
                {
                    tasks.RemoveAt(taskNumber - 1);
                    Console.WriteLine("Zadanie usunięto pomyślnie.\n");
                    ShowTasks() ;
                }
                else { Console.WriteLine("Nieprawidłowy numer zadania."); }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format numeru zadania.");
            }
        }

        public void EditTask()
        {
            Console.WriteLine("Wybierz, które zadanie chcesz edytować:");
            ShowTasks();
            if (tasks.Count == 0) { return; }

            Console.WriteLine("Podaj numer zadania do edycji: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber))
            {
                if (taskNumber >= 1 && taskNumber <= tasks.Count)
                {
                    Console.WriteLine($"Aktualna treść zadania {taskNumber}: {tasks[taskNumber - 1]}");
                    Console.WriteLine("Podaj nową treść zadania: ");
                    string editedTask = Console.ReadLine();
                    tasks[taskNumber - 1] = editedTask;
                    Console.WriteLine("Zadanie zostało zaktualizowane.");
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy numer zadania.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format numeru zadania.");
            }
        }

        public void SaveTasks() 
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    foreach (string task in tasks)
                    {
                        writer.WriteLine(task);
                    }
                }
                Console.WriteLine("Zadania zostały zapisane.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas zapisywania zadań: {ex.Message}");
            }
        }

        public void LoadTasks()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    tasks.Clear();
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            tasks.Add(line);
                        }
                    }
                    Console.WriteLine("Zadania zostały wczytane.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd podczas wczytywania zadań: {ex.Message}");
                }
            }
            else { Console.WriteLine("Brak pliku z zadaniami. Nowy plik zostanie utworzony po dodaniu zadania.")  ; }
        }
    }
}
