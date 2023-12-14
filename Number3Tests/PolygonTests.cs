using System.Drawing;
using Number3;

namespace Number3Tests;

public class PolygonTests
{
    [Theory]
    [InlineData(new[] { 0, 0, 10, 0, 10, 10, 0, 10 }, false)] // Квадрат
    [InlineData(new[] { 0, 0, 10, 0, 10, 10, 0, 5, 5, 10 }, true)] // Пятиугольник с одной пересекающейся стороной
    [InlineData(new[] { 0, 0, 10, 0, 10, 10, 0, 10, 5, 5, 10, 5 }, false)] // Шестиугольник
    public void IsSelfIntersecting(int[] coordinates, bool expected)
    {
        var polygon = new Polygon();
        for (int i = 0; i < coordinates.Length; i += 2)
        {
            polygon.AddPoint(new Point(coordinates[i], coordinates[i + 1]));
        }

        Assert.Equal(expected, polygon.IsSelfIntersecting());
    }
    
    [Fact]
    public void AddPoint()
    {
        var p1 = new Point(100, 100);
        var p2 = new Point(200, 50);
        var p3 = new Point(200, 90);
        var polygon = new Polygon();
        
        Assert.False(polygon.IsValid);
        polygon.AddPoint(p1);
        Assert.False(polygon.IsValid);
        Assert.Contains(p1, polygon.Points);
        
        polygon.AddPoint(p2);
        Assert.False(polygon.IsValid);
        Assert.Contains(p2, polygon.Points);
        
        polygon.AddPoint(p3);
        Assert.True(polygon.IsValid);
        Assert.Contains(p3, polygon.Points);
        Assert.Equal(3, polygon.Points.Count);
    }
    
    [Fact]
    public void AddPoint_CheckSegments()
    {
        var p1 = new Point(100, 100);
        var p2 = new Point(200, 50);
        var p3 = new Point(200, 90);
        var polygon = new Polygon();

        polygon.AddPoint(p1);
        Assert.Empty(polygon.Segments);
        polygon.AddPoint(p2);
        Assert.Single(polygon.Segments);
        Assert.Equal(p1, polygon.Segments[0].A);
        Assert.Equal(p2, polygon.Segments[0].B);

        polygon.AddPoint(p3);
        Assert.Equal(3, polygon.Segments.Count);
        Assert.Equal(p2, polygon.Segments[1].A);
        Assert.Equal(p3, polygon.Segments[1].B);
        Assert.Equal(p3, polygon.Segments[2].A);
        Assert.Equal(p1, polygon.Segments[2].B);
    }
    
    [Fact]
    public void Clear()
    {
        var polygon = new Polygon();
        polygon.AddPoint(new Point(100, 100));
        polygon.AddPoint(new Point(200, 50));
        polygon.AddPoint(new Point(200, 90));
        
        Assert.NotEmpty(polygon.Points);
        polygon.Clear();
        Assert.Empty(polygon.Points);
    }
}