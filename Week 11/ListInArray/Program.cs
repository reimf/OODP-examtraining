class Program
{
    public static void Main(string[] args)
    {
        FakeList<string> fake = new();
        Check(fake.Count == 0, "With no elements the length should be 0");
        Check(fake.Capacity == 1, "With no elements the capacity should be 1");
        Check(fake.Peek() == default, "With no elements Peek should return the default value");

        fake.Push("one");
        Check(fake.Count == 1, "With one element the length should be 1");
        Check(fake.Capacity == 1, "With one element the capacity should be 1");
        Check(fake.Peek() == "one", "With one element the last element should be one");

        fake.Push("two");
        Check(fake.Count == 2, "With two elements the length should be 2");
        Check(fake.Capacity == 2, "With two elements the capacity should be 2");
        Check(fake.Peek() == "two", "With two elements the last element should be two");

        fake.Push("three");
        Check(fake.Count == 3, "With three elements the length should be 3");
        Check(fake.Capacity == 4, "With three elements the capacity should be 4");
        Check(fake.Peek() == "three", "With three elements the last element should be three");

        fake.Push("four");
        Check(fake.Count == 4, "With four elements the length should be 4");
        Check(fake.Capacity == 4, "With four elements the capacity should be 4");
        Check(fake.Peek() == "four", "With four elements the last element should be four");

        fake.Push("five");
        Check(fake.Count == 5, "With five elements the length should be 5");
        Check(fake.Capacity == 8, "With five elements the capacity should be 8");
        Check(fake.Peek() == "five", "With five elements the last element should be five");

        string five = fake.Pop();
        Check(five == "five", "With five elements Pop should return five");
        Check(fake.Count == 4, "After popping the fifth element the length should be 4");
        Check(fake.Capacity == 4, "After popping the fifth element the capacity should be 4");
        Check(fake.Peek() == "four", "After popping the fifth element the last element should be four");

        string four = fake.Pop();
        Check(four == "four", "With four elements Pop should return four");
        Check(fake.Count == 3, "After popping the fourth element the length should be 3");
        Check(fake.Capacity == 4, "After popping the fourth element the capacity should be 4");
        Check(fake.Peek() == "three", "After popping the fourth element the last element should be three");

        string three = fake.Pop();
        Check(three == "three", "With three elements Pop should return three");
        Check(fake.Count == 2, "After popping the third element the length should be 2");
        Check(fake.Capacity == 2, "After popping the third element the capacity should be 2");
        Check(fake.Peek() == "two", "After popping the third element the last element should be two");

        string two = fake.Pop();
        Check(two == "two", "With two elements Pop should return two");
        Check(fake.Count == 1, "After popping the second element the length should be 1");
        Check(fake.Capacity == 1, "After popping the second element the capacity should be 1");
        Check(fake.Peek() == "one", "After popping the second element the last element should be one");

        string one = fake.Pop();
        Check(one == "one", "With one element Pop should return one");
        Check(fake.Count == 0, "After popping the first element the length should be 0");
        Check(fake.Capacity == 1, "After popping the first element the capacity should be 1");
        Check(fake.Peek() == default, "After popping the first element Peek should return the default value");

        Console.WriteLine("All tests passed successfully!");
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