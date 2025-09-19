// Тема 2, Задача T2.1_DualFormatter
// Явная реализация интерфейсов для разных форматов сериализации.

namespace App.Topics.ExplicitInterface.T2_1_DualFormatter;

public interface IJsonSerializable
{
    string Serialize();
}

public interface IXmlSerializable
{
    string Serialize();
}

public sealed class Report : IJsonSerializable, IXmlSerializable
{
    // Эти поля остаются приватными; доступ извне не требуется для решения.
    private readonly string _title;
    private readonly int _value;

    public Report(string title, int value)
    {
        // Ожидается, что title не null/empty, value произвольный
        // В решении проведите валидацию и сохраните значения
        throw new NotImplementedException();
    }

    // Явные реализации интерфейсов — пока бросают NotImplementedException,
    // чтобы проект компилировался, а тесты падали до реализации.
    string IJsonSerializable.Serialize() => throw new NotImplementedException();
    string IXmlSerializable.Serialize() => throw new NotImplementedException();

    public override string ToString()
    {
        // Должно возвращать человекочитаемую строку вида: "Report: {Title}, value={Value}"
        throw new NotImplementedException();
    }
}
