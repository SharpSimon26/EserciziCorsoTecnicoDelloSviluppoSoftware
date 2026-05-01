namespace ConsAppLinq.Models;

public class User
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public int BirthYear { get; set; }
    public string Job { get; set; } = string.Empty;

    public User() { }

    public User(string firstname, string lastname, int birthyear, string job)
    {
        Firstname = firstname;
        Lastname = lastname;
        BirthYear = birthyear;
        Job = job;
    }
}