using CompanionStudio.Core.Engine;
using CompanionStudio.Core.Factory;
using CompanionStudio.Core.Factory;
using CompanionStudio.Core.Factory;
using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Manager;
using CompanionStudio.Core.Manager;
using CompanionStudio.Core.Memory;
using CompanionStudio.Core.Migration;
using CompanionStudio.Core.Migration;
using CompanionStudio.Core.Package;
using CompanionStudio.Core.Package;
using CompanionStudio.Core.Package;
using CompanionStudio.Core.Personality;
using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Registry;
using CompanionStudio.Core.Repository;
using CompanionStudio.Core.Repository;
using CompanionStudio.Core.Runtime;
using CompanionStudio.Core.Security;
using CompanionStudio.Core.Security;
using CompanionStudio.Core.Security;
using CompanionStudio.Core.Security;
using CompanionStudio.Core.Serialization;
using CompanionStudio.Core.Services;
using CompanionStudio.Core.State;
using CompanionStudio.Core.Version;
using CompanionStudio.Data.Storage;
using CompanionStudio.Data.Storage;
using CompanionStudio.Data.Storage;
using CompanionStudio.Data.Storage;
using CompanionStudio.Core.Runtime;

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

        Assert.NotNull(
    result.State);


        Assert.True(
            result.State.IsActive);


        Assert.Equal(
            "1.0",
            result.State.Version);
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
        Assert.NotEmpty(
    companion.IntegrityHash);


        Assert.NotNull(
            companion.State);


        Assert.True(
            companion.State.IsActive);


        Assert.Equal(
            "1.0",
            companion.State.Version);


        Assert.Equal(
            "Created",
            companion.State.Status);
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

public class CompanionVersionTests
{
    [Fact]
    public void Version_ShouldInitializeCorrectly()
    {
        var version =
            new CompanionVersion();


        Assert.Equal(
            "1.0",
            version.CreatedVersion);


        Assert.Equal(
            "1.0",
            version.CurrentVersion);
    }


    [Fact]
    public void Profile_ShouldContainVersion()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel(),
                new PersonalityModel());


        Assert.NotNull(
            profile.Version);


        Assert.Equal(
            "1.0",
            profile.Version.CurrentVersion);
    }
}

public class MigrationManagerTests
{
    [Fact]
    public void Migrate_ShouldUpdateCompanionVersion()
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


        var migration =
            new MigrationManager();


        migration.Migrate(
            profile,
            "2.0");


        Assert.Equal(
            "2.0",
            profile.Version.CurrentVersion);


        Assert.NotNull(
            profile.Version.LastMigration);


        Assert.Equal(
            "Lilith",
            profile.Identity.Name);
    }


    [Fact]
    public void Migrate_SameVersion_ShouldDoNothing()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel(),
                new PersonalityModel());


        var before =
            profile.Version.LastMigration;


        var migration =
            new MigrationManager();


        migration.Migrate(
            profile,
            "1.0");


        Assert.Equal(
            "1.0",
            profile.Version.CurrentVersion);


        Assert.Equal(
            before,
            profile.Version.LastMigration);
    }
}

public class CompanionSerializerTests
{
    [Fact]
    public void Serialize_ShouldCreateJson()
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


        var serializer =
            new CompanionSerializer();


        var json =
            serializer.Serialize(profile);


        Assert.Contains(
            "Lilith",
            json);
    }


    [Fact]
    public void Deserialize_ShouldRestoreCompanion()
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


        var serializer =
            new CompanionSerializer();


        var json =
            serializer.Serialize(profile);


        var result =
            serializer.Deserialize(json);


        Assert.NotNull(
            result);


        Assert.Equal(
            "Lilith",
            result!.Identity.Name);


        Assert.NotNull(
            result.State);


        Assert.NotNull(
            result.Version);
    }
}

public class CompanionPackageTests
{
    [Fact]
    public void Package_ShouldContainCompanionProfile()
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


