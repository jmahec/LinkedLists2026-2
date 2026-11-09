namespace Backend;

public class DoubleNode<T>
{
    public DoubleNode(T data)
    {
        Data = data;
        Prev = null; // This line can be removed
        Next = null; // This line can be removed
    }

    public DoubleNode<T>? Prev { get; set; }
    public T? Data { get; set; }
    public DoubleNode<T>? Next { get; set; }
}