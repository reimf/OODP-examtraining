class Program
{
    static void Main()
    {
        Container container = new(3, 4);
        Check("Empty container", container, ". . . .\n. . . .\n. . . .");

        Check("Five boxes do not fit", container.FindPalletAndBox(5), (-1, -1));
        Check("Adding five boxes is not possible", container.AddBoxes(5, "X"), false);
        Check("Empty container is not full", container.IsFull(), false);
        Check("Container is still empty", container, ". . . .\n. . . .\n. . . .");

        Check("Four boxes do fit on first pallet", container.FindPalletAndBox(4), (0, 0));
        Check("Single box fits on first pallet", container.FindPalletAndBox(1), (0, 0));

        Check("Single box added", container.AddBoxes(1, "A"), true);
        Check("Container with 1 box", container, "A . . .\n. . . .\n. . . .");
        Check("Container with 1 box is not full", container.IsFull(), false);
        Check("Four boxes do now fit on second pallet", container.FindPalletAndBox(4), (1, 0));
        Check("Three boxes do still fit on first pallet", container.FindPalletAndBox(3), (0, 1));

        Check("Four boxes added", container.AddBoxes(4, "B"), true);
        Check("Container with 5 boxes", container, "A . . .\nB B B B\n. . . .");
        Check("Container with 5 boxes is not full", container.IsFull(), false);

        Check("Four boxes do now fit on third pallet", container.FindPalletAndBox(4), (2, 0));
        Check("Three boxes do still fit on first pallet", container.FindPalletAndBox(3), (0, 1));

        Check("Two boxes added", container.AddBoxes(2, "C"), true);
        Check("Container with 7 boxes", container, "A C C .\nB B B B\n. . . .");
        Check("Container with 7 boxes is not full", container.IsFull(), false);

        Check("Another two boxes added", container.AddBoxes(2, "D"), true);
        Check("Container with 9 boxes", container, "A C C .\nB B B B\nD D . .");
        Check("Container with 9 boxes is not full", container.IsFull(), false);

        Check("Another box added", container.AddBoxes(1, "E"), true);
        Check("Container with 10 boxes", container, "A C C E\nB B B B\nD D . .");
        Check("Container with 10 boxes is not full", container.IsFull(), false);

        Check("Last two boxes added", container.AddBoxes(2, "F"), true);
        Check("Full container with 12 boxes", container, "A C C E\nB B B B\nD D F F");
        Check("Container with 12 boxes is full", container.IsFull(), true);

        Check("Even a single box does not fit anymore", container.FindPalletAndBox(1), (-1, -1));

        Console.WriteLine("All tests passed successfully");
    }

    static void Check(string message, object actual, object expected)
    {
        string actualString = actual.ToString().Trim().Replace(" \n", "\n");
        string expectedString = expected.ToString();
        if (actualString != expectedString)
        {
            Console.WriteLine($"Test failed: {message}");
            Console.WriteLine($"Actual:\n{actualString}");
            Console.WriteLine($"Expected:\n{expectedString}");
            Environment.Exit(1);
        }
    }
}