using App.Topics.InterfaceInheritance.T1_2_Repository_Advanced;

namespace App.Tests.Topics.InterfaceInheritance.T1_2_Repository_Advanced;

[Category("*")]
public class RepositoryTests
{
    private sealed record User(int Id, string Name) : IHasId<int>;

    [Test]
    public void Add_And_GetById_Works()
    {
        IAuditableRepository<int, User> repo = new InMemoryRepository<int, User>();
        var u = new User(1, "Alice");
        repo.Add(u);
        Assert.That(repo.Count, Is.EqualTo(1));
        var fromRepo = repo.GetById(1);
        Assert.That(fromRepo, Is.EqualTo(u));
    }

    [Test]
    public void Add_DuplicateId_Throws()
    {
        IAuditableRepository<int, User> repo = new InMemoryRepository<int, User>();
        repo.Add(new User(1, "A"));
        Assert.Throws<InvalidOperationException>(() => repo.Add(new User(1, "B")));
    }

    [Test]
    public void GetById_Unknown_Throws()
    {
        IAuditableRepository<int, User> repo = new InMemoryRepository<int, User>();
        Assert.Throws<KeyNotFoundException>(() => repo.GetById(42));
    }

    [Test]
    public void Save_Sets_LastSavedAt()
    {
        var repo = new InMemoryRepository<int, User>();
        Assert.That(repo.LastSavedAt, Is.EqualTo(default(DateTime)));
        repo.Save();
        Assert.That(repo.LastSavedAt, Is.Not.EqualTo(default(DateTime)));
        Assert.That(repo.LastSavedAt.Kind, Is.EqualTo(DateTimeKind.Utc));
    }
}
