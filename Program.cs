using Avalonia;
using OOP_Practice.UI;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;


namespace OOP_Practice
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //Console.CancelKeyPress += (s, e) =>
            //{
            //    e.Cancel = true;
            //    LifecycleController.MasterTokenSource.Cancel();
            //};

            AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .StartWithClassicDesktopLifetime(args);
        }


            //while (true)
            //{
            //    string? t = Console.ReadLine();
            //    if (t == null || t == string.Empty) break;

            //    if (t.Equals("bti", StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        string? v = Console.ReadLine();
            //        if (v == null || v == string.Empty)
            //        {
            //            Console.WriteLine("Received an empty string");
            //        }
            //        else
            //        {
            //            string[] stringChannels = v.Split(", ");
            //            if (stringChannels.Length != 4)
            //            {
            //                Console.WriteLine($"Channels must be 4, but received {stringChannels.Length}");
            //            }
            //            else
            //            {
            //                byte ch = 0;
            //                byte[] byteChannels = new byte[4];
            //                for (int i = 0; i < 4; i++)
            //                {
            //                    if (!byte.TryParse(stringChannels[i], out ch))
            //                    {
            //                        Console.WriteLine($"Failed to convert {stringChannels[i]} to byte value");
            //                        break;
            //                    }

            //                    byteChannels[i] = ch;
            //                }

            //                uint uintVal = BinaryPrimitives.ReadUInt32BigEndian(byteChannels.AsSpan(0, byteChannels.Length));
            //                Console.WriteLine($"{string.Join(", ", stringChannels)} -> {uintVal}");
            //            }
            //        }
            //        continue;
            //    }

            //    if (t.Equals("itb", StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        string? v = Console.ReadLine();
            //        if (!uint.TryParse(v, out uint uintVal))
            //        {
            //            Console.WriteLine("Failed to parse uint");
            //        }
            //        else
            //        {
            //            byte[] byteChannels = BitConverter.GetBytes(uintVal);
            //            byteChannels = byteChannels.Reverse().ToArray();
            //            Console.WriteLine($"{uintVal} -> {string.Join(", ", byteChannels)}");
            //        }
            //        continue;
            //    }
            //}
    }
}
