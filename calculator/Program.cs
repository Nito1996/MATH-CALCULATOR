using System;
using calculator;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace calculator
{
    internal class Program
    {
        static readonly string mainRegex = @"^[1-6]$";
        static readonly string regex = @"^-?\d+(\.\d+)?$";
        public static ICalculator calculator = new Calculator();
        public static bool exitRequested = false;

        public enum MathOperation
        {
            ADDITION = 1,
            SUBSTRACTION,
            MULTIPLICATION,
            DIVISION
        }

        static void Main()
        {
            do
            {
                PromptMenu();
            } while (!exitRequested);
        }

        public static void PromptMenu()
        {
            Console.WriteLine("Welcome to the best CALCULATOR all over the world Mista'|Ma'am !");
            Console.WriteLine("Which action would you like to perform?");
            Console.WriteLine("");
            Console.WriteLine($"1. {MathOperation.ADDITION}");
            Console.WriteLine($"2. {MathOperation.SUBSTRACTION}");
            Console.WriteLine($"3. {MathOperation.MULTIPLICATION}");
            Console.WriteLine($"4. {MathOperation.DIVISION}");
            Console.WriteLine("5. SHOW HISTORY");
            Console.WriteLine("6. LOG OUT");
            Console.WriteLine("");

            string userInput = Console.ReadLine();

            if (!Regex.IsMatch(userInput, mainRegex))
            {
                Console.WriteLine("Invalid Input. Please enter a valid numeric value from 1 to 6.");
                Console.WriteLine("");
                return;
            }

            Console.WriteLine("");
            HandleOperation(userInput);
        }

        public static void HandleOperation(string operationSelected)
        {
            if (operationSelected == "6")
            {
                string input;
                do
                {
                    Console.WriteLine("Are you sure you want to log out?");
                    Console.WriteLine("1. YES / 2. NO");

                    input = Console.ReadLine();
                    Console.WriteLine("");
                }
                while (input != "1" && input != "2");

                if (input == "1")
                {
                    Console.WriteLine("Logging out...");
                    Console.WriteLine("Thank you for using our services. You have a great day!");
                    Console.WriteLine("");
                    exitRequested = true;
                }
                return;
            }
            else if (operationSelected == "5")
            {
                IList<Operation> history = calculator.GetHistory();

                Console.WriteLine("Operation History:");
                foreach (var operation in history)
                {
                    Console.WriteLine($"{operation.Timestamp}: {operation.Num1} {operation.Type} {operation.Num2} = {operation.Result}");
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Please enter a FIRST valid numeric value:");
                string num1 = Console.ReadLine();
                Console.WriteLine("");

                if (!Regex.IsMatch(num1, regex))
                {
                    Console.WriteLine("Invalid entry for FIRST numeric value. Please enter a valid numeric value.");
                    Console.WriteLine("");
                    return;
                }

                Console.WriteLine("Please enter a SECOND valid numeric value:");
                string num2 = Console.ReadLine();
                Console.WriteLine("");

                if (!Regex.IsMatch(num2, regex))
                {
                    Console.WriteLine("Invalid entry for SECOND numeric value. Please enter a valid numeric value.");
                    Console.WriteLine("");
                    return;
                }

                decimal firstOption = Decimal.Parse(num1);
                decimal secondOption = Decimal.Parse(num2);

                MathOperation mathOperation = Enum.Parse<MathOperation>(operationSelected);

                switch (mathOperation)
                {
                    case MathOperation.ADDITION:
                        decimal sumResult = calculator.Sum(firstOption, secondOption);
                        Console.WriteLine($"Operation Succeeded: {firstOption} + {secondOption} = {sumResult}");
                        break;
                    case MathOperation.SUBSTRACTION:
                        decimal subtractResult = calculator.Substract(firstOption, secondOption);
                        Console.WriteLine($"Operation Succeeded: {firstOption} - {secondOption} = {subtractResult}");
                        break;
                    case MathOperation.MULTIPLICATION:
                        decimal multiplyResult = calculator.Multiply(firstOption, secondOption);
                        Console.WriteLine($"Operation Succeeded: {firstOption} * {secondOption} = {multiplyResult}");
                        break;
                    case MathOperation.DIVISION:
                        try
                        {
                            decimal divideResult = calculator.Divide(firstOption, secondOption);
                            Console.WriteLine($"Operation Succeeded: {firstOption} / {secondOption} = {divideResult}");
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                }
                Console.WriteLine("");
            }
        }
    }
}
