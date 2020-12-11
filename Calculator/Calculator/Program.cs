using System;
using System.Data.Common;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator!");
            Console.Write("Please enter an operator");
            string op = Console.ReadLine();
            Console.WriteLine("How many numbers do you want to " + op + " ?");
            int amount = int.Parse(Console.ReadLine());
            int[] numbers = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("Please enter " + (i+1) + " number");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (op == "+")
                {
                    result += numbers[i];
                } else if(op == "-")
                {
                    result -= numbers[i];
                }else if (op == "*")
                {
                    result *= numbers[i];
                }else if (op == "/")
                {
                    result=result/numbers[i];
                }
            }
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers[1]);
            Console.WriteLine(result);
        }
    }
}



    
        
    
