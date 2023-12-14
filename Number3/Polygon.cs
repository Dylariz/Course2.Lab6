using System.Collections.Generic;
using System.Drawing;

namespace Number3;

public class Polygon
{
    private List<Point> _points = new();
    
    public IReadOnlyList<Point> Points => _points;
    
    public bool IsValid => Points.Count >= 3;

    public void AddPoint(Point point)
    {
        _points.Add(point);
    }
    
    public void Clear()
    {
        _points.Clear();
    }
    
    public bool IsSelfIntersecting()
    {
        for (var i = 0; i < _points.Count - 1; i++)
        {
            for (var j = i + 2; j < _points.Count - 1; j++)
            {
                if (IsSegmentsIntersecting(_points[i], _points[i + 1], _points[j], _points[j + 1]))
                    return true;
            }
        }

        return false;
    }
    
    private static bool IsSegmentsIntersecting(Point a, Point b, Point c, Point d)
    {
        // Векторное произведение
        var v1 = (d.X - c.X) * (a.Y - c.Y) - (d.Y - c.Y) * (a.X - c.X);
        var v2 = (d.X - c.X) * (b.Y - c.Y) - (d.Y - c.Y) * (b.X - c.X);
        var v3 = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        var v4 = (b.X - a.X) * (d.Y - a.Y) - (b.Y - a.Y) * (d.X - a.X);
        return v1 * v2 < 0 && v3 * v4 < 0;
    }
}