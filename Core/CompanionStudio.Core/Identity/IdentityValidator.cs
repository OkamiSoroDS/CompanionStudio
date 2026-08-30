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
            $"{identity.CreatedAt:O}";



        using var sha =
            SHA256.Create();



        var bytes =
            Encoding.UTF8.GetBytes(data);



        var hash =
            sha.ComputeHash(bytes);



        return
            Convert.ToHexString(hash);

    }





    public string GenerateFingerprint(
        IdentityModel identity)
    {

        var data =
            $"{identity.Id}" +
            $"{identity.CreatedAt:O}" +
            $"{identity.Version}" +
            "COMPANION-STUDIO-CORE";



        using var sha =
            SHA256.Create();



        var bytes =
            Encoding.UTF8.GetBytes(data);



        var fingerprint =
            sha.ComputeHash(bytes);



        return
            "CS-" +
            Convert.ToHexString(fingerprint)
            .Substring(0, 32);

    }





    public bool Validate(
        IdentityModel identity)
    {

        var hash =
            GenerateHash(identity);



        return string.Equals(
            hash,
            identity.IntegrityHash,
            StringComparison.OrdinalIgnoreCase);

    }





    public bool ValidateFingerprint(
        IdentityModel identity)
    {

        var fingerprint =
            GenerateFingerprint(identity);



        return string.Equals(
            fingerprint,
            identity.IdentityFingerprint,
            StringComparison.OrdinalIgnoreCase);

    }



}