using System;

namespace calculator
{
    public class Operation
    {
        public decimal Num1 { get; }
        public decimal Num2 { get; }
        public decimal Result { get; }
        public char Type { get; }
        public DateTime Timestamp { get; }

        public Operation(decimal num1, char type, decimal num2, decimal result)
        {
            Num1 = num1;
            Num2 = num2;
            Type = type;
            Result = result;
            Timestamp = DateTime.Now;
        }
    }
}
