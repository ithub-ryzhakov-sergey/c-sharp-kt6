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
    private readonly string _title;
    private readonly int _value;
    string IJsonSerializable.Serialize()
    {
        return $"{{\"title\":\"{_title}\",\"value\":{_value}}}";
    }
    string IXmlSerializable.Serialize()
    {
        return $"<Report><Title>{_title}</Title><Value>{_value}</Value></Report>";
    }
    public Report(string title, int value)
    {
        if (title == null)
        {
            throw new ArgumentNullException();
        }
        if (title.Trim() == "")
        {
            throw new ArgumentException();
        }
        _title = title;
        _value = value;
    }
    public override string ToString()
    {
        return $"Report: {_title}, value={_value}";
    }
}
