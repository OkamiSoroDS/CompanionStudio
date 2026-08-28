using CompanionStudio.Core.Engine;
using CompanionStudio.Core.Factory;
using CompanionStudio.Core.Factory;
using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Manager;
using CompanionStudio.Core.Memory;
using CompanionStudio.Core.Personality;
using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Repository;
using CompanionStudio.Core.Security;
using CompanionStudio.Core.Security;
using CompanionStudio.Core.Services;
using CompanionStudio.Data.Storage;
using CompanionStudio.Data.Storage;
using CompanionStudio.Data.Storage;
using CompanionStudio.Core.Manager;
using CompanionStudio.Core.Factory;
using CompanionStudio.Core.Repository;
using CompanionStudio.Core.Security;
using CompanionStudio.Data.Storage;
using CompanionStudio.Core.State;

namespace CompanionStudio.Tests;

public class IdentityFileStorageTests
{
    [Fact]
    public void Save_ShouldCreateIdentityFile()
    {
        var storage = new IdentityFileStorage(
     Path.Combine(
         Path.GetTempPath(),
         Guid.NewGuid() + ".json"));

        var identity = new IdentityModel
        {
            Id = "CS-000001",
            Name = "Lilith",
            Description = "Asistente personal",
            IsActive = true
        };

        storage.Save(
            new List<IdentityModel>
            {
                identity
            });

        var result = storage.Load();

        Assert.Single(result);
        Assert.Equal("Lilith", result.First().Name);
    }
}


public class IdentityServiceTests
{
    [Fact]
    public void Create_ShouldSaveIdentityAutomatically()
    {
        var storage = new IdentityFileStorage(
    Path.Combine(
        Path.GetTempPath(),
        Guid.NewGuid() + ".json"));

        var service = new IdentityService(storage);

        var identity = service.Create(
            "Lilith",
            "Asistente personal");

        var saved = storage.Load();

        Assert.Contains(
            saved,
            x => x.Name == identity.Name);
    }
}

public class MemoryTests
{
    [Fact]
    public void Save_ShouldCreateMemoryFile()
    {
        var storage = new MemoryFileStorage();

        var memory = new MemoryModel
        {
            Id = "MEM-000001",
            Type = "fact",
            Content = "Primera memoria",
            Importance = 80,
            CreatedAt = DateTime.Now
        };

        storage.Save(
            new List<MemoryModel>
            {
                memory
            });

        var result = storage.Load();

        Assert.Single(result);
        Assert.Equal(
            "Primera memoria",
            result.First().Content);
    }


    [Fact]
    public void Create_ShouldSaveMemoryAutomatically()
    {
        var storage = new MemoryFileStorage();

        var service = new MemoryService(storage);

        var memory = service.Create(
            "fact",
            "Companion Studio tiene memoria persistente",
            90);

        var saved = storage.Load();

        Assert.Contains(
            saved,
            x => x.Content == memory.Content);
    }
}

public class PersonalityTests
{
    [Fact]
    public void Save_ShouldCreatePersonalityFile()
    {
        var storage = new PersonalityFileStorage();

        var personality = new PersonalityModel
        {
            Id = "PER-000001",
            Name = "Lilith",
            Tone = "Cálido",
            Humor = 70,
            Curiosity = 90,
            Formality = 40,
            CreatedAt = DateTime.Now
        };

        storage.Save(
            new List<PersonalityModel>
            {
                personality
            });

        var result = storage.Load();

        Assert.Single(result);
        Assert.Equal(
            "Lilith",
            result.First().Name);
    }


    [Fact]
    public void Create_ShouldSavePersonalityAutomatically()
    {
        var storage = new PersonalityFileStorage();

        var service = new PersonalityService(storage);

        var personality = service.Create(
            "Lilith",
            "Cálido",
            70,
            90,
            40);

        var saved = storage.Load();

        Assert.Contains(
            saved,
            x => x.Name == personality.Name);
    }
}

