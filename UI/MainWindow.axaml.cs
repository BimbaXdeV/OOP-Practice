using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice.UI
{
    partial class MainWindow : Window
    {
        private readonly Random _rand = new();

        public MainWindow()
        {
            InitializeComponent();
            Canvas.SetBackgroundColor(ShapeColors.Violet, ColorFilters.Blackout, blackoutFactor: 0.2f);

            //IShape[] shapes = [
            //    new Circle(100, 75, 25, ShapeColors.Red),
            //    new FilledRing(200, 90, 40, 25, ShapeColors.Green),
            //    new Ring(300, 50, 30, 20, ShapeColors.Blue),
            //    new Sphere(400, 40, 10, 30, ShapeColors.Yellow),
            //    new Cylinder(500, 80, 50, 30, 40, ShapeColors.Salad),
            //    new Torus(600, 60, 20, 20, 15, ShapeColors.Cyan)
            //];
            //Canvas.Add(shapes, AdditionOptions.AutoRedraw | AdditionOptions.DebugInfo);

            //Console.WriteLine("\nShape list:\n" + Canvas.ToString());
            //Console.WriteLine("\nTotal 2D perimeter: " + Canvas.GetTotal2DPerimeter());
            //Console.WriteLine("Total 2D area     : " + Canvas.GetTotal2DArea());
            //Console.WriteLine("Total 3D surf area: " + Canvas.GetTotal3DSurfaceArea());
            //Console.WriteLine("Total 3D volume   : " + Canvas.GetTotal3DVolume());

            //Canvas.SaveToFile("shape_cache.json", clearLocal: true);
            //Canvas.Redraw();

            Canvas.LoadFromFile("shape_cache.json");
        }

        private void AddCircle_Click(object? sender, RoutedEventArgs e)
        {
            int x = _rand.Next(50, (int)Math.Max(100, Canvas.Bounds.Width - 50));
            int y = _rand.Next(50, (int)Math.Max(100, Canvas.Bounds.Height - 50));

            Canvas.Add(new Circle(x, y, 30, ShapeColors.Red), AdditionOptions.AutoRedraw);
        }

        private void AddSphere_Click(object? sender, RoutedEventArgs e)
        {
            int x = _rand.Next(50, (int)Math.Max(100, Canvas.Bounds.Width - 80));
            int y = _rand.Next(50, (int)Math.Max(100, Canvas.Bounds.Height - 80));
            Canvas.Add(new Sphere(x, y, 10, 30, ShapeColors.Yellow), AdditionOptions.AutoRedraw);
        }

        private void AddTorus_Click(object? sender, RoutedEventArgs e)
        {
            int x = _rand.Next(50, (int)Math.Max(100, Canvas.Bounds.Width - 80));
            int y = _rand.Next(50, (int)Math.Max(100, Canvas.Bounds.Height - 80));

            Canvas.Add(new Torus(x, y, 20, 30, 15, ShapeColors.Cyan), AdditionOptions.AutoRedraw);
        }

        private void MoveUp_Click(object? sender, RoutedEventArgs e)
        {
            Canvas.Move(new ShapeGeometry(x: 0, y: -50));
        }

        private void MoveRight_Click(object? sender, RoutedEventArgs e)
        {
            Canvas.Move(new ShapeGeometry(x: 50, y: 0));
        }

        private void MoveLeft_Click(object? sender, RoutedEventArgs e)
        {
            Canvas.Move(new ShapeGeometry(x: -50, y: 0));
        }

        private void MoveDown_Click(object? sender, RoutedEventArgs e)
        {
            Canvas.Move(new ShapeGeometry(x: 0, y: 50));
        }

        private void Save_Click(object? sender, RoutedEventArgs e)
        {
            Canvas.SaveToFile("shape_cache.json");
        }

        private void Load_Click(object? sender, RoutedEventArgs e)
        {
            Canvas.LoadFromFile("shape_cache.json");
        }

        private void ClearCanvas_Click(object? sender, RoutedEventArgs e)
        {
            Canvas.SaveToFile("shape_cache.json", clearLocal: true);
            Canvas.Redraw();
        }

        private void ClearCache_Click(object? sender, RoutedEventArgs e)
        {
            Canvas.SaveToFile("shape_cache.json", clearLocal: true);
            File.WriteAllText("shape_cache.json", string.Empty);
            Canvas.Redraw();
        }
    }
}
