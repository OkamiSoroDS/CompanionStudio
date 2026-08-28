using CompanionStudio.Core.Api;
using CompanionStudio.Core.Backup;
using CompanionStudio.Core.Backup;
using CompanionStudio.Core.Commands;
using CompanionStudio.Core.Commands;
using CompanionStudio.Core.Configuration;
using CompanionStudio.Core.Configuration;
using CompanionStudio.Core.Engine;
using CompanionStudio.Core.Events;
using CompanionStudio.Core.Factory;
using CompanionStudio.Core.Factory;
using CompanionStudio.Core.Factory;
using CompanionStudio.Core.Health;
using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Lifecycle;
using CompanionStudio.Core.Lifecycle;
using CompanionStudio.Core.Logging;
using CompanionStudio.Core.Manager;
using CompanionStudio.Core.Manager;
using CompanionStudio.Core.Memory;
using CompanionStudio.Core.Migration;
using CompanionStudio.Core.Migration;
using CompanionStudio.Core.Modules;
using CompanionStudio.Core.Package;
using CompanionStudio.Core.Package;
using CompanionStudio.Core.Package;
using CompanionStudio.Core.Permissions;
using CompanionStudio.Core.Personality;
using CompanionStudio.Core.Personality;
using CompanionStudio.Core.Plugins;
using CompanionStudio.Core.Plugins;
using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Registry;
using CompanionStudio.Core.Repository;
using CompanionStudio.Core.Repository;
using CompanionStudio.Core.Runtime;
using CompanionStudio.Core.Runtime;
using CompanionStudio.Core.Scheduler;
using CompanionStudio.Core.Security;
using CompanionStudio.Core.Security;
using CompanionStudio.Core.Security;
using CompanionStudio.Core.Security;
using CompanionStudio.Core.Serialization;
using CompanionStudio.Core.Services;
using CompanionStudio.Core.State;
using CompanionStudio.Core.Storage;
using CompanionStudio.Core.Version;
using CompanionStudio.Data.Storage;
using CompanionStudio.Data.Storage;
using CompanionStudio.Data.Storage;
using CompanionStudio.Data.Storage;
using CompanionStudio.Core.Scheduler;
using CompanionStudio.Core.StateMachine;
using CompanionStudio.Core.Events;
using CompanionStudio.Core.Logging;
using CompanionStudio.Core.Migration;
using CompanionStudio.Core.Storage;

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

public class CompanionEventSystemTests
{
    [Fact]
    public void Publish_ShouldRegisterEvent()
    {
        var system =
            new CompanionEventSystem();


        var companionEvent =
            new CompanionEvent(
                "CompanionStarted");


        system.Publish(
            companionEvent);


        var events =
            system.GetAll();


        Assert.Single(
            events);


        Assert.Equal(
            "CompanionStarted",
            events.First().Name);
    }


    [Fact]
    public void MultipleEvents_ShouldKeepHistory()
    {
        var system =
            new CompanionEventSystem();


        system.Publish(
            new CompanionEvent(
                "CompanionStarted"));


        system.Publish(
            new CompanionEvent(
                "MemoryCreated"));


        system.Publish(
            new CompanionEvent(
                "VersionUpdated"));


        var events =
            system.GetAll();


        Assert.Equal(
            3,
            events.Count);
    }
}

public class CompanionLoggerTests
{
    [Fact]
    public void Log_ShouldCreateEntry()
    {
        var logger =
            new CompanionLogger();


        logger.Log(
            "CompanionStarted");


        var logs =
            logger.GetLogs();


        Assert.Single(
            logs);


        Assert.Contains(
            "CompanionStarted",
            logs.First());
    }


    [Fact]
    public void MultipleLogs_ShouldKeepHistory()
    {
        var logger =
            new CompanionLogger();


        logger.Log(
            "CompanionStarted");


        logger.Log(
            "MemoryCreated");


        logger.Log(
            "VersionUpdated");


        var logs =
            logger.GetLogs();


        Assert.Equal(
            3,
            logs.Count);
    }
}

public class CompanionConfigurationTests
{
    [Fact]
    public void Configuration_ShouldInitializeDefaults()
    {
        var config =
            new CompanionConfiguration();


        Assert.Equal(
            "Companions",
            config.StoragePath);


        Assert.Equal(
            "es",
            config.DefaultLanguage);


        Assert.True(
            config.AutoSave);


        Assert.True(
            config.LoggingEnabled);


        Assert.Equal(
            "1.0",
            config.Version);
    }


