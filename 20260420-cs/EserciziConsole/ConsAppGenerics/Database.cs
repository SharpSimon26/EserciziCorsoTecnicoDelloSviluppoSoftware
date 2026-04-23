namespace ConsAppGenerics;


internal class Database<T> where T: Entity
{
    private T[] _items;

    public Database()
    {
        _items = [];
    }

    public T[] GetItems()
    {
        return _items;
    }

    public T? GetItemById(int id)
    {
        return _items.FirstOrDefault(m => m.Id == id);
    }

    public void AddItem(T item)
    {
        Array.Resize(ref _items, _items.Length + 1);
        _items[_items.Length -1] = item;
    }

    public void DeleteItem(int id)
    {
        var newItems = new List<T>(_items);
        var itemToRemove = newItems.FirstOrDefault(m => m.Id == id);
        if (itemToRemove != null)
        {
            newItems.Remove(itemToRemove);  
            _items = newItems.ToArray();          
        }
    }
}

internal class User : Entity
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
}

internal class Post : Entity
{
    public string Text { get; set; } = "";
    public string ImgPath { get; set; } = "";
}

internal class Entity
{
    public int Id { get; set; }
}