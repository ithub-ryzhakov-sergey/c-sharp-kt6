// Тема 2, Задача T2.1_DualFormatter
// Явная реализация интерфейсов для разных форматов сериализации.

using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

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
    public string Title { get; set; }
    public int Value { get; set; }
    public Report()
    {
        Title = string.Empty;
    }

    public Report(string title, int value)
    {
        if (title == null)
            throw new ArgumentNullException(nameof(title));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty or whitespace", nameof(title));

        Title = title;
        Value = value;
    }

    string IJsonSerializable.Serialize()
    {
        return JsonSerializer.Serialize(this);
    }

    string IXmlSerializable.Serialize()
    {
        var serializer = new XmlSerializer(typeof(Report));
        using var writer = new StringWriter();
        serializer.Serialize(writer, this);
        return writer.ToString();
    }

    public override string ToString()
    {
        return $"Report: {Title}, value={Value}";
    }
}



