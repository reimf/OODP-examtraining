class Program
{
    static void Main()
    {
        Node two = new Operand(2);
        Check("two.ToString()", two.ToString(), "2");
        Check("two.Evaluate()", two.Evaluate(), "2");

        Node three = new Operand(3);
        Check("three.ToString()", three.ToString(), "3");
        Check("three.Evaluate()", three.Evaluate(), "3");

        Node four = new Operand(4);

        Node add2And3 = new Add(two, three);
        Check("add2And3.ToString()", add2And3.ToString(), "(2+3)");
        Check("add2And3.Evaluate()", add2And3.Evaluate(), "5");

        Node multiply3And4 = new Multiply(three, four);
        Check("multiply2And3.ToString()", multiply3And4.ToString(), "(3*4)");
        Check("multiply2And3.Evaluate()", multiply3And4.Evaluate(), "12");

        Node add2AndMultiply3And4 = new Add(two, new Multiply(three, four));
        Check("add2AndMultiply3And4.ToString()", add2AndMultiply3And4.ToString(), "(2+(3*4))");
        Check("add2AndMultiply3And4.Evaluate()", add2AndMultiply3And4.Evaluate(), "14");

        Node multiplyAdd2And3And4 = new Multiply(new Add(two, three), four);
        Check("multiplyAdd2And3And4.ToString()", multiplyAdd2And3And4.ToString(), "((2+3)*4)");
        Check("multiplyAdd2And3And4.Evaluate()", multiplyAdd2And3And4.Evaluate(), "20");

        Console.WriteLine("All tests passed successfully!");
    }

    static void Check(string message, object actual, string expected)
    {
        if (!actual.ToString().Equals(expected))
        {
            Console.WriteLine($"ERROR: {message}\nExpected: {expected}\nActual: {actual}");
            Environment.Exit(1);
        }
    }
}