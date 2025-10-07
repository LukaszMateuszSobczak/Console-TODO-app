namespace TodoList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> todos = new List<string>();
            if (File.Exists("todos.txt"))
            {
                ReadFromFile(ref todos, "todos.txt");
            }

            while (true)
            {
                
                string userChoice = PrintMenuAndGetUserInput(todos);
                if (!NavigateToSubMenu(userChoice, todos)) {
                    break;
                }
            }

            Console.ReadKey();
        }

        static void PrintSelectedOption(string selectedOption)
        {
            Console.WriteLine("\tSelected option: " + selectedOption);
            Console.WriteLine("===========================================");
        }

        static string PrintMenuAndGetUserInput(List<string> todos)
        {
            Console.WriteLine("Hello");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[S]ee all TODOs");
            Console.WriteLine("[A]dd a TODO");
            Console.WriteLine("[R]emove a TODO");
            Console.WriteLine("[E]xit");
            string userChoice = Console.ReadLine().ToLower();
            return userChoice;
        }

        static bool NavigateToSubMenu(string userChoice, List<string> todos)
        {
            switch (userChoice)
            {
                case "s":
                    PrintSelectedOption("See all TODOs");
                    Console.WriteLine(PrintAllTodos(todos));
                    ClearMenu();
                    break;
                case "a":
                    PrintSelectedOption("Add a TODO");
                    AddNewTodos(todos);
                    ClearMenu();
                    break;
                case "r":
                    PrintSelectedOption("Remove TODO");
                    RemoveTodo(todos);
                    ClearMenu();
                    break;
                case "e":
                    PrintSelectedOption("Exit and save!");
                    SaveToFile(todos);
                    Console.WriteLine("Press any key to exit...");
                    return false;
                default:
                    Console.WriteLine("\aWrong input try again!");
                    break;
            }
            return true;
        }

        static void AddNewTodos(List<string> todos)
        {
            string todo;
            while (true)
            {
                Console.Write("Enter your todos: ");
                todo = Console.ReadLine();
                if (todo == null || todo == "")
                {
                    Console.WriteLine("Empty todos. Try again!");
                }
                else if (todos.Contains(todo))
                {
                    Console.WriteLine("Todos already exist. Try again!");
                }
                else
                {
                    todos.Add(todo);
                    Console.WriteLine("Todos added.");
                    break;
                }
            }

            
        }

        static string PrintAllTodos(List<string> todos)
        {
            string allTodos = "";
            if (todos.Count == 0)
            {
                allTodos = "Nothing to show";
            }
            else
            {
                
                for (int i = 0; i < todos.Count; i++)
                {
                    allTodos += $"{i + 1}. {todos[i]}\n";
                }
            }

            return allTodos;
        }

        static void RemoveTodo(List<string> todos)
        {
            string userInput;
            while (true)
            {
                Console.WriteLine($"Saved todos: \n{PrintAllTodos(todos)}");
                Console.Write("Input index of todos for delete: ");
                userInput = Console.ReadLine();
                bool isParsingSuccesful = int.TryParse(userInput, out int result);

                if (isParsingSuccesful)
                {
                    result -= 1; // actual index of element inside of list
                    if (result < todos.Count && result >= 0)
                    {
                        todos.RemoveAt(result);
                        Console.WriteLine("Element deleted.");
                        break;
                    }
                }
                Console.WriteLine("Wrong index. Try again");
            }
        }

        static void SaveToFile(List<string> todos)
        {
            File.WriteAllLines("todos.txt", todos);
        }

        static void ReadFromFile(ref List<string> todos, string filePath)
        {
            todos = File.ReadAllLines(filePath).ToList();
        }

        static void ClearMenu()
        {
            Console.WriteLine("Press any key to back to main menu");
            Console.ReadKey();
            Console.Clear();
        }
        
    }
}
