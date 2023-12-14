using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Number3;

/// <summary>
/// Самопересечение многоугольника.
/// Многоугольник задан списком вершин в порядке обхода их по часовой стрелке.
/// Самопересекающимся называется многоугольник, у которого хотя бы одна пара несмежных сторон имеет общую точку.
/// Реализовать и протестировать метод, возвращающий истину, если многоугольник является самопересекающимся и ложь в противном случае.
/// </summary>
public partial class Graph : Form
{
    public Polygon Polygon { get; }
    public Point XPoint { get; private set; }
    public bool IsPolygonFinished { get; private set; }

    public Graph()
    {
        InitializeComponent();
        Polygon = new Polygon();
        IsPolygonFinished = false;
    }

    private void Graph_Paint(object sender, PaintEventArgs e)
    {
        var points = Polygon.Points.ToArray();

        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        if (points.Length >= 3)
            e.Graphics.DrawPolygon(Pens.Red, points.ToArray()); // Рисуем полигон по точкам
        else if (points.Length == 2)
            e.Graphics.DrawLine(Pens.Red, points[0], points[1]); // Рисуем линию по точкам
        else if (points.Length == 1)
            e.Graphics.FillEllipse(Brushes.Red, points[0].X - 2, points[0].Y - 2, 3, 3); // Рисуем точку

        if (XPoint != Point.Empty) // Если точка XPoint задана, то рисуем её
            e.Graphics.FillEllipse(Brushes.Green, XPoint.X - 2, XPoint.Y - 2, 5, 5);
    }
    
    private void Graph_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {

            statusLabel.Text = Polygon.IsSelfIntersecting() switch
            {
                true => "Статус: Многоугольник самопересекающийся",
                false => "Статус: Стороны многоугольника не пересекаются"
            };
        
            Polygon.AddPoint(e.Location);
            Invalidate();
        }
    }

    private void ResetToDefault()
    {
        IsPolygonFinished = false;
        Polygon.Clear();
        XPoint = Point.Empty;
        statusLabel.Text = "Статус: Ожидание построения";
        pinButton.Text = "Закрепить многоугольник";
        Invalidate();
    }
}