namespace TodoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello");
            //Console.WriteLine("Waht do you want to do?");
            //Console.WriteLine("[S]ee ale TODOs");
            //Console.WriteLine("[A]dd a TODO");
            //Console.WriteLine("[R]emove a TODO");
            //Console.WriteLine("[E]xit");

            //string userChoice = Console.ReadLine();

            //if (userChoice == "S")
            //{
            //    PrintSelectetOption("See all TODOs");
            //}
            //else if (userChoice == "A")
            //{
            //    PrintSelectetOption("Add a TODO");
            //}
            //else if (userChoice == "R")
            //{
            //    PrintSelectetOption("Remove TODO");
            //}
            //else if (userChoice == "E")
            //{
            //    PrintSelectetOption("Exit program");
            //}

            Console.WriteLine("Input a number");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(number);

            Console.ReadKey();


        }

        static void PrintSelectetOption(string selectedOption)
        {
            Console.WriteLine("Selected option: " + selectedOption);
        }
    }
}
