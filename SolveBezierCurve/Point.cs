using System.Numerics;
using System.Runtime.CompilerServices;

namespace SolveBezierCurve
{
    public record struct Point(double X, double Y)
    {
        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Is(0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Is(double x, double y) => X == x && Y == y;

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Point operator *(Point point, double factor)
        {
            return new Point(point.X * factor, point.Y * factor);
        }

        public static Point operator /(Point point, double factor)
        {
            return new Point(point.X / factor, point.Y / factor);
        }

        public static Point Lerp(Point a, Point b, double t)
        {
            return a * (1 - t) + b * t;
        }
    }
}
