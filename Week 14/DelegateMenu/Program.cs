class Program
{
    static void Main()
    {
        TextWriter oldOut = Console.Out;
        StringWriter newOut = new();
        Console.SetOut(newOut);

        TextReader oldIn = Console.In;
        StringReader newIn = new("1\n2\n3\n9");
        Console.SetIn(newIn);

        Menu menu = new();
        menu.AddOption("1", "Say hello", () => Console.WriteLine("Hello"));
        menu.AddOption("2", "Say goodbye", () => Console.WriteLine("Goodbye"));
        menu.AddOption("9", "Exit", null);
        menu.Show();

        Console.SetOut(oldOut);
        Console.SetIn(oldIn);

        string actual = newOut.ToString().Replace("\r\n", "\n");
        string menutext = $"[1] Say hello\n[2] Say goodbye\n[9] Exit\nPlease choose an option and press Enter:";
        string expected = $"{menutext}\nHello\n{menutext}\nGoodbye\n{menutext}\nInvalid option, please try again\n{menutext}\n";
        if (actual != expected)
        {
            Console.WriteLine("Test failed");
            for (int i = 0; i < Math.Max(expected.Length, actual.Length); i++)
            {
                if (i == actual.Length || i == expected.Length || expected[i] != actual[i])
                {
                    Console.WriteLine($"The first {i} characters are as expected:");
                    Console.WriteLine("----------");
                    Console.WriteLine(actual[0..i]);	
                    Console.WriteLine("----------");
                    if (i == expected.Length)
                        Console.WriteLine("But then nothing is expected");
                    else
                        Console.WriteLine($"But then an '{expected[i]}' ({Convert.ToInt32(expected[i])}) is expected");
                    if (i == actual.Length)
                        Console.WriteLine("Instead nothing is found");
                    else
                        Console.WriteLine($"Instead an '{actual[i]}' ({Convert.ToInt32(actual[i])}) is found");
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Test passed successfully");
        }
    }
}