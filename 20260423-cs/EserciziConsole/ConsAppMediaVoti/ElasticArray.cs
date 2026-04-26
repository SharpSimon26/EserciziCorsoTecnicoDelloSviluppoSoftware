namespace ConsAppMediaVoti;

internal class ElasticArray<T>
{
    //private T[] _items;
    private ElasticArrayIytem<T> _first;

    public ElasticArray()
    {
        //_items = new T[0];
    }

    public T[] GetItems()
    {
        //return _items;
        List<T> itemValues = [];
        var currentItem = _first;

        do {
            itemValues.Add(currentItem.Value);
        } while (currentItem.Next != null);

        return itemValues.ToArray();
    }

    public void Push(T value)
    {
        //Array.Resize(ref _items, _items.Length + 1);
        //_items[_items.Length - 1] = value;

        ElasticArrayIytem<T> cell = new()
        {
            Value = value
        };

        if (_first == null)
        {
            _first = cell;
        }        
        else
        {
            ElasticArrayIytem<T> tmp = _first;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }

            tmp.Next = cell;            
        }
    }

    public int GetLength()
    {
        // return _items.Length;

        var count = 0;
        var currentItem = _first;

        while (currentItem.Next != null)
        {
            count++;
            currentItem = currentItem.Next;
        }

        return count;
    }

    public T GetItem(int index)
    {
        // return _items[index];
        var num = 0;
        var currentItem = _first;
        
        while (num < index)
        {
            currentItem = currentItem.Next;
            num++;
        }

        return currentItem.Value;
    }
}