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

    public Graph()
    {
        InitializeComponent();
        Polygon = new Polygon();
        resetButton.Click += (s, a) => ResetToDefault(); // Обработка нажатия кнопки "Сброс"
    }

    // Перерисовка графики, вызывается при вызове Invalidate()
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
    }

    // Обработка нажатия левой кнопки мыши
    private void Graph_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Polygon.AddPoint(e.Location); // Добавляем точку в полигон

            if (Polygon.IsValid) // Если многоугольник завершен
            {
                statusLabel.Text = Polygon.IsSelfIntersecting() switch
                {
                    true => "Многоугольник самопересекающийся",
                    false => "Стороны многоугольника не пересекаются"
                };
            }

            Invalidate();
        }
    }

    private void ResetToDefault()
    {
        Polygon.Clear();
        statusLabel.Text = "Ожидание построения";
        Invalidate();
    }
}