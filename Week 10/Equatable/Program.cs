class Program
{
    static void Main()
    {
        Visitor visitor1 = new("");
        Visitor visitor2 = new("1000000000");
        Visitor visitor3 = new("1020000000");
        Visitor visitor4 = new("1020300000");
        Visitor visitor5 = new("1020304000");
        Visitor visitor6 = null;

        Console.WriteLine(visitor6 == visitor1);

        // Constructor && Barcode Property
        Check(visitor1.Barcode == "0000000000", $"visitor1.Barcode != \"0000000000\"");	
        Check(visitor2.Barcode == "1000000000", $"visitor2.Barcode != \"1000000000\"");
        Check(visitor3.Barcode == "1020000000", $"visitor3.Barcode != \"1020000000\"");
        Check(visitor4.Barcode == "1020300000", $"visitor4.Barcode != \"1020300000\"");
        Check(visitor5.Barcode == "1020304000", $"visitor5.Barcode != \"1020304000\"");

        // ToString
        Check(visitor1.ToString() == "bezoeker 0000000000", $"visitor1.ToString() != \"bezoeker 0000000000\"");	
        Check(visitor2.ToString() == "bezoeker 1000000000", $"visitor2.ToString() != \"bezoeker 1000000000\"");	
        Check(visitor3.ToString() == "bezoeker 1020000000", $"visitor3.ToString() != \"bezoeker 1020000000\"");	
        Check(visitor4.ToString() == "bezoeker 1020300000", $"visitor4.ToString() != \"bezoeker 1020300000\"");	
        Check(visitor5.ToString() == "bezoeker 1020304000", $"visitor5.ToString() != \"bezoeker 1020304000\"");	

        // NumberOfDifferences
        Check(visitor1.NumberOfDifferences(visitor1) == 0, $"visitor1.NumberOfDifferences(visitor1) != 0");
        Check(visitor1.NumberOfDifferences(visitor2) == 1, $"visitor1.NumberOfDifferences(visitor2) != 1");
        Check(visitor1.NumberOfDifferences(visitor3) == 2, $"visitor1.NumberOfDifferences(visitor3) != 2");
        Check(visitor1.NumberOfDifferences(visitor4) == 3, $"visitor1.NumberOfDifferences(visitor4) != 3");
        Check(visitor1.NumberOfDifferences(visitor5) == 4, $"visitor1.NumberOfDifferences(visitor5) != 4");
        Check(visitor2.NumberOfDifferences(visitor2) == 0, $"visitor2.NumberOfDifferences(visitor2) != 0");
        Check(visitor2.NumberOfDifferences(visitor3) == 1, $"visitor2.NumberOfDifferences(visitor3) != 1");
        Check(visitor2.NumberOfDifferences(visitor4) == 2, $"visitor2.NumberOfDifferences(visitor4) != 2");
        Check(visitor2.NumberOfDifferences(visitor5) == 3, $"visitor2.NumberOfDifferences(visitor5) != 3");
        Check(visitor3.NumberOfDifferences(visitor3) == 0, $"visitor3.NumberOfDifferences(visitor3) != 0");
        Check(visitor3.NumberOfDifferences(visitor4) == 1, $"visitor3.NumberOfDifferences(visitor4) != 1");
        Check(visitor3.NumberOfDifferences(visitor5) == 2, $"visitor3.NumberOfDifferences(visitor5) != 2");
        Check(visitor4.NumberOfDifferences(visitor4) == 0, $"visitor4.NumberOfDifferences(visitor4) != 0");
        Check(visitor4.NumberOfDifferences(visitor5) == 1, $"visitor4.NumberOfDifferences(visitor5) != 1");
        Check(visitor5.NumberOfDifferences(visitor5) == 0, $"visitor5.NumberOfDifferences(visitor5) != 0");

        // Equals
        Check(!visitor1.Equals(null), $"visitor1.Equals(null)");
        Check(visitor1.Equals(visitor1), $"!visitor1.Equals(visitor1)");
        Check(visitor1.Equals(visitor2), $"!visitor1.Equals(visitor2)");
        Check(visitor1.Equals(visitor3), $"!visitor1.Equals(visitor3)");
        Check(!visitor1.Equals(visitor4), $"visitor1.Equals(visitor4)");
        Check(!visitor1.Equals(visitor5), $"visitor1.Equals(visitor5)");
        Check(!visitor2.Equals(null), $"visitor2.Equals(null)");
        Check(visitor2.Equals(visitor2), $"!visitor2.Equals(visitor2)");
        Check(visitor2.Equals(visitor3), $"!visitor2.Equals(visitor3)");
        Check(visitor2.Equals(visitor4), $"!visitor2.Equals(visitor4)");
        Check(!visitor2.Equals(visitor5), $"visitor2.Equals(visitor5)");
        Check(!visitor3.Equals(null), $"visitor3.Equals(null)");
        Check(visitor3.Equals(visitor3), $"!visitor3.Equals(visitor3)");
        Check(visitor3.Equals(visitor4), $"!visitor3.Equals(visitor4)");
        Check(visitor3.Equals(visitor5), $"!visitor3.Equals(visitor5)");
        Check(!visitor4.Equals(null), $"visitor4.Equals(null)");
        Check(visitor4.Equals(visitor4), $"!visitor4.Equals(visitor4)");
        Check(visitor4.Equals(visitor5), $"!visitor4.Equals(visitor5)");
        Check(!visitor5.Equals(null), $"visitor5.Equals(null)");
        Check(visitor5.Equals(visitor5), $"!visitor5.Equals(visitor5)");

        // == && !=
        Check(visitor1 == visitor1, $"visitor1 != visitor1");
        Check(visitor1 == visitor2, $"visitor1 != visitor2");
        Check(visitor1 == visitor3, $"visitor1 != visitor3");
        Check(visitor1 != visitor4, $"visitor1 == visitor4");
        Check(visitor1 != visitor5, $"visitor1 == visitor5");
        Check(visitor2 == visitor2, $"visitor2 != visitor2");
        Check(visitor2 == visitor3, $"visitor2 != visitor3");
        Check(visitor2 == visitor4, $"visitor2 != visitor4");
        Check(visitor2 != visitor5, $"visitor2 == visitor5");
        Check(visitor3 == visitor3, $"visitor3 != visitor3");
        Check(visitor3 == visitor4, $"visitor3 != visitor4");
        Check(visitor3 == visitor5, $"visitor3 != visitor5");
        Check(visitor4 == visitor4, $"visitor4 != visitor4");
        Check(visitor4 == visitor5, $"visitor4 != visitor5");
        Check(visitor5 == visitor5, $"visitor5 != visitor5");
    }

    static void Check(bool result, string description)
    {
        if (result)
        {
            Console.Write(".");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"ERROR: {description}");
        }
    }
}