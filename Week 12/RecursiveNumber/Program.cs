class Program
{
    static Dictionary<int, string> Pronounciations = ReadPronounciations();

    static void Main()
    {
        Console.WriteLine("Checking step 1...");
        for (int number = 1; number <= 20; number++)
            Check(number, "Step 1");
        Console.WriteLine("Step 1 finished! All numbers from 1 to 20 are pronounced correctly");

        Console.WriteLine("Checking step 2...");
        for (int number = 10; number < 100; number += 10)
            Check(number, "Step 2");
        Console.WriteLine("Step 2 finished! All multiples of 10 up to 90 are pronounced correctly");

        Console.WriteLine("Checking step 3...");
        for (int number = 1; number <= 99; number++)
            Check(number, "Step 3");
        Console.WriteLine("Step 3 finished! All numbers from 1 to 99 are pronounced correctly");

        if (Speaker.Speak(100) != "onbekend")
        {
            Console.WriteLine("OPTIONAL: Checking step 4 and 5...");
            for (int number = 1; number <= 199_999; number++)
                Check(number, "OPTINAL");
            Console.WriteLine($"OPTIONAL: Step 4 and 5 finished! All numbers from 1 to 199_999 are pronounced correctly");
        }
    }

    static Dictionary<int, string> ReadPronounciations()
    {
        Dictionary<int, string> pronounciations = new();
        string[] lines = File.ReadAllLines("Pronounciations.csv");
        foreach (string line in lines)
        {
            string[] fields = line.Split(',');
            pronounciations[int.Parse(fields[0])] = fields[1];
        }
        return pronounciations;
    }

    static void Check(int number, string prefix = "")
    {
        string actual = Speaker.Speak(number);
        string expected = Pronounciations[number];
        if (expected != actual)
        {
            Console.WriteLine($"{prefix}: {number} should be pronounced as \"{expected}\" but is pronounced as \"{actual}\"");
            Environment.Exit(1);
        }
    }
}