    [Fact]
    public void Configuration_ShouldAllowChanges()
    {
        var config =
            new CompanionConfiguration();


        config.DefaultLanguage = "en";

        config.AutoSave = false;


        Assert.Equal(
            "en",
            config.DefaultLanguage);


        Assert.False(
            config.AutoSave);
    }

    [Fact]
    public void Manager_ShouldUpdateConfiguration()
    {
        var manager =
            new CompanionConfigurationManager();


        var newConfig =
            new CompanionConfiguration
            {
                StoragePath = "LilithData",
                DefaultLanguage = "es",
                AutoSave = false,
                LoggingEnabled = true,
                Version = "2.0"
            };


        manager.Update(
            newConfig);


        var result =
            manager.Get();


        Assert.Equal(
            "LilithData",
            result.StoragePath);


        Assert.Equal(
            "2.0",
            result.Version);


        Assert.False(
            result.AutoSave);
    }
}

public class CompanionStorageManagerTests
{
    [Fact]
    public void Save_ShouldCreateCompanionFile()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        var package =
            new CompanionPackage(profile);


        var storage =
            new CompanionStorageManager();


        var path =
            "test.companion";


        storage.Save(
            package,
            path);


        Assert.True(
            File.Exists(path));


        storage.Delete(path);
    }


    [Fact]
    public void Load_ShouldRestorePackage()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        var package =
            new CompanionPackage(profile);


        var storage =
            new CompanionStorageManager();


        var path =
            "test.companion";


        storage.Save(
            package,
            path);


        var result =
            storage.Load(path);


        Assert.NotNull(
            result);


        Assert.Equal(
            "Lilith",
            result!.Profile.Identity.Name);


        storage.Delete(path);
    }
}

public class CompanionBackupManagerTests
{
    [Fact]
    public void CreateBackup_ShouldCreateFile()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        var package =
            new CompanionPackage(profile);


        var backup =
            new CompanionBackupManager();


        var path =
            "backup_test.companion";


        backup.CreateBackup(
            package,
            path);


        Assert.True(
            backup.Exists(path));


        File.Delete(path);
    }


    [Fact]
    public void RestoreBackup_ShouldRecoverPackage()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        var package =
            new CompanionPackage(profile);


        var backup =
            new CompanionBackupManager();


        var path =
            "backup_test.companion";


        backup.CreateBackup(
            package,
            path);


        var restored =
            backup.RestoreBackup(path);


        Assert.NotNull(
            restored);


        Assert.Equal(
            "Lilith",
            restored!.Profile.Identity.Name);


        File.Delete(path);
    }
}

public class CompanionHealthMonitorTests
{
    [Fact]
    public void HealthyCompanion_ShouldPassAllChecks()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        var monitor =
            new CompanionHealthMonitor();


        Assert.True(
            monitor.CheckIdentity(profile));


        Assert.True(
            monitor.CheckState(profile));


        Assert.True(
            monitor.CheckVersion(profile));


        Assert.True(
            monitor.IsHealthy(profile));
    }


    [Fact]
    public void CompanionWithoutIdentity_ShouldFail()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel(),
                new PersonalityModel());


        var monitor =
            new CompanionHealthMonitor();


        Assert.False(
            monitor.CheckIdentity(profile));


        Assert.False(
            monitor.IsHealthy(profile));
    }
}

public class CompanionLifecycleManagerTests
{
    [Fact]
    public void Start_ShouldActivateRegisteredCompanion()
    {
        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        var manager =
            new CompanionLifecycleManager();


        manager.Register(profile);


        var result =
            manager.Start(
                "CS-000001");


        Assert.True(result);


        Assert.True(
            manager.Runtime.IsRunning);


        Assert.NotNull(
            manager.Runtime.ActiveCompanion);
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


        var manager =
            new CompanionLifecycleManager();


        manager.Register(profile);


        manager.Start(
            "CS-000001");


        manager.Stop();


        Assert.False(
            manager.Runtime.IsRunning);


        Assert.Null(
            manager.Runtime.ActiveCompanion);
    }
}

public class CompanionApiTests
{
    [Fact]
    public void Start_ShouldRunCompanionThroughApi()
    {
        var api =
            new CompanionApi();


        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        api.Register(profile);


        var result =
            api.Start(
                "CS-000001");


        Assert.True(result);


        Assert.True(
            api.IsRunning());
    }


