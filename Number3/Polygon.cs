using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Number3;

public class Polygon
{
    private List<Point> _points = new();

    public IReadOnlyList<Point> Points => _points;

    public IReadOnlyList<Segment> Segments
    {
        get
        {
            if (_points.Count < 2)
            {
                return new List<Segment>();
            }

            var segments = _points.Select((point, index) =>
                new Segment(point, _points[(index + 1) % _points.Count])).ToList();

            // Удаляем последний сегмент, если точек всего две
            if (_points.Count == 2)
            {
                segments.RemoveAt(segments.Count - 1);
            }

            return segments;
        }
    }

    public bool IsValid => Points.Count >= 3;

    public void AddPoint(Point point)
    {
        _points.Add(point);
    }

    public void Clear()
    {
        _points.Clear();
    }

    // Пересекаются ли стороны многоугольника
    public bool IsSelfIntersecting()
    {
        var segments = new List<Segment>(Segments);
        return segments.Any(s1 => segments.Any(s2 => s1 != s2 && s1.IsIntersecting(s2)));
    }
}