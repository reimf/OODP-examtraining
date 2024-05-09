class Program
{
    public static void Main()
    {
        Person unknown = null;
        Person grandmaMothersSide = new("Grandma mothers side", 1920, unknown, unknown);
        Person grandpaFathersSide = new("Grandpa fathers side", 1912, unknown, unknown);
        Person grandmaFathersSide = new("Grandma fathers side", 1910, unknown, unknown);
        Person mother = new("Mother", 1946, grandmaMothersSide, unknown);
        Person father = new("Father", 1948, grandmaFathersSide, grandpaFathersSide);
        Person me = new("Me", 1970, mother, father);

        string expectedGrandma = "Grandma mothers side";
        string actualGrandma = grandmaMothersSide.ToString();
        Check(actualGrandma == expectedGrandma, $"grandmaMothersSide.ToString() is {actualGrandma} instead of {expectedGrandma}");

        string expectedMother = "Mother (child of Grandma mothers side)";
        string actualMother = mother.ToString();
        Check(actualMother == expectedMother, $"mother.ToString() is {actualMother} instead of {expectedMother}");

        string expectedFather = "Father (child of Grandma fathers side and Grandpa fathers side)";
        string actualFather = father.ToString();
        Check(actualFather == expectedFather, $"father.ToString() is {actualFather} instead of {expectedFather}");

        string expectedMe = $"Me (child of {expectedMother} and {expectedFather})";
        string actualMe = me.ToString();
        Check(actualMe == expectedMe, $"me.ToString() is {actualMe} instead of {expectedMe}");

        List<Person> mothersActual = mother.AncestorsBornAfter(1945);
        List<Person> mothersExpected = new() { mother };
        foreach (Person person in mothersExpected)
            Check(mothersActual.Contains(person), $"mother.AncestorsBornAfter(1915) should contain {person}");
        foreach (Person person in mothersActual)
            Check(mothersExpected.Contains(person), $"mother.AncestorsBornAfter(1915) should not contain {person}");

        List<Person> myActual = me.AncestorsBornAfter(1915);
        List<Person> myExpected = new() { me, mother, father, grandmaMothersSide };
        foreach (Person person in myExpected)
            Check(myActual.Contains(person), $"me.AncestorsBornAfter(1915) should contain {person}");
        foreach (Person person in myActual)
            Check(myExpected.Contains(person), $"me.AncestorsBornAfter(1915) should not contain {person}");

        Console.WriteLine("Your family passed all the checks!");
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