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
        Check("subtract4To3Quarters.Evaluate()", subtract4To3Quarters.Evaluate(), "3 1/4");

        Node add3QuartersTo3Quarters = new Add(threeQuarters, threeQuarters);
        Check("add3QuartersTo3Quarters.ToString()", add3QuartersTo3Quarters, "(3/4+3/4)");
        Check("add3QuartersTo3Quarters.Evaluate()", add3QuartersTo3Quarters.Evaluate(), "1 1/2");

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

        Fraction half = new(1, 2);
        Fraction twoFourth = new(2, 4);
        Check("half.Equals(otherHalf)", half.Equals(twoFourth), true);

        Fraction oneThird = new(1, 3);
        Check("half.Equals(oneThird)", half.Equals(oneThird), false);

        Check("half == twoFourth", half == twoFourth, true);
        Check("half == oneThird", half == oneThird, false);

        Check("half != twoFourth", half != twoFourth, false);
        Check("half != oneThird", half != oneThird, true);

        Fraction fiveEights = new(5, 8);
        Check("half.CompareTo(twoFourth)", half.CompareTo(twoFourth), 0);
        Check("half.CompareTo(oneThird)", half.CompareTo(oneThird), 1);
        Check("half.CompareTo(fiveEights)", half.CompareTo(fiveEights), -1);

        Check("half > twoFourth", half > twoFourth, false);
        Check("half > oneThird", half > oneThird, true);
        Check("half > fiveEights", half > fiveEights, false);

        Check("half < twoFourth", half < twoFourth, false);
        Check("half < oneThird", half < oneThird, false);
        Check("half < fiveEights", half < fiveEights, true);

        Check("half >= twoFourth", half >= twoFourth, true);
        Check("half >= oneThird", half >= oneThird, true);
        Check("half >= fiveEights", half >= fiveEights, false);

        Check("half <= twoFourth", half <= twoFourth, true);
        Check("half <= oneThird", half <= oneThird, false);
        Check("half <= fiveEights", half <= fiveEights, true);

        //Console.WriteLine($"{(Fraction) 3}");

        Console.WriteLine("All tests passed successfully!");
    }

    static void Check(string message, object actual, object expected)
    {
        string actualString = actual.ToString();
        string expectedString = expected.ToString();
        if (!actualString.Equals(expectedString))
        {
            Console.WriteLine($"ERROR: {message}\nExpected: {expectedString}\nActual: {actualString}");
            Environment.Exit(1);
        }
    }
}