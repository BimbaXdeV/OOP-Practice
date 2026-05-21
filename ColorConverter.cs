using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    internal static class ColorConverter
    {
        static readonly uint DefaultUIntValue = uint.MinValue;
        static readonly byte[] DefaultByteArray = new byte[4];

        public static uint ToUInt32(ReadOnlySpan<byte> channels)
        {
            if (channels.IsEmpty || channels.Length != 4)
            {
                return DefaultUIntValue;
            }

            try
            {
                uint uintVal = BinaryPrimitives.ReadUInt32BigEndian(channels);
                return uintVal;
            }
            catch (ArgumentOutOfRangeException)
            {
                return DefaultUIntValue;
            }
        }

        public static byte[] SplitToChannels(uint unumber)
        {
            try
            {
                byte[] channels = BitConverter.GetBytes(unumber).Reverse().ToArray();
                return channels;
            }
            catch (ArgumentNullException)
            {
                return DefaultByteArray;
            }
        }
    }
}
