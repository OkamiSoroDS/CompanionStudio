namespace CompanionStudio.Core.Migration;

public class CompanionMigrationSystem
{
    private readonly List<CompanionMigration> migrations;


    public CompanionMigrationSystem()
    {
        migrations =
            new List<CompanionMigration>();
    }


    public void Register(
        CompanionMigration migration)
    {
        migrations.Add(migration);
    }


    public CompanionMigration? Find(
        string fromVersion,
        string toVersion)
    {
        return migrations.FirstOrDefault(
            x =>
            x.FromVersion == fromVersion &&
            x.ToVersion == toVersion);
    }


    public void Execute(
        string fromVersion,
        string toVersion)
    {
        var migration =
            Find(
                fromVersion,
                toVersion);


        if (migration != null)
        {
            migration.Complete();
        }
    }


    public IReadOnlyList<CompanionMigration> GetAll()
    {
        return migrations;
    }
}