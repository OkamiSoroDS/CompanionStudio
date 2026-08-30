using System;
using System.Collections.Generic;
using System.Linq;


namespace CompanionStudio.Core.Identity;


public class IdentityManager
{

    private readonly List<IdentityModel> identities;

    private readonly IdentityValidator validator = new();

    private int nextId;



    public IdentityManager(
        IIdentityStorage storage)
    {

        identities =
            storage.Load()
            .ToList();



        nextId =
            identities
            .Select(x =>
            {

                if (x.Id.StartsWith("CS-") &&
                    int.TryParse(
                        x.Id.Substring(3),
                        out int number))
                {
                    return number;
                }


                return 0;

            })
            .DefaultIfEmpty(0)
            .Max()
            + 1;

    }





    public IdentityModel CreateIdentity(
        string name,
        string description)
    {

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Identity name cannot be empty");
        }



        var identity =
            new IdentityModel
            {

                Id =
                    $"CS-{nextId:000000}",


                Name =
                    name.Trim(),


                Description =
                    description ?? string.Empty,


                CreatedAt =
                    DateTime.UtcNow,


                Version =
                    "1.0",


                IsActive =
                    true,


                IsLocked =
                    false

            };





        // ==============================
        // IDENTITY INTEGRITY CREATION
        // ==============================


        identity.IntegrityHash =
            validator
            .GenerateHash(identity);



        identity.IdentityFingerprint =
            validator
            .GenerateFingerprint(identity);





        // ==============================
        // CORE PROTECTION LOCK
        // ==============================


        identity.IsLocked =
            true;




        identities.Add(identity);



        nextId++;



        return identity;

    }





    public IEnumerable<IdentityModel> GetIdentities()
    {
        return identities;
    }

}