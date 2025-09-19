// Тема 5 (*), Задача T5.2_Permissions
// [Flags] enum с утилитами разбора и проверки наборов прав.

namespace App.Topics.Enums.T5_2_Permissions_Advanced;

[Flags]
public enum Permission
{
    None = 0,
    Read = 1 << 0,
    Write = 1 << 1,
    Execute = 1 << 2,
    Delete = 1 << 3,
    Admin = 1 << 4
}

public static class PermissionUtils
{
    // Комбинирует набор прав по их строковым именам (регистронезависимо). Неизвестное имя — ArgumentException.
    public static Permission Combine(IEnumerable<string> names) => throw new NotImplementedException();

    // Проверяет, содержит ли value ВСЕ указанные флаги
    public static bool HasAll(Permission value, Permission flags) => throw new NotImplementedException();

    // Преобразует список строк в Permission, эквивалент Combine
    public static Permission FromStringList(IEnumerable<string> names) => throw new NotImplementedException();
}
