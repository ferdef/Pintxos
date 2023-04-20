using System.Security.Cryptography;
using System.Text;

namespace BlazorPintxos;

public class User
{
    private String? _password;

    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Fullname { get; set; }
    public string? Password {
        get { return _password; }
        set
        {
            _password = getHash(value);
        }
    }

    private static string getHash(string? text)  
    {  
    // SHA512 is disposable by inheritance.  
        using(var sha256 = SHA256.Create())  
        {  
            // Send a sample text to hash.  
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));  
            // Get the hashed string.  
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();  
        }  
    }  
}