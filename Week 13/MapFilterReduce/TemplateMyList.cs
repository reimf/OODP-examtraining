using System.Collections;

public class MyList<T> : IEnumerable<T>
{
    private readonly List<T> Items = new();

    public override string ToString() => string.Join(",", Items);

    public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Add(T item) => Items.Add(item);
}
