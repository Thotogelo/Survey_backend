namespace Survey_backend.Model;

public class UserDTO
{
    public string Id { get; set; }
    public string FullNames { get; set; }
    public string Email { get; set; }
    public string DateOfBirth { get; set; }
    public string MobileNumber { get; set; }

    public UserDTO()
    {
    }

    public UserDTO(string id, string fullNames, string email, string dateOfBirth, string mobileNumber)
    {
        Id = id;
        FullNames = fullNames;
        Email = email;
        DateOfBirth = dateOfBirth;
        MobileNumber = mobileNumber;
    }
}