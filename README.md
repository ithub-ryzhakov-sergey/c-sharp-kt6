# 📚 Практика по C#: Интерфейсы, структуры и перечисления

Набор практических заданий для отработки тем из презентаций. Ваша задача — реализовать код в проекте `App` так, чтобы все тесты в `App.Tests` стали «зелёными».

---

### Как работать с задачами
1. Изучите подробные описания задач ниже.
2. Откройте решение `App.sln`.
3. В проекте `App` найдите соответствующий файл задачи (например, `App/Topics/Enums/T5_1_OrderStatus/OrderWorkflow.cs`). Файлы содержат только `namespace`.
4. Напишите необходимый код с нуля, руководствуясь описанием.
5. Запустите тесты в проекте `App.Tests` и добейтесь их успешного прохождения.

---

### Тема 1: Явная реализация интерфейса

#### T2.1_DualFormatter
- **Файл:** `App/Topics/ExplicitInterface/T2_1_DualFormatter/Contracts.cs`
- **Цель:** Реализовать класс, который по-разному сериализуется в JSON и XML.
- **Что нужно сделать:**
  1. Определите публичный интерфейс `IJsonSerializable` с одним методом: `string Serialize();`.
  2. Определите публичный интерфейс `IXmlSerializable` с одним методом: `string Serialize();`.
  3. Определите `public sealed class Report`, который реализует оба интерфейса: `IJsonSerializable` и `IXmlSerializable`.
  4. В классе `Report` создайте приватные `readonly` поля `_title` (string) и `_value` (int).
  5. Создайте `public` конструктор `Report(string title, int value)`, который:
     - Выбрасывает `ArgumentNullException`, если `title` равен `null`.
     - Выбрасывает `ArgumentException`, если `title` пустой.
     - Инициализирует поля `_title` и `_value`.
  6. Реализуйте **явно** метод `IJsonSerializable.Serialize`, который возвращает JSON-строку. Пример: `{"title":"Q1","value":42}`.
  7. Реализуйте **явно** метод `IXmlSerializable.Serialize`, который возвращает XML-строку. Пример: `<Report><Title>Q1</Title><Value>42</Value></Report>`.
  8. Переопределите `public override string ToString()`, чтобы он возвращал строку вида `"Report: Q1, value=42"`.

#### T2.2_MoveConflict_Advanced (*)
- **Файл:** `App/Topics/ExplicitInterface/T2_2_MoveConflict_Advanced/Contracts.cs`
- **Цель:** Разрешить конфликт имён методов из разных интерфейсов.
- **Что нужно сделать:**
  1. Определите `public` интерфейс `ILeft` с методом `void Move(int dx);`.
  2. Определите `public` интерфейс `IRight` с методом `void Move(int dx);`.
  3. Определите `public sealed class Cursor`, реализующий `ILeft` и `IRight`.
  4. В классе `Cursor` создайте свойство `public int X { get; private set; }`.
  5. Реализуйте **явно** метод `ILeft.Move(int dx)`, который смещает `X` влево: `X -= Math.Abs(dx)`.
  6. Реализуйте **явно** метод `IRight.Move(int dx)`, который смещает `X` вправо: `X += Math.Abs(dx)`.

---

### Тема 2: Структуры

#### T3.1_Point2D
- **Файл:** `App/Topics/Structs/T3_1_Point2D/Point2D.cs`
- **Цель:** Создать иммутабельную структуру для 2D-точки.
- **Что нужно сделать:**
  1. Определите `public readonly struct Point2D`.
  2. Создайте `public` автосвойства `double X { get; }` и `double Y { get; }`.
  3. Создайте `public` конструктор `Point2D(double x, double y)`, который инициализирует `X` и `Y`.
  4. Создайте `public` свойство `double Length`, которое вычисляет длину вектора от `(0,0)` до `(X,Y)`.
  5. Создайте `public` метод `Point2D Add(in Point2D other)`, который возвращает новую точку, являющуюся суммой текущей и `other`.
  6. Создайте `public` метод `Point2D Subtract(in Point2D other)`, который возвращает разность.
  7. Создайте `public` метод `double DistanceTo(in Point2D other)`, который вычисляет расстояние до `other`.
  8. Переопределите `public override bool Equals(object? obj)` и `public override int GetHashCode()` для сравнения точек по значению.

