namespace CompanionStudio.Core.Identity;

public class CompanionIdentityService
{
    private readonly IdentityValidator validator;


    public CompanionIdentityService()
    {
        validator =
            new IdentityValidator();
    }


    public IdentityModel Create(
        string name,
        string description = "")
    {
        var identity =
            new IdentityModel
            {
                Id = Guid.NewGuid()
                    .ToString(),

                Name = name,

                Description = description,

                CreatedAt = DateTime.UtcNow,

                IsActive = true
            };


        identity.IntegrityHash =
            validator.GenerateHash(
                identity);


        return identity;
    }



    public bool Validate(
        IdentityModel identity)
    {
        return validator.Validate(
            identity);
    }



    public void RefreshHash(
        IdentityModel identity)
    {
        identity.IntegrityHash =
            validator.GenerateHash(
                identity);
    }
}