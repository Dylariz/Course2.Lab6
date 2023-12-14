using System.Drawing;

namespace Number3;

// Сторона многоугольника
public class Segment
{
    public Point A { get; }
    public Point B { get; }

    public Segment(Point a, Point b)
    {
        A = a;
        B = b;
    }

    // Пересекаются ли отрезки
    public bool IsIntersecting(Segment other)
    {
        // Проверка на совпадение отрезков
        if ((A == other.A && B == other.B) || (A == other.B && B == other.A))
        {
            return true;
        }

        // Проверка на пересечение отрезков
        if (IsSegmentsIntersecting(A, B, other.A, other.B))
        {
            return true;
        }

        // Если ни одно из условий не выполнилось, возвращаем false
        return false;
    }

    private static bool IsSegmentsIntersecting(Point a, Point b, Point a1, Point b1)
    {
        // Векторное произведение
        var v1 = (b1.X - a1.X) * (a.Y - a1.Y) - (b1.Y - a1.Y) * (a.X - a1.X);
        var v2 = (b1.X - a1.X) * (b.Y - a1.Y) - (b1.Y - a1.Y) * (b.X - a1.X);
        var v3 = (b.X - a.X) * (a1.Y - a.Y) - (b.Y - a.Y) * (a1.X - a.X);
        var v4 = (b.X - a.X) * (b1.Y - a.Y) - (b.Y - a.Y) * (b1.X - a.X);
        return v1 * v2 < 0 && v3 * v4 < 0;
    }
}