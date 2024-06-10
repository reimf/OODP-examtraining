class Program
{
    static void Main()
    {
        Synonyms synonyms = new();
        Check("Empty dictionary", synonyms.ToString(), "");

        Check("Synonym of unknown word", synonyms.Get("onbekend"), null);

        synonyms.Add("kapot", "stuk");
        Check("Dictionary with 1 synonym", synonyms.ToString(), "kapot,stuk");

        Check("Synonym of unknown word", synonyms.Get("onbekend"), null);
        Check("Synonym of kapot", synonyms.Get("kapot"), "stuk");
        Check("Synonym of stuk", synonyms.Get("stuk"), "kapot");

        synonyms.Add("hollen", "rennen");
        Check("Dictionary with 2 synonyms", synonyms.ToString(), "hollen,kapot,rennen,stuk");

        Check("Synonym of unknown word", synonyms.Get("onbekend"), null);
        Check("Synonym of kapot", synonyms.Get("kapot"), "stuk");
        Check("Synonym of stuk", synonyms.Get("stuk"), "kapot");
        Check("Synonym of hollen", synonyms.Get("hollen"), "rennen");
        Check("Synonym of rennen", synonyms.Get("rennen"), "hollen");

        synonyms.Add("maar", "echter");
        Check("Dictionary with 3 synonyms", synonyms.ToString(), "echter,hollen,kapot,maar,rennen,stuk");
        synonyms.Remove("kapot");
        Check("Dictionary with 2 synonyms left", synonyms.ToString(), "echter,hollen,maar,rennen");
        synonyms.Remove("rennen");
        Check("Dictionary with 1 synonym left", synonyms.ToString(), "echter,maar");
        synonyms.Remove("echter");
        Check("Dictionary with no synonyms left", synonyms.ToString(), "");

        Synonyms added = new();
        added.Add("lijst", "opsomming");
        added.Add("lijst", "reeks");
        Check("Dictionary with 2 overlapping synonyms added", added.ToString(), "lijst,opsomming,reeks");
        Check("Synonym of lijst in added", added.Get("lijst"), "reeks");
        Check("Synonym of opsomming in added", added.Get("opsomming"), "lijst");
        Check("Synonym of reeks in added", added.Get("reeks"), "lijst");

        Synonyms replaced = new();
        replaced.Replace("lijst", "opsomming");
        replaced.Replace("lijst", "reeks");
        Check("Dictionary with 2 overlapping synonyms replaced", replaced.ToString(), "lijst,reeks");
        Check("Synonym of lijst in replaced", replaced.Get("lijst"), "reeks");
        Check("Synonym of opsomming in replaced", replaced.Get("opsomming"), null);
        Check("Synonym of reeks in replaced", replaced.Get("reeks"), "lijst");

        Console.WriteLine("All checks passed succesfully!");
    }

    static void Check(string message, string actual, string expected)
    {
        if (actual != expected)
        {
            Console.WriteLine($"{message}: FAIL");
            Console.WriteLine($"Expected: {expected}");
            Console.WriteLine($"Actual: {actual}");
            Environment.Exit(1);
        }
    }
}