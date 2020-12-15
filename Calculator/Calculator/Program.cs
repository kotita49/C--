using System;
using System.Data.Common;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            while (true)
            {
                int calculationMode = AskForCalculationMode();
                if (calculationMode == NumberCalculator)
                {
                    calculateNumberResult();
                }
                else
                {
                    calculateDate();
                }

            }
        }


        private const int NumberCalculator = 1;
        private const int DateCalculator = 2;

        private static int AskForCalculationMode()
        {
            int mode = enterNumber("What calculator do you want? 1 - Numbers, 2 - Dates");
            return mode;
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the calculator!");
        }

        private static string enterOp()
        {
            Console.Write("Please enter an operator");
            string op = Console.ReadLine();
            return op;
        }

        private static int enterNumber(string message)
        {
            int number;
            do
            {
                Console.WriteLine(message);
            } while (!int.TryParse(Console.ReadLine(), out number));

            return number;
        }


        private static int[] enterNumberArray(string op)
        {
            int amount = enterNumber("How many numbers do you want to " + op + "?");
            int[] numbers = new int[amount];
            int j;
            for (int i = 0;
                i < amount;
                i++)
            {
                numbers[i] = enterNumber("Please enter number " + (i + 1) + ": ");

            }

            return numbers;
        }

        private static double performCalculation(string op, int[] numbers)
        {

            double result = numbers[0];
            for (int i = 1;
                i < numbers.Length;
                i++)
            {
                if (op == "+")
                {
                    result += numbers[i];
                }
                else if (op == "-")
                {
                    result -= numbers[i];
                }
                else if (op == "*")
                {
                    result *= numbers[i];
                }
                else if (op == "/")
                {
                    result /= numbers[i];
                }


            }

            return result;
        }

        private static void calculateNumberResult()
        {
            string op = enterOp();
            int[] numbers = enterNumberArray(op);
            double result = performCalculation(op, numbers);
            Console.Write("The answer is " + result);
            Console.WriteLine();
        }

        private static DateTime enterDate()
        {
            DateTime mydate;
            do
            {
                Console.WriteLine("Please enter a date");
            } while (!DateTime.TryParse(Console.ReadLine(), out mydate));

            return mydate;

        }

        private static void calculateDate()
        {
            DateTime mydate = enterDate();
            int daysToAdd = enterNumber("Please enter a number of days to add:");
DateTime resultDate = mydate.AddDays(daysToAdd);
Console.Write("The answer is "+ resultDate);
Console.WriteLine();
        }
    }
}

        

      

        




    
        
    
