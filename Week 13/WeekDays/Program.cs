class Program
{
    static void Main()
    {
        WeekDay sunday = new() { Name = "Sunday", NextDay = null };
        sunday.AddNext("Monday");
        sunday.AddNext("Tuesday");
        sunday.AddNext("Wednesday");
        sunday.AddNext("Thursday");
        sunday.AddNext("Friday");
        sunday.AddNext("Saturday");

        WeekDay monday = sunday.NextDay;
        WeekDay tuesday = monday.NextDay;
        WeekDay wednesday = tuesday.NextDay;
        WeekDay thursday = wednesday.NextDay;
        WeekDay friday = thursday.NextDay;
        WeekDay saturday = friday.NextDay;
        WeekDay sundayAgain = saturday.NextDay;

        Check("sunday.Name", sunday.Name, "Sunday");
        Check("monday.Name", monday.Name, "Monday");
        Check("tuesday.Name", tuesday.Name, "Tuesday");
        Check("wednesday.Name", wednesday.Name, "Wednesday");
        Check("thursday.Name", thursday.Name, "Thursday");
        Check("friday.Name", friday.Name, "Friday");
        Check("saturday.Name", saturday.Name, "Saturday");
        Check("sundayAgain.Name", sundayAgain.Name, "Sunday");

        sunday.ForAll(d => d.Name += d.Name == "Sunday" || d.Name == "Saturday" ? " (free)" : " (work)", sunday);

        Check("sunday.Name after applying the function", sunday.Name, "Sunday (free)");
        Check("monday.Name after applying the function", monday.Name, "Monday (work)");
        Check("tuesday.Name after applying the function", tuesday.Name, "Tuesday (work)");
        Check("wednesday.Name after applying the function", wednesday.Name, "Wednesday (work)");
        Check("thursday.Name after applying the function", thursday.Name, "Thursday (work)");
        Check("friday.Name after applying the function", friday.Name, "Friday (work)");
        Check("saturday.Name after applying the function", saturday.Name, "Saturday (free)");
    
        Console.WriteLine("All tests passed successfully!");
    }

    static void Check(string message, string actual, string expected)
    {
        if (actual != expected)
        {
            Console.WriteLine($"Test failed: {message}\n"
                            + $"Expected: {expected}\n"
                            + $"Actual: {actual}");
            Environment.Exit(1);
        }
    }
}