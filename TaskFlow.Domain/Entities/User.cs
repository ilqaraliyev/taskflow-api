using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; private set; }
    public string Email { get; private set; }

    public User(string fullName, string email)
    {
        SetFullName(fullName);
        SetEmail(email);
    }

    public void SetFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Full Name cannot be empty", nameof(fullName));
        }

        FullName = fullName;
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            throw new ArgumentException("Invalid email format", nameof(email));
        }

        Email = email;
    }
}
