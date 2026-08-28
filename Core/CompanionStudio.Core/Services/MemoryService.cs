using CompanionStudio.Core.Memory;

namespace CompanionStudio.Core.Services;

public class MemoryService
{
    private readonly MemoryManager manager;
    private readonly IMemoryStorage storage;

    public MemoryService(IMemoryStorage storage)
    {
        manager = new MemoryManager();
        this.storage = storage;
    }

    public MemoryModel Create(
        string type,
        string content,
        int importance)
    {
        var memory = manager.CreateMemory(
            type,
            content,
            importance);

        var memories = storage.Load().ToList();

        memories.Add(memory);

        storage.Save(memories);

        return memory;
    }
}