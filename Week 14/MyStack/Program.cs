class Program
{
    static void Main(string[] args)
    {
        MyStack<int> ints = new();
        Check(ints.Pop(), default, "After initialization, Pop()");
        ints.Push(1);
        ints.Push(2);
        ints.Push(3);
        Check(ints.Peek(), 3, "After Push(1), Push(2) and Push(3), Peek()");
        Check(ints.Pop(), 3, "After Push(1), Push(2) and Push(3), the 1st Pop()");
        Check(ints.Peek(), 2, "After Push(1), Push(2), Push(3) and 1x Pop(), Peek()");
        Check(ints.Pop(), 2, "After Push(1), Push(2) and Push(3), the 2nd Pop()");
        Check(ints.Peek(), 1, "After Push(1), Push(2), Push(3) and 2x Pop(), Peek()");
        Check(ints.Pop(), 1, "After Push(1), Push(2) and Push(3), the 3rd Pop()");
        Check(ints.Peek(), default, "After Push(1), Push(2), Push(3) and 3x Pop(), Peek()");
        Check(ints.Pop(), default, "After Push(1), Push(2) and Push(3), the 4th Pop()");

        MyStack<double> doubles = new();
        doubles.Push(1.5);
        doubles.Push(2.1);
        doubles.Push(3.4);
        doubles.Push(4.7);
        doubles.ReverseTopElements(3);
        Check(doubles.Pop(), 2.1, "After Push(a), Push(b), Push(c), Push(d) and reverseTopElements(3), the 1st Pop()");
        Check(doubles.Pop(), 3.4, "After Push(a), Push(b), Push(c), Push(d) and reverseTopElements(3), the 2nd Pop()");
        Check(doubles.Pop(), 4.7, "After Push(a), Push(b), Push(c), Push(d) and reverseTopElements(3), the 3rd Pop()");
        Check(doubles.Pop(), 1.5, "After Push(a), Push(b), Push(c), Push(d) and reverseTopElements(3), the 4th Pop()");
        Check(doubles.Pop(), default, "After Push(a), Push(b), Push(c), Push(d) and reverseTopElements(3), the 5th Pop()");

        Console.WriteLine("All tests passed!");
    }

    static void Check<T>(T actual, T expected, string message) where T : IEquatable<T>
    {
        if (!actual.Equals(expected))
        {
            Console.WriteLine($"{message} should return {expected}, not {actual}");
            Environment.Exit(1);
        }
    }
}
