namespace Backend;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;
    private bool _isDescending;

    public DoublyLinkedList()
    {
        _head = null; // This line can be removed
        _tail = null; // This line can be removed
        _isDescending = false;
    }

    // Inserts the item directly in the position that keeps the list ordered
    // (ascending by default, descending once SortDescending has been used).
    public void Add(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        var current = _head;
        while (current != null && !GoesBefore(data, current.Data!))
        {
            current = current.Next;
        }

        if (current == null) // End
        {
            newNode.Prev = _tail;
            _tail!.Next = newNode;
            _tail = newNode;
            return;
        }
        if (current.Prev == null) // Beginning
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }
        // Middle
        newNode.Prev = current.Prev;
        newNode.Next = current;
        current.Prev.Next = newNode;
        current.Prev = newNode;
    }

    private bool GoesBefore(T newData, T existingData)
    {
        return _isDescending
            ? newData.CompareTo(existingData) > 0
            : newData.CompareTo(existingData) < 0;
    }

    // Changes the order of the list itself (not only the way it is shown).
    public void SortDescending()
    {
        if (_isDescending)
        {
            return;
        }
        var current = _head;
        while (current != null)
        {
            (current.Prev, current.Next) = (current.Next, current.Prev);
            current = current.Prev; // The old Next
        }
        (_head, _tail) = (_tail, _head);
        _isDescending = true;
    }

    // Returns every item that appears the most times (all of them if there is a tie).
    public List<T> GetModes()
    {
        var modes = new List<T>();
        var max = 0;
        var current = _head;
        while (current != null)
        {
            var value = current.Data;
            var count = 0;
            while (current != null && current.Data!.Equals(value)) // Equal items are together
            {
                count++;
                current = current.Next;
            }
            if (count > max)
            {
                max = count;
                modes.Clear();
                modes.Add(value!);
            }
            else if (count == max)
            {
                modes.Add(value!);
            }
        }
        return modes;
    }

    // One line per different item: the item followed by one * per occurrence.
    public string ToStringGraph()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            var value = current.Data;
            var count = 0;
            while (current != null && current.Data!.Equals(value))
            {
                count++;
                current = current.Next;
            }
            output += $"{value} {new string('*', count)}{Environment.NewLine}";
        }
        return output;
    }

    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    // Removes the first occurrence found.
    public bool Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data)) // Found
            {
                Unlink(current);
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    // Removes every occurrence found and returns how many were removed.
    public int RemoveAll(T data)
    {
        var removed = 0;
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            if (current.Data!.Equals(data))
            {
                Unlink(current);
                removed++;
            }
            current = next;
        }
        return removed;
    }

    private void Unlink(DoubleNode<T> node)
    {
        if (node.Prev == null) // Beginning
        {
            _head = node.Next;
        }
        else
        {
            node.Prev.Next = node.Next;
        }

        if (node.Next == null) // End
        {
            _tail = node.Prev;
        }
        else
        {
            node.Next.Prev = node.Prev;
        }
    }

    public override string ToString()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Next;
        }
        return $"{output} null";
    }

    public string ToStringReverse()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Prev;
        }
        return $"{output} null";
    }
}
