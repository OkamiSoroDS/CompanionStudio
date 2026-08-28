using System.Security.Cryptography;
using System.Text;

namespace CompanionStudio.Core.Security;

public class IntegrityChecker
{
    public string CreateHash(string content)
    {
        using var sha256 = SHA256.Create();

        var bytes = Encoding.UTF8.GetBytes(content);

        var hash = sha256.ComputeHash(bytes);

        return Convert.ToHexString(hash);
    }

    public bool Verify(
        string content,
        string hash)
    {
        var newHash = CreateHash(content);

        return newHash == hash;
    }
}