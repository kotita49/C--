using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator!");
            Console.Write("Enter first number");
           string first = Console.ReadLine();
           int firstInt = int.Parse(first);
           Console.WriteLine(firstInt);
           Console.Write("Enter second number");
           string second = Console.ReadLine();
           int secondInt = int.Parse(second);
           Console.WriteLine(secondInt);
           int multiplier = firstInt * secondInt;
           Console.WriteLine("The answer is :" + multiplier);
        }
    }
}