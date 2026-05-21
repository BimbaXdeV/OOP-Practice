using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public static class ColorUtils
    {
        public static byte[]? InvertChannels(byte[] channels)
        {
            if (channels.Length != 4)
            {
                return null;
            }

            // Не дай Боже альфа-канал зачепити :0
            for (int i = 0; i < 3; i++)
            {
                channels[i] = (byte)(255 - channels[i]);
            }
            return channels;
        }

        public static byte[]? Blackout(byte[] channels, float factor)
        {
            if (factor < 0 || factor > 1 || channels.Length != 4)
            {
                return null;
            }

            for (int i = 0; i < 3; i++)
            {
                channels[i] = (byte)(channels[i] * factor);
            }
            return channels;
        }
    }
}
