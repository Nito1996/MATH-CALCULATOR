using System.Collections.Generic;
using calculator;

namespace calculator
{
    public interface ICalculator
    {
        decimal Sum(decimal num1, decimal num2);
        decimal Substract(decimal num1, decimal num2);
        decimal Multiply(decimal num1, decimal num2);
        decimal Divide(decimal num1, decimal num2);
        IList<Operation> GetHistory();
    }

    public class Calculator : ICalculator
    {
        public IList<Operation> history = new List<Operation>();

        public decimal Sum(decimal num1, decimal num2)
        {
            decimal result = num1 + num2;
            AddToHistory(num1, '+', num2, result);
            return result;
        }

        public decimal Substract(decimal num1, decimal num2)
        {
            decimal result = num1 - num2;
            AddToHistory(num1, '-', num2, result);
            return result;
        }

        public decimal Multiply(decimal num1, decimal num2)
        {
            decimal result = num1 * num2;
            AddToHistory(num1, '*', num2, result);
            return result;
        }

        public decimal Divide(decimal num1, decimal num2)
        {
            decimal result = num1 / num2;
            AddToHistory(num1, '/', num2, result);
            return result;
        }

        public IList<Operation> GetHistory()
        {
            return history;
        }

        public void AddToHistory(decimal num1, char type, decimal num2, decimal result)
        {
            history.Add(new Operation(num1, type, num2, result));
        }
    }
}