public class IntegrityTests
{
    [Fact]
    public void CreateHash_ShouldGenerateHash()
    {
        var checker = new IntegrityChecker();

        var hash = checker.CreateHash(
            "Lilith");

        Assert.NotEmpty(hash);
    }


    [Fact]
    public void Verify_ShouldDetectValidContent()
    {
        var checker = new IntegrityChecker();

        var content = "Companion Studio";

        var hash = checker.CreateHash(content);

        var result = checker.Verify(
            content,
            hash);

        Assert.True(result);
    }


    [Fact]
    public void Verify_ShouldDetectModifiedContent()
    {
        var checker = new IntegrityChecker();

        var hash = checker.CreateHash(
            "Companion Studio");

        var result = checker.Verify(
            "Companion Studio Modificado",
            hash);

        Assert.False(result);
    }
}

public class CompanionEngineTests
{
    [Fact]
    public void Engine_ShouldCreateCompanion()
    {
        var identity = new IdentityModel
        {
            Id = "CS-000001",
            Name = "Lilith",
            Description = "Asistente personal",
            IsActive = true
        };

        var personality = new PersonalityModel
        {
            Id = "PER-000001",
            Name = "Lilith",
            Tone = "Cálido",
            Humor = 70,
            Curiosity = 90,
            Formality = 40
        };

        var engine = new CompanionEngine(
            identity,
            personality);

        Assert.Equal(
            "Lilith",
            engine.Identity.Name);

        Assert.Equal(
            "Lilith",
            engine.Personality.Name);
    }


    [Fact]
    public void Engine_ShouldStoreMemory()
    {
        var identity = new IdentityModel();

        var personality = new PersonalityModel();

        var engine = new CompanionEngine(
            identity,
            personality);

        var memory = new MemoryModel
        {
            Id = "MEM-000001",
            Content = "Primer recuerdo"
        };

        engine.AddMemory(memory);

        Assert.Single(engine.Memories);

        Assert.Equal(
            "Primer recuerdo",
            engine.Memories.First().Content);
    }
}

public class CompanionProfileTests
{
    [Fact]
    public void Profile_ShouldInitializeState()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel
                {
                    Id = "PER-000001",
                    Name = "Lilith"
                });


        Assert.NotNull(
            profile.State);


        Assert.True(
            profile.State.IsActive);


        Assert.Equal(
            "1.0",
            profile.State.Version);


        Assert.Equal(
            "Created",
            profile.State.Status);
    }


    [Fact]
    public void Profile_ShouldAddMemory()
    {
        var profile = new CompanionProfile(
            new IdentityModel(),
            new PersonalityModel());


        var memory = new MemoryModel
        {
            Id = "MEM-000001",
            Content = "Primer recuerdo"
        };


        profile.AddMemory(memory);


        Assert.Single(
            profile.Memories);


        Assert.Equal(
            "Primer recuerdo",
            profile.Memories.First().Content);
    }
}

public class ProfileIntegrityTests
{
    [Fact]
    public void GenerateHash_ShouldCreateIntegrityHash()
    {
        var profile = new CompanionProfile(
            new IdentityModel
            {
                Id = "CS-000001",
                Name = "Lilith"
            },
            new PersonalityModel
            {
                Id = "PER-000001",
                Name = "Lilith"
            });


        var service = new ProfileIntegrityService();


        var hash = service.GenerateHash(profile);


        Assert.NotEmpty(hash);

        Assert.Equal(
            hash,
            profile.IntegrityHash);
    }


    [Fact]
    public void Verify_ShouldDetectOriginalProfile()
    {
        var profile = new CompanionProfile(
            new IdentityModel
            {
                Id = "CS-000001",
                Name = "Lilith"
            },
            new PersonalityModel
            {
                Id = "PER-000001",
                Name = "Lilith"
            });


        var service = new ProfileIntegrityService();


        service.GenerateHash(profile);


        var result = service.Verify(profile);


        Assert.True(result);
    }


