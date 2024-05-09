public class Program
{
    public static void Main()
    {
        YearCalender year2024 = new(2024);

        // Property Year
        Check(year2024.Year == 2024, "The property Year is not set correctly.");

        // Property Holidays
        Check(year2024.Holidays.Length == 12, "The array Holidays is not set correctly dimensioned.");
        Check(year2024.Holidays[0] == null, "The array Holidays already contains days.");

        // Method MonthLength
        Check(year2024.MonthLength(1) == 31, "The number of days for January is not 31.");
        Check(year2024.MonthLength(2) == 29, "The number of days for February 2024 is not 29.");
        Check(year2024.MonthLength(3) == 31, "The number of days for March is not 31.");
        Check(year2024.MonthLength(4) == 30, "The number of days for April is not 30.");
        Check(year2024.MonthLength(5) == 31, "The number of days for May is not 31.");
        Check(year2024.MonthLength(6) == 30, "The number of days for June is not 30.");
        Check(year2024.MonthLength(7) == 31, "The number of days for July is not 31.");
        Check(year2024.MonthLength(8) == 31, "The number of days for August is not 31.");
        Check(year2024.MonthLength(9) == 30, "The number of days for September is not 30.");
        Check(year2024.MonthLength(10) == 31, "The number of days for October is not 31.");
        Check(year2024.MonthLength(11) == 30, "The number of days for November is not 30.");
        Check(year2024.MonthLength(12) == 31, "The number of days for December is not 31.");
        Check(new YearCalender(2025).MonthLength(2) == 28, "The number of days for February 2025 is not 28.");
        Check(new YearCalender(2000).MonthLength(2) == 29, "The number of days for February 2000 is not 29.");
        Check(new YearCalender(2100).MonthLength(2) == 28, "The number of days for February 2100 is not 28.");
        Check(year2024.MonthLength(0) == 0, "The number of days for Month 0 is not 0.");
        Check(year2024.MonthLength(13) == 0, "The number of days for Month 13 is not 0.");

        // Method FillHolidays
        year2024.FillHolidays();
        Check(year2024.Holidays[0].Length == 31, "The number of days for January is not set correctly.");
        Check(year2024.Holidays[1].Length == 29, "The number of days for February 2024 is not set correctly.");
        Check(year2024.Holidays[2].Length == 31, "The number of days for March is not set correctly.");
        Check(year2024.Holidays[3].Length == 30, "The number of days for April is not set correctly.");
        Check(year2024.Holidays[4].Length == 31, "The number of days for May is not set correctly.");
        Check(year2024.Holidays[5].Length == 30, "The number of days for June is not set correctly.");
        Check(year2024.Holidays[6].Length == 31, "The number of days for July is not set correctly.");
        Check(year2024.Holidays[7].Length == 31, "The number of days for August is not set correctly.");
        Check(year2024.Holidays[8].Length == 30, "The number of days for September is not set correctly.");
        Check(year2024.Holidays[9].Length == 31, "The number of days for October is not set correctly.");
        Check(year2024.Holidays[10].Length == 30, "The number of days for November is not set correctly.");
        Check(year2024.Holidays[11].Length == 31, "The number of days for December is not set correctly.");

        Check(year2024.Holidays[0][0] == false, "The days are not initialised correctly.");

        // Method IsValidDay
        Check(year2024.IsValidDay(1, 1), "The day 1, 1 is a valid day.");
        Check(year2024.IsValidDay(1, 31), "The day 1, 31 is a valid day.");
        Check(year2024.IsValidDay(2, 29), "The day 2, 29 is a valid day.");
        Check(year2024.IsValidDay(12, 31), "The day 12, 31 is a valid day.");

        Check(!year2024.IsValidDay(0, 1), "The day 0, 1 is not a valid day.");
        Check(!year2024.IsValidDay(1, 0), "The day 1, 0 is not a valid day.");
        Check(!year2024.IsValidDay(1, 32), "The day 1, 32 is not a valid day.");
        Check(!year2024.IsValidDay(2, 30), "The day 2, 30 is not a valid day.");
        Check(!year2024.IsValidDay(13, 0), "The day 13, 0 is not a valid day.");
        Check(!year2024.IsValidDay(13, 1), "The day 13, 1 is not a valid day.");

        // Method AddHoliday
        Check(year2024.AddHoliday(1, 1) == true, "The day 1, 1 is a valid day.");
        Check(year2024.Holidays[0][0] == true, "The day 1, 1 is not set to a holiday.");

        Check(year2024.AddHoliday(12, 25) == true, "The day 12, 25 is a valid day.");
        Check(year2024.Holidays[11][24] == true, "The day 12, 25 is not set to a holiday.");

        Check(year2024.AddHoliday(0, 0) == false, "The day 0, 0 is not a valid day.");

        // Method IsHoliday
        Check(year2024.IsValidHoliday(1, 0) == (isValidDay: false, isHoliday: false), "The day 1, 0 is valid.");
        Check(year2024.IsValidHoliday(1, 1) == (isValidDay: true, isHoliday: true), "The day 1, 1 is a holiday.");
        Check(year2024.IsValidHoliday(1, 2) == (isValidDay: true, isHoliday: false), "The day 1, 2 is not a holiday.");

        // Done
        Console.WriteLine("All is well my friend!");
    }

    public static void Check(bool condition, string error)
    {
        if (!condition) {
            Console.WriteLine(error);
            Environment.Exit(1);
        }
    }
}