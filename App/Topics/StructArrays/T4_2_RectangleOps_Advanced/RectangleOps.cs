using System;

namespace App.Topics.StructArrays.T4_2_RectangleOps_Advanced
{
    public readonly struct Rect
    {
        public int Width { get; }
        public int Height { get; }

        public Rect(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0.");
            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0.");

            Width = width;
            Height = height;
        }

        public int Area => Width * Height;

        public int Perimeter => 2 * (Width + Height);
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

            int total = 0;
            foreach (var rect in rects)
            {
                if (!Validate(rect))
                    throw new ArgumentException("Array contains an invalid rectangle.");
                total += rect.Area;
            }
            return total;
        }

        public static int BiggestPerimeter(Rect[] rects)
        {
            if (rects == null)
                throw new ArgumentNullException(nameof(rects));
            if (rects.Length == 0)
                throw new ArgumentException("Array is empty.");

            int maxPerimeter = rects[0].Perimeter;
            for (int i = 1; i < rects.Length; i++)
            {
                if (!Validate(rects[i]))
                    throw new ArgumentException("Array contains an invalid rectangle.");
                int perimeter = rects[i].Perimeter;
                if (perimeter > maxPerimeter)
                    maxPerimeter = perimeter;
            }
            return maxPerimeter;
        }
    }
}