// Тема 4 (*), Задача T4.2_RectangleOps
// Работа с массивами структур и валидацией данных.

namespace App.Topics.StructArrays.T4_2_RectangleOps_Advanced;

public readonly struct Rect
{
    public int Width { get; }
    public int Height { get; }
    public Rect(int width, int height)
    {
        // Требуется: width > 0, height > 0
        throw new NotImplementedException();
    }

    public int Area => throw new NotImplementedException();
    public int Perimeter => throw new NotImplementedException();
}

public static class RectangleOps
{
    public static bool Validate(in Rect rect) => throw new NotImplementedException();

    // Если встречен невалидный прямоугольник — ArgumentException
    public static int TotalArea(Rect[] rects) => throw new NotImplementedException();

    // Если массив пустой — InvalidOperationException; если невалидный элемент — ArgumentException
    public static int BiggestPerimeter(Rect[] rects) => throw new NotImplementedException();
}