    [Fact]
    public void Stop_ShouldStopCompanionThroughApi()
    {
        var api =
            new CompanionApi();


        var profile =
            new CompanionProfile(
                new IdentityModel
                {
                    Id = "CS-000001",
                    Name = "Lilith"
                },
                new PersonalityModel());


        api.Register(profile);


        api.Start(
            "CS-000001");


        api.Stop();


        Assert.False(
            api.IsRunning());
    }
}

public class CompanionCommandSystemTests
{
    [Fact]
    public void StartCommand_ShouldActivateCompanion()
    {
        var system =
            new CompanionCommandSystem();


        var command =
            new CompanionCommand(
                "Start",
                "CS-000001");


        var result =
            system.Execute(command);


        Assert.False(result);
    }


    [Fact]
    public void StopCommand_ShouldExecute()
    {
        var system =
            new CompanionCommandSystem();


        var command =
            new CompanionCommand(
                "Stop");


        var result =
            system.Execute(command);


        Assert.True(result);
    }


    [Fact]
    public void UnknownCommand_ShouldFail()
    {
        var system =
            new CompanionCommandSystem();


        var command =
            new CompanionCommand(
                "Unknown");


        var result =
            system.Execute(command);


        Assert.False(result);
    }
}

public class CompanionModuleSystemTests
{
    [Fact]
    public void Register_ShouldAddModule()
    {
        var system =
            new CompanionModuleSystem();


        var module =
            new CompanionModule(
                "voice",
                "Voice Module");


        system.Register(module);


        var result =
            system.Find("voice");


        Assert.NotNull(result);


        Assert.Equal(
            "Voice Module",
            result!.Name);
    }


    [Fact]
    public void Enable_ShouldActivateModule()
    {
        var module =
            new CompanionModule(
                "memory",
                "Memory Module");


        module.Enable();


        Assert.True(
            module.Enabled);
    }


    [Fact]
    public void Disable_ShouldDeactivateModule()
    {
        var module =
            new CompanionModule(
                "vision",
                "Vision Module");


        module.Enable();

        module.Disable();


        Assert.False(
            module.Enabled);
    }
}

public class CompanionPluginSystemTests
{
    [Fact]
    public void Register_ShouldAddPlugin()
    {
        var system =
            new CompanionPluginSystem();


        var plugin =
            new CompanionPlugin(
                "local-ai",
                "Local AI Engine");


        system.Register(plugin);


        var result =
            system.Find("local-ai");


        Assert.NotNull(result);


        Assert.Equal(
            "Local AI Engine",
            result!.Name);
    }


    [Fact]
    public void Load_ShouldActivatePlugin()
    {
        var plugin =
            new CompanionPlugin(
                "voice",
                "Voice Plugin");


        plugin.Load();


        Assert.True(
            plugin.Loaded);
    }


    [Fact]
    public void Unload_ShouldDeactivatePlugin()
    {
        var plugin =
            new CompanionPlugin(
                "vision",
                "Vision Plugin");


        plugin.Load();


        plugin.Unload();


        Assert.False(
            plugin.Loaded);
    }
}

public class CompanionPermissionSystemTests
{
    [Fact]
    public void Grant_ShouldAddPermission()
    {
        var system =
            new CompanionPermissionSystem();


        var permission =
            new CompanionPermission(
                "Microphone.Access",
                "Allow voice input");


        system.Grant(permission);


        Assert.True(
            system.HasPermission(
                "Microphone.Access"));
    }


    [Fact]
    public void Revoke_ShouldRemovePermission()
    {
        var system =
            new CompanionPermissionSystem();


        var permission =
            new CompanionPermission(
                "Memory.Write",
                "Allow memory changes");


        system.Grant(permission);


        system.Revoke(
            "Memory.Write");


        Assert.False(
            system.HasPermission(
                "Memory.Write"));
    }


    [Fact]
    public void GetAll_ShouldReturnPermissions()
    {
        var system =
            new CompanionPermissionSystem();


        system.Grant(
            new CompanionPermission(
                "Model.Execute",
                "Allow AI execution"));


        var permissions =
            system.GetAll();


        Assert.Single(
            permissions);


        Assert.Equal(
            "Model.Execute",
            permissions.First().Id);
    }
}

public class CompanionSchedulerTests
{
    [Fact]
    public void Schedule_ShouldAddTask()
    {
        var scheduler =
            new CompanionScheduler();


        var task =
            new CompanionTask(
                "backup",
                "Daily Backup");


        scheduler.Schedule(task);


        var result =
            scheduler.Find("backup");


        Assert.NotNull(result);


        Assert.Equal(
            "Daily Backup",
            result!.Name);
    }


