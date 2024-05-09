class Program
{
    public static void Main()
    {
        int[] ints = { 2, 3, 5, 7, 11, 13, 17, 19 };
        string expected1 = "2 3 5 7 11 13 17 19";
        ArrayPrinter<int> intPrinter = new(ints);
        string actual1 = CatchOutput(intPrinter.WriteUsingForeach);
        Check(actual1 == expected1, $"WriteUsingForeach NOT ok: {actual1}");

        bool[] bools = { true, false, true, false, false };
        string expected2 = "True False True False False";
        ArrayPrinter<bool> boolPrinter = new(bools);
        string actual2 = CatchOutput(() => boolPrinter.WriteUsingRecursion(0));
        Check(actual2 == expected2, $"WriteUsingRecursion NOT ok: {actual2}");

        string[] strings = { "abc", "def", "ghi" };
        string expected3 = "abc def ghi";
        ArrayPrinter<string> stringPrinter = new(strings);
        string actual3 = stringPrinter.ConcatUsingForeach().TrimEnd();
        Check(actual3 == expected3, $"ConcatUsingForeach NOT ok: {actual3}");

        char[] chars = { 'a', 'b', 'c', 'd' };
        string expected4 = "a b c d";
        ArrayPrinter<char> charPrinter = new(chars);
        string actual4 = charPrinter.ConcatUsingRecursion(0).TrimEnd();
        Check(actual4 == expected4, $"ConcatUsingRecursion NOT ok: {actual4}");

        Console.WriteLine("All tests passed on recursion!");
    }

    public static string CatchOutput(Action action)
    {
        TextWriter screen = Console.Out;
        StringWriter output = new();
        Console.SetOut(output);
        action();
        Console.SetOut(screen);
        return output.ToString().TrimEnd();
    }

    public static void Check(bool condition, string message)
    {
        if (!condition)
        {
            Console.WriteLine(message);
            Environment.Exit(1);
        }
    }
}