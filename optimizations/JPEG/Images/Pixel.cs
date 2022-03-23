using System;
using System.Linq;
using JPEG.Utilities;

namespace JPEG.Images
{
    public class Pixel
    {
        private readonly PixelFormat format;

        public Pixel(byte firstComponent, byte secondComponent, byte thirdComponent, PixelFormat pixelFormat)
        {
            if (pixelFormat is not PixelFormat.RGB and not PixelFormat.YCbCr)
                throw new FormatException("Unknown pixel format: " + pixelFormat);
            format = pixelFormat;
            
            switch (pixelFormat)
            {
                case PixelFormat.RGB:
                    r = Cast.ToByte(firstComponent);
                    g = Cast.ToByte(secondComponent);
                    b = Cast.ToByte(thirdComponent);
                    
                    break;
                case PixelFormat.YCbCr:
                    y = Cast.ToByte(firstComponent);
                    cb = Cast.ToByte(secondComponent);
                    cr = Cast.ToByte(thirdComponent);
                    break;
            }
        }

        private readonly byte r;
        private readonly byte g;
        private readonly byte b;

        private readonly byte y;
        private readonly byte cb;
        private readonly byte cr;

        public byte R => Cast.ToByte(format == PixelFormat.RGB ? r :
            (298.082 * y + 408.583 * Cr) / 256.0 - 222.921);
        public byte G => Cast.ToByte(format == PixelFormat.RGB ? g :
            (298.082 * Y - 100.291 * Cb - 208.120 * Cr) / 256.0 + 135.576);
        public byte B => Cast.ToByte(format == PixelFormat.RGB ? b :
            (298.082 * Y + 516.412 * Cb) / 256.0 - 276.836);

        public byte Y => Cast.ToByte(format == PixelFormat.YCbCr ? y :
            16.0 + (65.738 * R + 129.057 * G + 24.064 * B) / 256.0);
        public byte Cb => Cast.ToByte(format == PixelFormat.YCbCr ? cb :
            128.0 + (-37.945 * R - 74.494 * G + 112.439 * B) / 256.0);
        public byte Cr => Cast.ToByte(format == PixelFormat.YCbCr ? cr :
            128.0 + (112.439 * R - 94.154 * G - 18.285 * B) / 256.0);
    }
}