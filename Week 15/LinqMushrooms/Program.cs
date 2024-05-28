class Program
{
    static void Main()
    {
        // Check answers against expected results
        CheckAnswer(
            "The names of edible mushrooms with a cap diameter greater than 10cm",
            new List<string> { "Eekhoorntjesbrood", "Grote parasolzwam", "Shiitake", "Oesterzwam", "Reuzenbovist" },
            Questions.GetNamesOfEdibleMushroomsWithLargeCap()
        );
        CheckAnswer(
            "The names of mushrooms found in grasslands during autumn",
            new List<string> { "Weidechampignon", "Inktzwam", "Puntige kaalkopje" },
            Questions.GetNamesOfMushroomsInGrasslandsDuringAutumn()
        );
        CheckAnswer(
            "The edibility of the mushroom found in a mixed forest during spring, with a cap diameter smaller than 4 cm and an average weight of 15 grams",
            false,
            Questions.IsMushroomEdible()
        );
        CheckAnswer(
            "The scientific name of the heaviest mushroom", 
            "Calvatia gigantea",
            Questions.GetScientificNameOfHeaviestMushroom()
        );
        CheckAnswer(
            "How many types of cap shapes are there?",
            11,
            Questions.GetNumberOfCapShapes()
        );
        CheckAnswer(
            "The cap shape with the most types of mushrooms",
            "Rond",
            Questions.GetCapShapeWithMostTypesOfMushrooms()
        );
        Console.WriteLine("All tests passed successfully!");
    }

    static void CheckAnswer<T>(string question, T expected, T actual)
    {
        string expectedString = expected.ToString();
        string actualString = actual.ToString();
        if (expected is IEnumerable<string> expectedList && actual is IEnumerable<string> actualList)
        {
            expectedString = string.Join(", ", expectedList);
            actualString = string.Join(", ", actualList);
        }
        if (expectedString != actualString)
        {
            Console.WriteLine($"{question}:");
            Console.WriteLine($"Expected result: {expectedString}");
            Console.WriteLine($"Actual result: {actualString}");
            Environment.Exit(1);
        }
    }
}
