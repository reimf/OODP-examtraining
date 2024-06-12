class Program
{
    static void Main()
    {
        Node four = new Operand(new Fraction(4));
        Check("two.ToString()", four, "4");
        Check("two.Evaluate()", four.Evaluate(), "4");

        Node threeQuarters = new Operand(new Fraction(3, 4));
        Check("threeQuarters.ToString()", threeQuarters, "3/4");
        Check("threeQuarters.Evaluate()", threeQuarters.Evaluate(), "3/4");

        Node subtract4To3Quarters = new Subtract(four, threeQuarters);
        Check("subtract4To3Quarters.ToString()", subtract4To3Quarters, "(4-3/4)");
        Check("subtract4To3Quarters.Evaluate()", subtract4To3Quarters.Evaluate(), "13/4");

        Node add3QuartersTo3Quarters = new Add(threeQuarters, threeQuarters);
        Check("add3QuartersTo3Quarters.ToString()", add3QuartersTo3Quarters, "(3/4+3/4)");
        Check("add3QuartersTo3Quarters.Evaluate()", add3QuartersTo3Quarters.Evaluate(), "3/2");

        Node multiply4By3Quarters = new Multiply(four, threeQuarters);
        Check("multiply4By3Quarters.ToString()", multiply4By3Quarters, "(4*3/4)");
        Check("multiply4By3Quarters.Evaluate()", multiply4By3Quarters.Evaluate(), "3");

        Node divide3QuartersBy4 = new Divide(threeQuarters, four);
        Check("divide3QuartersBy4.ToString()", divide3QuartersBy4, "(3/4/4)");
        Check("divide3QuartersBy4.Evaluate()", divide3QuartersBy4.Evaluate(), "3/16");

        try
        {
            Check("infinity.ToString()", new Operand(new Fraction(1, 0)), "DivideByZeroException");
        }
        catch (DivideByZeroException) { }

        Node zero = new Operand(new Fraction(0));
        Node divide4By0 = new Divide(four, zero);
        Check("divide4By0.ToString()", divide4By0, "(4/0)");
        try
        {
            Check("divide4By0.Evaluate()", divide4By0.Evaluate(), "DivideByZeroException");
        }
        catch (DivideByZeroException) { }

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