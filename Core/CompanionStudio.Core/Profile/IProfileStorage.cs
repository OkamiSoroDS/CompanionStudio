using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Profile;

public interface IProfileStorage
{
    void Save(CompanionProfile profile);

    CompanionProfile? Load();
}