﻿using System;
using System.Data.Common;

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
               { Console.WriteLine("Please enter " + (i + 1) + " number");
                   
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


    class Program
    {

        static void Main(string[] args)
        {
            Start myStart = new Start();
            Start.PrintWelcomeMessage();
            while (true)
            {

                if (myStart.AskForCalculationMode() == NumberCalculator)
                {
                    NumberCalculator myNum = new NumberCalculator();
                    string op = myNum.enterOp();
                    int[] numbers = myNum.enterNumberArray(op);
                    Console.WriteLine("The answer is {0} .", myNum.performCalculation(op, numbers));
                }
                else
                {
                    DateCalculator newDate = new DateCalculator();
                    DateTime myDate = newDate.EnterDate();
                    DateTime resultDate = newDate.CalculateDate(myDate);
                    Console.Write("The answer is "+ resultDate);
                }
                Console.WriteLine();
            }
        }

        private const int NumberCalculator = 1;
        private const int DateCalculator = 2;

    }
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

    


        

      

        




    
        
    
