class Program
{
    static void Main()
    {
        // a. The password must not be null or empty; hint: find a method that checks this.
        Weak("a", null);
        Weak("a", "");
        Console.WriteLine("Check a. is implemented correctly");

        // b. The password must have the character 'A' in it.
        Weak("b", "-#-B-x");
        Console.WriteLine("Check b. is implemented correctly");

        // c. The password must not start nor end with a white-space character.
        Weak("c", " A-#--x");
        Weak("c", "\tA-#--x");
        Weak("c", "A-#--x ");
        Weak("c", "A-#--x  ");
        Weak("c", "A-#--x\n");
        Console.WriteLine("Check c. is implemented correctly");
        
        // d. The password must contain exactly 3 dashes ('-'); hint: use the Split method.
        Weak("d", "A-#-xy");
        Weak("d", "A-#---x");
        Console.WriteLine("Check d. is implemented correctly");
        
        // e. The password length must be at least 6.
        Weak("e", "A-#--");
        Weak("e", "A---x");
        Console.WriteLine("Check e. is implemented correctly");

        // f. The third, fourth and/or fifth character must be a '#'.
        Weak("f", "A#---x");
        Weak("f", "Ax---#");
        Console.WriteLine("Check f. is implemented correctly");
        
        // g. The password must contain a lowercase character; hint: use the ToUpper or ToLower method.
        Weak("g", "A-#--B");
        Console.WriteLine("Check g. is implemented correctly");

        Strong("A-#--x");
        Strong("A-#--y");
        Strong("A--#-x");
        Strong("A---#x");
        Strong("A-#-!-x");
        Strong("A---#xyz");
        Strong("-x#- -AB");
        Console.WriteLine("IsStrong is implemented correctly");
    }

    static void Weak(string description, string password)
    {
        PasswordChecker pw = new();
        if (pw.IsStrong(password))
        {
            Console.Write($"Check {description}. is NOT implemented correctly, ");
            Console.WriteLine($"because password \"{password}\" should be weak");
            Environment.Exit(1);
        }
    }

    static void Strong(string password)
    {
        PasswordChecker pw = new();
        if (!pw.IsStrong(password))
        {
            Console.Write($"IsStrong is NOT implemented correctly, ");
            Console.WriteLine($"because password \"{password}\" should be strong");
            Environment.Exit(2);
        }
    }
}