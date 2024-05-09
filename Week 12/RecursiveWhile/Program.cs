class Program
{
    static void Main()
    {
        string[] six = new string[] { "heads", "tails", "heads", "tails", "tails", "heads" };
        string[] four = new string[] { "heads", "tails", "heads", "tails" };	

        OneTimeReader readerSixWhile = new(six);
        int stringsLengthWhile = LengthCounter.LengthUsingWhile(readerSixWhile);
        Check(stringsLengthWhile == 6, "The number of strings in array 6 should be 6 using while");

        OneTimeReader readerFourWhile = new(four);
        int boolsLengthWhile = LengthCounter.LengthUsingWhile(readerFourWhile);
        Check(boolsLengthWhile == 4, "The number of strings in array 4 should be 4 using while");

        OneTimeReader readerSixRecursion = new(six);
        int stringsLengthRecursion = LengthCounter.LengthUsingRecursion(readerSixRecursion);
        Check(stringsLengthRecursion == 6, "The number of strings in array 6  should be 6 using recursion");

        OneTimeReader readerFourRecursion = new(four);
        int boolsLengthRecursion = LengthCounter.LengthUsingRecursion(readerFourRecursion);
        Check(boolsLengthRecursion == 4, "The number of strings in array 4 should be 4 using recursion");

        Console.WriteLine("All tests passed!");
    }

    static void Check(bool condition, string message)
    {
        if (!condition)
        {
            Console.WriteLine(message);
            Environment.Exit(1);
        }
    }
}