﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Number8
{
    public partial class Graph : Form
    {
        public Polygon Polygon { get; }
        public Point XPoint { get; set; }
        public bool IsPolygonFinished { get; set; }

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
                e.Graphics.DrawPolygon(Pens.Red, points.ToArray()); // Рисуем полигон по точкам из списка Points
            else if (points.Length == 2)
                e.Graphics.DrawLine(Pens.Red, points[0], points[1]); // Рисуем линию по точкам из списка Points
            else if (points.Length == 1)
                e.Graphics.FillEllipse(Brushes.Red, points[0].X - 2, points[0].Y - 2, 3, 3);

            if (XPoint != Point.Empty) // Если точка XPoint задана, то рисуем её
                e.Graphics.FillEllipse(Brushes.Green, XPoint.X - 2, XPoint.Y - 2, 4, 4);
        }

        private void Graph_MouseDown(object sender, MouseEventArgs e)
        {
            // Мышь не наведена на элемент управления
            if (e.Button == MouseButtons.Left)
            {
                if (IsPolygonFinished)
                {
                    XPoint = e.Location;
                    statusLabel.Text = Polygon.IsPointInPolygon(XPoint) switch
                    {
                        1 => "Статус: Точка внутри многоугольника",
                        -1 => "Статус: Точка снаружи многоугольника",
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }
                else
                    Polygon.AddPoint(e.Location);

                Invalidate();
            }
        }

        private void pinButton_Click(object sender, EventArgs e)
        {
            if (Polygon.IsValid)
            {
                IsPolygonFinished = true;
                statusLabel.Text = "Статус: Ожидание точки X";
            }
            else
            {
                MessageBox.Show("Многоугольник не задан.");
                Polygon.Clear();
            }
        }
    }
}