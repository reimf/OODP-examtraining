using System.Text.Json;

static class TemplateQuestions
{
    private static readonly string json = File.ReadAllText("Mushrooms.json");
    private static readonly List<Mushroom> mushrooms =
        JsonSerializer.Deserialize<List<Mushroom>>(json);

    //What are the names of edible mushrooms
    //that have a cap diameter that can be greater than the 10cm?
    static IEnumerable<string> GetNamesOfEdibleMushroomsWithLargeCap() => default;

    // What are the names of mushrooms found in grasslands during autumn?
    static IEnumerable<string> GetNamesOfMushroomsInGrasslandsDuringAutumn() => default;

    // Is the mushroom edible that is found in a coniferous forests (naaldbos) during summer?
    static bool IsMushroomEdible() => default;

    //What is the scientific name of the heaviest mushroom?
    static string GetScientificNameOfHeaviestMushroom() => default;

    // How many types of cap shapes are there?
    static int GetNumberOfCapShapes() => default;

    //What is the cap shape with the most types of mushrooms?
    static string GetCapShapeWithMostTypesOfMushrooms() => default;
}