    [Fact]
    public void Verify_ShouldDetectModifiedProfile()
    {
        var profile = new CompanionProfile(
            new IdentityModel
            {
                Id = "CS-000001",
                Name = "Lilith"
            },
            new PersonalityModel
            {
                Id = "PER-000001",
                Name = "Lilith"
            });


        var service = new ProfileIntegrityService();


        service.GenerateHash(profile);


        profile.Identity.Name = "Lilith_Modificada";


        var result = service.Verify(profile);


        Assert.False(result);
    }
}

public class CompanionProfileStorageTests
{
    [Fact]
    public void Save_ShouldCreateCompanionFile()
    {
        var path = Path.Combine(
            Path.GetTempPath(),
            Guid.NewGuid() + ".json");


        var storage =
            new CompanionProfileFileStorage(path);


        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel
                {
                    Id = "PER-000001",
                    Name = "Lilith",
                    Tone = "Cálido"
                });


        storage.Save(profile);


        var result =
            storage.Load();


        Assert.NotNull(result);

        Assert.Equal(
            "Lilith",
            result!.Identity.Name);
    }
}

public class CompanionFactoryTests
{
    [Fact]
    public void Create_ShouldGenerateCompleteCompanion()
    {
        var factory = new CompanionFactory();


        var companion =
            factory.Create(
                "Lilith",
                "Asistente personal",
                "Cálido",
                70,
                90,
                40);


        Assert.NotNull(companion);


        Assert.Equal(
            "Lilith",
            companion.Identity.Name);


        Assert.Equal(
            "Lilith",
            companion.Personality.Name);


        Assert.NotEmpty(
            companion.IntegrityHash);
    }
}

public class CompanionRepositoryTests
{
    [Fact]
    public void SaveAndLoad_ShouldPersistCompanion()
    {
        var path = Path.Combine(
            Path.GetTempPath(),
            Guid.NewGuid() + ".json");


        var storage =
            new CompanionProfileFileStorage(path);


        var repository =
            new CompanionRepository(storage);


        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel
                {
                    Id = "PER-000001",
                    Name = "Lilith",
                    Tone = "Cálido"
                });


        repository.Save(profile);


        var result =
            repository.Load();


        Assert.NotNull(result);


        Assert.Equal(
            "Lilith",
            result!.Identity.Name);
    }
}

public class CompanionManagerTests
{
    [Fact]
    public void Create_ShouldSaveAndLoadCompanion()
    {
        var path = Path.Combine(
            Path.GetTempPath(),
            Guid.NewGuid() + ".json");


        var storage =
            new CompanionProfileFileStorage(path);


        var repository =
            new CompanionRepository(storage);


        var manager =
            new CompanionManager(
                new CompanionFactory(),
                repository,
                new ProfileIntegrityService());


        var companion =
            manager.Create(
                "Lilith",
                "Asistente personal",
                "Cálido",
                70,
                90,
                40);


        var loaded =
            manager.Load();


        Assert.NotNull(loaded);


        Assert.Equal(
            "Lilith",
            loaded!.Identity.Name);


        Assert.True(
            manager.Verify(companion));
    }
}

public class CompanionStateTests
{
    [Fact]
    public void State_ShouldInitializeCorrectly()
    {
        var state = new CompanionState
        {
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            LastLoaded = DateTime.UtcNow,
            Version = "1.0",
            Status = "Active"
        };


        Assert.True(
            state.IsActive);


        Assert.Equal(
            "1.0",
            state.Version);


        Assert.Equal(
            "Active",
            state.Status);
    }


    [Fact]
    public void State_ShouldUpdateStatus()
    {
        var state = new CompanionState();


        state.Status = "Running";


        Assert.Equal(
            "Running",
            state.Status);
    }
}

