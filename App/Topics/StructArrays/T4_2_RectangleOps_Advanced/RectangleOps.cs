using App.Topics.StructArrays.T4_2_RectangleOps_Advanced;
using System;
using System.ComponentModel;
using System.Linq;

namespace App.Topics.StructArrays.T4_2_RectangleOps_Advanced
{
    public readonly struct Rect
    {
        public int Width { get; }
        public int Height { get; }

        public int Area => Width * Height;
        public int Perimeter => 2 * (Width + Height);

        public Rect(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0");
            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0");

            Width = width;
            Height = height;
        }
    }

    public static class RectangleOps
    {
        public static bool Validate(in Rect rect)
        {
            return rect.Width > 0 && rect.Height > 0;
        }

        public static int TotalArea(Rect[] rects)
        {
            if (rects == null)
                throw new ArgumentNullException(nameof(rects));

            if (rects.Any(r => !Validate(r)))
                throw new ArgumentException("Array contains invalid rectangle");

            return rects.Sum(r => r.Area);
        }

        public static int BiggestPerimeter(Rect[] rects)
        {
            if (rects == null)
                throw new ArgumentNullException(nameof(rects));
            if (rects.Length == 0)
                throw new InvalidOperationException("Array cannot be empty");
            if (rects.Any(r => !Validate(r)))
                throw new ArgumentException("Array contains invalid rectangle");

            return rects.Max(r => r.Perimeter);
        }
    }
}
