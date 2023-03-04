namespace HouseFinder360.Domain.User;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public UserRole UserRole { get; private set; }

    public User(Guid id, string firstName, string lastName, string email, string password, UserRole userRole)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        UserRole = userRole;
    }
}