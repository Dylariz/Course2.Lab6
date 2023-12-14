using System.Drawing;
using Number3;

namespace Number3Tests;

public class SegmentTests
{
    [Fact]
    public void IsIntersecting_ReturnsTrue_WhenSegmentsIntersect()
    {
        // Arrange
        var segment1 = new Segment(new Point(0, 0), new Point(10, 10));
        var segment2 = new Segment(new Point(0, 10), new Point(10, 0));

        // Act
        var result = segment1.IsIntersecting(segment2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsIntersecting_ReturnsFalse_WhenSegmentsDoNotIntersect()
    {
        // Arrange
        var segment1 = new Segment(new Point(0, 0), new Point(10, 10));
        var segment2 = new Segment(new Point(20, 20), new Point(30, 30));

        // Act
        var result = segment1.IsIntersecting(segment2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsIntersecting_ReturnsFalse_WhenSegmentsAreParallel()
    {
        // Arrange
        var segment1 = new Segment(new Point(0, 0), new Point(10, 10));
        var segment2 = new Segment(new Point(0, 1), new Point(10, 11));

        // Act
        var result = segment1.IsIntersecting(segment2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsIntersecting_ReturnsTrue_WhenSegmentsAreCoincident()
    {
        // Arrange
        var segment1 = new Segment(new Point(0, 0), new Point(10, 10));
        var segment2 = new Segment(new Point(0, 0), new Point(10, 10));

        // Act
        var result = segment1.IsIntersecting(segment2);

        // Assert
        Assert.True(result);
    }
}