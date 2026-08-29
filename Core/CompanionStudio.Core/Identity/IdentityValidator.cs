using System.Security.Cryptography;
using System.Text;

namespace CompanionStudio.Core.Identity;

public class IdentityValidator
{
    public string GenerateHash(
        IdentityModel identity)
    {
        var data =
    $"{identity.Id}" +
    $"{identity.Name}" +
    $"{identity.Version}" +
    $"{identity.Description}" +
    $"{identity.CreatedAt}" +
    $"{identity.IsActive}";


        using var sha =
            SHA256.Create();


        var bytes =
            Encoding.UTF8.GetBytes(
                data);


        var hash =
            sha.ComputeHash(
                bytes);


        return Convert.ToHexString(
            hash);
    }



    public bool Validate(
        IdentityModel identity)
    {
        var hash =
            GenerateHash(
                identity);


        return hash ==
            identity.IntegrityHash;
    }
}