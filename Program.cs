using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace E3_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Fractions validator");
            Console.WriteLine("2) Names validator");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    FractionsValidator();
                    return true;
                case "2":
                    NamesValidator();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
        private static void FractionsValidator()
        {
            Console.Clear();
            Console.WriteLine("Enter a fraction: ");
            var fraction = Console.ReadLine();
            var rgxresult = Regex.IsMatch(fraction, @"^[0-9]{1,}\/[0-9]{1,}$");
            if (rgxresult == false)
            {
                Console.WriteLine("Not a fraction");
            }
            else
            {
                var arr = fraction.Split("/").Select(int.Parse).ToList(); ;
                var div = gcd(arr[0], arr[1]);
                Console.WriteLine();
                Console.WriteLine("The result is: " + (arr[0] / div + "/" + arr[1] / div));
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey();
        }
        private static int gcd(int a, int b)
        {
            if (b == 0) return a;
            else return gcd(b, a % b);
        }

        private static void NamesValidator()
        {
            Console.Clear();
            Console.WriteLine("Enter a name: "); 
            var name = Console.ReadLine();
            var rgxresult = Regex.IsMatch(name, @"^([A-Z][a-z]{2,}( [A-Z][a-z]{2,}( [A-Z][a-z]{2,})?| [A-Z]\.( [A-Z][a-z]{2,})?)|([A-Z]\.( [A-Z][a-z]{2,}))|[A-Z]\.( [A-Z]\.)( [A-Z][a-z]{2,}))$");
            Console.WriteLine();
            Console.WriteLine("The name " + name + " is " + rgxresult);
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey();
        }
    }
}
