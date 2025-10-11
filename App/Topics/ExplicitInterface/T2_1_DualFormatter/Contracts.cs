using System;

namespace App.Topics.ExplicitInterface.T2_1_DualFormatter
{
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

        public Report(string title, int value)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));
            if (title == string.Empty)
                throw new ArgumentException("Title cannot be empty.", nameof(title));

            _title = title;
            _value = value;
        }

        // Явная реализация IJsonSerializable.Serialize
        string IJsonSerializable.Serialize()
        {
            return $"{{\"title\":\"{_title}\",\"value\":{_value}}}";
        }

        // Явная реализация IXmlSerializable.Serialize
        string IXmlSerializable.Serialize()
        {
            return $"<Report><Title>{_title}</Title><Value>{_value}</Value></Report>";
        }

        public override string ToString()
        {
            return $"Report: {_title}, value={_value}";
        }
    }
}