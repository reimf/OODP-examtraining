public class Program
{
    public static void Main()
    {
        Employee employee1 = new("Ellis", "Boenders");
        Employee employee2 = new("Amy", "Sedir");
        Employee employee3 = new("Bernard", null);
        Employee employee4 = new("C", "Sedir");
        Employee employee5 = new("Bo", "Boenders");

        // FirstName
        Check(employee1.FirstName == "Ellis", "employee1.FirstName != \"Ellis\"");
        Check(employee2.FirstName == "Amy", "employee2.FirstName != \"Amy\"");
        Check(employee3.FirstName == "Bernard", "employee3.FirstName != \"Bernard\"");
        Check(employee4.FirstName == "C?", "employee4.FirstName != \"C?\"");
        Check(employee5.FirstName == "Bo?", "employee5.FirstName != \"Bo?\"");

        // LastName
        Check(employee1.LastName == "Boenders", "employee1.LastName != \"Boenders\"");
        Check(employee2.LastName == "Sedir", "employee2.LastName != \"Sedir\"");
        Check(employee3.LastName == "Onbekend", "employee3.LastName != \"Onbekend\"");
        Check(employee4.LastName == "Sedir", "employee4.LastName != \"Sedir\"");
        Check(employee5.LastName == "Boenders", "employee5.LastName != \"Boenders\"");

        // ToString
        Check(employee1.ToString() == "Ellis Boenders", "employee1.ToString() != \"Ellis Boenders\"");
        Check(employee2.ToString() == "Amy Sedir", "employee2.ToString() != \"Amy Sedir\"");
        Check(employee3.ToString() == "Bernard Onbekend", "employee3.ToString() != \"Bernard Onbekend\"");
        Check(employee4.ToString() == "C? Sedir", "employee4.ToString() != \"Charlotte Sedir\"");
        Check(employee5.ToString() == "Bo? Boenders", "employee5.ToString() != \"Bo? Boenders\"");

        // IComparable / CompareTo
        Check(employee1.CompareTo(null) < 0, "employee1.CompareTo(null) >= 0");       
        Check(employee1.CompareTo(employee1) == 0, "employee1.CompareTo(employee1) != 0");       
        Check(employee1.CompareTo(employee2) < 0, "employee1.CompareTo(employee2) >= 0");       
        Check(employee1.CompareTo(employee3) < 0, "employee1.CompareTo(employee3) >= 0");       
        Check(employee1.CompareTo(employee4) < 0, "employee1.CompareTo(employee4) >= 0");       
        Check(employee1.CompareTo(employee5) > 0, "employee1.CompareTo(employee5) <= 0");       
        Check(employee2.CompareTo(null) < 0, "employee2.CompareTo(null) >= 0");       
        Check(employee2.CompareTo(employee2) == 0, "employee2.CompareTo(employee2) != 0");       
        Check(employee2.CompareTo(employee3) > 0, "employee2.CompareTo(employee3) <= 0");       
        Check(employee2.CompareTo(employee4) < 0, "employee2.CompareTo(employee4) >= 0");       
        Check(employee2.CompareTo(employee5) > 0, "employee2.CompareTo(employee5) <= 0");       
        Check(employee3.CompareTo(null) < 0, "employee3.CompareTo(null) >= 0");       
        Check(employee3.CompareTo(employee3) == 0, "employee3.CompareTo(employee3) != 0");       
        Check(employee3.CompareTo(employee4) < 0, "employee3.CompareTo(employee4) >= 0");       
        Check(employee3.CompareTo(employee5) > 0, "employee3.CompareTo(employee5) <= 0");       
        Check(employee4.CompareTo(null) < 0, "employee4.CompareTo(null) >= 0");       
        Check(employee4.CompareTo(employee4) == 0, "employee4.CompareTo(employee4) != 0");       
        Check(employee4.CompareTo(employee5) > 0, "employee4.CompareTo(employee5) <= 0");       
        Check(employee5.CompareTo(null) < 0, "employee5.CompareTo(null) >= 0");       
        Check(employee5.CompareTo(employee5) == 0, "employee5.CompareTo(employee5) != 0");

        // Sort
        List<Employee> employees = new() { employee1, employee2, employee3, employee4, employee5, null };
        employees.Sort();
        Check(employees[0] == null, "employees[0] != null");
        Check(employees[1] == employee5, "employees[1] != employee5");
        Check(employees[2] == employee1, "employees[2] != employee1");
        Check(employees[3] == employee3, "employees[3] != employee3");
        Check(employees[4] == employee2, "employees[4] != employee2");
        Check(employees[5] == employee4, "employees[5] != employee4");
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