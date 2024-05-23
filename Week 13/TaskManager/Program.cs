class Program
{
    static void Main()
    {
        ToDo initial = new("Initial Planning and Budgeting", new ToDo[] {});
        ToDo speaker = new("Speaker Coordination", new ToDo[] { initial });
        ToDo venue = new("Venue Selection", new ToDo[] { initial });
        ToDo marketing = new("Marketing and Promotion", new ToDo[] { speaker, venue });
        ToDo registration = new("Registration Setup", new ToDo[] { marketing });
        ToDo logistics = new("Logistics Planning", new ToDo[] { marketing });
        ToDo final = new("Final Day-of-Event Coordination", new ToDo[] { registration, logistics });

        ToDo[] allToDos = new ToDo[] { initial, speaker, venue, marketing, registration, logistics, final };

        CheckStatus("After initialization", allToDos, 
            new ToDo[] { speaker, venue, marketing, registration, logistics, final }, 
            new ToDo[] { initial }, 
            new ToDo[] { });

        speaker.MarkAsDone(); // Doesn't do anything because speaker isn't busy

        CheckStatus("After speaker.MarkAsDone()", allToDos,
            new ToDo[] { speaker, venue, marketing, registration, logistics, final }, 
            new ToDo[] { initial }, 
            new ToDo[] { });

        initial.MarkAsDone();

        CheckStatus("After initial.MarkAsDone()", allToDos,
            new ToDo[] { marketing, registration, logistics, final }, 
            new ToDo[] { speaker, venue }, 
            new ToDo[] { initial });

        speaker.MarkAsDone();

        CheckStatus("After speaker.MarkAsDone()", allToDos,
            new ToDo[] { marketing, registration, logistics, final }, 
            new ToDo[] { venue }, 
            new ToDo[] { initial, speaker });

        venue.MarkAsDone();

        CheckStatus("After venue.MarkAsDone()", allToDos,
            new ToDo[] { registration, logistics, final }, 
            new ToDo[] { marketing }, 
            new ToDo[] { initial, speaker, venue });

        marketing.MarkAsDone();

        CheckStatus("After marketing.MarkAsDone()", allToDos,
            new ToDo[] { final },
            new ToDo[] { registration, logistics }, 
            new ToDo[] { initial, speaker, venue, marketing });

        registration.MarkAsDone();

        CheckStatus("After registration.MarkAsDone()", allToDos,
            new ToDo[] { final },
            new ToDo[] { logistics }, 
            new ToDo[] { initial, speaker, venue, marketing, registration });

        logistics.MarkAsDone();

        CheckStatus("After logistics.MarkAsDone()", allToDos,
            new ToDo[] { },
            new ToDo[] { final }, 
            new ToDo[] { initial, speaker, venue, marketing, registration, logistics });

        final.MarkAsDone();

        CheckStatus("After final.MarkAsDone()", allToDos,
            new ToDo[] { },
            new ToDo[] { }, 
            new ToDo[] { initial, speaker, venue, marketing, registration, logistics, final });

        Console.WriteLine("All tests passed.");
    }

    static void CheckStatus(string name, ToDo[] all, ToDo[] expectedWaiting, ToDo[] expectedBusy, ToDo[] expectedDone)
    {
        var actualWaiting = all.Where(t => t.IsWaiting);
        if (!actualWaiting.SequenceEqual(expectedWaiting))
        {
            Console.WriteLine($"{name} waiting failed:\n" 
                            + $"expected = {string.Join<ToDo>(" + ", expectedWaiting)}\n"
                            + $"actual = {string.Join(" + ", actualWaiting)}");
            Environment.Exit(1);
        }
        var actualBusy = all.Where(t => t.IsBusy);
        if (!actualBusy.SequenceEqual(expectedBusy))
        {
            Console.WriteLine($"{name} busy failed:\n" 
                            + $"expected = {string.Join<ToDo>(" + ", expectedBusy)}\n"
                            + $"actual = {string.Join(" + ", actualBusy)}");
            Environment.Exit(1);
        }
        var actualDone = all.Where(t => t.IsDone);
        if (!actualDone.SequenceEqual(expectedDone))
        {
            Console.WriteLine($"{name} done failed:\n" 
                            + $"expected = {string.Join<ToDo>(" + ", expectedDone)}\n"
                            + $"actual = {string.Join(" + ", actualDone)}");
            Environment.Exit(1);
        }
    }

    static void Check<T>(string name, T actual, T expected)
    {
        if (!actual.Equals(expected))
        {
            Console.WriteLine($"{name} failed:\nexpected: {expected}\nactual: {actual}");
            Environment.Exit(1);
        }
    }
}
