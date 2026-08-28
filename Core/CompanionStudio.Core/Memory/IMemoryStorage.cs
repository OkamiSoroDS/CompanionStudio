namespace CompanionStudio.Core.Memory;

public interface IMemoryStorage
{
    void Save(IEnumerable<MemoryModel> memories);

    IEnumerable<MemoryModel> Load();
}