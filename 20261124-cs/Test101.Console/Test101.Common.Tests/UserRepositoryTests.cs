namespace Test101.Common.Tests;

public class UserRepositoryTests
{
    [Fact]
    public void AddUser_ShouldAdd_NewUser()
    {
        // 1 Arrange
        var userRepository = new UserRepository();

        // 2 Act
        userRepository.AddUser(new User { Id = 5, FirstName = "Antonio", LastName = "Neri" });
        var user = userRepository.GetUserById(5);

        // 3 Assert
        Assert.NotNull(user);
        Assert.Equal(5, user.Id);
        Assert.Equal("Antonio", user.FirstName);
        Assert.Equal("Neri", user.LastName);
    }

    [Fact]
    public void GetUserById_ShouldReturn_User()
    {
        // 1 Arrange
        var userRepository = new UserRepository();
        userRepository.AddUser(new User { Id = 1, FirstName = "Mario", LastName = "Rossi" });
        userRepository.AddUser(new User { Id = 2, FirstName = "Luigi", LastName = "Bianchi" });
        userRepository.AddUser(new User { Id = 3, FirstName = "Paolo", LastName = "Verdi" });

        // 2 Act
        var result = userRepository.GetUserById(2);

        // 3 Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Id);
        Assert.Equal("Luigi", result.FirstName);
        Assert.Equal("Bianchi", result.LastName);
    }

    [Fact]
    public void GetUserById_ShouldReturn_Null_WhenUser_DoesNot_Exist()
    {
        // 1 Arrange
        var userRepository = new UserRepository();
        userRepository.AddUser(new User { Id = 1, FirstName = "Mario", LastName = "Rossi" });
        userRepository.AddUser(new User { Id = 2, FirstName = "Luigi", LastName = "Bianchi" });
        userRepository.AddUser(new User { Id = 3, FirstName = "Paolo", LastName = "Verdi" });

        // 2 Act
        var result = userRepository.GetUserById(80);

        // 3 Assert
        Assert.Null(result);
    }

    [Fact]
    public void Count_ShouldReturn_UsersCount()
    {
        // 1 Arrange
        var userRepository = new UserRepository();
        userRepository.AddUser(new User { Id = 1, FirstName = "Mario", LastName = "Rossi" });
        userRepository.AddUser(new User { Id = 2, FirstName = "Luigi", LastName = "Bianchi" });
        userRepository.AddUser(new User { Id = 3, FirstName = "Paolo", LastName = "Verdi" });

        // 2 Act
        var count = userRepository.Count();

        // 3 Assert
        Assert.Equal(3, count);
    }

    [Fact]
    public void DeleteUserById_ShouldDelete_User()
    {
        // 1 Arrange
        var userRepository = new UserRepository();
        userRepository.AddUser(new User { Id = 1, FirstName = "Mario", LastName = "Rossi" });
        userRepository.AddUser(new User { Id = 2, FirstName = "Luigi", LastName = "Bianchi" });
        userRepository.AddUser(new User { Id = 3, FirstName = "Paolo", LastName = "Verdi" });

        // 2 Act
        userRepository.DeleteUserById(3);
        var user = userRepository.GetUserById(3);

        // 3 Assert
        Assert.Null(user);
        Assert.Equal(2, userRepository.Count());
    }

    [Fact]
    public void DeleteUserById_ShouldNotDelete_User_IfNotExists()
    {
        // 1 Arrange
        var userRepository = new UserRepository();
        userRepository.AddUser(new User { Id = 1, FirstName = "Mario", LastName = "Rossi" });
        userRepository.AddUser(new User { Id = 2, FirstName = "Luigi", LastName = "Bianchi" });
        userRepository.AddUser(new User { Id = 3, FirstName = "Paolo", LastName = "Verdi" });

        // 2 Act
        userRepository.DeleteUserById(30);
        var user = userRepository.GetUserById(30);

        // 3 Assert
        Assert.Null(user);
        Assert.Equal(3, userRepository.Count());
    }
}
