public class Contact
{
    // Nullable türü kullanılıyor
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    // Parametresiz Constructor
    public Contact()
    {
        // Varsayılan değerler atıyoruz
        Name = string.Empty;
        Address = string.Empty;
        PhoneNumber = string.Empty;
        Email = string.Empty;
    }

    // Parametreli Constructor
    public Contact(string name, string address, string phoneNumber, string email)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}