    [Fact]
    public void Run_ShouldCompleteTask()
    {
        var scheduler =
            new CompanionScheduler();


        var task =
            new CompanionTask(
                "memory",
                "Save Memory");


        scheduler.Schedule(task);


        scheduler.Run(
            "memory");


        Assert.True(
            task.Completed);
    }


    [Fact]
    public void GetAll_ShouldReturnTasks()
    {
        var scheduler =
            new CompanionScheduler();


        scheduler.Schedule(
            new CompanionTask(
                "health",
                "Health Check"));


        var tasks =
            scheduler.GetAll();


        Assert.Single(
            tasks);
    }
}

public class CompanionStateMachineTests
{
    [Fact]
    public void NewStateMachine_ShouldStartIdle()
    {
        var machine =
            new CompanionStateMachine();


        Assert.Equal(
            CompanionStateType.Idle,
            machine.CurrentState);
    }


    [Fact]
    public void ChangeState_ShouldUpdateCurrentState()
    {
        var machine =
            new CompanionStateMachine();


        machine.ChangeState(
            CompanionStateType.Thinking);


        Assert.Equal(
            CompanionStateType.Thinking,
            machine.CurrentState);
    }


    [Fact]
    public void Is_ShouldDetectCurrentState()
    {
        var machine =
            new CompanionStateMachine();


        machine.ChangeState(
            CompanionStateType.Listening);


        Assert.True(
            machine.Is(
                CompanionStateType.Listening));


        Assert.False(
            machine.Is(
                CompanionStateType.Sleeping));
    }
}

public class CompanionEventBusTests
{
    [Fact]
    public void Publish_ShouldStoreEvent()
    {
        var bus =
            new CompanionEventBus();


        var eventData =
            new CompanionEvent(
                "CompanionStarted");


        bus.Publish(eventData);


        var events =
            bus.GetEvents();


        Assert.Single(
            events);


        Assert.Equal(
            "CompanionStarted",
            events[0].Name);
    }


    [Fact]
    public void Clear_ShouldRemoveEvents()
    {
        var bus =
            new CompanionEventBus();


        bus.Publish(
            new CompanionEvent(
                "StateChanged"));


        bus.Clear();


        Assert.Empty(
            bus.GetEvents());
    }


    [Fact]
    public void Event_ShouldHaveCreationDate()
    {
        var eventData =
            new CompanionEvent(
                "MemoryCreated");


        Assert.NotEqual(
            default,
            eventData.CreatedAt);
    }
}

public class CompanionMigrationTests
{
    [Fact]
    public void Register_ShouldAddMigration()
    {
        var system =
            new CompanionMigrationSystem();


        var migration =
            new CompanionMigration(
                "1.0",
                "2.0");


        system.Register(
            migration);


        var result =
            system.Find(
                "1.0",
                "2.0");


        Assert.NotNull(
            result);


        Assert.Equal(
            "2.0",
            result!.ToVersion);
    }


    [Fact]
    public void Execute_ShouldCompleteMigration()
    {
        var system =
            new CompanionMigrationSystem();


        var migration =
            new CompanionMigration(
                "1.0",
                "2.0");


        system.Register(
            migration);


        system.Execute(
            "1.0",
            "2.0");


        Assert.True(
            migration.Completed);
    }


    [Fact]
    public void GetAll_ShouldReturnMigrations()
    {
        var system =
            new CompanionMigrationSystem();


        system.Register(
            new CompanionMigration(
                "1.0",
                "2.0"));


        var migrations =
            system.GetAll();


        Assert.Single(
            migrations);
    }
}

public class CompanionStorageProviderTests
{
    [Fact]
    public void Save_ShouldStoreValue()
    {
        var storage =
            new CompanionStorageProvider();


        storage.Save(
            "identity",
            "Lilith");


        var result =
            storage.Load(
                "identity");


        Assert.Equal(
            "Lilith",
            result);
    }


    [Fact]
    public void Exists_ShouldDetectStoredValue()
    {
        var storage =
            new CompanionStorageProvider();


        storage.Save(
            "memory",
            "Hello");


        Assert.True(
            storage.Exists(
                "memory"));
    }


    [Fact]
    public void Delete_ShouldRemoveValue()
    {
        var storage =
            new CompanionStorageProvider();


        storage.Save(
            "profile",
            "Companion");


        storage.Delete(
            "profile");


        Assert.False(
            storage.Exists(
                "profile"));
    }
}