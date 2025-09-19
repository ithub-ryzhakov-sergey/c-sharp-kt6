using App.Topics.Enums.T5_2_Permissions_Advanced;

namespace App.Tests.Topics.Enums.T5_2_Permissions_Advanced;

[Category("*")]
public class PermissionsTests
{
    [Test]
    public void Combine_Parses_Names_Case_Insensitive()
    {
        var p = PermissionUtils.Combine(new[] { "read", "WRITE", "Execute" });
        Assert.That(p.HasFlag(Permission.Read), Is.True);
        Assert.That(p.HasFlag(Permission.Write), Is.True);
        Assert.That(p.HasFlag(Permission.Execute), Is.True);
        Assert.That(p.HasFlag(Permission.Delete), Is.False);
    }

    [Test]
    public void HasAll_Works()
    {
        var p = Permission.Read | Permission.Write | Permission.Delete;
        Assert.That(PermissionUtils.HasAll(p, Permission.Read | Permission.Write), Is.True);
        Assert.That(PermissionUtils.HasAll(p, Permission.Execute), Is.False);
    }

    [Test]
    public void FromStringList_Validates_Unknown()
    {
        Assert.Throws<ArgumentException>(() => PermissionUtils.FromStringList(new List<string> { "unknown" }));
        Assert.Throws<ArgumentNullException>(() => PermissionUtils.FromStringList(null!));
    }
}
