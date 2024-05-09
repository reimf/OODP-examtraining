public class OneTimeReader
{
    private readonly string[] Array;
    private int Index = 0;

    public OneTimeReader(string[] array)
    {
        Array = array;
    }

    public string ReadNext()
    {
        if (Index >= Array.Length)
            return null;
        return Array[Index++];
    }
}