using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice.UI
{
    public class ShapeCanvas : Control, ICanvas
    {
        public ObservableCollection<IShape> Shapes { get; private set; } = [];
        public ShapeColors BackgroundColor { get; set; } = Shape._defaultColor;

        public IShape? this[int index]
        {
            get
            {
                if (index >= 0 && index < this.Shapes.Count)
                {
                    return this.Shapes[index];
                }
                return null;
            }

            set
            {
                // Не підтримується)
                return;
            }
        }

        public void Add(IShape shape, AdditionOptions options = 0)
        {
            this.Shapes.Add(shape);
            if ((options & AdditionOptions.UseDefaultColor) == AdditionOptions.UseDefaultColor)
            {
                shape.Recolor(Shape._defaultColor);
            }

            bool centerByX = (options & AdditionOptions.CenterByX) == AdditionOptions.CenterByX;
            bool centerByY = (options & AdditionOptions.CenterByY) == AdditionOptions.CenterByY;
            if (centerByX || centerByY)
            {
                if (this.Bounds.Width > 0 && this.Bounds.Height > 0)
                {
                    short newX = centerByX ? (short)(this.Bounds.Width / 2) : shape.X;
                    short newY = centerByY ? (short)(this.Bounds.Height / 2) : shape.Y;
                    shape.Move(new ShapeGeometry(x: newX, y: newY));
                }
                else
                {
                    void OnFirstLayoutArrange(object? sender, SizeChangedEventArgs e)
                    {
                        if (e.NewSize.Width > 0 && e.NewSize.Height > 0)
                        {
                            short newX = centerByX ? (short)(this.Bounds.Width / 2) : shape.X;
                            short newY = centerByY ? (short)(this.Bounds.Height / 2) : shape.Y;
                            shape.Move(new ShapeGeometry(x: newX, y: newY));
                            this.SizeChanged -= OnFirstLayoutArrange;
                        }
                    }
                    this.SizeChanged += OnFirstLayoutArrange;
                }
            }

            if ((options & AdditionOptions.AutoRedraw) == AdditionOptions.AutoRedraw)
            {
                Redraw();
            }

            if ((options & AdditionOptions.DebugInfo) == AdditionOptions.DebugInfo)
            {
                Console.WriteLine($"Added new shape: {shape}");
            }
        }

        public void Add(IList<IShape> shapes, AdditionOptions options = 0)
        {
            foreach (IShape sh in shapes)
            {
                Add(sh, options);
            }
        }

        public void Move(ShapeGeometry deltaGeometry)
        {
            foreach (IShape shape in this.Shapes)
            {
                shape.MoveDelta(deltaGeometry);
            }
            Redraw();
        }

        public void Remove(IShape shape)
        {
            this.Shapes.Remove(shape);
            Redraw();
        }

        public void SetBackgroundColor(ShapeColors color, ColorFilters filters = 0, float blackoutFactor = 0)
        {
            if (this.BackgroundColor != color)
            {
                if (filters != 0)
                {
                    byte[] colorChannels = ColorConverter.SplitToChannels((uint)color);
                    if ((filters & ColorFilters.InvertChannels) == ColorFilters.InvertChannels)
                    {
                        ColorUtils.InvertChannels(colorChannels);
                    }

                    if ((filters & ColorFilters.Blackout) == ColorFilters.Blackout)
                    {
                        ColorUtils.Blackout(colorChannels, blackoutFactor);
                    }

                    color = (ShapeColors)ColorConverter.ToUInt32(colorChannels);
                }

                this.BackgroundColor = color;
                Redraw();
            }
        }

        public void Redraw()
        {
            InvalidateVisual();
        }

        // Сам якось справиться
        public override void Render(DrawingContext context)
        {
            byte[] backgroundColor = ColorConverter.SplitToChannels((uint)this.BackgroundColor);
            Color avaloniaColor = new(backgroundColor[3], backgroundColor[0], backgroundColor[1], backgroundColor[2]);
            context.DrawRectangle(new SolidColorBrush(avaloniaColor), null, new Rect(0, 0, this.Bounds.Width, this.Bounds.Height));

            for (int i = 0; i < this.Shapes.Count; i++)
            {
                IShape shape = Shapes[i];
                if (shape is IDrawable drawable)
                {
                    drawable.Draw(context);
                }
            }
        }

        public double GetTotal2DPerimeter()
        {
            return this.Shapes.OfType<IMeasurable2D>().Sum(shape => shape.Perimeter);
        }

        public double GetTotal2DArea()
        {
            return this.Shapes.OfType<IMeasurable2D>().Sum(shape => shape.Area);
        }

        public double GetTotal3DSurfaceArea()
        {
            return this.Shapes.OfType<IMeasurable3D>().Sum(shape => shape.SurfaceArea);
        }

        public double GetTotal3DVolume()
        {
            return this.Shapes.OfType<IMeasurable3D>().Sum(shape => shape.Volume);
        }

        public void SaveToFile(string filePath, bool clearLocal = false)
        {
            JsonSerializerSettings settings = new()
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(this.Shapes, settings);
            File.WriteAllText(filePath, json);

            if (clearLocal)
            {
                this.Shapes.Clear();
            }
        }

        public void LoadFromFile(string filePath, bool mergeWithExist = false)
        {
            if (!File.Exists(filePath)) return;

            string json = File.ReadAllText(filePath);

            JsonSerializerSettings settings = new()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            ObservableCollection<IShape>? loadedShapes = JsonConvert.DeserializeObject<ObservableCollection<IShape>>(json, settings);

            if (loadedShapes != null)
            {
                if (!mergeWithExist)
                {
                    this.Shapes.Clear();
                }
                Add(loadedShapes, AdditionOptions.AutoRedraw);
            }
        }

        public override string ToString()
        {
            if (this.Shapes.Count == 0)
            {
                return "Canvas is empty";
            }

            StringBuilder sb = new();
            foreach (IShape shape in this.Shapes)
            {
                sb.AppendLine(shape.ToString());
            }
            return sb.ToString();
        }
    }
}
