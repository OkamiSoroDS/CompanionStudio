using System.Security.Cryptography;
using System.Text;
using CompanionStudio.Core.Package;

namespace CompanionStudio.Core.Security;

public class IntegrityPackageVerifier
{
    public string GenerateHash(
        CompanionPackage package)
    {
        var json =
            System.Text.Json.JsonSerializer.Serialize(package);


        using var sha =
            SHA256.Create();


        var bytes =
            Encoding.UTF8.GetBytes(json);


        var hash =
            sha.ComputeHash(bytes);


        return Convert.ToHexString(hash);
    }


    public bool Verify(
        CompanionPackage package,
        string expectedHash)
    {
        var currentHash =
            GenerateHash(package);


        return currentHash ==
               expectedHash;
    }
}