        var package =
            new CompanionPackage(profile);


        Assert.NotNull(
            package.Profile);


        Assert.Equal(
            "Lilith",
            package.Profile.Identity.Name);


        Assert.Equal(
            "1.0",
            package.PackageVersion);
    }


    [Fact]
    public void Package_ShouldCreateTimestamp()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel(),
                new PersonalityModel());


        var package =
            new CompanionPackage(profile);


        Assert.NotEqual(
            default,
            package.CreatedAt);
    }
}

public class PackageSerializerTests
{
    [Fact]
    public void Serialize_ShouldCreatePackageJson()
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


        var package =
            new CompanionPackage(profile);


        var serializer =
            new PackageSerializer();


        var json =
            serializer.Serialize(package);


        Assert.Contains(
            "Lilith",
            json);


        Assert.Contains(
            "PackageVersion",
            json);
    }


    [Fact]
    public void Deserialize_ShouldRestorePackage()
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


        var package =
            new CompanionPackage(profile);


        var serializer =
            new PackageSerializer();


        var json =
            serializer.Serialize(package);


        var result =
            serializer.Deserialize(json);


        Assert.NotNull(
            result);


        Assert.Equal(
            "Lilith",
            result!.Profile.Identity.Name);


        Assert.Equal(
            "1.0",
            result.PackageVersion);
    }
}

public class IntegrityPackageVerifierTests
{
    [Fact]
    public void GenerateHash_ShouldCreatePackageFingerprint()
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


        var package =
            new CompanionPackage(profile);


        var verifier =
            new IntegrityPackageVerifier();


        var hash =
            verifier.GenerateHash(package);


        Assert.False(
            string.IsNullOrEmpty(hash));
    }


    [Fact]
    public void Verify_ShouldConfirmOriginalPackage()
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


        var package =
            new CompanionPackage(profile);


        var verifier =
            new IntegrityPackageVerifier();


        var hash =
            verifier.GenerateHash(package);


        var result =
            verifier.Verify(
                package,
                hash);


        Assert.True(result);
    }
}

public class CompanionRegistryTests
{
    [Fact]
    public void Register_ShouldAddCompanion()
    {
        var registry =
            new CompanionRegistry();


        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        registry.Register(profile);


        var result =
            registry.Find("CS-000001");


        Assert.NotNull(result);


        Assert.Equal(
            "Lilith",
            result!.Identity.Name);
    }


    [Fact]
    public void List_ShouldReturnAllCompanions()
    {
        var registry =
            new CompanionRegistry();


        registry.Register(
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel()));


        registry.Register(
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000002",
                    Name = "Atlas"
                },
                new PersonalityModel()));


        var result =
            registry.List();


        Assert.Equal(
            2,
            result.Count);
    }


    [Fact]
    public void Remove_ShouldDeleteCompanion()
    {
        var registry =
            new CompanionRegistry();


        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        registry.Register(profile);


        var removed =
            registry.Remove("CS-000001");


        Assert.True(removed);


        Assert.Null(
            registry.Find("CS-000001"));
    }
}

public class CompanionRuntimeTests
{
    [Fact]
    public void Start_ShouldActivateCompanion()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        var runtime =
            new CompanionRuntime();


        runtime.Start(profile);


        Assert.NotNull(
            runtime.ActiveCompanion);


        Assert.True(
            runtime.IsRunning);


        Assert.Equal(
            "Running",
            profile.State.Status);


        Assert.True(
            profile.State.IsActive);
    }


    [Fact]
    public void Stop_ShouldDeactivateCompanion()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        var runtime =
            new CompanionRuntime();


        runtime.Start(profile);

        runtime.Stop();


        Assert.False(
            runtime.IsRunning);


        Assert.Null(
            runtime.ActiveCompanion);


        Assert.Equal(
            "Stopped",
            profile.State.Status);


        Assert.False(
            profile.State.IsActive);
    }
}