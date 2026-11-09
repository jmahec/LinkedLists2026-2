namespace Backend;

public class SinglyLinkedList<T>
{
    private Node<T>? _head;

    public SinglyLinkedList()
    {
        _head = null;
    }

    public void InsertAtBeginning(T data)
    {
        var newNode = new Node<T>(data);
        newNode.Next = _head;
        _head = newNode;
    }

    public void InsertAtEnd(T data)
    {
        var newNode = new Node<T>(data);
        if (_head == null)
        {
            _head = newNode;
            return;
        }
        var current = _head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    public override string ToString()
    {
        var output = string.Empty;
        var current = _head;
        while(current != null)
        {
            output += $"{current.Data} -> ";
            current = current.Next;
        }
        return $"{output} null";
    }

}