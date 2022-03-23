namespace JPEG.Utilities
{
    public static class Cast
    {
        public static byte ToByte(double d)
        {
            var val = (int) d;
            return val switch
            {
                > byte.MaxValue => byte.MaxValue,
                < byte.MinValue => byte.MinValue,
                _ => (byte) val
            };
        }
    }
}