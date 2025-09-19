// Тема 1, Задача T1.1_ShapeDrawable
// Определите иерархию интерфейсов и реализуйте классы фигур.

namespace App.Topics.InterfaceInheritance.T1_1_ShapeDrawable;

public interface IShape
{
    // Площадь фигуры. Должна быть неотрицательной.
    double Area { get; }

    // Периметр/длина окружности. Должен быть неотрицательным.
    double Perimeter { get; }
}

public interface IDrawable
{
    // Возвращает текстовое представление фигуры (например, "Circle(r=3)").
    string Draw();
}

// Наследование интерфейсов: фигура, которую можно "рисовать".
public interface IDrawableShape : IShape, IDrawable { }

// Подсказка: реализуйте корректные формулы и валидацию входных параметров в конструкторах классов.
public sealed class Circle : IDrawableShape
{
    public Circle(double radius)
    {
        // Ожидаем: radius > 0, иначе ArgumentOutOfRangeException
        throw new NotImplementedException();
    }

    public double Area => throw new NotImplementedException();
    public double Perimeter => throw new NotImplementedException();
    public string Draw() => throw new NotImplementedException();
}

public sealed class Rectangle : IDrawableShape
{
    public Rectangle(double width, double height)
    {
        // Ожидаем: width > 0 и height > 0, иначе ArgumentOutOfRangeException
        throw new NotImplementedException();
    }

    public double Area => throw new NotImplementedException();
    public double Perimeter => throw new NotImplementedException();
    public string Draw() => throw new NotImplementedException();
}
