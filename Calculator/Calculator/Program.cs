using System;
using System.Data.Common;
using System.IO;
using Calculator;

namespace Calculator
{
    class Start
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the calculator!");
        }

        public int AskForCalculationMode()
        {
            Console.WriteLine("What calculator do you want? " +
                              "1 - Numbers, " +
                              "2 - Dates");
            int mode;
            while (!int.TryParse(Console.ReadLine(), out mode)) ;
            return mode;
        }

    }

    class NumberCalculator
    {
        public string enterOp()
        {
            Console.Write("Please enter an operator");
            string op = Console.ReadLine();
            return op;
        }

        public int[] enterNumberArray(string op)
        {
            Console.WriteLine("How many numbers do you want to " + op + "?");
            int amount = int.Parse(Console.ReadLine());
            int[] numbers = new int[amount];
            for (int i = 0;
                i < amount;
                i++)
            {
                int number;
                do
                {
                    Console.WriteLine("Please enter " + (i + 1) + " number");

                } while (!int.TryParse(Console.ReadLine(), out number));

                numbers[i] = number;
            }

            return numbers;
        }

        public double performCalculation(string op, int[] numbers)
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

    }

    class WriteLog
    {
        string path = @"c:\Users\Tatyana\CalculatorLog.txt";

        public void StartLog(int mode)
        {
                
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Welcome to Calculator");
                    Console.Clear();
                    sw.WriteLine("You chose " + mode + " mode");
                }
            
        }

        public void LogNumbers(string op, int[] numbers, double result)
        {
            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("You chose " + op + " operator");
                sw.WriteLine("The answer is "+ result);
            }
        }

        public void LogDates(DateTime mydate, DateTime resultDate)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("You entered " + mydate);
                sw.WriteLine("The result is " + resultDate);
            }
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Start myStart = new Start();
            Start.PrintWelcomeMessage();
            WriteLog myLog = new WriteLog();
            while (true)
            {

                if (myStart.AskForCalculationMode() == NumberCalculator)
                {

                    myLog.StartLog(NumberCalculator);
                    NumberCalculator myNum = new NumberCalculator();
                    string op = myNum.enterOp();
                    int[] numbers = myNum.enterNumberArray(op);
                   Console.WriteLine("The answer is {0} .", myNum.performCalculation(op, numbers));
                   myLog.LogNumbers(op, numbers, result: myNum.performCalculation(op, numbers));
                }
                else
                {
                    myLog.StartLog(DateCalculator);
                    DateCalculator newDate = new DateCalculator();
                    DateTime myDate = newDate.EnterDate();
                   DateTime resultDate = newDate.CalculateDate(myDate);
                   Console.Write("The answer is " + resultDate);
                   myLog.LogDates(myDate, resultDate);
                }


                Console.WriteLine();
                
            }
        }


        private const int NumberCalculator = 1;
        private const int DateCalculator = 2;

    }


    class DateCalculator
    {
        public DateTime EnterDate()
        {
            DateTime mydate;
            do
            {
                Console.WriteLine("Please enter a date");
            } while (!DateTime.TryParse(Console.ReadLine(), out mydate));

            return mydate;
        }

        public DateTime CalculateDate(DateTime mydate)
        {
            Console.WriteLine("Please enter a number of days to add:");
            int daysToAdd = int.Parse(Console.ReadLine());
            DateTime resultDate = mydate.AddDays(daysToAdd);
            return resultDate;
        }

    }
}


    


        

      

        




    
        
    
