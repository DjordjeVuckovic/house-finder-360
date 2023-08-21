namespace HouseFinder360.Domain.Users;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserRole UserRole { get; private set; }
    public string Phone { get; private set; }

    public User(
        Guid id, 
        string firstName, 
        string lastName, 
        string email, 
        string password, 
        UserRole userRole, 
        string phone)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        UserRole = userRole;
        Phone = phone;
    }

    public void SetHash(string hash)
    {
        Password = hash;
    }

    public string GetRoleName() => UserRole.User.ToString().ToLower();
}