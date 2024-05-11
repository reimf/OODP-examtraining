class Program
{
    public static void Main()
    {
        MyList<int> myList = new();
        Check(myList.ToString(), "", "ToString failed for []");	
        myList.Add(1);
        Check(myList.ToString(), "1", "ToString failed for [1]");	
        myList.Add(2);
        Check(myList.ToString(), "1,2", "ToString failed for [1,2]");	
        myList.Add(3);
        Check(myList.ToString(), "1,2,3", "ToString failed for [1,2,3]");	
        myList.Add(4);
        Check(myList.ToString(), "1,2,3,4", "ToString failed for [1,2,3,4]");	

        Check(myList.Map(x => x + 1).ToString(), "2,3,4,5", "Map(x=>x+1) failed for [1,2,3,4]");
        Check(myList.Map(x => 2 * x).ToString(), "2,4,6,8", "Map(x=>2*x) failed for [1,2,3,4]");
        Check(myList.Map(x => x * x).ToString(), "1,4,9,16", "Map(x=>x*x) failed for [1,2,3,4]");
        Console.WriteLine("All tests for Map passed successfully");

        Check(myList.Filter(x => x % 2 == 0).ToString(), "2,4", "Filter(x=>x%2==0) failed for [1,2,3,4]");
        Check(myList.Filter(x => x > 2).ToString(), "3,4", "Filter(x=>x>2) failed for [1,2,3,4]");
        Console.WriteLine("All tests for Filter passed successfully");

        Check(myList.Reduce((r, n) => r + n, 0).ToString(), "10", "Reduce((r,n)=>r+n,0) failed for [1,2,3,4]");
        Check(myList.Reduce((r, n) => r * n, 1).ToString(), "24", "Reduce((r,n)=>r*n,0) failed for [1,2,3,4]");
        Check(myList.Reduce(Math.Min, int.MaxValue).ToString(), "1", "Reduce(Math.Min,int.MaxValue) failed for [1,2,3,4]");
        Console.WriteLine("All tests for Reduce passed successfully");

        Console.WriteLine("Congratulations, all tests passed successfully!");
    }

    public static void Check(string actual, string expected, string message)
    {
        if (expected != actual)
        {
            Console.WriteLine($"{message}: expected {expected}, got {actual}");
            Environment.Exit(1);
        }
    }
}