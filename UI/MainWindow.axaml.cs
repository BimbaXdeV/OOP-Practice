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
        public MainWindow()
        {
            InitializeComponent();
            ShapesList.ItemsSource = Canvas.Shapes;
            Canvas.SetBackgroundColor(ShapeColors.Violet, ColorFilters.Blackout, blackoutFactor: 0.2f);

            IShape[] shapes = [
                new Circle(100, 75, 25, ShapeColors.Red),
                new FilledRing(200, 90, 40, 25, ShapeColors.Green),
                new Ring(300, 50, 30, 20, ShapeColors.Blue),
                new Sphere(400, 40, 10, 30, ShapeColors.Yellow),
                new Cylinder(500, 80, 50, 30, 40, ShapeColors.Salad),
                new Torus(600, 60, 20, 20, 15, ShapeColors.Cyan)
            ];
            Canvas.Add(shapes, AdditionOptions.AutoRedraw | AdditionOptions.DebugInfo);

            //Console.WriteLine("\nShape list:\n" + Canvas.ToString());
            //Console.WriteLine("\nTotal 2D perimeter: " + Canvas.GetTotal2DPerimeter());
            //Console.WriteLine("Total 2D area     : " + Canvas.GetTotal2DArea());
            //Console.WriteLine("Total 3D surf area: " + Canvas.GetTotal3DSurfaceArea());
            //Console.WriteLine("Total 3D volume   : " + Canvas.GetTotal3DVolume());
        }

        private void AddCircle_Click(object? sender, RoutedEventArgs e)
        {
            short x = (short)(NumX.Value ?? 0);
            short y = (short)(NumY.Value ?? 0);
            short r = (short)(NumOuterR.Value ?? 0);
            Canvas.Add(new Circle(x, y, r, ShapeColors.White), AdditionOptions.AutoRedraw);
        }

        private void AddRing_Click(object? sender, RoutedEventArgs e)
        {
            short x = (short)(NumX.Value ?? 0);
            short y = (short)(NumY.Value ?? 0);
            short or = (short)(NumOuterR.Value ?? 0);
            short ir = (short)(NumInnerR.Value ?? 0);
            Canvas.Add(new Ring(x, y, or, ir, ShapeColors.White), AdditionOptions.AutoRedraw);
        }

        private void AddFilledRing_Click(object? sender, RoutedEventArgs e)
        {
            short x = (short)(NumX.Value ?? 0);
            short y = (short)(NumY.Value ?? 0);
            short or = (short)(NumOuterR.Value ?? 0);
            short ir = (short)(NumInnerR.Value ?? 0);
            Canvas.Add(new FilledRing(x, y, or, ir, ShapeColors.White), AdditionOptions.AutoRedraw);
        }

        private void AddSphere_Click(object? sender, RoutedEventArgs e)
        {
            short x = (short)(NumX.Value ?? 0);
            short y = (short)(NumY.Value ?? 0);
            short z = (short)(NumZ.Value ?? 0);
            short r = (short)(NumOuterR.Value ?? 0);
            Canvas.Add(new Sphere(x, y, z, r, ShapeColors.White), AdditionOptions.AutoRedraw);
        }

        private void AddCylinder_Click(object? sender, RoutedEventArgs e)
        {
            short x = (short)(NumX.Value ?? 0);
            short y = (short)(NumY.Value ?? 0);
            short z = (short)(NumZ.Value ?? 0);
            short r = (short)(NumOuterR.Value ?? 0);
            short h = (short)(NumH.Value ?? 0);
            Canvas.Add(new Cylinder(x, y, z, r, h, ShapeColors.White), AdditionOptions.AutoRedraw);
        }

        private void AddTorus_Click(object? sender, RoutedEventArgs e)
        {
            short x = (short)(NumX.Value ?? 0);
            short y = (short)(NumY.Value ?? 0);
            short z = (short)(NumZ.Value ?? 0);
            short or = (short)(NumOuterR.Value ?? 0);
            short ir = (short)(NumInnerR.Value ?? 0);
            Canvas.Add(new Torus(x, y, z, or, ir, ShapeColors.White), AdditionOptions.AutoRedraw);
        }

        // Ще не торкався, а воно уже ваняє
        private void ShapesList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (ShapesList.SelectedItem is IShape selectedShape)
            {
                NumX.Value = selectedShape.X;
                NumY.Value = selectedShape.Y;
                NumZ.Value = 0;
                NumW.Value = 1;
                NumH.Value = 1;
                NumD.Value = 1;
                NumOuterR.Value = 1;
                NumInnerR.Value = 1;

                if (selectedShape is Shape3D shape3D)
                {
                    NumZ.Value = shape3D.Z;
                }

                switch (selectedShape)
                {
                    case Torus t:
                        NumOuterR.Value = t.MajorRadius;
                        NumInnerR.Value = t.MinorRadius;
                        break;

                    case Cylinder cy:
                        NumH.Value = cy.Height;
                        NumOuterR.Value = cy.Radius;
                        break;

                    case Sphere s:
                        NumOuterR.Value = s.Radius;
                        break;

                    case Ring r:
                        NumOuterR.Value = r.Radius;
                        NumInnerR.Value = r.InnerRadius;
                        break;


                    case Circle c:
                        NumOuterR.Value = c.Radius;
                        break;
                }
            }
        }

        private void UpdateShape_Click(object? sender, RoutedEventArgs e)
        {
            if (ShapesList.SelectedItem is IShape selectedShape)
            {
                short newX = (short)(NumX.Value ?? 0);
                short newY = (short)(NumY.Value ?? 0);
                short newZ = (short)(NumZ.Value ?? 0);
                short newW = (short)(NumW.Value ?? 1);
                short newH = (short)(NumH.Value ?? 1);
                short newD = (short)(NumD.Value ?? 1);
                short newOuterR = (short)(NumOuterR.Value ?? 1);
                short newInnerR = (short)(NumInnerR.Value ?? 1);

                ShapeGeometry newGeometry = new(newX, newY, newZ, newW, newH, newD, newOuterR, newInnerR);

                selectedShape.Move(newGeometry);
                selectedShape.Resize(newGeometry);

                Canvas.Redraw();
            }
        }

        private void MoveUp_Click(object? sender, RoutedEventArgs e)
        {
            short newDeltaY = (short)(-(NumT.Value ?? 1));
            Canvas.Move(new ShapeGeometry(x: 0, y: newDeltaY));
        }

        private void MoveLeft_Click(object? sender, RoutedEventArgs e)
        {
            short newDeltaX = (short)(-(NumT.Value ?? 1));
            Canvas.Move(new ShapeGeometry(x: newDeltaX, y: 0));
        }

        private void MoveRight_Click(object? sender, RoutedEventArgs e)
        {
            short newDeltaX = (short)(NumT.Value ?? 1);
            Canvas.Move(new ShapeGeometry(x: newDeltaX, y: 0));
        }

        private void MoveDown_Click(object? sender, RoutedEventArgs e)
        {
            short newDeltaY = (short)(NumT.Value ?? 1);
            Canvas.Move(new ShapeGeometry(x: 0, y: newDeltaY));
        }

        private void Save_Click(object? sender, RoutedEventArgs e)
        {
            Canvas.SaveToFile("shape_cache.json");
        }

        private void Load_Click(object? sender, RoutedEventArgs e)
        {
            Canvas.LoadFromFile("shape_cache.json");
        }

        private void Merge_Click(object? sender, RoutedEventArgs e)
        {
            Canvas.LoadFromFile("shape_cache.json", mergeWithExist: true);
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
