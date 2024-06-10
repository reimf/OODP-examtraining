class Program
{
    static void Main()
    {
        Operand two = new(2);
        Check("two.ToString()", two.ToString(), "2");
        Check("two.Evaluate()", two.Evaluate(), 2);

        Operand three = new(3);
        Check("three.ToString()", three.ToString(), "3");
        Check("three.Evaluate()", three.Evaluate(), 3);

        Operand four = new(4);

        Add add2And3 = new(two, three);
        Check("add2And3.ToString()", add2And3.ToString(), "(2+3)");
        Check("add2And3.Evaluate()", add2And3.Evaluate(), 5);

        Multiply multiply2And3 = new(two, three);
        Check("multiply2And3.ToString()", multiply2And3.ToString(), "(2*3)");
        Check("multiply2And3.Evaluate()", multiply2And3.Evaluate(), 6);

        Add add2AndMultiply3And4 = new(two, new Multiply(three, four));
        Check("add2AndMultiply3And4.ToString()", add2AndMultiply3And4.ToString(), "(2+(3*4))");
        Check("add2AndMultiply3And4.Evaluate()", add2AndMultiply3And4.Evaluate(), 14);

        Multiply multiplyAdd2And3And4 = new(new Add(two, three), four);
        Check("multiplyAdd2And3And4.ToString()", multiplyAdd2And3And4.ToString(), "((2+3)*4)");
        Check("multiplyAdd2And3And4.Evaluate()", multiplyAdd2And3And4.Evaluate(), 20);

        Console.WriteLine("All tests passed successfully!");
    }

    static void Check<T>(string message, T actual, T expected)
    {
        if (!actual.Equals(expected))
        {
            Console.WriteLine($"ERROR: {message}\nExpected: {expected}\nActual: {actual}");
            Environment.Exit(1);
        }
    }
}