#### T3.2_Rational_Advanced (*)
- **Файл:** `App/Topics/Structs/T3_2_Rational_Advanced/Rational.cs`
- **Цель:** Реализовать структуру для работы с рациональными числами.
- **Что нужно сделать:**
  1. Определите `public readonly struct Rational`, реализующую `IEquatable<Rational>` и `IComparable<Rational>`.
  2. Создайте `public` автосвойства `int Numerator { get; }` и `int Denominator { get; }`.
  3. Создайте `public` конструктор `Rational(int numerator, int denominator)`, который:
     - Выбрасывает `DivideByZeroException`, если `denominator` равен 0.
     - Нормализует знак (он должен быть только у числителя).
     - Сокращает дробь, используя наибольший общий делитель (НОД).
  4. Перегрузите операторы `+`, `-`, `*`, `/`.
  5. Реализуйте методы `Equals` и `CompareTo`.
  6. Переопределите `ToString()` для вывода дроби в формате `"1/2"`.

---

### Тема 3: Массивы структур

#### T4.1_StudentStats
- **Файл:** `App/Topics/StructArrays/T4_1_StudentStats/StudentStats.cs`
- **Цель:** Написать функции для анализа массива структур.
- **Что нужно сделать:**
  1. Определите `public readonly struct Student`.
     - Свойства: `public string Name { get; }`, `public int Score { get; }`.
     - Конструктор `Student(string name, int score)`, который валидирует `name` (не `null`/пустой) и `score` (`[0, 100]`).
  2. Определите `public static class StudentAnalytics`.
     - `double AverageScore(Student[] students)`: считает средний балл. Бросает `ArgumentNullException` для `null` и `InvalidOperationException` для пустого массива.
     - `int MaxScore(Student[] students)`: находит максимальный балл.
     - `int CountPassed(Student[] students)`: считает студентов с баллом `>= 60`.
     - `Student[] NormalizeScores(Student[] students)`: пересчитывает баллы в диапазон `[0, 100]`.

#### T4.2_RectangleOps_Advanced (*)
- **Файл:** `App/Topics/StructArrays/T4_2_RectangleOps_Advanced/RectangleOps.cs`
- **Цель:** Реализовать функции для работы с массивом прямоугольников.
- **Что нужно сделать:**
  1. Определите `public readonly struct Rect`.
     - Свойства: `public int Width { get; }`, `public int Height { get; }`.
     - Конструктор `Rect(int width, int height)`, который выбрасывает `ArgumentOutOfRangeException`, если `width` или `height` `<= 0`.
     - Свойства `Area` и `Perimeter`.
  2. Определите `public static class RectangleOps`.
     - `bool Validate(in Rect rect)`: проверяет, что стороны `> 0`.
     - `int TotalArea(Rect[] rects)`: считает общую площадь. Бросает `ArgumentException`, если есть невалидный прямоугольник.
     - `int BiggestPerimeter(Rect[] rects)`: находит максимальный периметр.

---

### Тема 4: Перечисления

#### T5.1_OrderStatus
- **Файл:** `App/Topics/Enums/T5_1_OrderStatus/OrderWorkflow.cs`
- **Цель:** Реализовать логику конечного автомата для статусов заказа.
- **Что нужно сделать:**
  1. Определите `public enum OrderStatus` со значениями: `New`, `Paid`, `Shipped`, `Delivered`, `Cancelled`.
  2. Определите `public static class OrderWorkflow`.
  3. Создайте метод `public static bool CanTransition(OrderStatus from, OrderStatus to)`, который реализует логику:
     - `New` -> `Paid`
     - `Paid` -> `Shipped`
     - `Shipped` -> `Delivered`
     - `New`, `Paid`, `Shipped` -> `Cancelled`
     - Другие переходы запрещены.
  4. Создайте метод `public static OrderStatus Next(OrderStatus current)`, который возвращает следующий статус в основной цепочке. Для `Delivered` и `Cancelled` бросает `InvalidOperationException`.
  5. Создайте метод `public static OrderStatus Parse(string text)`, который разбирает строку в `OrderStatus` без учёта регистра. Для `null`/пустых/неизвестных строк бросает исключения.

#### T5.2_Permissions_Advanced (*)
- **Файл:** `App/Topics/Enums/T5_2_Permissions_Advanced/Permissions.cs`
- **Цель:** Создать утилиты для работы с `[Flags]` enum.
- **Что нужно сделать:**
  1. Определите `public enum Permission` с атрибутом `[Flags]`.
     - Значения: `None = 0`, `Read = 1`, `Write = 2`, `Execute = 4`, `Delete = 8`, `Admin = 16`.
  2. Определите `public static class PermissionUtils`.
     - `Permission Combine(IEnumerable<string> names)`: комбинирует права из строк (регистронезависимо).
     - `bool HasAll(Permission value, Permission flags)`: проверяет, что `value` содержит все флаги из `flags`.
     - `Permission FromStringList(IEnumerable<string> names)`: аналог `Combine`.
