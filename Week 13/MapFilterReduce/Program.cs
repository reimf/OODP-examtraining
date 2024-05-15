class Program
{
    public static void Main()
    {
        MyList<int> myList = new() { 1, 2, 3, 4 };

        Check(Processor.Map(myList, x => x + 1).ToString(), "2,3,4,5", "Map([1,2,3,4],x=>x+1)");
        Check(Processor.Map(myList, x => 2 * x).ToString(), "2,4,6,8", "Map([1,2,3,4],x=>2*x)");
        Check(Processor.Map(myList, x => x * x).ToString(), "1,4,9,16", "Map([1,2,3,4],x=>x*x)");
        Console.WriteLine("All tests for Map passed successfully");

        Check(Processor.Filter(myList, x => x % 2 == 0).ToString(), "2,4", "Filter([1,2,3,4],x=>x%2==0)");
        Check(Processor.Filter(myList, x => x > 2).ToString(), "3,4", "Filter([1,2,3,4],x=>x>2)");
        Console.WriteLine("All tests for Filter passed successfully");

        Check(Processor.Reduce(myList, (r, n) => r + n, 0).ToString(), "10", "Reduce([1,2,3,4],(r,n)=>r+n,0)");
        Check(Processor.Reduce(myList, (r, n) => r * n, 1).ToString(), "24", "Reduce([1,2,3,4],(r,n)=>r*n,0)");
        Check(Processor.Reduce(myList, Math.Min, int.MaxValue).ToString(), "1", "Reduce([1,2,3,4],Math.Min,int.MaxValue)");
        Console.WriteLine("All tests for Reduce passed successfully");

        Console.WriteLine("Congratulations, all tests passed successfully!");
    }

    public static void Check(string actual, string expected, string message)
    {
        if (expected != actual)
        {
            Console.WriteLine($"{message} failed: expected {expected}, got {actual}");
            Environment.Exit(1);
        }
    }
}