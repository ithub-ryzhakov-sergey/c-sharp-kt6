// Тема 1 (*), Задача T1.2_Repository
// Иерархия интерфейсов с обобщениями и реализация репозитория в памяти.

namespace App.Topics.InterfaceInheritance.T1_2_Repository_Advanced;

public interface IHasId<TId>
{
    TId Id { get; }
}

public interface IBaseRepository<TId, TEntity> where TEntity : IHasId<TId>
{
    // Добавляет новую сущность. Если сущность с таким Id уже есть — InvalidOperationException.
    void Add(TEntity entity);

    // Возвращает сущность по Id или бросает KeyNotFoundException.
    TEntity GetById(TId id);

    // Возвращает количество сущностей в хранилище.
    int Count { get; }
}

public interface IAuditableRepository<TId, TEntity> : IBaseRepository<TId, TEntity>
    where TEntity : IHasId<TId>
{
    DateTime LastSavedAt { get; }
    void Save();
}

public sealed class InMemoryRepository<TId, TEntity> : IAuditableRepository<TId, TEntity>
    where TEntity : IHasId<TId>
    where TId : notnull
{
    public int Count => throw new NotImplementedException();

    public DateTime LastSavedAt => throw new NotImplementedException();

    public void Add(TEntity entity)
    {
        // Должен проверять дубликаты Id и добавлять новую сущность.
        throw new NotImplementedException();
    }

    public TEntity GetById(TId id)
    {
        // Должен искать по ключу или бросать KeyNotFoundException
        throw new NotImplementedException();
    }

    public void Save()
    {
        // Должен выставлять LastSavedAt = DateTime.UtcNow
        throw new NotImplementedException();
    }
}
