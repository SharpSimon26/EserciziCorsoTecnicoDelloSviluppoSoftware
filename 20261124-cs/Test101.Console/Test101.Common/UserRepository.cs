namespace Test101.Common;

public class UserRepository
{
    private readonly List<User> _userList;

    public UserRepository()
    {
        _userList = [];
    }

    public void AddUser(User user)
    {
        _userList.Add(user);
    }

    public int Count()
    {
        return _userList.Count;
    }

    public User? GetUserById(int id)
    {
        return _userList.FirstOrDefault(x => x.Id == id);
    }

    public void DeleteUserById(int id)
    {
        var u = GetUserById(id);

        if (u != null)
        {
            _userList.Remove(u);
        }
    }
}
