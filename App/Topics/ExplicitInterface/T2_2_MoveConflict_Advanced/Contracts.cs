// Тема 2 (*), Задача T2.2_MoveConflict
// Явная реализация методов с одинаковым сигнатурным именем, но разной семантикой.

namespace App.Topics.ExplicitInterface.T2_2_MoveConflict_Advanced;

public interface ILeft
{
    void Move(int dx);
}

public interface IRight
{
    void Move(int dx);
}

public sealed class Cursor : ILeft, IRight
{
    public int X { get; private set; }

    // Методы интерфейсов должны быть реализованы явно, чтобы не "мешать" друг другу.
    // Логика: ILeft.Move(dx) — смещение влево (X -= |dx|), IRight.Move(dx) — вправо (X += |dx|)
    // Публичного метода Move в классе быть не должно.

    // Подсказка: используйте Math.Abs(dx) и защититесь от переполнения по int если посчитаете нужным.

    // Заглушки:
    void ILeft.Move(int dx) => throw new NotImplementedException();
    void IRight.Move(int dx) => throw new NotImplementedException();
}
